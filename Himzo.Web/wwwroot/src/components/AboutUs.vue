<template>
  <div>
    <Header></Header>
    <Title></Title>
    <AboutUsBody></AboutUsBody>
    <Footer></Footer>
  </div>
</template>

<script>
import Header from "./Header.vue";
import Title from "./Title.vue";
import AboutUsBody from "./AboutUsBody.vue";
import Footer from "./Footer.vue";

export default {
  name: "AboutUs",
  props: {},
  components: {
    Header,
    Title,
    AboutUsBody,
    Footer
  }
};
</script>