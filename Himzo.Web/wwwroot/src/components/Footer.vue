 <template>
  <!-- Footer -->

  <footer class="page-footer font-small special-color-dark pt-4">
    <div class="container">
      <p class="float-right row">
        <a href>{{scrollBackToTop}}</a>
      </p>
    </div>

    <!-- Footer Elements -->
    <div class="container logo">
      <!-- Social buttons -->

      <!-- E-mail -->
      <a>
        <a data-tooltip title="himzo@sch.bme.hu">
          <i class="fas fa-envelope mx-3 fa-2x"></i>
        </a>
      </a>

      <!-- Cím -->
      <a>
        <a
          data-html="true"
          data-tooltip
          title="<b>Schönherz Kollégium</b><p>819. szoba</p><p> Irinyi József utca 42.</p>"
        >
          <i class="fas fa-home mx-3 fa-2x"></i>
        </a>
      </a>

      <!-- Facebook -->
      <a href="https://www.facebook.com/pulcsi.es.foltmekor/">
        <i class="fab fa-facebook-f mx-3 fa-2x"></i>
      </a>

      <!-- Social buttons -->
    </div>
    <!-- Footer Elements -->

    <!-- Copyright -->
    <div class="footer-copyright text-center py-3">{{copiright}}</div>
    <!-- Copyright -->
  </footer>
  <!-- Footer -->
</template>

<script>
import axios from "axios";
export default {
  name: "Footer",
  props: {},
  data() {
    return {
      scrollBackToTop: null,
      copiright: null,
      email: null
    };
  },
  async mounted() {
    try {
      const res = await axios.get(
        "http://localhost:52140/api/Contents?path=footer"
      );
      this.scrollBackToTop = res.data[0].title;
      this.copiright = res.data[1].title;
      this.emial = res.data[2].title;
      /* var i;
      this.allcontents = res.data;
      for (i = 0; i < this.allcontents.length; i++) {
        this.contents[i].title = this.allcontents[i].title;
        this.contents[i].description = this.allcontents[i].contentString;*/
      // }
    } catch (e) {
      console.log(e);
    }
  }
};
</script>
