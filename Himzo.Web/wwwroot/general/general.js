Vue.component("himzoheader", {
  template: `
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
              <a class="nav-link" href="index.html">{{ order }} </a>
            </li>
            <li class="nav-item">
              <a class="nav-link" href="aboutUs.html">{{ aboutUs }}</a>
            </li>
          </ul>
          <form class="form-inline mt-2 mt-md-0">
          
          <a
            class="btn btn-outline-success my-2 my-sm-0"
            type="submit"
            href="signin.html"
          >
            {{ logIn }}
          </a>
        </form>


        </div>
      </nav>
    </div>
  `,
  data() {
    return {
      titleHimzo: "Hímző",
      order: "Rendelés",
      aboutUs: "Rólunk",
      logIn: "Bejelentkezés"
    };
  }
});

Vue.component("himzofooter", {
  template: `
  <!-- Footer -->
<footer class="page-footer font-small special-color-dark pt-4">


<div class="container">
<p class="float-right row"><a href="">Vissza a tetejére</a></p>
</div>




  <!-- Footer Elements -->
  <div class="container logo">

    <!-- Social buttons -->

        <!-- E-mail -->
        <a >
            <a class="pop-me-over" data-toggle="popover" data-placement="bottom" 
              data-content="himzo@sch.bme.hu"
              ><i class="fas fa-envelope mx-3 fa-2x"></i></a> 
        </a>

        <!-- Cím -->
        <a >
            <a class="pop-me-over" data-toggle="popover" data-placement="top" 
              data-content="Schönherz Kollégium 819. szoba Írinyi József 42
              Budapest"
              ><i class="fas fa-home mx-3 fa-2x"></i></a> 
        </a>

        <!-- Facebook -->
        <a href="https://www.facebook.com/pulcsi.es.foltmekor/">
            <i class="fab fa-facebook-f mx-3 fa-2x"> </i>
        </a>

    <!-- Social buttons -->

  </div>
  <!-- Footer Elements -->

  <!-- Copyright -->
  <div class="footer-copyright text-center py-3">© Pulcsi és FoltMéKör</a>
  </div>
  <!-- Copyright -->

</footer>
<!-- Footer -->
   `
});

Vue.component("order", {
  props: ["order"],
  template: `
      <div class="order">
          <div class="jumbotron" >

            <div>
                <h1>{{ order.name }}</h1>
                <h1>{{ order.amount }} db {{ order.productType }}</h2>
            </div>

            <select name="sample" id="sample" class="fa">
                <option value="fas fa-cog ">&#xf013; Rendelés feldolgozás alatt</option>
                <option value="fas fa-clock ">&#xf017; Folyamatban</option>
                <option value="fas fa-check-circle ">&#xf058; Kész</option>
                <option value="fas fa-times-circle ">&#xf057; Rendelés elutasítva</option>
            </select>

            <div>
              <div class="form-group shadow-textarea">
                <textarea class="form-control z-depth-1" id="exampleFormControlTextarea6" rows="3" ></textarea>
              </div>
              <p class="lead">{{ order.time }}</p>
            </div>

            <a class="btn btn-lg btn-primary" href="/docs/4.3/components/navbar/" role="button">Rendelés adatai &raquo;</a>
            <a class="btn btn-lg btn-primary" href="/docs/4.3/components/navbar/" role="button">Mentés</a>


         </div>
        
      </div>
    `
});

Vue.component("userorder", {
  props: ["order"],
  template: `
    <div class="order">
        <div class="jumbotron" >
          <div class ="icon">
              <i v-bind:class="order.statusIcon"></i>
          </div>
          <div class="status">
            <h2>{{ order.amount }} db {{ order.productType }}</h2>
            <h1>{{ order.statusText }}</h1>
          </div>
          <div>
            <p class="lead">{{ order.message }}</p>
            <p class="lead">{{ order.time }}</p>
          </div>
          <a class="btn btn-lg btn-primary" href="/docs/4.3/components/navbar/" role="button">Rendelés adatai &raquo;</a>
       </div>
      
    </div>
  `
});

