<template>
<div>
  <div class="jumbotron">
    <div class="container">
      <h1 class="display-3">{{ patternFormTitle }}</h1>
      <p>{{ patternFormDescription }}</p>
    </div>
  </div>
  <body>
    <main role="main">
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
              <div class="row">
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
              </div>

              <div class="row">
                <div class="col-md-3 mb-3">
                  <label for="size">{{ size }}</label>
                  <input v-model="inputSize" type="text" class="form-control" id="size" required />
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
                </div>
                <div class="col-md-4 mb-3">
                  <label for="deadline">{{ deadline }}</label>
                  <input type="date" class="form-control" id="deadline" v-model="inputDeadline" />
                </div>
              </div>

              <div class="row">
                <div class="col-md-6 mb-3">
                  <label for="patternLocation">{{ patternLocation }}</label>
                  <input
                    type="text"
                    class="form-control"
                    id="patternLocation"
                    value
                    v-model="inputPatternLocation"
                  />
                  <div class="invalid-feedback">Kérlek add meg a minta helyét!</div>
                </div>
              </div>

              <div class="row">
                <div class="col-md-6 mb-3">
                  <label for="font">{{ fonts }}</label>
                  <input v-model="inputFonts" type="text" class="form-control" id="font" required />
                  <div class="invalid-feedback">Kérlek add meg a mintában használt fontot!</div>
                </div>
              </div>

              <div class="row">
                <div class="col-md-6 mb-3">
                  <label for="comment">{{ comment }}</label>
                  <input v-model="inputComment" type="text" class="form-control" id="comment" />
                </div>
              </div>

              <div class="row ml-1 mt-5">
                <hr class="mb-4" />
                <a class="btn btn-lg  btn-outline-primary mr-4" v-on:click="reset" type="reset">{{ cancelButton }}</a>
                <a class="btn btn-lg  btn-outline-primary" type="submit" v-on:click="checkForm">{{ orderButton }}</a>
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
  name: "PatternFormBody",
  props: {},
  data() {
    return {
      correctErrors: "Kérlek helyes formátumban add meg a következőket:",
      patternFormTitle: "Minta hímeztetése",
      patternFormDescription:
        "Mintát hozott anyagra így meg amúgy tudsz hímeztetni.",
      chooseFile: "Válaszd ki a fájlt",
      pattern: "Minta",
      inputPattern: "null",
      patternLocation: "Minta helye",
      inputPatternLocation: null,
      size: "Méret (cm)",
      inputSize: null,
      amount: "Mennyiség",
      inputAmount: null,
      deadline: "Határidő",
      inputDeadline: null,
      fonts: "Mintában használt fontok",
      inputFonts: "",
      comment: "Megjegyzés",
      inputComment: " ",
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
          type: 1,
          patternPlace: this.inputPatternLocation
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

      if (!file.type.includes("image/")) {
        alert("Please select an image file");
        return;
      }
      this.chooseFile = e.target.files[0].name;

      if (typeof FileReader === "function") {
        const reader = new FileReader();

        reader.onload = event => {
          this.inputPattern = event.target.result.slice(23);

          this.$refs.cropper.replace(event.target.result);
        };
        reader.readAsDataURL(file);
      } else {
        alert("Sorry, FileReader API not supported");
      }
    },
    checkForm: function(e) {
      if (
        this.inputPattern &&
        this.inputSize &&
        this.inputAmount &&
        this.inputDeadline &&
        this.inputPatternLocation &&
        this.checkDate()
      ) {
        this.postPost();
        return true;
      }
      this.errors = [];

      if (!this.inputPattern) {
        this.errors.push({ id: 0, name: "a mintát" });
      }
      if (!this.inputSize) {
        this.errors.push({ id: 2, name: "a minta méretét" });
      }
      if (!this.inputAmount) {
        this.errors.push({ id: 3, name: "a mennyiséget" });
      }
      if (!this.inputDeadline) {
        this.errors.push({ id: 4, name: "a határidőt" });
      }
      if (this.inputDeadline && !this.checkDate()) {
        this.errors.push({ id: 5, name: " határidőt" });
      }
      if (!this.inputPatternLocation) {
        this.errors.push({ id: 6, name: "a minta helyét" });
      }

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
    }
  }
};
</script>

<style scoped></style>
