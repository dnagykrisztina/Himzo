<template>
<div>
  <div class="jumbotron">
    <div class="container">
      <h1 class="display-3">{{ patchFormTitle }}</h1>
      <p>{{ patchFormDescription }}</p>
    </div>
  </div>
  <body>
    <main role="main">
      <!-- Main jumbotron for a primary marketing message or call to action -->

      <div class="container">
        <div v-if="errors.length" class="alert alert-danger" role="alert">
          <div class="pl-2">
            <b>{{correctErrors}}</b>
            <ul>
              <li v-for="error in errors" v-bind:key="error.id">{{ error.name }}</li>
            </ul>
          </div>
        </div>

        <div class="row">
          <div class="col-md-8 order-md-1">
            <form>
              <div class="col-md-6 mb-3">
                <input
                  type="file"
                  class="custom-file-input"
                  id="customFile"
                  v-validate="'image'"
                  data-vv-as="image"
                  name="image_field"
                  @change="setImage"
                />
                <label class="custom-file-label" for="customFile">
                  {{
                  chooseFile
                  }}
                </label>
              </div>

              <div class="row">
                <div class="col-md-3 mb-3">
                  <label for="size">{{ size }}</label>
                  <input type="text" class="form-control" id="size" required v-model="inputSize" />
                </div>
                <div class="col-md-3 mb-3">
                  <label for="amount">{{ amount }}</label>
                  <input
                    type="number"
                    class="form-control"
                    id="amount"
                    value="1"
                    min="1"
                    v-model="inputAmount"
                  />
                  <div class="invalid-feedback">Kérlek add meg a mintában használt fontot!</div>
                </div>
                <div class="col-md-4 mb-3">
                  <label for="deadline">{{ deadline }}</label>
                  <input type="date" class="form-control" id="deadline" v-model="inputDeadline" />
                </div>
              </div>

              <div class="row">
                <div class="col-md-6 mb-3">
                  <label for="fonts">{{ fonts }}</label>
                  <input type="text" class="form-control" id="fonts" value v-model="inputFonts" />
                  <div class="invalid-feedback">Kérlek add meg a mintában használt fontot!</div>
                </div>
              </div>
              <div class="row">
                <div class="col-md-6 mb-3">
                  <label for="comment">{{ comment }}</label>
                  <input type="text" class="form-control" id="comment" v-model="inputComment" />
                </div>
              </div>

              <div class="row ml-1 mt-5">
                <hr class="mb-4" />
                <a class="btn btn-lg btn-outline-primary mr-4" v-on:click="reset" type="reset">Mégse</a>
                <a
                  class="btn btn-lg btn-outline-primary"
                  value="submit"
                  type="submit"
                  v-on:click="checkForm"
                >Megrendelem</a>
              </div>
            </form>
            <notifications position="top center" width="30%" class="error" group="err" max="3" />
          </div>
        </div>
      </div>
    </main>
  </body>
</div>
</template>

<script>
import axios from "axios";
import Vue from "vue";
export default {
  name: "PatchFormBody",
  props: {},
  data() {
    return {
      file: "Kép a mintáról*",
      correctErrors: "Kérlek helyes formátumban add meg a következőket:",
      patchFormTitle: "Folt rendelés",
      patchFormDescription:
        "Foltot így meg így tudsz rendelni, ezt meg ezt kell tudni róla.",
      chooseFile: "Válaszd ki a fájlt",
      pattern: "Minta*",
      inputPattern: null,
      patternLocation: "Minta helye*",
      inputPatternLocation: null,
      size: "Méret (cm)*",
      inputSize: null,
      amount: "Mennyiség*",
      inputAmount: null,
      deadline: "Határidő*",
      inputDeadline: null,
      fonts: "Mintában használt betűtípusok",
      inputFonts: "",
      comment: "Megjegyzés",
      inputComment: "",
      cancelButton: "Mégse",
      orderButton: "Megrendelem",
      errors: []
    };
  },
  methods: {
    reset: function() {
      this.$router.push("/");
    },
    postPost: function() {
      const myStatus = this;
      axios
        .post(`http://localhost:52140/api/Orders`, {
          size: this.inputSize,
          amount: this.inputAmount,
          deadline: this.inputDeadline,
          pattern: this.inputPattern,
          orderComment: this.inputComment,
          fonts: this.inputFonts,
          type: 0,
          patternPlace: "-"
        })
        .then(function(response) {
          if (response.status === 201) {
            myStatus.$router.push("/userorder");
          }
        })

        .catch(error => {
          console.log(error);
          Vue.notify({
            group: "err",
            title: "HIBA!",
            text: "Valamelyik adatot nem megfelelően adtad meg!",
            type: "error",
            duration: 5000
          });
          return;
        });
    },

    setImage: function(e) {
      const file = e.target.files[0];
      var s;
      if (!file.type.includes("image/")) {
        alert("Kérlek, egy képet válassz!");
        return;
      }
      if (file.type.includes("jpeg") || file.type.includes("jpg")) {
        s = 23;
      } else {
        s = 22;
      }

      this.chooseFile = e.target.files[0].name;

      if (typeof FileReader === "function") {
        const reader = new FileReader();

        reader.onload = event => {
          this.inputPattern = event.target.result.slice(s);
        };
        reader.readAsDataURL(file);
      } else {
        alert("Sorry, FileReader API not supported");
      }
    },

    checkForm: function(e) {
      this.errors = [];
      if (
        this.inputPattern &&
        this.inputSize &&
        this.inputAmount &&
        this.inputDeadline &&
        this.checkDate() &&
        this.checkAmount()
      ) {
        this.postPost();

        return true;
      }

      if (!this.inputPattern) {
        this.errors.push({ id: 0, name: "a mintát" });
      }

      if (!this.inputSize) {
        this.errors.push({ id: 2, name: "a minta méretét" });
      }
      if (!this.inputAmount) {
        this.errors.push({ id: 3, name: "a mennyiséget" });
      }
      if (this.inputAmount && !this.checkAmount()) {
        this.errors.push({ id: 3, name: "a mennyiséget (0<x<5000)" });
      }
      if (!this.inputDeadline) {
        this.errors.push({ id: 4, name: "a határidőt" });
      }
      if (this.inputDeadline && !this.checkDate()) {
        this.errors.push({ id: 5, name: " határidőt" });
      }

      console.log(this.inputDeadline);
      e.preventDefault();
    },
    checkDate: function() {
      var today = new Date();
      var dd = String(today.getDate()).padStart(2, "0");
      var mm = String(today.getMonth() + 1).padStart(2, "0"); //January is 0!
      var yyyy = today.getFullYear();

      today = yyyy + "-" + mm + "-" + dd;

      if (today >= this.inputDeadline) {
        return false;
      } else if (today < this.inputDeadline) {
        return true;
      }
    },
    checkAmount: function() {
      if (this.inputAmount < 5000 && this.inputAmount > 0) {
        return true;
      } else return false;
    }
  }
};
</script>

<style scoped>
.file-input {
  cursor: pointer;
}
label {
  cursor: pointer;
}
input[type="file" i] {
  cursor: pointer;
}
</style>









