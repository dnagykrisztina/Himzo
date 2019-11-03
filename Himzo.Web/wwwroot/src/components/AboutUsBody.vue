<template>
<body>
  <main role="main">
    <div class="container marketing">
      <!-- START THE FEATURETTES -->

      <div class="row featurette">
        <div class="col-md-5">
          <h2 class="featurette-heading">{{ job_title }}</h2>
        </div>
        <div class="col-md-7">
          <p class="lead">{{ job_description }}</p>
        </div>
      </div>

      <hr class="featurette-divider" />

      <div class="row featurette">
        <div class="col-md-7">
          <p class="lead">{{ history_description }}</p>
        </div>
        <div class="col-md-5">
          <h2 class="featurette-heading">{{ history_title }}</h2>
        </div>
      </div>

      <hr class="featurette-divider" />

      <div class="row featurette">
        <div class="col-md-5">
          <h2 class="featurette-heading">{{ how_to_join_title }}</h2>
        </div>
        <div class="col-md-7">
          <p class="lead">{{ how_to_join_description }}</p>
        </div>
      </div>

      <hr class="featurette-divider" />

      <div class="row featurette">
        <div class="col-md-7">
          <p class="lead">{{ team_description }}</p>
        </div>
        <div class="col-md-5">
          <h2 class="featurette-heading">{{ team_title }}</h2>
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
import axios from "axios";
export default {
  name: "AboutUsBody",
  props: {},
  data() {
    return {
      job_description: null,
      job_title: null,
      history_description: null,
      history_title: null,
      how_to_join_description: null,
      how_to_join_title: null,
      team_title: null,
      team_description: null
    };
  },
  async mounted() {
    try {
      const res = await axios.get(
        "http://localhost:52140/api/Contents?path=aboutus"
      );
      this.job_title = res.data[0].title;
      this.job_description = res.data[0].contentString;
      this.history_title = res.data[1].title;
      this.history_description = res.data[1].contentString;
      this.how_to_join_title = res.data[2].title;
      this.how_to_join_description = res.data[2].contentString;
      this.team_title = res.data[3].title;
      this.team_description = res.data[3].contentString;
      /* var i;
      this.allcontents = res.data;
      for (i = 0; i < this.allcontents.length; i++) {
        this.contents[i].title = this.allcontents[i].title;
        this.contents[i].description = this.allcontents[i].contentString;*/
      // }
    } catch (e) {
      console.log(e);
    }
  }
};
</script>

<style scoped>
</style>
