<template>
<body>
  <main role="main">
    <div class="container marketing">
      <!-- START THE FEATURETTES -->

      <div class="row featurette">
        <div class="col-md-5">
          <div v-if="role==='Admin'">
            <textarea
              class="form-control title"
              id="inputJobTitle"
              rows="3"
              for="inputJobTitle"
              v-model="job.title"
              placeholder="Amivel foglalkozunk"
              @change="updateJobTitle"
            ></textarea>
          </div>
          <div v-if="role !=='Admin'">
            <h2 class="featurette-heading">{{ job.title }}</h2>
          </div>
        </div>
        <div class="col-md-7">
          <div v-if="role==='Admin'">
            <textarea
              class="form-control description"
              id="inputJobDescription"
              rows="3"
              for="inputJobDescription"
              v-model="job.description"
              placeholder="Add meg mivel foglalkoztok!"
              @change="updateJobDescription"
            ></textarea>
          </div>
          <div v-if="role !=='Admin'">
            <p class="lead">{{ job.description }}</p>
          </div>
        </div>
      </div>

      <hr class="featurette-divider" />

      <div class="row featurette">
        <div class="col-md-7">
          <div v-if="role==='Admin'">
            <textarea
              class="form-control description"
              id="inputHistoryDescription"
              rows="3"
              for="inputHistoryDescription"
              v-model="history.description"
              placeholder="�rj p�r sz�t a k�r t�rt�net�r�l!"
              @change="updateHistoryDescription"
            ></textarea>
          </div>
          <div v-if="role !=='Admin'">
            <p class="lead">{{ history.description }}</p>
          </div>
        </div>
        <div class="col-md-5">
          <div v-if="role==='Admin'">
            <textarea
              class="form-control title"
              id="inputHistoryTitle"
              rows="3"
              for="inputHistoryTitle"
              v-model="history.title"
              placeholder="A k�r t�rt�nete"
              @change="updateHistoryTitle"
            ></textarea>
          </div>
          <div v-if="role !=='Admin'">
            <h2 class="featurette-heading">{{ history.title }}</h2>
          </div>
        </div>
      </div>

      <hr class="featurette-divider" />

      <div class="row featurette">
        <div class="col-md-5">
          <div v-if="role==='Admin'">
            <textarea
              class="form-control title"
              id="inputJoinTitle"
              rows="3"
              for="inputJoinTitle"
              v-model="join.title"
              placeholder="Csatlakoz�si lehet�s�g"
              @change="updateJoinTitle"
            ></textarea>
          </div>
          <div v-if="role !=='Admin'">
            <h2 class="featurette-heading">{{ join.title }}</h2>
          </div>
        </div>
        <div class="col-md-7">
          <div v-if="role==='Admin'">
            <textarea
              class="form-control description"
              id="inputJoinDescription"
              rows="3"
              for="inputJoinDescription"
              v-model="join.description"
              placeholder="Add meg hogy lehet csatlakozni a k�rh�z!"
              @change="updateJoinDescription"
            ></textarea>
          </div>
          <div v-if="role !=='Admin'">
            <p class="lead">{{ join.description }}</p>
          </div>
        </div>
      </div>

      <hr class="featurette-divider" />

      <div class="row featurette">
        <div class="col-md-7">
          <div v-if="role==='Admin'">
            <textarea
              class="form-control description"
              id="inputTeamDescription"
              rows="3"
              for="inputTeamDescription"
              v-model="team.description"
              placeholder="�rj a csapatr�l p�r sz�t!"
              @change="updateTeamDescription"
            ></textarea>
          </div>
          <div v-if="role !=='Admin'">
            <p class="lead">{{ team.description }}</p>
          </div>
        </div>
        <div class="col-md-5">
          <div v-if="role==='Admin'">
            <textarea
              class="form-control title"
              id="inputTeamTitle"
              rows="3"
              for="inputTeamTitle"
              v-model="team.title"
              placeholder="A csapat"
              @change="updateTeamTitle"
            ></textarea>
          </div>
          <div v-if="role !=='Admin'">
            <h2 class="featurette-heading">{{ team.title }}</h2>
          </div>
        </div>
      </div>

      <hr class="featurette-divider" />

      <!-- /END THE FEATURETTES -->
    </div>
    <!-- /.container -->
  </main>
</body>
</template>


