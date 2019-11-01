<template>
<body>
  <main role="main">
    <div class="container marketing">
      <!-- START THE FEATURETTES -->

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

export default {
  name: "MainPageBody",
  props: {},
  data() {
    return {
      patchTitle: "Foltok",
      patchDescription:
        "Foltot igy meg igy kell rendelni. Nem csak rendezvényekre készítjük őket, hanem egyéni megrendeléseket is fogadunk!",
      embroideredPatternTitle: "Hímzett minták",
      embroideredPatternDescription:
        "Hozott anyagokra tudunk neked hímeztetni, ez meg ez kell hozzá, tök jó lesz.",
      sweaterTitle: "VIK-es pulcsik",
      sweaterDescription:
        "Több féle színben elérhetőek a VIK-es pulóverek. Ha megtetszett valamelyik, a himzo.sch.bme.hu email címen kaphatsz több információt róla.",
      photo: "../images/picture.jpg"
    };
  },

  mounted: function() {
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
  },

  components: {
    Coverflow
  }
};
</script>

<style scoped>
</style>



