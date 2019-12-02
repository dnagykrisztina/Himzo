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
import axios from "axios";

export default {
  name: "Index",
  props: {},
  components: {
    Header,
    PatternFormBody,
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