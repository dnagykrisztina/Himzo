<template>
  <div>
    <div class="jumbotron">
        <div class="container">

            <div v-if="role==='Admin'">
                <textarea class="form-control title"
                          id="inputTitle"
                          for="inputTitle"
                          v-model="title"
                          placeholder="Amivel foglalkozunk"
                          @change="updateTitle"></textarea>
            </div>
            <div v-if="role !=='Admin'">
                <h1 class="display-3">{{ title }}</h1>
            </div>

            
            <div v-if="role==='Admin'">
                <textarea class="form-control description"
                          id="inputtitleDescription"
                          rows="3"
                          for="inputtitleDescription"
                          v-model="titleDescription"
                          placeholder="Add meg mivel foglalkoztok!"
                          @change="updateTitleDescription"></textarea>
            </div>
            <div v-if="role !=='Admin'">
                <p>{{ titleDescription }}</p>
            </div>
            <p>
                <a class="btn btn-primary btn-lg"
                   @click="aboutus"
                   role="button">{{ moreButton }}&raquo;</a>
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
        console.log("aboutus")
        this.$router.push('/aboutus')
      },
      updateTitleDescription() {
          axios.patch('http://localhost:52140/api/Contents/4',
                [{
                    "op": "replace",
                    "path": "/contentString",
                    "value": this.titleDescription
                    }]) 
            .then(
                //res => console.log(res.data),
                console.log(this.titleDescription)
            )
            .catch(e => {
                this.errors.push(e);
            });
      },
      updateTitle() {
          axios.patch('http://localhost:52140/api/Contents/4',
                [{
                    "op": "replace",
                    "path": "/title",
                    "value": this.title
                    }]) 
            .then(
                //res => console.log(res.data),
                console.log(this.title)
            )
            .catch(e => {
                this.errors.push(e);
            });
      }
  },
  data() {
    return {
      //allcontents: [],
      title: null,
      titleDescription: null,
      moreButton: null,
      contents: [{ key: "title", title: null, description: null }],
      postBody: "",
      errors: [],
      role: null
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
      try {
                const response = await axios.get("http://localhost:52140/api/User");
                this.role = response.data.roles[0]
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
        height: auto;
    }

    .title {
            font-size: 4.5rem;
    font-weight: 300;
    line-height: 1.2;
        margin-bottom: .5rem;
            margin-top: 0;
            font-family: -apple-system,BlinkMacSystemFont,"Segoe UI",Roboto,"Helvetica Neue",Arial,"Noto Sans",sans-serif,"Apple Color Emoji","Segoe UI Emoji","Segoe UI Symbol","Noto Color Emoji";
        }

    .description {
        margin-top: 0;
    margin-bottom: 1rem;
    display: block;
    margin-block-start: 1em;
    margin-block-end: 1em;
    margin-inline-start: 0px;
    margin-inline-end: 0px;
    font-family: -apple-system,BlinkMacSystemFont,"Segoe UI",Roboto,"Helvetica Neue",Arial,"Noto Sans",sans-serif,"Apple Color Emoji","Segoe UI Emoji","Segoe UI Symbol","Noto Color Emoji";
    font-size: 1rem;
    font-weight: 400;
    line-height: 1.5;
    }
</style>