import Vue from "vue";
import App from "./App.vue";
import router from "./router";
import coverflow from "../lib";
import axios from "axios";
import VueAxios from "vue-axios";
window.axios = require("axios");
import Notifications from "vue-notification";


Vue.use(coverflow);
Vue.config.productionTip = false;
Vue.prototype.$axios = axios;
Vue.use(VueAxios, axios);
Vue.use(Notifications);

new Vue({
  render: h => h(App),
  router
}).$mount("#app");
