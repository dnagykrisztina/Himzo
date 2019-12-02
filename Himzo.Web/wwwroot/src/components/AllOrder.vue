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
import axios from "axios";

export default {
  name: "AllOrder",
  props: {},
  components: {
    Header,
    AllOrderBody,
    Footer
  },
  async mounted() {
    var role;
    try {
        const response = await axios.get("http://localhost:52140/api/User");
        role = response.data.roles[0]
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

    if ( role !== 'Admin' && role !== 'Kortag') {
        this.$router.push("/");
    } 
  }

};
</script>