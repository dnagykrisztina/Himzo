<template>
<body>
  <main role="main">
    <div class="container marketing">
      <!-- START THE FEATURETTES -->

      <!--<img :src="dataUrl" />-->

      <div class="row featurette">
        <div class="col-md-7 d-flex flex-column">
          <div>
            <h2 class="featurette-heading">{{ patchTitle }}</h2>
            <p class="lead">{{ patchDescription }}</p>
            <a v-on:click="patchForm" class="btn btn-lg btn-block btn-outline-primary">Rendelés</a>
          </div>
          <div style="position: relative;">
            <input
              type="file"
              class="custom-file-input col-5"
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
            <a
              class="btn btn-primary"
              value="submit"
              type="submit"
              v-on:click="postImage(0)"
            >{{ saveButton }}</a>
          </div>
        </div>

        <div class="col-md-5 d-flex flex-column">
          <div class="demo">
            <coverflow :coverList="coverList0" :width="400" :coverWidth="300" :index="1"></coverflow>
          </div>
        </div>
      </div>

      <hr class="featurette-divider" />

      <div class="row featurette">
        <div class="d-flex flex-column">
          <div class="col-md-7 order-md-2">
            <h2 class="featurette-heading">{{ embroideredPatternTitle }}</h2>
            <p class="lead">{{ embroideredPatternDescription }}</p>
            <a v-on:click="patternForm" class="btn btn-lg btn-block btn-outline-primary">Rendelés</a>
          </div>
        </div>
        <div class="d-flex flex-column">
          <div class="col-md-5 order-md-1">
            <coverflow :coverList="coverList1" :width="400" :coverWidth="300" :index="0"></coverflow>
          </div>
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
            <a
              class="btn btn-primary"
              value="submit"
              type="submit"
              v-on:click="postImage(1)"
            >{{ saveButton }}</a>
          </div>
        </div>
      </div>

      <hr class="featurette-divider" />

      <div class="row featurette" id="down">
        <div class="col-md-7">
          <h2 class="featurette-heading">{{ sewaterTitle }}</h2>
          <p class="lead">{{ sweaterDescription }}</p>
        </div>
        <div class="col-md-5">
          <coverflow :coverList="coverList2" :width="400" :coverWidth="300" :index="1"></coverflow>
        </div>
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
          <a
            class="btn btn-primary"
            value="submit"
            type="submit"
            v-on:click="postImage(2)"
          >{{ saveButton }}</a>
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
  props: {},

  data() {
    return {
      //allcontents: [],
      chooseFile: "Válassz képet",
      auth: false,
      patchTitle: null,
      patchDescription: null,
      embroideredPatternTitle: null,
      embroideredPatternDescription: null,
      sewaterTitle: null,
      sweaterDescription: null,
      image: null,
      username: null,
      saveButton: "Mentés",
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
          this.image = event.target.result.slice(23);
        };
        reader.readAsDataURL(file);
      } else {
        alert("Sorry, FileReader API not supported");
      }
    },
    postImage: function(itype) {
      const loc = location;
      //const myStatus = this;
      console.log(this.image);
      axios
        .post(`http://localhost:52140/api/Images`, {
          path: "welcome",
          byteImage: this.image,
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
      this.patchTitle = res.data[0].title;
      this.patchDescription = res.data[0].contentString;
      this.embroideredPatternTitle = res.data[1].title;
      this.embroideredPatternDescription = res.data[1].contentString;
      this.sewaterTitle = res.data[2].title;
      this.sweaterDescription = res.data[2].contentString;
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

<style scoped></style>
