function login() {
  var jsonData = {
    Email: $("#Email")[0].value.trim(),
    Password: $("#Password")[0].value.trim(),
    KeepMeSignedIn: $("#KeepMeSignIn")[0].value == "on"
  };

  $.ajax({
    url: "/api/Auth/Login",
    method: "POST",
    data: JSON.stringify(jsonData),
    contentType: "application/json; charset=utf-8",
    cache: false,
    dataType: "json",
    success: function(data) {
      if (data.success == true) {
        window.location = "/dist/index.html";
      } else {
        alert(data.message);
      }
    },
    error: function(data) {
      console.log(data);
    }
  });
}

function signup() {
  var jsonData = {
    Name: $("#Name")[0].value.trim(),
    Email: $("#Email")[0].value.trim(),
    University: $("#University")[0].value.trim(),
    Password: $("#Password")[0].value.trim()
  };

  if ($("#Password")[0].value.trim() != $("#Password2")[0].value.trim()) {
    alert("Nem egyezik meg a két jelszó!");
    return;
  }

  $.ajax({
    url: "/api/Auth/SignUp",
    method: "PUT",
    data: JSON.stringify(jsonData),
    contentType: "application/json; charset=utf-8",
    cache: false,
    dataType: "json",
    success: function(data) {
      if (data.success == true) {
        window.location = "/dist/index.html";
      } else {
        alert(data.message);
      }
    },
    error: function(data) {
      console.log(data);
    }
  });
}

function googleLogin() {
  this.window.location.href = "/api/Auth/GoogleLogin";
}

function facebookLogin() {
  this.window.location.href = "/api/Auth/FacebookLogin";
}

function microsoftLogin() {
  this.window.location.href = "/api/Auth/MicrosoftLogin";
}

function schLogin() {
  this.window.location.href = "/api/Auth/SchLogin";
}

function whoAmi() {
  var username = "";
  $.ajax({
    url: "/api/User",
    method: "GET",
    async: false,
    success: function(data) {
      username = data.userName;
    },
    error: function(data) {
      console.log(data);
    }
  });
  return username;
}

function logout() {
  $.ajax({
    url: "/api/Auth/Logout",
    method: "POST",
    async: false,
    success: function(data) {
      console.log(data.message);
      document.cookie = "";
      window.location.href = "/dist/index.html";
    },
    error: function(data) {
      console.log(data.message);
    }
  });
}
