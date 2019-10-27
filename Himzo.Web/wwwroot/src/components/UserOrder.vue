<template>
  <div>
    <Header></Header>
    <UserOrderBody></UserOrderBody>
    <Footer></Footer>
  </div>
</template>

<script>
import Header from "./Header.vue";
import UserOrderBody from "./UserOrderBody.vue";
import Footer from "./Footer.vue";

export default {
  name: "Index",
  props: {},
  components: {
    Header,
    UserOrderBody,
    Footer
  }
};
</script>