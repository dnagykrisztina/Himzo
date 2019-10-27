<template>
  <div>
    <Header></Header>
    <Title></Title>
    <ProfileBody></ProfileBody>
    <Footer></Footer>
  </div>
</template>

<script>
import Header from "./Header.vue";
import Title from "./Title.vue";
import ProfileBody from "./ProfileBody.vue";
import Footer from "./Footer.vue";

export default {
  name: "ProfileBody",
  props: {},
  components: {
    Header,
    Title,
    ProfileBody,
    Footer
  }
};
</script>