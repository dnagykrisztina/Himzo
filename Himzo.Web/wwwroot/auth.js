function login() {
    var jsonData = {
        "Email": $('#Email')[0].value.trim(),
        "Password": $('#Password')[0].value.trim(),
        "KeepMeSignedIn": $('#KeepMeSignIn')[0].value == 'on'
    };

    console.log(jsonData);
    $.ajax({
        url: "/api/Auth/Login",
        method: "POST",
        data: JSON.stringify(jsonData),
        contentType: "application/json; charset=utf-8",
        cache: false,
        dataType: 'json',
        success: function (data) {
            if (data.success == true) {
                alert(whoAmi());
                window.location = "/user/indexUser.html";
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