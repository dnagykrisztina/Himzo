using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Himzo.Dal;
using Himzo.Dal.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Himzo.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly HimzoDbContext _context;
        private readonly SignInManager<User> _SignInManager;
        private readonly UserManager<User> _UserManager;

        public AuthController(HimzoDbContext context,
            SignInManager<User> SignInMagager,
            UserManager<User> UserManager)
        {
            _context = context;
            _SignInManager = SignInMagager;
            _UserManager = UserManager;
        }

        public class LoginRequest
        {
            public string UserName { get; set; }
            public string Password { get; set; }
            public bool KeepMeSignedIn { get; set; }
        }

        public class LoginResult
        {
            public string UserName { get; set; }
            public string Message { get; set; }
            public bool Success { get; set; }
        }

        // POST: api/Auth/Login
        [Produces("application/json")]
        [HttpPost("api/[controller]/Login")]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> OnPostLogin([FromBody]LoginRequest loginRequest)
        {
            var signInResult = await _SignInManager.PasswordSignInAsync(
                loginRequest.UserName,
                loginRequest.Password,
                loginRequest.KeepMeSignedIn,
                false);

            if (signInResult.Succeeded)
            {
                return new JsonResult(new LoginResult
                {
                    UserName = loginRequest.UserName,
                    Message = loginRequest.UserName + " has successfully signed in",
                    Success = true
                });
            }
            else
            {
                return new JsonResult(new LoginResult
                {
                    UserName = loginRequest.UserName,
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

        // POST: api/Auth/Login
        [Produces("application/json")]
        [HttpPost("api/[controller]/Logout/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> OnPostLogout(string id)
        {
            var loginUser = (await _UserManager.GetUserAsync(HttpContext.User));
            if (loginUser != null)
            {
                    await _SignInManager.SignOutAsync();
                    return new JsonResult(new SignOutResult
                    {
                        Message = "User " + id + " signed out!",
                        Success = true
                    });
            } else
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
        [Produces("application/json")]
        [HttpPost("api/[controller]/SignUp")]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> OnPutSignUp([FromBody] SignUpRequest SignUpRequest)
        {
            var loginUser = (await _UserManager.GetUserAsync(HttpContext.User));
            if (loginUser != null)
            {
                IList<string> roles = await _UserManager.GetRolesAsync(loginUser);
                if (roles.Contains("Admin"))
                {
                    if (await _UserManager.FindByEmailAsync(SignUpRequest.Email) != null)
                        return new JsonResult(new SignUpResult
                        {
                            UserName = SignUpRequest.Email,
                            Message = "User already exists!",
                            Success = false
                        });
                    User newUser = new User
                    {
                        Email = SignUpRequest.Email,
                        Name = SignUpRequest.Name,
                        SecurityStamp = Guid.NewGuid().ToString(),
                        UserName = SignUpRequest.Email,
                        University = SignUpRequest.University
                    };
                    var createResult = await _UserManager.CreateAsync(newUser, SignUpRequest.Password);
                    var addToRoleResult = await _UserManager.AddToRoleAsync(newUser, Role.User);
                    await _context.SaveChangesAsync();
                    return new JsonResult(new SignUpResult
                    {
                        UserName = SignUpRequest.Email,
                        Message = "User " + SignUpRequest.Email + " has been created!",
                        Success = false
                    });
                } else
                {
                    return new JsonResult(new SignUpResult
                    {
                        UserName = "Unknown",
                        Message = "Permission denied",
                        Success = false
                    });
                }
            } else
            {
                return new JsonResult(new SignUpResult
                {
                    UserName = "Unknown",
                    Message = "You have to sign in for this function!",
                    Success = false
                });
            }
        }

        public class UserResult
        {
            public string UserName;
            public string Email;
            public string University;
            public IList<string> Roles;
        }

        // GET: api/Auth/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<JsonResult> Get(string id)
        {
            User user = (await _UserManager.FindByEmailAsync(id));
            IList<string> userRoles = (await _UserManager.GetRolesAsync(user));
            return new JsonResult(new UserResult{
                UserName = user.Email,
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

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
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
                            Success = false
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
                } else
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
                return new JsonResult(new DeleteResult{
                    Message = "You have to authenticate before delete a user!",
                    Success = false
                });
            }
        }
    }
}
