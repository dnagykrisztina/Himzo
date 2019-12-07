<template>
  <div>
    <head>
      <link href="./signin_reg.css" rel="stylesheet" />

      <link
        href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-social/5.1.1/bootstrap-social.min.css"
        rel="stylesheet"
      />
      <script
        src="https://kit.fontawesome.com/cd3ec43ff2.js"
        crossorigin="anonymous"
      ></script>
    </head>

    <body class="mystyle text-center justify-content-center">
      <form class="col-3 myform justify-content-center">
        <img
          class="rounded-circle"
          src="./pic/logo.png"
          alt
          width="100"
          height="100"
        />
        <h1 class="h3 mb-3 font-weight-normal">Bejelentkezés</h1>
        <label for="Email" class="sr-only">E-mail cím</label>
        <input
          type="email"
          id="Email"
          class="form-control mb-1"
          placeholder="E-mail cím"
          required
          autofocus
        />
        <label for="Password" class="sr-only">Jelszó</label>
        <input
          type="password"
          id="Password"
          class="form-control mb-1"
          placeholder="Jelszó"
          required
        />
        <br />Maradj bejelentkezve
        <input type="checkbox" id="KeepMeSignIn" checked />
        <button
          class="btn btn-lg btn-primary btn-block  mt-2 mb-2"
          type="button"
          onclick="login()"
        >
          Bejelentkezés
        </button>

        <div class="flex-row d-flex justify-content-around ">
          <a
            class="fab fa-google fa-2x col-2 p-1 m-1 text-center t"
            style="color: red"
            onclick="googleLogin()"
          >
          </a>
          <a
            class="fab fa-facebook fa-2x col-2 p-1 m-1 text-center"
            style="color: darkblue"
            onclick="facebookLogin()"
          >
          </a>
          <a
            class=" fab fa-microsoft fa-2x col-2 p-1 m-1 text-center"
            style="color: blue"
            onclick="microsoftLogin()"
          >
          </a>
          <a
            class=" far fa-building fa-2x col-2 p-1 m-1 text-center"
            style="color: grey"
            onclick="schLogin()"
          >
          </a>
        </div>
        <label style="margin-top: 20px;">
          Nincs fiókod?
          <a class="link pt-2" @click="register">Regisztrálj</a>
        </label>
        <p class="mt-5 mb-3 text-muted">&copy; Pulcsi és FoltMéKör</p>
      </form>
    </body>
  </div>
</template>

<script>
export default {
  name: "SignIn",
  props: {},
  methods: {
    register() {
      console.log("register");
      this.$router.push("/registration");
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