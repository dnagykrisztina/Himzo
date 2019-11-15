<template>
  <div class="order">
    <div class="jumbotron">
      <div>
        <h1>{{ order.orderId }}</h1>
        <h2 v-if="order.type === 1">{{ order.amount }} db hímzés</h2>
        <h2 v-else-if="order.type === 0">{{ order.amount }} db folt</h2>
      </div>

      <select name="sample" id="sample" class="fa">
        <option value="fas fa-cog ">&#xf013; Rendelés feldolgozás alatt</option>
        <option value="fas fa-clock ">&#xf017; Folyamatban</option>
        <option value="fas fa-check-circle ">&#xf058; Kész</option>
        <option value="fas fa-times-circle ">&#xf057; Rendelés elutasítva</option>
      </select>

      <div>
        <div class="form-group shadow-textarea">
          <textarea
            class="form-control z-depth-1"
            id="exampleFormControlTextarea6"
            rows="3"
            v-model="order.commentContent"
            placeholder="Írj kommentet!"
          ></textarea>
          <p>Message is: {{ order.commentContent }}</p>
        </div>
        <p class="lead">{{ order.orderTime }}</p>
      </div>

      <!--<a
        class="btn btn-lg btn-primary"
        href="/docs/4.3/components/navbar/"
        role="button"
      >Rendelés adatai &raquo;</a>-->
      <div>
          <b-button id="show-btn" @click="showModal">Rendelés adatai &raquo;</b-button>

          <b-modal ref="my-modal" centered hide-backdrop content-class="shadow" hide-footer title="Rendelés adatai">

              <div class="d-block ">
                  <div class="container marketing">
                      <div class="row featurette">
                          <div class="col-md-12">
                              <h2 class="featurette-heading" >Mézga Géza</h2>
                              <p class="lead">mezga.geza@gmail.com</p>
                          </div>
                      </div>
                  </div>
                  <table class="table">
                      <tr>
                          <th scope="row">Méret:</th>
                          <td>00x00</td>
                      </tr>
                      <tr>
                          <th scope="row">Mennyiség:</th>
                          <td>{{ order.amount }}</td>
                      </tr>
                      <tr>
                          <th scope="row">Használt fontok:</th>
                          <td>valami font fájl</td>
                      </tr>
                      <tr>
                          <th scope="row">Határidő</th>
                          <td>0000.00.00</td>
                      </tr>
                      <tr>
                          <th scope="row">Megjegyzés:</th>
                          <td>Uuuu de sokat irt ide valaki, biztos nagyon fontos ez a megrendeles, most mi fog törtennim, csunya lesz a tablazat? remelem nem. huhaa de izgi, mindjart kiderül.</td>
                      </tr>
                      <tr>
                          <th scope="row">Rendelés ideje:</th>
                          <td>0000.00.00</td>
                      </tr>
                  </table>
              </div>
          </b-modal>
      </div>
      <a class="btn btn-lg btn-primary" href="/docs/4.3/components/navbar/" role="button">Mentés</a>
    </div>
  </div>
</template>

<script>
import { BModal, VBModal } from 'bootstrap-vue'
export default {
    name: "order",
    props: ["order"],
    methods: {
        showModal() {
            this.$refs['my-modal'].show()
        }
    },
    components: {
        'b-modal': BModal
    },
    directives: {
        // Note that Vue automatically prefixes directive names with `v-`
        'b-modal': VBModal
    }
};
</script>
