<template>
<body>
  <main role="main">
    <div class="container marketing">
      <div class="row featurette">
        <div class="col-md-7">
          <div v-if="role==='Admin'">
            <textarea
              class="form-control title"
              id="inputpatchTitle"
              for="inputpatchTitle"
              v-model="patch.title"
              placeholder="Amivel foglalkozun"
              @change="updatePatchTitle"
            ></textarea>
          </div>
          <div v-if="role !=='Admin'">
            <h2 class="featurette-heading">{{ patch.title }}</h2>
          </div>
          <div v-if="role==='Admin'">
            <textarea
              class="form-control description"
              id="inputpatchDescription"
              rows="3"
              for="inputpatchDescription"
              v-model="patch.description"
              placeholder="Add meg mivel foglalkoztok!"
              @change="updatePatchDescription"
            ></textarea>
          </div>
          <div v-if="role !=='Admin'">
            <p class="lead">{{ patch.description }}</p>
          </div>
          <a v-on:click="patchForm" class="btn btn-lg btn-block btn-outline-primary">Rendelés</a>
        </div>

        <div class="col-md-5">
          <div class="demo row">
            <coverflow :coverList="coverList0" :width="400" :coverWidth="300" :index="1"></coverflow>
          </div>
          <div v-if="role==='Admin'" class="row">
            <div class="col-6">
              <input
                type="file"
                class="custom-file-input col-5"
                id="customFile0"
                v-validate="'image0'"
                data-vv-as="image"
                name="image_field"
                @change="setImage($event, 0)"
              />
              <label class="custom-file-label" for="customFile0">
                {{
                chooseFile0
                }}
              </label>
            </div>
            <span
              class="btn btn-primary col-5"
              value="submit"
              type="submit"
              v-on:click="postImage(0)"
            >Mentés</span>
          </div>
        </div>
      </div>

      <hr class="featurette-divider" />

      <div class="row featurette">
        <div class="col-md-7 order-md-2">
          <div v-if="role==='Admin'">
            <textarea
              class="form-control title"
              id="inputPatternTitle"
              for="inputPatternTitle"
              v-model="embroideredPattern.title"
              placeholder="Amivel foglalkozunk"
              @change="updatePatternTitle"
            ></textarea>
          </div>
          <div v-if="role !=='Admin'">
            <h2 class="featurette-heading">{{ embroideredPattern.title }}</h2>
          </div>

          <div v-if="role==='Admin'">
            <textarea
              class="form-control description"
              id="inputPatternDescription"
              rows="3"
              for="inputPatternDescription"
              v-model="embroideredPattern.description"
              placeholder="Add meg mivel foglalkoztok!"
              @change="updatePatternDescription"
            ></textarea>
          </div>
          <div v-if="role !=='Admin'">
            <p class="lead">{{ embroideredPattern.description }}</p>
          </div>
          <a v-on:click="patternForm" class="btn btn-lg btn-block btn-outline-primary">Rendelés</a>
        </div>
        <div class="col-md-5">
          <div class="demo">
            <coverflow :coverList="coverList1" :width="400" :coverWidth="300" :index="1"></coverflow>
          </div>
          <div v-if="role==='Admin'" class="row">
            <div class="col-6">
              <input
                type="file"
                class="custom-file-input col-5"
                id="customFile1"
                v-validate="'image1'"
                data-vv-as="image"
                name="image_field"
                @change="setImage($event, 1)"
              />
              <label class="custom-file-label" for="customFile1">
                {{
                chooseFile1
                }}
              </label>
            </div>
            <span
              class="btn btn-primary col-5"
              value="submit"
              type="submit"
              v-on:click="postImage(1)"
            >Mentés</span>
          </div>
        </div>
      </div>

      <hr class="featurette-divider" />

      <div class="row featurette" id="down">
        <div class="col-md-7">
          <div v-if="role==='Admin'">
            <textarea
              class="form-control title"
              id="inputsewaterTitle"
              for="inputsewaterTitle"
              v-model="sweater.title"
              placeholder="Amivel foglalkozunk"
              @change="updateSweaterTitle"
            ></textarea>
          </div>
          <div v-if="role !=='Admin'">
            <h2 class="featurette-heading">{{ sweater.title }}</h2>
          </div>

          <div v-if="role==='Admin'">
            <textarea
              class="form-control description"
              id="inputsweaterDescription"
              rows="3"
              for="inputsweaterDescription"
              v-model="sweater.description"
              placeholder="Add meg mivel foglalkoztok!"
              @change="updateSweaterDescription"
            ></textarea>
          </div>
          <div v-if="role !=='Admin'">
            <p class="lead">{{ sweater.description }}</p>
          </div>
        </div>
        <div class="col-md-5">
          <div class="demo">
            <coverflow :coverList="coverList2" :width="400" :coverWidth="300" :index="1"></coverflow>
          </div>
          <div v-if="role==='Admin'" class="row">
            <div class="col-6">
              <input
                type="file"
                class="custom-file-input col-5"
                id="customFile2"
                v-validate="'image2'"
                data-vv-as="image"
                name="image_field"
                @change="setImage($event, 2)"
              />
              <label class="custom-file-label" for="customFile2">
                {{
                chooseFile2
                }}
              </label>
            </div>
            <span
              class="btn btn-primary col-5"
              value="submit"
              type="submit"
              v-on:click="postImage(2)"
            >Mentés</span>
          </div>
        </div>
      </div>

      <hr class="featurette-divider" />

      <!-- /END THE FEATURETTES -->
    </div>
    <!-- /.container -->
  </main>
