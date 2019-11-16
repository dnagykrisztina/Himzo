<template>
    <div>
        <div class="jumbotron">
            <div class="container">
                <h1 class="display-3">{{ title }}</h1>

                <p>{{ titleDescription }}</p>
            </div>
        </div>
        <body>
            <main role="main">
                <!-- Main jumbotron for a primary marketing message or call to action -->

            </main>

            <main role="main" class="container">
                <hr class="featurette-divider" />
                <!--<userorder v-for="order in orders" v-bind:key="order.id" v-bind:order="order"></userorder> -->
                <userorder v-for="order in orders" v-bind:key="order.id" v-bind:order="order"></userorder>

                <hr class="featurette-divider" />
            </main>
        </body>
    </div>
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
      orders: [],

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

  async mounted() {
    try {
      const res = await axios.get(
        "http://localhost:52140/api/Orders/?all=true" //ide /userid kell!!
      );
      this.orders = res.data;
    } catch (e) {
      console.log(e);
    }
  }
};
</script>

<style scoped>
</style>