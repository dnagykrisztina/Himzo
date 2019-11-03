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
import axios from "axios";
export default {
  name: "Title",
  props: {},
  components: {},
  data() {
    return {
      //allcontents: [],
      title: null,
      titleDescription: null,
      moreButton: null,
      contents: [{ key: "title", title: null, description: null }]
    };
  },
  async mounted() {
    try {
      const res = await axios.get(
        "http://localhost:52140/api/Contents?path=title"
      );
      //var i;
      // this.allcontents = res.data;
      this.title = res.data[0].title;
      this.titleDescription = res.data[0].contentString;
      this.moreButton = res.data[1].title;
      /* for (i = 0; i < this.allcontents.length; i++) {
        this.contents[i].title = this.allcontents[i].title;
        this.contents[i].description = this.allcontents[i].contentString;*/
    } catch (e) {
      console.log(e);
    }
  }
};
</script>