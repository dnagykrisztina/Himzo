<template>
  <div>
    <Header></Header>
    <MembersBody></MembersBody>
    <Footer></Footer>
  </div>
</template>

<script>
import Header from "./Header.vue";
//import Title from "./Title.vue";
import MembersBody from "./MembersBody.vue";
import Footer from "./Footer.vue";
import axios from "axios";

export default {
  name: "Members",
  props: {},
  components: {
    Header,
    //Title,
    MembersBody,
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

    if ( role !== 'Admin') {
        this.$router.push("/");
    } 
  }
};
</script>