<template>
<body class="bg-light">
  <main role="main">
    <!-- Main jumbotron for a primary marketing message or call to action -->

    <div class="jumbotron">
      <div class="container">
        <h1 class="display-3">{{ patchFormTitle }}</h1>
        <p>{{ patchFormDescription }}</p>
      </div>
    </div>

    <div class="container">
      <div class="row">
        <div class="col-md-8 order-md-1">
          <form class="needs-validation" novalidate @submit="postPost()">
            <div class="row"></div>

            <div class="col-md-6 mb-3">
              <input type="file" class="custom-file-input" id="customFile" />
              <label class="custom-file-label" for="customFile">{{chooseFile}}</label>
            </div>

            <div class="row">
              <div class="col-md-3 mb-3">
                <label for="cc-name">{{size}}</label>
                <input type="text" class="form-control" id="size" required />
              </div>
              <div class="col-md-3 mb-3">
                <label for="cc-name">{{amount}}</label>
                <input type="number" class="form-control" id="amount" required />
              </div>
              <div class="col-md-4 mb-3">
                <label for="cc-number">{{deadline}}</label>
                <input type="date" class="form-control" id="deadline" required />
              </div>
            </div>

            <div class="row">
              <div class="col-md-6 mb-3">
                <label for="firstName">{{fonts}}</label>
                <input
                  type="text"
                  class="form-control"
                  id="patternLocation"
                  value
                  required
                  v-model="inputFonts"
                />
                <div class="invalid-feedback">Kérlek add meg a mintában használt fontot!</div>
              </div>
            </div>
            <div class="row">
              <div class="col-md-6 mb-3">
                <label for="firstName">{{comment}}</label>
                <input type="text" class="form-control" id="patternLocation" placeholder value />
              </div>
            </div>

            <div class="row">
              <hr class="mb-4" />
              <a class="btn btn-primary" type="reset" href="index.html">{{cancelButton}}</a>
              <a
                class="btn btn-primary"
                type="submit"
                href="index.html#/userorder"
                @mouseup="postForm()"
              >{{orderButton}}</a>
            </div>
          </form>
        </div>
      </div>
    </div>
    <strong>Output:</strong>
    <pre>{{output}}</pre>
  </main>
</body>
</template>

 
 <script>
import axios from "axios";
export default {
  name: "PatchFormBody",
  props: {},
  data() {
    return {
      patchFormTitle: "Folt rendelés",
      patchFormDescription:
        "Foltot így meg így tudsz rendelni, ezt meg ezt kell tudni róla.",
      chooseFile: "Válaszd ki a fájlt",
      pattern: "Minta",
      inputPattern: "valami",
      patternLocation: "Minta helye",
      inputPatternLocation: "valami",
      size: "Méret (cm)",
      inputSize: "méret",
      amount: "Mennyiség",
      inputAmount: 3,
      deadline: "Határidő",
      inputDeadline: "2019-12-15T08:58:18.176Z",
      fonts: "Mintában használt fontok",
      inputFonts: "font",
      comment: "Megjegyzés",
      inputComment: "comment",
      cancelButton: "Mégse",
      orderButton: "Megrendelem",
      orderTime: "2019-12-11T08:58:18.176Z",
      output: ""
    };
  },
  methods: {
    /* async postForm() {
      const res = await axios
        .post("http://localhost:52140/api/Orders", {
          size: this.inputSize,
          amount: this.inputAmount,
          deadline: this.inputDeadline,
          orderComment: this.inputComment,
          orderTime: this.orderTime,
          fonts: this.inputFonts,
          type: 0,
          patternPlace: this.inputPatternLocation
        })
        .then(function(response) {
          res.output = response.data;
        })

        .catch(function(error) {
          res.output = error;
        });
    },*/
    formSubmit(e) {
      e.preventDefault();

      let currentObj = this;

      this.axios
        .post("http://localhost:52140/api/Orders", {
          size: this.inputSize,
          amount: this.inputAmount,
          deadline: this.inputDeadline,
          orderComment: this.inputComment,
          orderTime: this.orderTime,
          fonts: this.inputFonts,
          type: 0,
          patternPlace: this.inputPatternLocation
        })

        .then(function(response) {
          currentObj.output = response.data;
        })

        .catch(function(error) {
          currentObj.output = error;
        });
    }
    /*postPost() {
      axios
        .post(`http://localhost:52140/api/Orders`, {
          size: this.inputSize,
          amount: this.inputAmount,
          deadline: this.inputDeadline,
          orderComment: this.inputComment,
          orderTime: this.orderTime,
          fonts: this.inputFonts,
          type: 0,
          patternPlace: this.inputPatternLocation
        })
        // .then(response => {})
        .catch(e => {
          this.errors.push(e);
        });
    }*/
  }
};
</script>

<style scoped>
</style>