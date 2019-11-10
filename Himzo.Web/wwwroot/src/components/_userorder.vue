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
      <a
        class="btn btn-lg btn-primary"
        href="/docs/4.3/components/navbar/"
        role="button"
      >Rendelés adatai &raquo;</a>
    </div>
  </div>
</template>

<script>
export default {
  name: "userorder",
  props: ["order"]
};
</script>