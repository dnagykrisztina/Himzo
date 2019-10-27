<template>
  <div>
    <Header></Header>
    <Title></Title>
    <MainPageBody></MainPageBody>
    <Footer></Footer>
  </div>
</template>

<script>
import Header from "./Header.vue";
import Title from "./Title.vue";
import MainPageBody from "./MainPageBody.vue";
import Footer from "./Footer.vue";

export default {
  name: "Index",
  props: {},
  components: {
    Header,
    Title,
    MainPageBody,
    Footer
  }
};
</script>