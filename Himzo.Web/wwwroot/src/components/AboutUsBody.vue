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

            <div class="text-center">
                      <!--  <img src="../pic/team.jpg" class="rounded" alt="..." /> -->
            </div>
            <div class="text-center">
                <h2 class="featurette-heading">{{ team_title }}</h2>
                <p class="lead">{{ team_description }}</p>
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
  name: "AboutUsBody",
  props: {},
  data() {
    return {
      job_description:
        "Mit csinál a kör, blabla. Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
      job_title: "Amivel foglalkozunk",
      history_description:
        "Kör története, Pellentesque elit ullamcorper dignissim cras. Faucibus turpis in eu mi bibendum neque egestas. Tellus molestie nunc non blandit massa. Ornare arcu dui vivamus arcu felis bibendum ut. Volutpat diam ut venenatis tellus in. ",
      history_title: "A kör története",
      how_to_join_description:
        "Csatlakozási lehetőség: Auctor elit sed vulputate mi. Ullamcorper eget nulla facilisi etiam dignissim diam quis enim. Dui ut ornare lectus sit. Lobortis feugiat vivamus at augue eget arcu dictum varius duis.",
      how_to_join_title: "Csatlakozási lehetőség",
      team_title: "Tagok",
      team_description: "Valami szép leírás rólunk + csapatkép"
      
    };
  }
};
</script>

<style scoped>
</style>
