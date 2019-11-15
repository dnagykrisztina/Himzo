<template>
    <div class="order">
        <div class="jumbotron">
            <div class="fa">
                <i v-bind:class="order.statusIcon"></i>
                <i v-if="order.orderState === 0" value="fas fa-cog">&#xf013;</i>
                <i v-else-if="order.orderState === 1" value="fas fa-clock ">&#xf017;</i>
                <i v-else-if="order.orderState === 2" value="fas fa-check-circle ">&#xf058;</i>
                <i v-else-if="order.orderState === 3" value="fas fa-times-circle ">&#xf057;</i>
            </div>
            <div class="status">
                <h1>{{ order.orderId }}</h1>
                <h2 v-if="order.type === 1">{{ order.amount }} db hímzés</h2>
                <h2 v-else-if="order.type === 0">{{ order.amount }} db folt</h2>
                <h2 v-if="order.orderstate === 0">Rendelés feldolgozás alatt</h2>
                <h2 v-else-if="order.orderstate === 1">Folyamatban</h2>
                <h2 v-else-if="order.orderstate === 2">Kész</h2>
                <h2 v-if="order.orderstate === 3">Rendelés elutasítva</h2>
            </div>
            <div>
                <p class="lead">{{ order.commentContent }}</p>
                <p class="lead">{{ order.commentUpdateTime }}</p>
            </div>
            <!--<a
              class="btn btn-lg btn-primary"
              href="/docs/4.3/components/navbar/"
              role="button"
            >Rendelés adatai &raquo;</a>-->
            <div>
                <b-button id="show-btn" @click="showModal">Rendelés adatai &raquo;</b-button>

                <b-modal  ref="my-modal" centered hide-backdrop content-class="shadow" hide-footer title="Rendelés adatai">

                        <div class="d-block ">
                            <!--<div class="container marketing">
                                <div class="row featurette">
                                    <div class="col-md-12">
                                        <h2 class="featurette-heading" v-if="order.type === 1">Hímzés</h2>
                                        <h2 class="featurette-heading" v-else-if="order.type === 0">Folt</h2>
                                    </div>
                                </div>
                            </div>-->
                            <table class="table">
                                <tr class="table-borderless">
                                    <th scope="row">Méret:</th>
                                    <td>22x12</td>
                                </tr>
                                <tr>
                                    <th scope="row">Mennyiség:</th>
                                    <td>{{ order.amount }}</td>
                                </tr>
                                <tr>
                                    <th scope="row">Használt fontok:</th>
                                    <td>Ide is fájl kéne? vagy link?</td>
                                </tr>
                                <tr>
                                    <th scope="row">Határidő</th>
                                    <td>2019.12.24.</td>
                                </tr>
                                <tr>
                                    <th scope="row">Megjegyzés:</th>
                                    <td>Uuuu de sokat irt ide valaki, biztos nagyon fontos ez a megrendeles, most mi fog törtennim, csunya lesz a tablazat? remelem nem. huhaa de izgi, mindjart kiderül.</td>
                                </tr>
                                <tr>
                                    <th scope="row">Rendelés ideje:</th>
                                    <td>2019.10.22.</td>
                                </tr>
                            </table>
                        </div>
                </b-modal>
            </div>
        </div>
    </div>
</template>

<script>
//import axios from "axios";
import { BModal, VBModal } from 'bootstrap-vue'
    export default {
        name: "userorder",
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
        //,
        //async mounted() {
        //    try {
        //    const res = await axios.get(
        //    "http://localhost:52140/api/Orders/4"
        //    );
        //    this.orders = res.data;
        //    } catch (e) {
        //        console.log(e);
        //    }
        //}
};
</script>
