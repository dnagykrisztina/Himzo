using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;
using Himzo.Dal;
using Himzo.Dal.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Himzo.Web.Controllers
{
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly HimzoDbContext _context;
		private readonly SignInManager<User> _SignInManager;
		private readonly UserManager<User> _UserManager;
		private readonly ILogger<AuthController> Logger;
		private IConfiguration Configuration { get; }

		public AuthController(HimzoDbContext context,
			SignInManager<User> SignInMagager,
			UserManager<User> UserManager,
			IConfiguration configuration,
			ILogger<AuthController> logger)
		{
			_context = context;
			_SignInManager = SignInMagager;
			_UserManager = UserManager;
			Configuration = configuration;
			Logger = logger;
		}

		public class LoginRequest
		{
			public string Email { get; set; }
			public string Password { get; set; }
			public bool KeepMeSignedIn { get; set; }
		}

		public class LoginResult
		{
			public string Email { get; set; }
			public string Message { get; set; }
			public bool Success { get; set; }
		}

		// POST: api/Auth/Login
		[HttpPost]
		[Produces("application/json")]
		[Route("api/[controller]/Login")]
		public async Task<JsonResult> OnPostLogin([FromBody]LoginRequest loginRequest)
		{
			var signInResult = await _SignInManager.PasswordSignInAsync(loginRequest.Email,
																		loginRequest.Password,
																		loginRequest.KeepMeSignedIn,
																		false);
			Logger.LogDebug("The user {} tried to log in.", loginRequest.Email);

			if (signInResult.Succeeded)
			{
				Logger.LogInformation("The user {} logged in.", loginRequest.Email);
				return new JsonResult(new LoginResult
				{
					Email = loginRequest.Email,
					Message = loginRequest.Email + " has successfully signed in",
					Success = true
				});
			}
			else
			{
				Logger.LogInformation("The user {} couldn't log in.", loginRequest.Email);
				return new JsonResult(new LoginResult
				{
					Email = loginRequest.Email,
					Message = "Login failure! Invalid Username or Password!",
					Success = false
				});
			}
		}

		public class SignOutResult
		{
			public string Message;
			public bool Success;
		}

		// POST: api/Auth/Logout
		[HttpPost]
		[Produces("application/json")]
		[Route("api/[controller]/Logout")]
		public async Task<JsonResult> OnPostLogout()
		{
			User loginUser = (await _UserManager.GetUserAsync(HttpContext.User));
			if (loginUser != null)
			{
				Logger.LogInformation("The user {} logged out.", loginUser.Email);
				foreach (var cookie in HttpContext.Request.Cookies.Keys)
				{
					HttpContext.Response.Cookies.Delete(cookie);
				}
				await _SignInManager.SignOutAsync();
				return new JsonResult(new SignOutResult
				{
					Message = "User " + loginUser.Email + " signed out!",
					Success = true
				});
			}
			else
			{
				return new JsonResult(new SignOutResult
				{
					Message = "You are not signed in!",
					Success = false
				});
			}
		}

		public class SignUpRequest
		{
			public string Name { get; set; }
			public string University { get; set; }
			public string Password { get; set; }
			public string Email { get; set; }
		}

		public class SignUpResult
		{
			public string UserName { get; set; }
			public string Message { get; set; }
			public bool Success { get; set; }
		}

		// PUT: api/Auth/SignUp
		[HttpPut]
		[Produces("application/json")]
		[Route("api/[controller]/SignUp")]
		public async Task<JsonResult> OnPutSignUp([FromBody] SignUpRequest SignUpRequest)
		{
			Logger.LogDebug("New user request: {} {} {}", SignUpRequest.Email, SignUpRequest.Name, SignUpRequest.University);
			if (await _UserManager.FindByEmailAsync(SignUpRequest.Email) != null)
			{
				Logger.LogInformation("New user {}, already exists!", SignUpRequest.Email);
				return new JsonResult(new SignUpResult
				{
					UserName = SignUpRequest.Email,
					Message = "User already exists!",
					Success = false
				});
			}
			User newUser = new User
			{
				Email = SignUpRequest.Email,
				Name = SignUpRequest.Name,
				SecurityStamp = Guid.NewGuid().ToString(),
				UserName = SignUpRequest.Email,
				University = SignUpRequest.University,
				Comments = new List<Comment>(),
				Orders = new List<Order>()
			};
			var createResult = await _UserManager.CreateAsync(newUser, SignUpRequest.Password);
			if (createResult.Succeeded)
			{
				var addToRoleResult = await _UserManager.AddToRoleAsync(newUser, Role.User);
				if (!addToRoleResult.Succeeded)
				{
					await _UserManager.DeleteAsync(newUser);
					return new JsonResult(new SignUpResult
					{
						UserName = SignUpRequest.Email,
						Message = "User " + SignUpRequest.Email + " couldn't be added to Role!",
						Success = false
					});
				}
			}
			else
			{
				bool valid = true;
				foreach(var validator in _UserManager.PasswordValidators)
				{
					if (!(await validator.ValidateAsync(_UserManager, newUser, SignUpRequest.Password)).Succeeded)
					{
						valid = false;
					}
				}
				if (!valid)
				{
					return new JsonResult(new SignUpResult
					{
						UserName = SignUpRequest.Email,
						Message = "User password is not complex enough!",
						Success = false
					});
				}
				return new JsonResult(new SignUpResult
				{
					UserName = SignUpRequest.Email,
					Message = "User " + SignUpRequest.Email + " couldn't be created!",
					Success = false
				});
			}
		    await _context.SaveChangesAsync();
			Logger.LogInformation("New user has been created {}!", SignUpRequest.Email);
			return new JsonResult(new SignUpResult
			{
				UserName = SignUpRequest.Email,
				Message = "User " + SignUpRequest.Email + " has been created!",
				Success = true
			});
		}

		public class UserResult
		{
			public string UserName;
			public string Email;
			public string University;
			public IList<string> Roles;
		}

		// GET: api/User/<email@address>
		[HttpGet("api/User/{id}", Name = "Get")]
		[Produces("application/json")]
		public async Task<JsonResult> Get(string id)
		{
			Logger.LogInformation("Data requested for user {}", id);
			User user = (await _UserManager.FindByEmailAsync(id));
			IList<string> userRoles = (await _UserManager.GetRolesAsync(user));
			return new JsonResult(new UserResult
			{
				UserName = user.Name,
				Email = user.Email,
				University = user.University,
				Roles = userRoles
			});
		}

		// GET: api/User/<email@address>
		[HttpGet("api/User", Name = "GetUser")]
		[Produces("application/json")]
		public async Task<JsonResult> GetUser()
		{
			Logger.LogInformation("Requested the current user's data");
			User user = (await _UserManager.GetUserAsync(HttpContext.User));
			Logger.LogInformation("Current user is {}", user.Email);
			IList<string> userRoles = (await _UserManager.GetRolesAsync(user));
			return new JsonResult(new UserResult
			{
				UserName = user.Name,
				Email = user.Email,
				University = user.University,
				Roles = userRoles
			});
		}

		public class DeleteResult
		{
			public string Message;
			public bool Success;
		}

		// DELETE: api/Auth/<email@address>
		[HttpDelete]
		[Produces("application/json")]
		[Route("api/[controller]/{id}")]
		public async Task<JsonResult> Delete(string id)
		{
			var loginUser = (await _UserManager.GetUserAsync(HttpContext.User));
			if (loginUser != null)
			{
				IList<string> roles = await _UserManager.GetRolesAsync(loginUser);
				if (roles.Contains("Admin"))
				{
					User user = (await _UserManager.FindByEmailAsync(id));
					if (user != null)
					{
						await _UserManager.DeleteAsync(user);
						return new JsonResult(new DeleteResult
						{
							Message = "User " + user.UserName + " has been deleted!",
							Success = true
						});
					}
					else
					{
						return new JsonResult(new DeleteResult
						{
							Message = "The user " + id + " does not exist!",
							Success = false
						});
					}
				}
				else
				{
					return new JsonResult(new DeleteResult
					{
						Message = "Permission denied!",
						Success = false
					});
				}
			}
			else
			{
				return new JsonResult(new DeleteResult
				{
					Message = "You have to authenticate before delete a user!",
					Success = false
				});
			}
		}

		// PUT: api/Role/<role_name>/<email@address>
		[HttpPut]
		[Produces("application/json")]
		[Route("api/Role/{roleName}/{eMail}")]
		public async Task<JsonResult> AddToRole(string roleName, string eMail)
		{
			var loginUser = (await _UserManager.GetUserAsync(HttpContext.User));
			if (loginUser != null)
			{
				IList<string> roles = await _UserManager.GetRolesAsync(loginUser);
				if (roles.Contains("Admin"))
				{
					User user = (await _UserManager.FindByEmailAsync(eMail));
					if (user != null)
					{
						await _UserManager.AddToRoleAsync(user, roleName);
						return new JsonResult(new DeleteResult
						{
							Message = "User " + user.UserName + " has been deleted from role "+roleName+"!",
							Success = true
						});
					}
					else
					{
						return new JsonResult(new DeleteResult
						{
							Message = "The user " + eMail + "does not exist!",
							Success = false
						});
					}
				}
				else
				{
					return new JsonResult(new DeleteResult
					{
						Message = "Permission denied!",
						Success = false
					});
				}
			}
			else
			{
				return new JsonResult(new DeleteResult
				{
					Message = "You have to authenticate before delete a user!",
					Success = false
				});
			}
		}

		// DELETE: api/Role/<role_name>/<email@address>
		[HttpDelete]
		[Produces("application/json")]
		[Route("api/Role/{roleName}/{eMail}")]
		public async Task<JsonResult> RemoveFromRole(string roleName, string eMail)
		{
			var loginUser = (await _UserManager.GetUserAsync(HttpContext.User));
			if (loginUser != null)
			{
				IList<string> roles = await _UserManager.GetRolesAsync(loginUser);
				if (roles.Contains("Admin"))
				{
					User user = (await _UserManager.FindByEmailAsync(eMail));
					if (user != null)
					{
						await _UserManager.RemoveFromRoleAsync(user, roleName);
						return new JsonResult(new DeleteResult
						{
							Message = "User " + user.UserName + " has been deleted from role " + roleName + "!",
							Success = true
						});
					}
					else
					{
						return new JsonResult(new DeleteResult
						{
							Message = "The user " + eMail + "does not exist!",
							Success = false
						});
					}
				}
				else
				{
					return new JsonResult(new DeleteResult
					{
						Message = "Permission denied!",
						Success = false
					});
				}
			}
			else
			{
				return new JsonResult(new DeleteResult
				{
					Message = "You have to authenticate before delete a user!",
					Success = false
				});
			}
		}

		[ApiExplorerSettings(IgnoreApi = true)]
		[Produces("application/json")]
		[Route("api/[controller]/SchLogin")]
		public IActionResult SchLogin()
		{
			string redirectUrl = Url.Action("ExternalLoginResponse", "Auth", "api");
			var properties = _SignInManager.ConfigureExternalAuthenticationProperties("AuthSch", redirectUrl);
			return new ChallengeResult("AuthSch", properties);
		}

		[ApiExplorerSettings(IgnoreApi = true)]
		[Produces("application/json")]
		[Route("api/[controller]/MicrosoftLogin")]
		public IActionResult MicrosoftLogin()
		{
			string redirectUrl = Url.Action("ExternalLoginResponse", "Auth", "api");
			var properties = _SignInManager.ConfigureExternalAuthenticationProperties("Microsoft", redirectUrl);
			return new ChallengeResult("Microsoft", properties);
		}

		[ApiExplorerSettings(IgnoreApi = true)]
		[Produces("application/json")]
		[Route("api/[controller]/FacebookLogin")]
		public IActionResult FacebookLogin()
		{
			string redirectUrl = Url.Action("ExternalLoginResponse", "Auth", "api");
			var properties = _SignInManager.ConfigureExternalAuthenticationProperties("Facebook", redirectUrl);
			return new ChallengeResult("Facebook", properties);
		}

		[ApiExplorerSettings(IgnoreApi = true)]
		[Produces("application/json")]
		[Route("api/[controller]/GoogleLogin")]
		public IActionResult GoogleLogin()
		{
			string redirectUrl = Url.Action("ExternalLoginResponse", "Auth", "api");
			var properties = _SignInManager.ConfigureExternalAuthenticationProperties("Google", redirectUrl);
			return new ChallengeResult("Google", properties);
		}

		[ApiExplorerSettings(IgnoreApi = true)]
		[Produces("application/json")]
		[Route("api/[controller]/ExternalLoginResponse")]
		public async Task<IActionResult> ExternalLoginResponse()
		{
			ExternalLoginInfo info = await _SignInManager.GetExternalLoginInfoAsync();
			if (info == null)
				return Redirect("/dist/index.html#/signin");

			var result = await _SignInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, false);
			string[] userInfo = { info.Principal.FindFirst(ClaimTypes.Name).Value, info.Principal.FindFirst(ClaimTypes.Email).Value };
			System.Console.WriteLine(info.Principal.FindFirst(ClaimTypes.Email).Value);
			if (result.Succeeded)
				return Redirect("/dist/index.html");
			else
			{
				User user = new User
				{
					Email = info.Principal.FindFirst(ClaimTypes.Email).Value,
					UserName = info.Principal.FindFirst(ClaimTypes.Email).Value,
					Name = info.Principal.FindFirst(ClaimTypes.Name).Value,
					University = "",
					Orders = new List<Order>(),
					Comments = new List<Comment>()
				};

				var identResult = await _UserManager.CreateAsync(user);
				var addToRoleResult = await _UserManager.AddToRoleAsync(user, Role.User);
				await _context.SaveChangesAsync();
				if (identResult.Succeeded)
				{
					identResult = await _UserManager.AddLoginAsync(user, info);
					if (identResult.Succeeded)
					{
						await _SignInManager.SignInAsync(user, false);
						return Redirect("/dist/index.html");
					}
				}
				return Redirect("/dist/index.html#/signin");
			}
		}
	}
}
