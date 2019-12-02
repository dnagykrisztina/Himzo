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
import axios from "axios";

export default {
  name: "PatchForm",
  props: {},
  components: {
    Header,
    PatchFormBody,
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