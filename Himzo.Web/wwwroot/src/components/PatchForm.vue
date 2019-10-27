<template>
  <div>
    <Header></Header>
    <PatchFormBody></PatchFormBody>
    <Footer></Footer>
  </div>
</template>

<script>
import Header from "./Header.vue";
import PatchFormBody from "./PatchFormBody.vue";
import Footer from "./Footer.vue";

export default {
  name: "Index",
  props: {},
  components: {
    Header,
    PatchFormBody,
    Footer
  }
};
</script>