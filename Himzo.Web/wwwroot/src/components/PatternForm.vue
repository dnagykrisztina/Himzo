<template>
  <div>
    <Header></Header>
    <PatternFormBody></PatternFormBody>
    <Footer></Footer>
  </div>
</template>

<script>
import Header from "./Header.vue";
import PatternFormBody from "./PatternFormBody.vue";
import Footer from "./Footer.vue";

export default {
  name: "Index",
  props: {},
  components: {
    Header,
    PatternFormBody,
    Footer
  }
};
</script>