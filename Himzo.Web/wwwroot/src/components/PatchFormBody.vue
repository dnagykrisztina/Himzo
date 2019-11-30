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
                    required
                    @change="setImage"
                  />
                  <label class="custom-file-label" for="customFile">{{
                    chooseFile
                  }}</label>
                </div>

                <div class="row">
                  <div class="col-md-3 mb-3">
                    <label for="size">{{ size }}</label>
                    <input
                      type="text"
                      class="form-control"
                      id="size"
                      required
                      v-model="inputSize"
                    />
                  </div>
                  <div class="col-md-3 mb-3">
                    <label for="amount">{{ amount }}</label>
                    <input
                      type="number"
                      class="form-control"
                      id="amount"
                      required
                      v-model="inputAmount"
                    />
                    <div class="invalid-feedback">
                      Kérlek add meg a mintában használt fontot!
                    </div>
                  </div>
                  <div class="col-md-4 mb-3">
                    <label for="deadline">{{ deadline }}</label>
                    <input
                      type="date"
                      class="form-control"
                      id="deadline"
                      required
                      v-model="inputDeadline"
                    />
                  </div>
                </div>

                <div class="row">
                  <div class="col-md-6 mb-3">
                    <label for="fonts">{{ fonts }}</label>
                    <input
                      type="text"
                      class="form-control"
                      id="fonts"
                      value
                      required
                      v-model="inputFonts"
                    />
                    <div class="invalid-feedback">
                      Kérlek add meg a mintában használt fontot!
                    </div>
                  </div>
                </div>
                <div class="row">
                  <div class="col-md-6 mb-3">
                    <label for="comment">{{ comment }}</label>
                    <input
                      type="text"
                      class="form-control"
                      id="comment"
                      value
                      v-model="inputComment"
                    />
                  </div>
                </div>

                <div class="row">
                  <hr class="mb-4" />
                  <a class="btn btn-primary" @click="reset" type="reset">{{
                    cancelButton
                  }}</a>
                  <a
                    class="btn btn-primary"
                    type="submit"
                    @mouseup="postPost()"
                    >{{ orderButton }}</a
                  >
                </div>
              </form>
              <notifications
                position="top center"
                width="30%"
                class="error"
                group="err"
                max="3"
              />
            </div>
          </div>
        </div>
      </main>
    </body>
  </div>
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
      inputPattern: null,
      patternLocation: "Minta helye",
      inputPatternLocation: null,
      size: "Méret (cm)",
      inputSize: null,
      amount: "Mennyiség",
      inputAmount: null,
      deadline: "Határidő",
      inputDeadline: null,
      fonts: "Mintában használt fontok",
      inputFonts: null,
      comment: "Megjegyzés",
      inputComment: "",
      cancelButton: "Mégse",
      orderButton: "Megrendelem",
      valam: 1
    };
  },
  methods: {
    reset() {
      console.log("patchform reset");
      this.$router.push("/");
    },

    postPost() {
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

        .catch(error => {
          console.log(error.response + "hiba");
          });
        
      /*.finally({

          if(valami > 0) {
            console.log("patchForm submit"), this.$router.push("/userorder");
          }
        })*/

      //currentObj.output = response.data; //a response volt eredetileg a fgv paramétere
    },

    setImage: function(e) {
      const file = e.target.files[0];
      //console.log(file);

      if (!file.type.includes("image/")) {
        alert("Please select an image file");
        return;
      }

      this.chooseFile = e.target.files[0].name;

      if (typeof FileReader === "function") {
        const reader = new FileReader();

        reader.onload = event => {
          this.inputPattern = event.target.result.slice(23);
          //console.log(this.inputPattern);
          // rebuild cropperjs with the updated source
          this.$refs.cropper.replace(event.target.result);
        };
        reader.readAsDataURL(file);
      } else {
        alert("Sorry, FileReader API not supported");
      }
    }
  }
};
</script>

<style scoped></style>
