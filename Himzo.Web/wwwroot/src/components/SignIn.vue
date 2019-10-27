<template>
<div>
<header>
  <link href="signin_reg.css" rel="stylesheet" />
 </header>
  <body class="text-center">
    <form class="form-signin">
      <img
        class="rounded-circle"
        src="./pic/logo.png"
        alt=""
        width="100"
        height="100"
      />
      <h1 class="h3 mb-3 font-weight-normal">Bejelentkezés</h1>
      <label for="inputEmail" class="sr-only">E-mail cím</label>
      <input
        type="email"
        id="inputEmail"
        class="form-control"
        placeholder="E-mail cím"
        required
        autofocus
      />
      <label for="inputPassword" class="sr-only">Jelszó</label>
      <input
        type="password"
        id="inputPassword"
        class="form-control"
        placeholder="Jelszó"
        required
      />
      <button class="btn btn-lg btn-primary btn-block" type="submit">
        Bejelentkezés
      </button>
      <label> Nincs fiókod?<a href="registration.html"> Regisztrálj</a> </label>
      <p class="mt-5 mb-3 text-muted">&copy; Pulcsi és FoltMéKör</p>
    </form>
  </body>
  </div>
</template>

<script>


export default {
  name: "SignIn",
  props: {},
};
</script>