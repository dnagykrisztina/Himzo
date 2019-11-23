<template>
  <div>
    <Header></Header>
    <AllOrderBody></AllOrderBody>
    <Footer></Footer>
  </div>
</template>

<script>
import Header from "./Header.vue";
import AllOrderBody from "./AllOrderBody.vue";
import Footer from "./Footer.vue";

export default {
  name: "AllOrder",
  props: {},
  components: {
    Header,
    AllOrderBody,
    Footer
  }
};
</script>