var app = new Vue({
  el: "#general",

  data() {
    return {
      selectedVariant: 0,
      username: "Önnönmagam",

      title: "Pulcsi és FoltMéKör",
      titleDescription:
        "Mi, a Pulcsi és FoltMékör, tevékenységünkkel próbáljuk elősegíteni, hogy a Schönherzes rendezvények rendezői, résztvevői és a körök tagjai egy több 10 év múlva is megmaradó emlékekkel gazdagodhassanak.",
      moreButton: "Tudj meg többet",
      patchTitle: "Foltok",
      patchDescription:
        "Foltot igy meg igy kell rendelni. Nem csak rendezvényekre készítjük őket, hanem egyéni megrendeléseket is fogadunk!",
      embroideredPatternTitle: "Hímzett minták",
      embroideredPatternDescription:
        "Hozott anyagokra tudunk neked hímeztetni, ez meg ez kell hozzá, tök jó lesz.",
      sweaterTitle: "VIK-es pulcsik",
      sweaterDescription:
        "Több féle színben elérhetőek a VIK-es pulóverek. Ha megtetszett valamelyik, a himzo.sch.bme.hu email címen kaphatsz több információt róla.",
      photo: "../images/picture.jpg",

      scrollBackToTop: "Vissza a  tetejére",

      job_description:
        "Mit csinál a kör, blabla. Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
      job_title: "Amivel foglalkozunk",
      history_description:
        "Kör története, Pellentesque elit ullamcorper dignissim cras. Faucibus turpis in eu mi bibendum neque egestas. Tellus molestie nunc non blandit massa. Ornare arcu dui vivamus arcu felis bibendum ut. Volutpat diam ut venenatis tellus in. ",
      history_title: "A kör története",
      how_to_join_description:
        "Csatlakozási lehetőség: Auctor elit sed vulputate mi. Ullamcorper eget nulla facilisi etiam dignissim diam quis enim. Dui ut ornare lectus sit. Lobortis feugiat vivamus at augue eget arcu dictum varius duis.",
      how_to_join_title: "Csatlakozási lehetőség",
      team_title: "Valami",
      team_description: "Még valami",
      editField: "",

      membersTitle: "Tagok",
      membersDescription: "Valami szép leírás rólunk",
      usernameTitle: "Név",
      emailTitle: "E-mail cím",
      adminTitle: "Admin",
      himzoMemberTitle: "Körtag",
      username: "Önnönmagam Én Vagykok",
      email: "email@cim.hu",
      adminOption: "admin",
      himzoMemberOption: "körtag",
      saveButton: "Mentés",
      searchButton: "Keresés",
      admins: [],
      himzoMembers: [],
      people: [
        { name: "Dörner Virág", email: "virag@dorner.hu", id: "elso" },
        { name: "Nagy Krisztina", email: "krisztina@nagy.hu", id: "masodik" },
        { name: "Demjén Klaudia", email: "klaudia@demjen.hu", id: "harmadik" },
        { name: "Sinkó Sára", email: "sara@sinko.hu", id: "negyedik" }
      ],

      patchFormTitle: "Folt rendelés",
      patchFormDescription:
        "Foltot így meg így tudsz rendelni, ezt meg ezt kell tudni róla.",
      patternFormTitle: "Minta hímeztetése",
      patternFormDescription:
        "Mintát hozott anyagra így meg amúgy tudsz hímeztetni.",

      chooseFile: "Válaszd ki a fájlt",
      pattern: "Minta",
      patternLocation: "Minta helye",
      size: "Méret (cm)",
      amount: "Mennyiség",
      deadline: "Határidő",
      fonts: "Mintában használt fontok",
      comment: "Megjegyzés",
      cancelButton: "Mégse",
      orderButton: "Megrendelem",

      username: "Önnönmagam",
      email: "E-mail cím",
      university: "Egyetem",
      newPassword: "Új jelszó",
      newPasswordAgain: "Új jelszó mégegyszer",
      oldPassword: "Régi jelszó",
      cancelButton: "Mégse",
      saveButton: "Adatok mentése",

      orders: [
        {
          id: 1,
          name: "Sinkó Sára",
          statusIcon: "fas fa-check-circle  fa-3x",
          amount: "51",
          productType: "folt",
          statusText: "Kész",
          message: "Jöhetsz érte.",
          time: "2025-03-03"
        },
        {
          id: 2,
          name: "Egy Másik Ember",
          statusIcon: "fas fa-clock  fa-3x",
          amount: "5",
          productType: "minta",
          statusText: "Folyamatban",
          message: "A mintád fele van kész",
          time: "2018-03-03"
        },
        {
          id: 3,
          name: "Gutai Auguszta Matild",
          statusIcon: "fas fa-times-circle  fa-3x",
          amount: "10",
          productType: "folt",
          statusText: "Rendelés elutasítva",
          message: "Jelenleg nem fogadunk rendeléseket.",
          time: "2019-10-13"
        },
        {
          id: 4,
          name: "Random Megrendelő",
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

  methods: {
    focusField(name) {
      this.editField = name;
    },
    blurField() {
      this.editField = "";
    },
    showField(name) {
      return this.editField == name;
    }
  }
});