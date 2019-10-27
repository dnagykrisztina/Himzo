<template>
<div>
  <header>
    <link href="signin_reg.css" rel="stylesheet" />
  </header>
  <body class="text-center">
    <form class="form-register">
      <img class="rounded-circle" src="./pic/logo.png" alt width="100" height="100" />
      <h1 class="h3 mb-3 font-weight-normal">Regisztrálás</h1>
      <label for="inputEmail" class="sr-only">Név</label>
      <input type="name" id="inputName" class="form-control" placeholder="Név" required autofocus />
      <label for="inputEmail" class="sr-only">E-mail cím</label>
      <input
        type="email"
        id="inputEmail"
        class="form-control"
        placeholder="E-mail cím"
        required
        autofocus
      />
      <input type="uni" id="inputUni" class="form-control" placeholder="Egyetem" required autofocus />
      <label for="inputUni" class="sr-only">Egyetem</label>
      <label for="inputPassword" class="sr-only">Jelszó</label>
      <input
        type="password"
        id="inputPassword"
        class="form-control"
        placeholder="Jelszó"
        required
        autofocus
      />
      <label for="inputPassword2" class="sr-only">Jelszó2</label>
      <input
        type="password"
        id="inputPassword2"
        class="form-control"
        placeholder="Jelszó megerősítése"
        required
        autofocus
      />

      <button class="btn btn-lg btn-primary btn-block" type="submit">Regisztrálás</button>
      <label>
        Már van fiókod?
        <a href="index.html#/signin">Jelenkezz be</a>
      </label>
      <p class="mt-5 mb-3 text-muted">&copy; Pulcsi és FoltMéKör</p>
    </form>
  </body>
</div>
</template>

<script>
export default {
  name: "Registration",
  props: {}
};
</script>