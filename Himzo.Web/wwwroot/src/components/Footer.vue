 <template>
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
            <a  data-tooltip title="himzo@sch.bme.hu"
            ><i class="fas fa-envelope mx-3 fa-2x"></i></a> 
              
        </a>

        <!-- Cím -->
        <a >
            <a data-html="true" data-tooltip title="<b>Schönherz Kollégium</b> \n 819. szoba \n Irinyi József utca 42."
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
  <div class="footer-copyright text-center py-3">© Pulcsi és FoltMéKör
  </div>
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
      scrollBackToTop: "Vissza a  tetejére"
    };
  }
};
</script>
