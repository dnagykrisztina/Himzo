<template>
    <body>
        <main role="main" class="container">

            <order
                v-for="order in orders"
                v-bind:key="order.id"
                v-bind:order="order"
            ></order>

            <hr class="featurette-divider" />

        </main>
    </body>

</template>

 
 <script>
    import order from "./_order.vue";

    export default {
        name: "AllOrderBody",
        props: {},
        components: {
            order
        },
        data() {
            return {
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
  }
};

</script>

<style scoped>
</style>