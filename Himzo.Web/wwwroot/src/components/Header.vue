<template>
  <div>
    <div>
      <nav class="navbar navbar-expand-md navbar-dark fixed-top bg-dark">
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
            <li class="nav-item">
              <a class="nav-link" href="index.html">{{ order }}</a>
            </li>
            <li class="nav-item">
              <a class="nav-link" href="index.html#/userorder">{{ myOrders }}</a>
            </li>
            <li class="nav-item">
              <a class="nav-link" href="index.html#/allorder">{{ allOrder }}</a>
            </li>
            <li class="nav-item">
              <a class="nav-link" href="index.html#/aboutus">{{ aboutUs }}</a>
            </li>
            <li class="dropdown nav-item">
              <a href="#" class="dropbtn nav-link">{{ username }}</a>
              <div class="dropdown-content">
                <a href="index.html#/profile">{{ profile }}</a>
                <a onclick="logout()">{{ signOut }}</a>
              </div>
            </li>
            <a class="nav-link" href="index.html#/signin">{{ signIn }}</a>
            <li class="nav-item"></li>
          </ul>
        </div>
      </nav>
    </div>
  </div>
</template>

<script>
export default {
  name: "Header",
  props: {},
  data() {
    return {
      titleHimzo: "Hímző",
      order: "Rendelés",
      myOrders: "Rendeléseim",
      aboutUs: "Rólunk",
      username: "Önnönmagam",
      profile: "Profilom",
      signOut: "Kilépés",
      signIn: "Bejelentkezés",
      allOrder: "Rendelések"
    };
  } /*,
  async mounted() {
    //Username
    try {
      const res = await axios.get(
        "http://localhost:52140/api/Contents?path=header"
      );
      this.titleHimzo = res.data[0].title;
      this.order = res.data[1].title;
      this.myOrders = res.data[2].title;
      this.aboutUs = res.data[3].title;
      this.profile = res.data[4].title;
      this.signOut = res.data[5].title;
      this.signIn = res.data[6].title;
      this.allOrder = res.data[7].title;
    } catch (e) {
      console.log(e);
    }
  }*/
};
</script>

<style scoped>
/*lenyíló menü*/

li a,
.dropbtn {
  display: inline-block;
  color: white;
  text-align: center;

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
}

.dropdown-content a {
  color: black;
  padding: 12px 16px;
  text-decoration: none;
  display: block;
  text-align: left;
}

.dropdown-content a:hover {
  background-color: #f1f1f1;
}

.dropdown:hover .dropdown-content {
  display: block;
}
</style>
