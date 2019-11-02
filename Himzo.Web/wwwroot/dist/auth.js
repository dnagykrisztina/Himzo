function login() {
    var jsonData = {
        "Email": $('#Email')[0].value.trim(),
        "Password": $('#Password')[0].value.trim(),
        "KeepMeSignedIn": $('#KeepMeSignIn')[0].value == 'on'
    };

    $.ajax({
        url: "/api/Auth/Login",
        method: "POST",
        data: JSON.stringify(jsonData),
        contentType: "application/json; charset=utf-8",
        cache: false,
        dataType: 'json',
        success: function (data) {
            if (data.success == true) {
                window.location = "/dist/index.html";
            } else {
                alert(data.message);
            }
        },
        error: function (data) {
            console.log(data);
        }
    });
}

function googleLogin() {
    this.window.location.href = "/api/Auth/GoogleLogin"
}

function facebookLogin() {
    this.window.location.href = "/api/Auth/FacebookLogin"
}

function whoAmi() {
    var username = "";
    $.ajax({
        url: "/api/User",
        method: "GET",
        async: false,
        success: function (data) {
            username = data.userName;
        },
        error: function (data) {
            console.log(data);
        }
    });
    return username;
}