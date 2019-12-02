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
import axios from "axios";

export default {
  name: "Index",
  props: {},
  components: {
    Header,
    UserOrderBody,
    Footer
  },
  async mounted() {
    try {
        const response = await axios.get("http://localhost:52140/api/User");
        if (response.status === 200) {
            this.auth = true;
        } else {
            this.auth = false;
    }
    } catch (e) {
        console.log(e);
    }

    if (!this.auth) {
        this.$router.push("/");
    }
  }
};
</script>