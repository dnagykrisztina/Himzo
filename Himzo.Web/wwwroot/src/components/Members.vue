<template>
  <div>
    <Header></Header>
    <Title></Title>
    <MembersBody></MembersBody>
    <Footer></Footer>
  </div>
</template>

<script>
import Header from "./Header.vue";
import Title from "./Title.vue";
import MembersBody from "./MembersBody.vue";
import Footer from "./Footer.vue";

export default {
  name: "MembersBody",
  props: {},
  components: {
    Header,
    Title,
    MembersBody,
    Footer
  }
};
</script>