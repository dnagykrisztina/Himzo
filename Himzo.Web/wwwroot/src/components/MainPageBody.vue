<template>
<body>
  <main role="main">
    <div class="container marketing">
      <!-- START THE FEATURETTES -->
      <p>{{info}}</p>

      <ul>
        <li v-for="todo in todos" :key="todo.contentId">{{todo.title}} {{todo.contentString}}</li>
      </ul>

      <hr class="featurette-divider" />

      <div class="row featurette">
        <div class="col-md-7">
          <h2 class="featurette-heading">{{ patchTitle }}</h2>
          <p class="lead">{{ patchDescription }}</p>
          <a href="index.html#/patchform" class="btn btn-lg btn-block btn-outline-primary">Rendelés</a>
          <div>halika</div>
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
      patchTitle: null,
      info: null,
      patchTitles: [],
      todos: [],
      patchDescription: null,
      embroideredPatternTitle: null,
      embroideredPatternDescription: null,
      sweaterTitle: null,
      sweaterDescription: null,
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
      this.todos = res.data;
    } catch (e) {
      console.log(e);
    }
  },
  components: {
    Coverflow
  }
};
</script>

<style scoped>
</style>



