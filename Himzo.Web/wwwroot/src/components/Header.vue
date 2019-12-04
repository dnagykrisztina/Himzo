<template>
  <div>
    <div>
      <nav class="navbar navbar-expand-md fixed-top navbar-dark">
        <a class="navbar-brand" href="index.html">{{ titleHimzo }}</a>
        <button
          class="navbar-toggler"
          type="button"
          data-toggle="collapse"
          data-target="#navbarCollapse"
          aria-controls="navbarCollapse"
          aria-expanded="false"
          aria-label="Toggle navigation"
        >
          <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarCollapse">
          <ul class="navbar-nav mr-auto">
            <li v-if="this.currentRoute === 'Index'" class="nav-item">
              <a class="nav-link" href="#" id="scrolldown">{{ order }}</a>
            </li>
            <li v-if="this.currentRoute !== 'Index'" class="nav-item">
              <a class="nav-link" @click="index">{{ order }}</a>
            </li>
            <li class="nav-item">
              <a class="nav-link" @click="aboutus">{{ aboutUs }}</a>
            </li>
            <li class="nav-item" v-if="role=== 'Admin' || role === 'Kortag' || role === 'User'">
              <a class="nav-link" @click="userorder">{{ myOrders }}</a>
            </li>
            <li class="nav-item" v-if="role=== 'Admin' || role === 'Kortag'">
              <a class="nav-link" @click="allorder">{{ allOrder }}</a>
            </li>
            <li class="nav-item" v-if="role=== 'Admin'">
              <a class="nav-link" @click="members">{{ memberss }}</a>
            </li>
          </ul>
          <!--<a class="nav-link btn btn-success" @click="signin">{{ signIn }}</a>-->
          <a
            class="dropdown nav-item my-2 my-sm-0"
            v-if="role=== 'Admin' || role === 'Kortag' || role === 'User'"
          >
            <a href="#" class="dropbtn nav-link">{{ username }}</a>
            <div class="dropdown-content">
              <a @click="profileroute">{{ profile }}</a>
              <a onclick="logout()">{{ signOut }}</a>
            </div>
          </a>
          <button
            class="btn btn-outline-success my-2 my-sm-0"
            @click="signin"
            v-if="role!== 'Admin' && role !== 'Kortag' && role !== 'User'"
          >{{ signIn }}</button>
        </div>
      </nav>
    </div>
  </div>
</template>

<script>
import axios from "axios";
export default {
  name: "Header",
  data() {
    return {
      currentRoute: null,
      titleHimzo: "Hímző",
      order: "Rendelés",
      myOrders: "Rendeléseim",
      aboutUs: "Rólunk",
      username: "",
      profile: "Profilom",
      signOut: "Kilépés",
      signIn: "Bejelentkezés",
      allOrder: "Rendelések",
      memberss: "Körtagok",
      role: null
    };
  },
  methods: {
    index() {
      this.$router.push("/");
    },
    aboutus() {
      this.$router.push("/aboutus");
    },
    profileroute() {
      console.log("valami");
      this.$router.push("/profile");
    },
    signin() {
      console.log("valami");
      this.$router.push("/signin");
    },
    userorder() {
      console.log("valami");
      this.$router.push("/userorder");
    },
    allorder() {
      console.log(location);
      this.$router.push("/allorder");
    }
  },

  async mounted() {
    try {
      this.currentRoute = this.$route.name;
    } catch (e) {
      console.log(e);
    }
    //Username
    try {
      const res = await axios.get("http://localhost:52140/api/User");
      this.username = res.data.userName;
      this.role = res.data.roles[0];
    } catch (e) {
      console.log(e);
    }
  }
};
</script>

<style scoped>
/*lenyíló menü*/

li a,
.dropbtn {
  display: inline-block;
  color: white;
  text-align: center;
  cursor: pointer;
  text-decoration: none;
}

li.dropdown {
  display: inline-block;
}

.dropdown-content {
  display: none;
  position: absolute;
  background-color: #f9f9f9;
  min-width: 160px;
  box-shadow: 0px 8px 16px 0px rgba(0, 0, 0, 0.2);
  z-index: 1;
  text-align: center;
}

.dropdown-content a {
  text-align: center;
  color: lightgrey;
  padding: 12px 16px;
  text-decoration: none;
  display: block;
  cursor: pointer;
}

.dropdown-content a:hover {
  color: whitesmoke;
  background-color:#445c3c;
}

.dropdown:hover .dropdown-content {
  display: block;
}
</style>
