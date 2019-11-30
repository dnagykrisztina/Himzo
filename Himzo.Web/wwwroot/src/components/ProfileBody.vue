<template>
<div>
  <div class="jumbotron">
    <div class="container">
      <h1 class="display-3 text-center">Profilom</h1>
    </div>
  </div>

  <body>
    <main role="main">
      <!-- Main jumbotron for a primary marketing message or call to action -->

      <div class="container jumbotron">
        <div class="d-flex justify-content-between">
          <div class="col-5 text-right h3 p-4">{{ username }}</div>
          <div class="col-5 text-left h3 p-4">{{username_}}</div>
        </div>
        <div class="d-flex justify-content-between">
          <div class="col-5 text-right h3 p-4">{{ email }}</div>
          <div class="col-5 text-left h3 p-4">{{email_}}</div>
        </div>
        <div class="d-flex justify-content-between">
          <div class="col-5 text-right h3 p-4">{{ university }}</div>
          <div class="col-5 text-left h3 p-4">{{university_}}</div>
        </div>
      </div>
    </main>
  </body>
</div>
</template>

 
 <script>
import axios from "axios";
export default {
  name: "ProfileBody",
  props: {},
  data() {
    return {
      username: "Név",
      username_: "Hahó",
      email: "E-mail cím",
      email_: "vmi",
      university: "Egyetem",
      university_: "BME"
    };
  },
  async mounted() {
    //Username
    try {
      const res = await axios.get("http://localhost:52140/api/User");
      this.username_ = res.data.userName;
      this.university_ = res.data.university;
      this.email_ = res.data.email;
    } catch (e) {
      console.log(e);
    }
  },
  methods: {
    postPost() {
      axios
        .push(`http://localhost:52140/api/User`, {
          /* size: this.inputSize,
          amount: this.inputAmount,
          deadline: this.inputDeadline,
          pattern: null,
          orderComment: this.inputComment,
          orderTime: this.orderTime,
          fonts: this.inputFonts,
          type: 0,
          patternPlace: this.inputPatternLocation*/
        })
        // .then(response => {})
        .catch(e => {
          this.errors.push(e);
        });
    }
  }
};
</script>

<style scoped>
</style>