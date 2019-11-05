<template>
<body>
  <main role="main">
    <!-- Main jumbotron for a primary marketing message or call to action -->
    <div class="jumbotron">
      <div class="container">
        <h1 class="display-3">{{ title }}</h1>

        <p>{{ titleDescription }}</p>
        <p>{{ valami }}</p>
        <p>{{ valami2 }}</p>
        <p>{{ valami3 }}</p>
        <p>{{ valami4 }}</p>
      </div>
    </div>
  </main>

  <main role="main" class="container">
    <p>{{ valami }}</p>
    <p>{{ valami2 }}</p>
    <p>{{ valami3 }}</p>
    <p>{{ valami4 }}</p>
    <hr class="featurette-divider" />
    <!--<userorder v-for="order in orders" v-bind:key="order.id" v-bind:order="order"></userorder> -->
    <userorder v-for="order in orders2" v-bind:key="order.id" v-bind:order="order"></userorder>

    <hr class="featurette-divider" />
  </main>
</body>
</template>

 
 <script>
import userorder from "./_userorder.vue";
import axios from "axios";
export default {
  name: "ProfileBody",
  props: {},
  components: {
    userorder
  },
  data() {
    return {
      title: "Rendeléseim",
      titleDescription: "Így állnak a megrendeléseim",
      allorders: [],
      valami: null,
      valami2: null,
      valami3: null,
      valami4: null,

      orders2: [
        {
          id: 1,
          statusIcon: "fas fa-check-circle  fa-3x",
          amount: "51",
          productType: "folt",
          statusText: "Kész",
          message: "Jöhetsz érte.",
          time: "2025-03-03"
        },
        {
          id: 2,
          statusIcon: "fas fa-clock  fa-3x",
          amount: "5",
          productType: "minta",
          statusText: "Folyamatban",
          message: "A mintád fele van kész",
          time: "2018-03-03"
        },
        {
          id: 3,
          statusIcon: "fas fa-times-circle  fa-3x",
          amount: "10",
          productType: "folt",
          statusText: "Rendelés elutasítva",
          message: "Jelenleg nem fogadunk rendeléseket.",
          time: "2019-10-13"
        },
        {
          id: 4,
          statusIcon: "fas fa-cog  fa-3x",
          amount: "450",
          productType: "folt",
          statusText: "Rendelés feldolgozás alatt",
          message: "",
          time: ""
        }
      ]
    };
  },
  /*async mounted() {
    try {
      const res = await axios.get("http://localhost:52140/api/Orders");
      this.allorders = res.data;
      this.valami = res.data[0].OrderComment;
      this.valami2 = res.data[1].amount;
      const res2 = await axios.get(
        "http://localhost:52140/api/Contents?path=title"
      );
      this.valami3 = res2.data[0].title;
      this.valami4 = res2.data[1].title;
    } catch (e) {
      console.log(e);
    }
  }*/
  async mounted() {
    try {
      const res = await axios.get("http://localhost:52140/api/Order");
      this.valami = res.data[0].amount;
      this.valami2 = res.data[0].orderComment;
      /*const ress = await axios.get("http://localhost:52140/api/Orders");
      this.valami3 = ress.data[0].orderComment;
      this.valami4 = ress.data[1].size;*/
    } catch (e) {
      console.log(e);
    }
  }
};
</script>

<style scoped>
</style>