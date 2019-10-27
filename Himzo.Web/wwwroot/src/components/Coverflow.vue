<template>
  <div class="demo">
    <coverflow :coverList="coverList" :width="400" :coverWidth="300" :index="2"></coverflow>
  </div>
</template>

<script>
import coverflow from "vue-coverflow";
export default {
  name: "Coverflow",
  data() {
    return {
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
      ]
    };
  },
  components: {
    coverflow
  },

  methods: {}
};
</script>

<style scoped>
.demo {
  width: 980px;
  margin: 0 auto;
}
</style>
