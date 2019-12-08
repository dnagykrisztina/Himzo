<template>
  <div class="order">
    <div class="jumbotron pl-8">
      <div class="row pl-4">
        <div class="col-lg-9 col-sm-12">
          <div class="row">
            <div class="col">
              <h2>{{ order.userName }}</h2>
            </div>
          </div>
          <div class="row pb-4">
            <div class="col">
              <h2 v-if="order.type === 1">{{ order.amount }} db hímzés</h2>
              <h2 v-else-if="order.type === 0">{{ order.amount }} db folt</h2>
            </div>
          </div>
          <div class="row">
            <div class="col-1 text-center">
              <h2 v-show="stateIcon == 0" class="fas fa-cog"></h2>
              <h2 v-show="stateIcon == 1" class="fas fa-clock"></h2>
              <h2 v-show="stateIcon == 2" class="fas fa-check-circle"></h2>
              <h2 v-show="stateIcon == 3" class="fas fa-times-circle"></h2>
            </div>
            <div class="col">
              <select
                v-model="order.orderState"
                class="mb-3 form-control"
                @change="updateState()"
                style="cursor: pointer;"
              >
                <option value="0">Rendelés feldolgozás alatt</option>
                <option value="1">Folyamatban</option>
                <option value="2">Kész</option>
                <option value="3">Rendelés elutasítva</option>
              </select>
            </div>
          </div>
          <div class="row text-right">
            <div class="col-1"></div>
            <div class="col-11">
              <textarea
                class="form-control"
                style="cursor: pointer;"
                id="inputComment"
                rows="3"
                for="inputComment"
                v-model="order.commentContent"
                placeholder="Írj kommentet!"
                @change="updateComment"
              ></textarea>
            </div>
          </div>
          <div class="row text-right">
            <div class="col">{{ order.orderTime | format}}</div>
          </div>
        </div>
        <div class="col-lg-3 col-sm-12 text-center pl-0">
          <div class="row">
            <div class="col">
              <b-button
                class="btn btn-lg btn-outline-primary"
                typeof=" button"
                id="show-btn"
                @click="showModal"
              >Rendelés adatai &raquo;</b-button>

              <b-modal
                ref="my-modal"
                centered
                hide-backdrop
                content-class="shadow"
                hide-footer
                title="Rendelés adatai"
              >
                <div class="d-block">
                  <div class="container marketing">
                    <div class="row featurette headContainer">
                      <div class="col-md-4">
                        <img
                          class="imageorder"
                          :src="'http://localhost:52140/api/Orders/' + order.orderId + '/image'"
                        />
                      </div>
                      <div class="col-md-8 modal-head">
                        <h2 class="featurette-heading">{{ order.userName }}</h2>
                        <p class="lead">{{ order.userEmail }}</p>
                      </div>
                    </div>
                  </div>

                  <table class="table">
                    <tr>
                      <th scope="row">Méret:</th>
                      <td>{{ order.size }}</td>
                    </tr>
                    <tr>
                      <th scope="row">Mennyiség:</th>
                      <td>{{ order.amount }}</td>
                    </tr>
                    <tr>
                      <th scope="row">Használt betűtípusok:</th>
                      <td>{{ order.fonts }}</td>
                    </tr>
                    <tr>
                      <th scope="row">Határidő:</th>
                      <td>{{ order.deadline | format }}</td>
                    </tr>
                    <tr>
                      <th scope="row">Megjegyzés:</th>
                      <td>{{ order.orderComment }}</td>
                    </tr>
                    <tr v-if="order.type === 1">
                      <th scope="row">Minta helye:</th>
                      <td>{{ order.patternPlace }}</td>
                    </tr>
                    <tr>
                      <th scope="row">Rendelés ideje:</th>
                      <td>{{ order.orderTime | format }}</td>
                    </tr>
                  </table>
                </div>
              </b-modal>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import axios from "axios";
import { BModal, VBModal } from "bootstrap-vue";
export default {
  name: "order",
  props: ["order"],
  data() {
    return {
      stateIcon: this.order.orderState
      //picture: 'http://localhost:52140/api/Orders/'.concat(this.order.orderId)
    };
  },
  filters: {
    format: function(str) {
      return str.substring(0, 10);
    }
  },
  methods: {
    showModal() {
      this.$refs["my-modal"].show();
    },
    updateComment() {
      axios
        .patch(
          "http://localhost:52140/api/Orders/".concat(this.order.orderId),
          [
            {
              op: "replace",
              path: "/CommentContent",
              value: this.order.commentContent
            }
          ]
        )
        .then(
          //res => console.log(res.data),
          console.log(this.order.commentContent)
        )
        .catch(e => {
          this.errors.push(e);
        });
    },
    updateState() {
      axios
        .patch(
          "http://localhost:52140/api/Orders/".concat(this.order.orderId),
          [
            {
              op: "replace",
              path: "/OrderState",
              value: this.order.orderState
            }
          ]
        )
        .then(
          //res => console.log(res.data),
          console.log(this.stateIcon),
          (this.stateIcon = this.order.orderState),
          console.log(this.order.orderState),
          console.log(this.stateIcon)
        )
        .catch(e => {
          this.errors.push(e);
        });
    }
  },
  components: {
    "b-modal": BModal
  },
  directives: {
    // Note that Vue automatically prefixes directive names with `v-`
    "b-modal": VBModal
  }
};
</script>

<style>
.imageorder {
  border: 1px solid #ddd;
  border-radius: 4px;
  padding: 5px;
  width: 150px;
  margin-bottom: 5%;
  vertical-align: central;
}
.modal-head {
  vertical-align: bottom;
  text-align: center;
  padding-top: 10%;
}
</style>
