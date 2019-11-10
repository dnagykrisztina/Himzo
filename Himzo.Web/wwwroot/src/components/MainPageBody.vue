<template>
<body>
  <main role="main">
    <div class="container marketing">
      <!-- START THE FEATURETTES -->

      <hr class="featurette-divider" />
      <img :src="dataUrl" />

      <div class="row featurette">
        <div class="col-md-7">
          <h2 class="featurette-heading">{{ patchTitle }}</h2>
          <p class="lead">{{ patchDescription }}</p>
          <a href="index.html#/patchform" class="btn btn-lg btn-block btn-outline-primary">Rendelés</a>
        </div>

        <div class="col-md-5">
          <!-- <coverflow :coverList="coverList" :coverWidth="100" :index="2" @change="handleChange"></coverflow> -->
          <Coverflow v-bind:coverList="coverList"></Coverflow>
        </div>
      </div>

      <hr class="featurette-divider" />

      <div class="row featurette">
        <div class="col-md-7 order-md-2">
          <h2 class="featurette-heading">{{ embroideredPatternTitle }}</h2>
          <p class="lead">{{ embroideredPatternDescription }}</p>
          <a
            href="index.html#/patternform"
            class="btn btn-lg btn-block btn-outline-primary"
          >Rendelés</a>
        </div>
        <div class="col-md-5 order-md-1">
          <Coverflow></Coverflow>
        </div>
      </div>

      <hr class="featurette-divider" />

      <div class="row featurette">
        <div class="col-md-7">
          <h2 class="featurette-heading">{{ sweaterTitle }}</h2>
          <p class="lead">{{ sweaterDescription }}</p>
        </div>
        <div class="col-md-5">
          <Coverflow></Coverflow>
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
import Coverflow from "./Coverflow";
import axios from "axios";

export default {
  name: "MainPageBody",
  props: {},
  data() {
    return {
      //allcontents: [],
      patchTitle: null,
      patchDescription: null,
      embroideredPatternTitle: null,
      embroideredPatternDescription: null,
      sewaterTitle: null,
      sweaterDescription: null,
      image: null,
      coverList: [
        {
          cover: require("../assets/images/react.png"),
          title: "React"
        },
        {
          cover: require("../assets/images/angular.png"),
          title: "Angular"
        },
        {
          cover: require("../assets/images/vue.png"),
          title: "Vue"
        },
        {
          cover: require("../assets/images/webpack.png"),
          title: "Webpack"
        },
        {
          cover: require("../assets/images/yarn.png"),
          title: "Yarn"
        },
        {
          cover: require("../assets/images/node.png"),
          title: "Node"
        }
      ],
      coverList2: [
        {
          cover: require("../assets/images/webpack.png"),
          title: "Webpack"
        },
        {
          cover: require("../assets/images/yarn.png"),
          title: "Yarn"
        },
        {
          cover: require("../assets/images/node.png"),
          title: "Node"
        }
      ],

      postBody: [
        {
          contentId: 20,
          title: "proba",
          contentString:
            "Proba igy meg igy kell rendelni. Nem csak rendezvényekre készítjük őket, hanem egyéni megrendeléseket is fogadunk!"
        },
        {
          contentId: 70,
          title: "Hímzett minták",
          contentString:
            "Hozott anyagokra tudunk neked hímeztetni, ez meg ez kell hozzá, tök jó lesz."
        },
        {
          contentId: 101,
          title: "VIK-es pulcsik",
          contentString:
            "Több féle színben elérhetőek a VIK-es pulóverek. Ha megtetszett valamelyik, a himzo.sch.bme.hu email címen kaphatsz több információt róla."
        }
      ]
    };
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

      axios.post(`http://localhost:52140/api/Contents?path=welcome`, {
        body: this.postBody
      });
    } catch (e) {
      console.log(e);
    }
  },
  components: {
    Coverflow
  },

  postPost() {
    axios.post(`http://localhost:52140/api/Contents?path=welcome`, {
      body: this.postBody
    });
    //.then(response => {})
    //.catch(e => {
    //  this.errors.push(e);
    //});
  }
};
var img = document.createElement("img");
img.src = "data:image/jpeg;base64," + btoa("your-binary-data");
document.body.appendChild(img);
</script>

<style scoped>
</style>
