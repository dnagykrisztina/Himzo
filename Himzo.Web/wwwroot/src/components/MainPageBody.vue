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
          <a href="signin.html" class="btn btn-lg btn-block btn-outline-primary">Rendelés</a>
        </div>

        <div class="col-md-5">
          <!-- <coverflow :coverList="coverList" :coverWidth="100" :index="2" @change="handleChange"></coverflow> -->
          <svg
            class="bd-placeholder-img bd-placeholder-img-lg featurette-image img-fluid mx-auto"
            width="500"
            height="500"
            xmlns="http://www.w3.org/2000/svg"
            preserveAspectRatio="xMidYMid slice"
            focusable="false"
            role="img"
            aria-label="Placeholder: 500x500"
          >
            <title>Placeholder</title>
            <rect width="100%" height="100%" fill="#eee" />
          </svg>
        </div>
      </div>

      <hr class="featurette-divider" />

      <div class="row featurette">
        <div class="col-md-7 order-md-2">
          <h2 class="featurette-heading">{{ embroideredPatternTitle }}</h2>
          <p class="lead">{{ embroideredPatternDescription }}</p>
          <a href="signin.html" class="btn btn-lg btn-block btn-outline-primary">Rendelés</a>
        </div>
        <div class="col-md-5 order-md-1">
          <svg
            class="bd-placeholder-img bd-placeholder-img-lg featurette-image img-fluid mx-auto"
            width="500"
            height="500"
            xmlns="http://www.w3.org/2000/svg"
            preserveAspectRatio="xMidYMid slice"
            focusable="false"
            role="img"
            aria-label="Placeholder: 500x500"
          >
            <title>Placeholder</title>

            <rect width="100%" height="100%" fill="#eee" />
          </svg>
        </div>
      </div>

      <hr class="featurette-divider" />

      <div class="row featurette">
        <div class="col-md-7">
          <h2 class="featurette-heading">{{ sweaterTitle }}</h2>
          <p class="lead">{{ sweaterDescription }}</p>
        </div>
        <div class="col-md-5">
          <img
            v-bind:src="photo"
            class="bd-placeholder-img bd-placeholder-img-lg featurette-image img-fluid mx-auto"
            width="500"
            height="500"
            preserveAspectRatio="xMidYMid slice"
            focusable="false"
            role="img"
            aria-label="Placeholder: 500x500"
          />
        </div>
      </div>

      <div id="coverflow">
        <section data-cover="../images/picture.jpg"></section>
        <section
          data-cover="http://a3.mzstatic.com/us/r1000/102/Music/95/45/3f/mzi.xqnmexwi.170x170-75.jpg"
        ></section>
        <section
          data-cover="http://a4.mzstatic.com/us/r1000/014/Music/ea/6f/96/mzi.egqrvlca.170x170-75.jpg"
        ></section>
        <section
          data-cover="http://a3.mzstatic.com/us/r1000/096/Music/1a/86/1f/mzi.dcotnnwo.170x170-75.jpg"
        ></section>
        <section
          data-cover="http://a4.mzstatic.com/us/r1000/094/Music/a8/8b/db/mzi.dyzjtwow.170x170-75.jpg"
        ></section>
        <section
          data-cover="http://a1.mzstatic.com/us/r1000/024/Music/81/54/3b/mzi.cceuzwlz.170x170-75.jpg"
        ></section>
        <section
          data-cover="http://a5.mzstatic.com/us/r1000/103/Music/2f/08/9e/mzi.gxjxokia.170x170-75.jpg"
        ></section>
      </div>

      <hr class="featurette-divider" />

      <!-- /END THE FEATURETTES -->
    </div>
    <!-- /.container -->
  </main>
</body>
</template>

<script>
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

  components: {}
};
</script>

<style scoped>
</style>



