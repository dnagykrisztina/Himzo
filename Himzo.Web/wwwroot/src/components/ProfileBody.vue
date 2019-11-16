<template>
    <div>
        <div class="jumbotron">
            <div class="container">
                <h1 class="display-3">{{ username }}</h1>
            </div>
        </div>

        <body>
            <main role="main">
                <form class="needs-validation" validate>
                    <!-- Main jumbotron for a primary marketing message or call to action -->

                    <div class="container">
                        <div class="row">
                            <div class="col-md-6 mb-3">
                                <input type="email"
                                       class="form-control"
                                       id="email"
                                       placeholder
                                       value
                                       required
                                       v-bind="inputEmail" />
                                <label for="email">{{ email }}</label>
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
                                <input type="password"
                                       class="form-control"
                                       id="newPassword"
                                       placeholder
                                       required
                                       value
                                       v-bind="inputNewPassword" />
                            </div>
                            <div class="invalid-feedback">Kérlek add meg az új jelszavad!</div>
                        </div>
                        <div class="row">
                            <div class="col-md-6 mb-3">
                                <label for="newPasswordAgain">{{ newPasswordAgain }}</label>
                                <input type="password"
                                       class="form-control"
                                       id="newPasswordAgain"
                                       required
                                       placeholder
                                       value
                                       v-bind="inputNewPasswordAgain" />
                            </div>
                            <div class="invalid-feedback">Kérlek add meg mégegyszer az új jelszavad!</div>
                        </div>
                        <div class="row">
                            <div class="col-md-6 mb-3">
                                <label for="oldPassword">{{ oldPassword }}</label>
                                <input type="password"
                                       class="form-control"
                                       id="oldPassword"
                                       placeholder
                                       value
                                       required
                                       v-bind="inputOldPassword" />
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
    </div>
</template>

 
 <script>
import axios from "axios";
export default {
  name: "ProfileBody",
  props: {},
  data() {
    return {
      username: null,
      email: "E-mail cím",
      university: "Egyetem",
      newPassword: "Új jelszó",
      newPasswordAgain: "Új jelszó mégegyszer",
      oldPassword: "Régi jelszó",
      inputEmail: "",
      inputUniversity: "",
      inputNewPassword: "",
      inputNewPasswordAgain: "",
      inputOldPassword: "",
      cancelButton: "Mégse",
      saveButton: "Adatok mentése"
    };
  },
  async mounted() {
    //Username
    try {
      const res = await axios.get("http://localhost:52140/api/User");
      this.username = res.data.userName;
      this.inputUniversity = res.data.university;
      this.inputEmail = res.data.email;
    } catch (e) {
      console.log(e);
    }
  },
  methods: {
    postPost() {
      axios
        .push(`http://localhost:52140/api/User`, {
          /* size: this.inputSize,
          amount: this.inputAmount,
          deadline: this.inputDeadline,
          pattern: null,
          orderComment: this.inputComment,
          orderTime: this.orderTime,
          fonts: this.inputFonts,
          type: 0,
          patternPlace: this.inputPatternLocation*/
        })
        // .then(response => {})
        .catch(e => {
          this.errors.push(e);
        });
    }
  }
};
</script>

<style scoped>
</style>