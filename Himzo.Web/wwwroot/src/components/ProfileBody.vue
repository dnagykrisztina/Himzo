<template>
<body>
  <main role="main">
    <form class="needs-validation" novalidate>
      <!-- Main jumbotron for a primary marketing message or call to action -->
      <div class="jumbotron">
        <div class="container">
          <h1 class="display-3">{{ username }}</h1>
        </div>
      </div>
      <div class="container">
        <div class="row">
          <div class="col-md-6 mb-3">
            <label for="email">{{ email }}</label>
            <input type="text" class="form-control" id="email" placeholder value required />
          </div>
          <div class="invalid-feedback">Kérlek add meg az e-mail címed!</div>
        </div>
        <div class="row">
          <div class="col-md-6 mb-3">
            <label for="university">{{ university }}</label>
            <input type="text" class="form-control" id="university" placeholder value />
          </div>
        </div>
        <div class="row">
          <div class="col-md-6 mb-3">
            <label for="newPassword">{{ newPassword }}</label>
            <input type="text" class="form-control" id="newPassword" placeholder value required />
          </div>
          <div class="invalid-feedback">Kérlek add meg az új jelszavad!</div>
        </div>
        <div class="row">
          <div class="col-md-6 mb-3">
            <label for="newPasswordAgain">{{ newPasswordAgain }}</label>
            <input
              type="text"
              class="form-control"
              id="newPasswordAgain"
              placeholder
              value
              required
            />
          </div>
          <div class="invalid-feedback">Kérlek add meg mégegyszer az új jelszavad!</div>
        </div>
        <div class="row">
          <div class="col-md-6 mb-3">
            <label for="oldPassword">{{ oldPassword }}</label>
            <input type="text" class="form-control" id="oldPassword" placeholder value required />
          </div>
          <div class="invalid-feedback">Kérlek add meg a régi jelszavad!</div>
        </div>
        <div class="row">
          <hr class="mb-4" />
          <button class="btn btn-primary" @click="reset" type="reset">{{ cancelButton }}</button>
          <button class="btn btn-primary" type="submit">{{ saveButton }}</button>
        </div>
      </div>
    </form>
  </main>
</body>
</template>

 
 <script>
export default {
    name: "ProfileBody",
    props: {},
    methods: {
        reset() {
            console.log("profile reset")
            this.$router.push('/')
        }
    },
    data() {
        return {
            username: "Önnönmagam",
            email: "E-mail cím",
            university: "Egyetem",
            newPassword: "Új jelszó",
            newPasswordAgain: "Új jelszó mégegyszer",
            oldPassword: "Régi jelszó",
            cancelButton: "Mégse",
            saveButton: "Adatok mentése"
        };
    }
};
</script>

<style scoped>
</style>