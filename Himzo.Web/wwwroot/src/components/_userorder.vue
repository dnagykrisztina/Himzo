<template>
    <div class="order">
        <div class="jumbotron  flex-column align-items-center">

            <div class="d-flex align-items-center mb-3">

                <div class="fa  p-2">
                    <i v-bind:class="order.statusIcon"></i>
  
                    <i v-if="order.orderState === 0" value="fas fa-cog">&#xf013;</i>
                    <i v-else-if="order.orderState === 1" value="fas fa-clock ">&#xf017;</i>
                    <i v-else-if="order.orderState === 2" value="fas fa-check-circle ">&#xf058;</i>
                    <i v-else-if="order.orderState === 3" value="fas fa-times-circle ">&#xf057;</i>
                </div>
                <div class="flex-column p-2">
                    <div class="status">

                        <h2 v-if="order.type === 1">{{ order.amount }} db hímzés</h2>
                        <h2 v-else-if="order.type === 0">{{ order.amount }} db folt</h2>
                    </div>
                    <div class="status">
                        <h2 v-if="order.orderState === 0">Rendelés feldolgozás alatt</h2>
                        <h2 v-else-if="order.orderState === 1">Folyamatban</h2>
                        <h2 v-else-if="order.orderState === 2">Kész</h2>
                        <h2 v-if="order.orderState === 3">Rendelés elutasítva</h2>
                    </div>
                </div>

                <div class="p-2 btn-modal  ">
                    <div>
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

            </div>
            <div class="message">
                <p class="lead">{{ order.commentContent }}</p>
                <p class="lead">{{ order.commentUpdateTime | format }}</p>
            </div>
            <div class="message">
                <p class="orderid">{{ order.orderId }}</p>
            </div>
            


            <!--<a
      class="btn btn-lg btn-primary"
      href="/docs/4.3/components/navbar/"
      role="button"
    >Rendelés adatai &raquo;</a>-->
            
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
            return str.substring(0, str.length - 9);
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
