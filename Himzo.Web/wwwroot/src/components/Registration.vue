<template>
  <div>
    <header>
      <link href="signin_reg.css" rel="stylesheet" />
    </header>
    <body class="mystyle text-center justify-content-center">
      <form class="form-register col-4 justify-content-center">
        <img
          class="rounded-circle"
          src="./pic/logo.png"
          alt
          width="100"
          height="100"
        />
        <h1 class="h3 mb-3 font-weight-normal">Regisztrálás</h1>
        <label for="Email" class="sr-only">Név</label>
        <input
          type="name"
          id="Name"
          class="form-control mb-1"
          placeholder="Név"
          required
          autofocus
        />
        <label for="Email" class="sr-only">E-mail cím</label>
        <input
          type="email"
          id="Email"
          class="form-control mb-1"
          placeholder="E-mail cím"
          required
          autofocus
        />
        <input
          type="uni"
          id="University"
          class="form-control mb-1"
          placeholder="Egyetem"
          required
          autofocus
        />
        <label for="University" class="sr-only">Egyetem</label>
        <label for="Password" class="sr-only">Jelszó</label>
        <input
          type="password"
          id="Password"
          class="form-control mb-1"
          placeholder="Jelszó"
          required
          autofocus
        />
        <label for="Password2" class="sr-only">Jelszó2</label>
        <input
          type="password"
          id="Password2"
          class="form-control mb-1"
          placeholder="Jelszó megerősítése"
          required
          autofocus
        />

        <button
          class="btn btn-lg btn-primary btn-block mt-2 mb-2"
          type="button"
          onclick="signup()"
        >
          Regisztrálás
        </button>
            <label style="margin-top: 20px;">
                Már van fiókod?
                <a class="link" @click="signin">Jelenkezz be</a>
            </label>
        <p class="mt-5 mb-3 text-muted">&copy; Pulcsi és FoltMéKör</p>
      </form>
    </body>
  </div>
</template>

<script>
export default {
  name: "Registration",
  props: {},
  methods: {
    signin() {
      console.log("signin");
      this.$router.push("/signin");
    }
  }
};
</script>

<style>

   a:not([href]):not([tabindex]).link {
        color: #007bff;
        cursor: pointer;
        text-decoration: underline;
    }
   .text-muted{
        cursor:default;
    }
   h1{
    cursor: default;
}
   
</style>