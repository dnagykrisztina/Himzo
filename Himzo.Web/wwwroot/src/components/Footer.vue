 <template>
  <!-- Footer -->

  <footer class="page-footer font-small special-color-dark pt-4">
    <div class="container">
      <p class="float-right row">
        <!--<a href="#">{{scrollBackToTop}}</a>-->
        <a href="#" id="scroll" style="display: none;">{{scrollBackToTop}}</a>
      </p>
    </div>

    <!-- Footer Elements -->
    <div class="container logo">
      <!-- Social buttons -->
      <!--tooltipes verzió
    <a>
        <a data-html="true"
           data-tooltip
           title="<b>Schönherz Kollégium</b><p>819. szoba</p><p> Irinyi József utca 42.</p>">
            <i class="fas fa-home mx-3 fa-2x"></i>
        </a>
      </a>-->
      <!-- E-mail -->
      <a>
        <a
          tabindex="0"
          class="footer_icon"
          role="button"
          data-placement="top"
          data-container="body"
          data-toggle="popover"
          data-trigger="focus"
          data-content="himzo@sch.bme.hu"
        >
          <i class="fas fa-envelope mx-3 fa-2x"></i>
        </a>
      </a>

      <!-- Cím -->
      <a>
        <a
          tabindex="0"
          class="footer_icon"
          role="button"
          data-html="true"
          data-placement="top"
          data-container="body"
          data-toggle="popover"
          data-trigger="focus"
          data-content="Schönherz Kollégium <br />819. szoba <br /> Irinyi József utca 42."
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
export default {
  name: "Footer",
  props: {},
  data() {
    return {
      scrollBackToTop: "Vissza a tetejére",
      copiright: "©Pulcsi és FoltMéKör",
      email: "himzo@sch.bme.hu"
    };
  }
};
</script>
