<template>
  <div>
    <div class="jumbotron">
      <div class="container">
        <h1 class="display-3">{{ title }}</h1>

        <p>{{ titleDescription }}</p>
        <p>
          <a
            class="btn btn-primary btn-lg"
            href="aboutUsUser.html"
            role="button"
          >{{ moreButton }}&raquo;</a>
        </p>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "Title",
  props: {},
  components: {},
  data() {
    return {
      title: "Pulcsi és FoltMéKör",
      titleDescription:
        "Mi, a Pulcsi és FoltMékör, tevékenységünkkel próbáljuk elősegíteni, hogy a Schönherzes rendezvények rendezői, résztvevői és a körök tagjai egy több 10 év múlva is megmaradó emlékekkel gazdagodhassanak.",
      moreButton: "Tudj meg többet"
    };
  }
};
</script>