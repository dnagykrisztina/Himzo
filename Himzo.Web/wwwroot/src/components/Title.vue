<template>
  <div>
    <div class="jumbotron">
      <div class="container">
        <div v-if="role === 'Admin'">
          <textarea
            class="form-control title"
            id="inputTitle"
            for="inputTitle"
            v-model="title.title"
            placeholder="Amivel foglalkozunk"
            @change="updateTitle"
          ></textarea>
        </div>
        <div v-if="role !== 'Admin'">
          <h1 class="display-3">{{ title.title }}</h1>
        </div>

        <div v-if="role === 'Admin'">
          <textarea
            class="form-control description"
            id="inputtitleDescription"
            rows="3"
            for="inputtitleDescription"
            v-model="title.description"
            placeholder="Írj pár szót a körről!"
            @change="updateTitleDescription"
          ></textarea>
        </div>
        <div v-if="role !== 'Admin'">
          <p>{{ title.description }}</p>
        </div>
        <p  v-if="this.currentRoute !== 'AboutUs'">
          <a class="btn btn-primary btn-lg" @click="aboutus" role="button"
            >{{ moreButton }}&raquo;</a
          >
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
  methods: {
    aboutus() {
      console.log("aboutus");
      this.$router.push("/aboutus");
    },
    updateTitleDescription() {
      axios
        .patch("http://localhost:52140/api/Contents/".concat(this.title.id), [
          {
            op: "replace",
            path: "/contentString",
            value: this.title.description
          }
        ])
        .then(
          //res => console.log(res.data),
          console.log(this.title.description)
        )
        .catch(e => {
          this.errors.push(e);
        });
    },
    updateTitle() {
      axios
        .patch("http://localhost:52140/api/Contents/".concat(this.title.id), [
          {
            op: "replace",
            path: "/title",
            value: this.title.title
          }
        ])
        .then(
          //res => console.log(res.data),
          console.log(this.title.title)
        )
        .catch(e => {
          this.errors.push(e);
        });
    }
  },
  data() {
    return {
      //allcontents: [],
      title: {
        title: null,
        description: null,
        id: null
      },
      moreButton: "Tudj meg többet",
      postBody: "",
      errors: [],
      role: null,
      currentRoute: null
    };
  },
  async mounted() {
    try {
      const res = await axios.get(
        "http://localhost:52140/api/Contents?path=title"
      );
      this.title.title = res.data[0].title;
      this.title.description = res.data[0].contentString;
      this.title.id = res.data[0].contentId;
    } catch (e) {
      console.log(e);
    }
    try {
      const response = await axios.get("http://localhost:52140/api/User");
      this.role = response.data.roles[0];
    } catch (e) {
      console.log(e);
    }
     try {
      this.currentRoute = this.$route.name;
    } catch (e) {
      console.log(e);
    }
  }
};
</script>

<style scoped>
textarea {
  background: transparent;
  border: 0 none;
  width: 100%;
  outline: none;
  resize: none;
  height: 98px;
}

.title {
  font-size: 4.5rem;
  font-weight: 300;
  line-height: 1.2;
  margin-bottom: 0.5rem;
  margin-top: 0;
  font-family: -apple-system, BlinkMacSystemFont, "Segoe UI", Roboto,
    "Helvetica Neue", Arial, "Noto Sans", sans-serif, "Apple Color Emoji",
    "Segoe UI Emoji", "Segoe UI Symbol", "Noto Color Emoji";
}

.description {
  margin-top: 0;
  margin-bottom: 1rem;
  display: block;
  margin-block-start: 1em;
  margin-block-end: 1em;
  margin-inline-start: 0px;
  margin-inline-end: 0px;
  font-family: -apple-system, BlinkMacSystemFont, "Segoe UI", Roboto,
    "Helvetica Neue", Arial, "Noto Sans", sans-serif, "Apple Color Emoji",
    "Segoe UI Emoji", "Segoe UI Symbol", "Noto Color Emoji";
  font-size: 1rem;
  font-weight: 400;
  line-height: 1.5;
}
</style>
