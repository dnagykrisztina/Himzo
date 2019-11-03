<template>
<body>
  <main role="main">
    <div class="container marketing">
      <!-- START THE FEATURETTES -->

      <!--
      <ul>
        <li v-for="content in contents" :key="content.key">{{content.value}}</li>
      </ul>

      <ul>
        <li v-for="content in allcontents" :key="content.contentId">{{content.contentString}}</li>
      </ul>
      -->

      <hr class="featurette-divider" />

      <div class="row featurette">
        <div class="col-md-7">
          <h2 class="featurette-heading">{{ patchTitle }}</h2>
          <p class="lead">{{ patchDescription }}</p>
          <a href="index.html#/patchform" class="btn btn-lg btn-block btn-outline-primary">Rendelés</a>
        </div>

        <div class="col-md-5">
          <!-- <coverflow :coverList="coverList" :coverWidth="100" :index="2" @change="handleChange"></coverflow> -->
          <Coverflow></Coverflow>
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

      /*contents: [
        { key: "patch", title: null, description: null },
        { key: "embroideredPattern", title: null, description: null },
        { key: "sweater", title: null, description: null }
      ],*/
      photo: "../images/picture.jpg"
    };
  },

  /* mounted: function() {
    this.testFetch();
  },
  methods: {
    testFetch: () => {
      fetch("http://localhost:52140/api/Comments", {
        mode: "cors",
        headers: {
          "Access-Control-Allow-Origin": "*"
        }
      })
        .then(v => v.json())
        .then(v => console.log(v));
    }
    http://localhost:3000/Comments
  },*/
  /*async created() {
    try {
      const res = await axios.get("http://localhost:3000/Comments");
      this.todos = res.data;
    } catch (e) {
      console.log(e);
    }
  },*/
  // axios
  // .get("http://localhost:3000/Comments")
  //.then(response => (this.info = response));
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
      /* var i;
      this.allcontents = res.data;
      for (i = 0; i < this.allcontents.length; i++) {
        this.contents[i].title = this.allcontents[i].title;
        this.contents[i].description = this.allcontents[i].contentString;*/
      // }
    } catch (e) {
      console.log(e);
    }
  },
  methods: {},
  components: {
    Coverflow
  }
};
</script>

<style scoped>
</style>



