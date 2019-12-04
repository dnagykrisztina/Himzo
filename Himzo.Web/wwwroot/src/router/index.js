import Vue from "vue";
import Router from "vue-router";
import Index from "@/components/Index";
import AboutUs from "@/components/AboutUs";
import SignIn from "@/components/SignIn";
import Registration from "@/components/Registration";
import Profile from "@/components/Profile";
import PatchForm from "@/components/PatchForm";
import PatternForm from "@/components/PatternForm";
import AllOrder from "@/components/AllOrder";
import UserOrder from "@/components/UserOrder";
//import axios from "axios"
//import { ModalPlugin } from 'bootstrap-vue'

//Vue.use(ModalPlugin)
Vue.use(Router);

export default new Router({
  routes: [
    {
      path: "/",
      name: "Index",
      component: Index
    },
    {
      path: "/aboutus",
      name: "AboutUs",
      component: AboutUs
    },
    {
      path: "/signin",
      name: "SignIn",
      component: SignIn
    },
    {
      path: "/registration",
      name: "Registration",
      component: Registration
    },
    {
      path: "/patchform",
      name: "PatchForm",
      component: PatchForm
    },
    {
      path: "/patternform",
      name: "PatternForm",
      component: PatternForm
    },
    {
      path: "/profile",
      name: "Profile",
      component: Profile
    },
    {
      path: "/allorder",
      name: "AllOrder",
      component: AllOrder
    },
    {
      path: "/userorder",
      name: "UserOrder",
      component: UserOrder
    }
  ]
});
