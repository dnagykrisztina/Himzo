<template>
    <div class="order">
        <div class="jumbotron pl-8">
            <div class="row">
                <div class="col-lg-1 col-sm-1">

                    <div class="fa pt-3">
                        <i v-bind:class="order.statusIcon"></i>

                        <i v-if="order.orderState === 0" value="fas fa-cog">&#xf013;</i>
                        <i v-else-if="order.orderState === 1" value="fas fa-clock ">&#xf017;</i>
                        <i v-else-if="order.orderState === 2" value="fas fa-check-circle ">&#xf058;</i>
                        <i v-else-if="order.orderState === 3" value="fas fa-times-circle ">&#xf057;</i>
                    </div>

                </div>
                <div class="col-lg-8 col-sm-11">
                    <div class="row">
                        <div class="col">
                            <h2 v-if="order.type === 1">{{ order.amount }} db hímzés</h2>
                            <h2 v-else-if="order.type === 0">{{ order.amount }} db folt</h2>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col">
                            <h2 v-if="order.orderState === 0">Rendelés feldolgozás alatt</h2>
                            <h2 v-else-if="order.orderState === 1">Folyamatban</h2>
                            <h2 v-else-if="order.orderState === 2">Kész</h2>
                            <h2 v-if="order.orderState === 3">Rendelés elutasítva</h2>
                        </div>
                    </div>
                    <div v-if="order.commentContent !== null" class="row">
                        <div class="col alert alert-light ml-3 mr-3 mt-3 mb-0" role="alert">
                            <p>{{ order.commentContent }}</p>
                        </div>
                    </div>
                    <div class="row text-right" v-if="order.commentContent !== null ">
                        <div class="col">
                            <p >{{ order.commentUpdateTime | format }}</p>
                        </div>
                    </div>
                </div>
                <div class="col-lg-3 col-sm-12 text-center">
                    <div class="row ">
                        <div class="col">
                            <b-button class="btn btn-primary" typeof=" button" id="show-btn" @click="showModal">Rendelés adatai &raquo;</b-button>

                            <b-modal ref="my-modal" centered hide-backdrop content-class="shadow" hide-footer title="Rendelés adatai">

                                <div class="d-block ">
                                    <div class="container marketing">
                                        <div class="row featurette">
                                            <div class="col-md-6">
                                                <img class="imageorder" :src="`data:image/png;base64,${  order.pattern  }`" />
                                            </div>
                                            <div class="col-md-6 modal-head ">
                                                <h2 class="featurette-heading" v-if="order.type === 1">Hímzés</h2>
                                                <h2 class="featurette-heading" v-else-if="order.type === 0">Folt</h2>
                                            </div>
                                        </div>
                                    </div>
                                    <table class="table">
                                        <tr class="table-borderless">
                                            <th scope="row">Méret:</th>
                                            <td>{{ order.size }}</td>
                                        </tr>
                                        <tr>
                                            <th scope="row">Mennyiség:</th>
                                            <td>{{ order.amount }}</td>
                                        </tr>
                                        <tr>
                                            <th scope="row">Használt fontok:</th>
                                            <td>{{ order.fonts }}</td>
                                        </tr>
                                        <tr v-if="order.type === 1">
                                            <th scope="row">Minta helye:</th>
                                            <td>{{ order.patternPlace }}</td>
                                        </tr>
                                        <tr>
                                            <th scope="row">Határidő</th>
                                            <td>{{ order.deadline | format }}</td>
                                        </tr>
                                        <tr>
                                            <th scope="row">Megjegyzés:</th>
                                            <td>{{ order.orderComment }}
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
                    <div class="row ">
                        <div class="col">
                            id: {{order.orderId}}
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
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
        },
        filters: {
          format: function (str) {
            return str.substring(0, 10);
          }
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
        padding-top: 10%
    }
    i { 
        /*text-shadow: 2px 4px 6px gray;*/
        font-style: normal;
    } 
    .fa{ 
        font-size: 50px; 
          
    } 
    .orderid{
        text-align: right;
        color: red;
    }
    .message{
        padding-left: 10%;
        padding-right: 10%;
    }
    .btn-modal{
        margin-left: 30%;
    }
</style>