</body>
</template>

<script>
import coverflow from "vue-coverflow";
import axios from "axios";

export default {
  name: "MainPageBody",
  data() {
    return {
      auth: false,
      chooseFile0: "Válassz képet",
      chooseFile1: "Válassz képet",
      chooseFile2: "Válassz képet",
      saveButton: "Mentés",
      image0: null,
      image1: null,
      image2: null,
      role: null,
      patch: {
        title: null,
        description: null,
        id: null
      },
      embroideredPattern: {
        title: null,
        description: null,
        id: null
      },
      sweater: {
        title: null,
        description: null,
        id: null
      },
      coverList0: [
        {
          cover: null
        },
        {
          cover: null
        },
        {
          cover: null
        },
        {
          cover: null
        },
        {
          cover: null
        },
        {
          cover: null
        },
        {
          cover: null
        },
        {
          cover: null
        },
        {
          cover: null
        },
        {
          cover: null
        }
      ],
      coverList1: [
        {
          cover: null
        },
        {
          cover: null
        },
        {
          cover: null
        },
        {
          cover: null
        },
        {
          cover: null
        },
        {
          cover: null
        },
        {
          cover: null
        },
        {
          cover: null
        },
        {
          cover: null
        },
        {
          cover: null
        }
      ],
      coverList2: [
        {
          cover: null
        },
        {
          cover: null
        },
        {
          cover: null
        },
        {
          cover: null
        },
        {
          cover: null
        },
        {
          cover: null
        },
        {
          cover: null
        },
        {
          cover: null
        },
        {
          cover: null
        },
        {
          cover: null
        }
      ]
    };
  },
  methods: {
    patchForm: function() {
      if (this.auth) {
        this.$router.push("/patchform");
      } else {
        this.$router.push("/signin");
      }
    },
    patternForm: function() {
      console.log("patternform");

      if (this.auth) {
        this.$router.push("/patternform");
      } else {
        this.$router.push("/signin");
      }
    },
    updatePatchTitle() {
      axios
        .patch("http://localhost:52140/api/Contents/".concat(this.patch.id), [
          {
            op: "replace",
            path: "/title",
            value: this.patch.title
          }
        ])
        .then(
          //res => console.log(res.data),
          console.log(this.patch.title)
        )
        .catch(e => {
          this.errors.push(e);
        });
    },
    updatePatchDescription() {
      axios
        .patch("http://localhost:52140/api/Contents/".concat(this.patch.id), [
          {
            op: "replace",
            path: "/contentString",
            value: this.patch.description
          }
        ])
        .then(
          //res => console.log(res.data),
          console.log(this.patch.description)
        )
        .catch(e => {
          this.errors.push(e);
        });
    },
    updatePatternTitle() {
      axios
        .patch(
          "http://localhost:52140/api/Contents/".concat(
            this.embroideredPattern.id
          ),
          [
            {
              op: "replace",
              path: "/title",
              value: this.embroideredPattern.title
            }
          ]
        )
        .then(
          //res => console.log(res.data),
          console.log(this.embroideredPattern.title)
        )
        .catch(e => {
          this.errors.push(e);
        });
    },
    updatePatternDescription() {
      axios
        .patch(
          "http://localhost:52140/api/Contents/".concat(
            this.embroideredPattern.id
          ),
          [
            {
              op: "replace",
              path: "/contentString",
              value: this.embroideredPattern.description
            }
          ]
        )
        .then(
          //res => console.log(res.data),
          console.log(this.embroideredPattern.description)
        )
        .catch(e => {
          this.errors.push(e);
        });
    },
    updateSweaterDescription() {
      axios
        .patch("http://localhost:52140/api/Contents/".concat(this.sweater.id), [
          {
            op: "replace",
            path: "/contentString",
            value: this.sweater.description
          }
        ])
        .then(
          //res => console.log(res.data),
          console.log(this.sweater.description)
        )
        .catch(e => {
          this.errors.push(e);
        });
    },
    updateSweaterTitle() {
      axios
        .patch("http://localhost:52140/api/Contents/".concat(this.sweater.id), [
          {
            op: "replace",
            path: "/title",
            value: this.sweater.title
          }
        ])
        .then(
          //res => console.log(res.data),
          console.log(this.sweater.title)
        )
        .catch(e => {
          this.errors.push(e);
        });
    },
    setImage: function(e, i) {
      const file = e.target.files[0];

      if (!file.type.includes("image/")) {
        alert("Please select an image file");
        return;
      }
      if (i === 0) {
        this.chooseFile0 = e.target.files[0].name;
      }
      if (i === 1) {
        this.chooseFile1 = e.target.files[0].name;
      }
      if (i === 2) {
        this.chooseFile2 = e.target.files[0].name;
      }

      if (typeof FileReader === "function") {
        const reader = new FileReader();

        reader.onload = event => {
          if (i === 0) {
            this.image0 = event.target.result.slice(23);
          }
          if (i === 1) {
            this.image1 = event.target.result.slice(23);
          }
          if (i === 2) {
            this.image2 = event.target.result.slice(23);
          }
        };
        reader.readAsDataURL(file);
      } else {
        alert("Sorry, FileReader API not supported");
      }
    },
    postImage: function(itype) {
      const loc = location;
      var postImage;
      if (itype === 0) {
        postImage = this.image0;
      }
      if (itype === 1) {
        postImage = this.image1;
      }
      if (itype === 2) {
        postImage = this.image2;
      }
      console.log(this.postImage);
      console.log(itype);
      axios
        .post(`http://localhost:52140/api/Images`, {
          path: "welcome",
          byteImage: postImage,
          type: itype,
          active: true
        })
        .then(function() {
          loc.reload();
        })
        .catch(error => {
          console.log(error);
        });
    }
  },

  async mounted() {
    try {
      const res = await axios.get(
        "http://localhost:52140/api/Contents?path=welcome"
      );
      this.patch.title = res.data[0].title;
      this.patch.description = res.data[0].contentString;
      this.patch.id = res.data[0].contentId;
      this.embroideredPattern.title = res.data[1].title;
      this.embroideredPattern.description = res.data[1].contentString;
      this.embroideredPattern.id = res.data[1].contentId;
      this.sweater.title = res.data[2].title;
      this.sweater.description = res.data[2].contentString;
      this.sweater.id = res.data[2].contentId;
    } catch (e) {
      console.log(e);
    }
    try {
      const img0 = await axios.get(
        "http://localhost:52140/api/Images/?path=welcome&type=0"
      );
      const arrayLength0 = img0.data.length;
      for (var i = 0; i < arrayLength0; i++) {
        let cover0 = "data:image/jpg;base64,".concat(img0.data[i].byteImage);
        this.coverList0[i].cover = cover0;
      }

      const img1 = await axios.get(
        "http://localhost:52140/api/Images/?path=welcome&type=1"
      );
      const arrayLength1 = img1.data.length;
      for (var j = 0; j < arrayLength1; j++) {
        let cover1 = "data:image/jpg;base64,".concat(img1.data[j].byteImage);
        this.coverList1[j].cover = cover1;
      }
      const img2 = await axios.get(
        "http://localhost:52140/api/Images/?path=welcome&type=2"
      );
      const arrayLength2 = img2.data.length;
      for (var k = 0; k < arrayLength2; k++) {
        let cover2 = "data:image/jpg;base64,".concat(img2.data[k].byteImage);
        this.coverList2[k].cover = cover2;
      }
    } catch (e) {
      console.log(e);
    }
    try {
      const response = await axios.get("http://localhost:52140/api/User");
      this.role = response.data.roles[0];
      console.log(response.status);
      if (response.status === 200) {
        this.auth = true;
      } else {
        this.auth = false;
      }
    } catch (e) {
      console.log(e);
    }
  },
  components: {
    coverflow
  }
};
</script>


<style scoped>
textarea {
  background: transparent;
  border: 0 none;
  width: 100%;
  outline: none;
  resize: none;
  height: 70px;
}
.title {
  font-weight: 400;
  font-size: 50px;
  line-height: 1;
  letter-spacing: -0.05rem;
  margin-right: 0.6rem;
  margin-left: 0.6rem;
  font-family: -apple-system, BlinkMacSystemFont, "Segoe UI", Roboto,
    "Helvetica Neue", Arial, "Noto Sans", sans-serif, "Apple Color Emoji",
    "Segoe UI Emoji", "Segoe UI Symbol", "Noto Color Emoji";
}
.description{
  font-size: 1.25rem;
  font-weight: 300;
  margin-top: 0;
  margin-bottom: 1rem;
  font-family: -apple-system, BlinkMacSystemFont, "Segoe UI", Roboto,
    "Helvetica Neue", Arial, "Noto Sans", sans-serif, "Apple Color Emoji",
    "Segoe UI Emoji", "Segoe UI Symbol", "Noto Color Emoji";
  height: fit-content;
}
.marketing .col-md-5 {
  text-align: left;
}
</style>