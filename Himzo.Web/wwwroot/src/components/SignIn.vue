<template>
<div>
  <head>
    <link href="./signin_reg.css" rel="stylesheet" />
    <link
      href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-social/5.1.1/bootstrap-social.min.css"
      rel="stylesheet"
    />
    <script src="https://kit.fontawesome.com/cd3ec43ff2.js" crossorigin="anonymous"></script>
  </head>
  <body class="text-center">
    <form>
      <img class="rounded-circle" src="./pic/logo.png" alt width="100" height="100" />
      <h1 class="h3 mb-3 font-weight-normal">Bejelentkezés</h1>
      <label for="Email" class="sr-only">E-mail cím</label>
      <input
        type="email"
        id="Email"
        class="form-control"
        placeholder="E-mail cím"
        required
        autofocus
      />
      <label for="Password" class="sr-only">Jelszó</label>
      <input type="password" id="Password" class="form-control" placeholder="Jelszó" required />
      <br />Maradj bejelentkezve
      <input type="checkbox" id="KeepMeSignIn" checked />
      <button class="btn btn-lg btn-primary btn-block" type="button" onclick="login()">Bejelentkezés</button>
      <a class="btn btn-block btn-social btn-google" style="color: white" onclick="googleLogin()">
        <span class="fab fa-google"></span> Google
      </a>
      <a
        class="btn btn-block btn-social btn-facebook"
        style="color: white"
        onclick="facebookLogin()"
      >
        <span class="fab fa-facebook"></span> Facebook
      </a>
      <a
        class="btn btn-block btn-social btn-microsoft"
        style="color: white"
        onclick="microsoftLogin()"
      >
        <span class="fab fa-microsoft"></span> Microsoft
      </a>
      <a class="btn btn-block btn-social btn-so" style="color: white" onclick="schLogin()">
        <span class="far fa-building"></span> AuthSCH
      </a>
      <label>
        Nincs fiókod?
        <a href="index.html#/registration">Regisztrálj</a>
      </label>
      <p class="mt-5 mb-3 text-muted">&copy; Pulcsi és FoltMéKör</p>
    </form>
  </body>
</div>
</template>

<script>
export default {
  name: "SignIn",
  props: {}
};
</script>