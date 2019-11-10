<template>
<body>
  <main role="main" class="container">
    <order v-for="order in orders" v-bind:key="order.id" v-bind:order="order"></order>

    <hr class="featurette-divider" />
  </main>
</body>
</template>

 
 <script>
import order from "./_order.vue";
import axios from "axios";

export default {
  name: "AllOrderBody",
  props: {},
  components: {
    order
  },
  data() {
    return {
      orders: []
    };
  },
  async mounted() {
    try {
      const res = await axios.get(
        "http://localhost:52140/api/Orders/?all=true"
      );
      this.orders = res.data;
    } catch (e) {
      console.log(e);
    }
  }
};
</script>
	