<script>
import axios from "axios";
export default {
  name: "AboutUsBody",
  props: {},
  methods: {
    updateJobDescription() {
      axios
        .patch("http://localhost:52140/api/Contents/".concat(this.job.id), [
          {
            op: "replace",
            path: "/contentString",
            value: this.job.description
          }
        ])
        .then(console.log(this.job.description))
        .catch(e => {
          this.errors.push(e);
        });
    },
    updateJobTitle() {
      axios
        .patch("http://localhost:52140/api/Contents/".concat(this.job.id), [
          {
            op: "replace",
            path: "/title",
            value: this.job.title
          }
        ])
        .then(console.log(this.job.title))
        .catch(e => {
          this.errors.push(e);
        });
    },
    updateHistoryDescription() {
      axios
        .patch("http://localhost:52140/api/Contents/".concat(this.history.id), [
          {
            op: "replace",
            path: "/contentString",
            value: this.history.description
          }
        ])
        .then(
          //res => console.log(res.data),
          console.log(this.history.description)
        )
        .catch(e => {
          this.errors.push(e);
        });
    },
    updateHistoryTitle() {
      axios
        .patch("http://localhost:52140/api/Contents/".concat(this.history.id), [
          {
            op: "replace",
            path: "/title",
            value: this.history.title
          }
        ])
        .then(
          //res => console.log(res.data),
          console.log(this.history.title)
        )
        .catch(e => {
          this.errors.push(e);
        });
    },
    updateJoinDescription() {
      axios
        .patch("http://localhost:52140/api/Contents/".concat(this.join.id), [
          {
            op: "replace",
            path: "/contentString",
            value: this.join.description
          }
        ])
        .then(
          //res => console.log(res.data),
          console.log(this.join.description)
        )
        .catch(e => {
          this.errors.push(e);
        });
    },
    updateJoinTitle() {
      axios
        .patch("http://localhost:52140/api/Contents/".concat(this.join.id), [
          {
            op: "replace",
            path: "/title",
            value: this.join.title
          }
        ])
        .then(
          //res => console.log(res.data),
          console.log(this.join.title)
        )
        .catch(e => {
          this.errors.push(e);
        });
    },
    updateTeamDescription() {
      axios
        .patch("http://localhost:52140/api/Contents/".concat(this.team.id), [
          {
            op: "replace",
            path: "/contentString",
            value: this.team.description
          }
        ])
        .then(
          //res => console.log(res.data),
          console.log(this.team.description)
        )
        .catch(e => {
          this.errors.push(e);
        });
    },
    updateTeamTitle() {
      axios
        .patch("http://localhost:52140/api/Contents/".concat(this.team.id), [
          {
            op: "replace",
            path: "/title",
            value: this.team.title
          }
        ])
        .then(
          //res => console.log(res.data),
          console.log(this.team.title)
        )
        .catch(e => {
          this.errors.push(e);
        });
    }
  },
  data() {
    return {
      job: {
        description: null,
        title: null,
        id: null
      },
      history: {
        description: null,
        title: null,
        id: null
      },
      join: {
        description: null,
        title: null,
        id: null
      },
      team: {
        description: null,
        title: null,
        id: null
      },

      role: null
    };
  },
  async mounted() {
    try {
      const res = await axios.get(
        "http://localhost:52140/api/Contents?path=aboutus"
      );
      this.job.title = res.data[0].title;
      this.job.description = res.data[0].contentString;
      this.job.id = res.data[0].contentId;
      this.history.title = res.data[1].title;
      this.history.description = res.data[1].contentString;
      this.history.id = res.data[1].contentId;
      this.join.title = res.data[2].title;
      this.join.description = res.data[2].contentString;
      this.join.id = res.data[2].contentId;
      this.team.title = res.data[3].title;
      this.team.description = res.data[3].contentString;
      this.team.id = res.data[3].contentId;
    } catch (e) {
      console.log(e);
    }

    try {
      const response = await axios.get("http://localhost:52140/api/User");
      this.role = response.data.roles[0];
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
  font-weight: 400;
  font-size: 50px;
  line-height: 1;
  letter-spacing: -0.05rem;
  margin-right: 0.6rem;
  margin-left: 0.6rem;
  font-family: -apple-system, BlinkMacSystemFont, "Segoe UI", Roboto,
    "Helvetica Neue", Arial, "Noto Sans", sans-serif, "Apple Color Emoji",
    "Segoe UI Emoji", "Segoe UI Symbol", "Noto Color Emoji";
}
.description {
  font-size: 1.25rem;
  font-weight: 300;
  margin-top: 0;
  margin-bottom: 1rem;
  font-family: -apple-system, BlinkMacSystemFont, "Segoe UI", Roboto,
    "Helvetica Neue", Arial, "Noto Sans", sans-serif, "Apple Color Emoji",
    "Segoe UI Emoji", "Segoe UI Symbol", "Noto Color Emoji";
}
</style>
