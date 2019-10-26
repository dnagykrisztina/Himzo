<template>
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
</template>

<script>

export default {
  name: "userorder",
  props: ["order"],
};
</script>