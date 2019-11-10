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

      <a
        class="btn btn-lg btn-primary"
        href="/docs/4.3/components/navbar/"
        role="button"
      >Rendelés adatai &raquo;</a>
      <a class="btn btn-lg btn-primary" href="/docs/4.3/components/navbar/" role="button">Mentés</a>
    </div>
  </div>
</template>

<script>
export default {
  name: "order",
  props: ["order"]
};
</script>
