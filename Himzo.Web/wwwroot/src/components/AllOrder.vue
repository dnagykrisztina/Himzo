<template>
  <div>
    <Header></Header>
    <Title></Title>
    <AllOrderBody></AllOrderBody>
    <Footer></Footer>
  </div>
</template>

<script>
import Header from "./Header.vue";
import Title from "./Title.vue";
import AllOrderBody from "./AllOrderBody.vue";
import Footer from "./Footer.vue";

export default {
  name: "AllOrder",
  props: {},
  components: {
    Header,
    Title,
    AllOrderBody,
    Footer
  }
};
</script>