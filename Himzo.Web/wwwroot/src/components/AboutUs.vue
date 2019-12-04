<template>
  <div>
    <Header></Header>
    <AboutUsBody></AboutUsBody>
    <Footer></Footer>
  </div>
</template>

<script>
import Header from "./Header.vue";
import AboutUsBody from "./AboutUsBody.vue";
import Footer from "./Footer.vue";

export default {
  name: "AboutUs",
  props: {},
  components: {
    Header,
    AboutUsBody,
    Footer
  }
};
</script>