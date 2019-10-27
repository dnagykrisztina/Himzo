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
              <a class="nav-link" href="index.html#/aboutus">{{ aboutUs }}</a>
            </li>
            <li class="dropdown nav-item">
              <a href="#" class="dropbtn nav-link">{{ username }}</a>
              <div class="dropdown-content">
                <a href="index.html#/profile">{{ profile }}</a>
                <a href="index.html">{{ signOut }}</a>
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
      signIn: "Bejelentkezés"
    };
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
