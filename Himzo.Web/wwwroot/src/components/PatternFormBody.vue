<template>
<body>
  <main role="main">
    <!-- Main jumbotron for a primary marketing message or call to action -->
    <div class="jumbotron">
      <div class="container">
        <h1 class="display-3">{{ patternFormTitle }}</h1>
        <p>{{ patternFormDescription }}</p>
      </div>
    </div>

    <div class="container">
      <div class="row">
        <div class="col-md-8 order-md-1">
          <form class="needs-validation" novalidate>
            <div class="row">
              <div class="col-md-6 mb-3">
                <input type="file" class="custom-file-input" id="customFile" />
                <label class="custom-file-label" for="customFile">{{chooseFile}}</label>
              </div>
            </div>

            <div class="row">
              <div class="col-md-3 mb-3">
                <label for="size">{{size}}</label>
                <input
                  v-model="inputSize"
                  type="number"
                  class="form-control"
                  id="size"
                  placeholder
                  required
                />
              </div>
              <div class="col-md-3 mb-3">
                <label for="amount">{{amount}}</label>
                <input
                  v-model="inputAmount"
                  type="number"
                  class="form-control"
                  id="amount"
                  placeholder
                  required
                />
              </div>
              <div class="col-md-4 mb-3">
                <label for="deadline">{{deadline}}</label>
                <input
                  v-model="inputDeadline"
                  type="date"
                  class="form-control"
                  id="deadline"
                  placeholder
                  required
                />
              </div>
            </div>

            <div class="row">
              <div class="col-md-6 mb-3">
                <label for="patternLocation">{{patternLocation}}</label>
                <input
                  v-model="inputPatternLocation"
                  type="text"
                  class="form-control"
                  id="patternLocation"
                  placeholder
                  value
                  required
                />
                <div class="invalid-feedback">Kérlek add meg a minta helyét!</div>
              </div>
            </div>

            <div class="row">
              <div class="col-md-6 mb-3">
                <label for="font">{{fonts}}</label>
                <input
                  v-model="inputFonts"
                  type="text"
                  class="form-control"
                  id="font"
                  placeholder
                  value
                  required
                />
                <div class="invalid-feedback">Kérlek add meg a mintában használt fontot!</div>
              </div>
            </div>

            <div class="row">
              <div class="col-md-6 mb-3">
                <label for="comment">{{comment}}</label>
                <input
                  v-model="inputComment"
                  type="text"
                  class="form-control"
                  id="comment"
                  placeholder
                  value
                />
              </div>
            </div>

            <div class="row">
              <hr class="mb-4" />
                
              <a class="btn btn-primary" @click="reset" type="reset"  @mouseup="postPost()" href="index.html">{{cancelButton}}</a>
              <a class="btn btn-primary" type="submit" href="index.html#/userorder">{{orderButton}}</a>
            </div>
          </form>
        </div>
      </div>
    </div>
  </main>
</body>
</template>

 
 <script>
import axios from "axios";
export default {
  name: "PatternFormBody",
  props: {},
  data() {
    return {
      patternFormTitle: "Minta hímeztetése",
      patternFormDescription:
        "Mintát hozott anyagra így meg amúgy tudsz hímeztetni.",

      chooseFile: "Válaszd ki a fájlt",
      pattern: "Minta",
      inputPattern: null,
      patternLocation: "Minta helye",
      inputPatternLocation: null,
      size: "Méret (cm)",
      inputSize: null,
      amount: "Mennyiség",
      inputAmount: null,
      deadline: "Határidő",
      inputDeadline: "2019-12-15T08:58:18.176Z",
      fonts: "Mintában használt fontok",
      inputFonts: null,
      comment: "Megjegyzés",
      inputComment: null,
      cancelButton: "Mégse",
      orderButton: "Megrendelem",
      orderTime: "2019-12-11T08:58:18.176Z"
    };
  },
  methods: {
    formSubmit(e) {
      e.preventDefault();

      let currentObj = this;

      this.axios
        .post("http://localhost:52140/api/Orders", {
          orderstate: 0,
          size: this.inputSize,
          amount: this.inputAmount,
          deadline: this.inputDeadline,
          pattern: null,
          orderComment: this.inputComment,
          orderTime: this.orderTime,
          fonts: this.inputFonts,
          type: 0,
          patternPlace: this.inputPatternLocation
        })

        .then(
            function (response) {
            currentObj.output = response.data;
            },
            //currentObj.output = response.data; //a response volt eredetileg a fgv paramétere
            console.log("patternForm submit"),
            this.$router.push("/userorder")
        )

        .catch(function(error) {
          currentObj.output = error;
        });
    }
  }
};
</script>

<style scoped>
</style>