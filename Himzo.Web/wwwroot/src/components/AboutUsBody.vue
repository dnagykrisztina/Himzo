<template>
<body>
  <main role="main">
    <div class="container marketing">
      <!-- START THE FEATURETTES -->

      <div class="row featurette">
          <div class="col-md-5">
              <div v-if="role==='Admin'">
                  <textarea class="form-control title"
                            id="inputJobTitle"
                            rows="3"
                            for="inputJobTitle"
                            v-model="job_title"
                            placeholder="Amivel foglalkozunk"
                            @change="updateJobTitle"></textarea>
              </div>
              <div v-if="role !=='Admin'">
                  <h2 class="featurette-heading">{{ job_title }}</h2>
              </div>
              
          </div>
        <div class="col-md-7">
            <div v-if="role==='Admin'">
                <textarea class="form-control description"
                          id="inputJobDescription"
                          rows="3"
                          for="inputJobDescription"
                          v-model="job_description"
                          placeholder="Add meg mivel foglalkoztok!"
                          @change="updateJobDescription"
                ></textarea>
            </div>
            <div v-if="role !=='Admin'">
                <p class="lead">{{ job_description }}</p>
            </div>
        </div>
      </div>

      <hr class="featurette-divider" />

      <div class="row featurette">
          <div class="col-md-7">
              <div v-if="role==='Admin'">
                  <textarea class="form-control description"
                            id="inputHistoryDescription"
                            rows="3"
                            for="inputHistoryDescription"
                            v-model="history_description"
                            placeholder="Írj pár szót a kör történetérõl!"
                            @change="updateHistoryDescription"></textarea>
              </div>
              <div v-if="role !=='Admin'">
                  <p class="lead">{{ history_description }}</p>
              </div>
          </div>
        <div class="col-md-5">
            
            <div v-if="role==='Admin'">
                <textarea class="form-control title"
                          id="inputHistoryTitle"
                          rows="3"
                          for="inputHistoryTitle"
                          v-model="history_title"
                          placeholder="A kör története"
                          @change="updateHistoryTitle"></textarea>
            </div>
            <div v-if="role !=='Admin'">
                <h2 class="featurette-heading">{{ history_title }}</h2>
            </div>
        </div>
      </div>

      <hr class="featurette-divider" />

      <div class="row featurette">
          <div class="col-md-5">
              <div v-if="role==='Admin'">
                  <textarea class="form-control title"
                            id="inputJoinTitle"
                            rows="3"
                            for="inputJoinTitle"
                            v-model="how_to_join_title"
                            placeholder="Csatlakozási lehetõség"
                            @change="updateJoinTitle"></textarea>
              </div>
              <div v-if="role !=='Admin'">
                  <h2 class="featurette-heading">{{ how_to_join_title }}</h2>
              </div>
          </div>
          <div class="col-md-7">
              <div v-if="role==='Admin'">
                  <textarea class="form-control description"
                            id="inputJoinDescription"
                            rows="3"
                            for="inputJoinDescription"
                            v-model="how_to_join_description"
                            placeholder="Add meg hogy lehet csatlakozni a körhöz!"
                            @change="updateJoinDescription"></textarea>
              </div>
              <div v-if="role !=='Admin'">
                  <p class="lead">{{ how_to_join_description }}</p>
              </div>
          </div>
      </div>

      <hr class="featurette-divider" />

      <div class="row featurette">
          <div class="col-md-7">
              <div v-if="role==='Admin'">
                  <textarea class="form-control description"
                            id="inputTeamDescription"
                            rows="3"
                            for="inputTeamDescription"
                            v-model="team_description"
                            placeholder="Írj a csapatról pár szót!"
                            @change="updateTeamDescription"></textarea>
              </div>
              <div v-if="role !=='Admin'">
                  <p class="lead">{{ team_description }}</p>
              </div>
          </div>
          <div class="col-md-5">
              <div v-if="role==='Admin'">
                  <textarea class="form-control title"
                            id="inputTeamTitle"
                            rows="3"
                            for="inputTeamTitle"
                            v-model="team_title"
                            placeholder="A csapat"
                            @change="updateTeamTitle"></textarea>
              </div>
              <div v-if="role !=='Admin'">
                  <h2 class="featurette-heading">{{ team_title }}</h2>
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
          axios.patch('http://localhost:52140/api/Contents/14',
                [{
                    "op": "replace",
                    "path": "/contentString",
                    "value": this.job_description
                    }]) 
            .then(
                //res => console.log(res.data),
                console.log(this.job_description)
            )
            .catch(e => {
                this.errors.push(e);
            });
      },
      updateJobTitle() {
          axios.patch('http://localhost:52140/api/Contents/14',
                [{
                    "op": "replace",
                    "path": "/title",
                    "value": this.job_title
                    }]) 
            .then(
                //res => console.log(res.data),
                console.log(this.job_title)
            )
            .catch(e => {
                this.errors.push(e);
            });
      },
      updateHistoryDescription() {
          axios.patch('http://localhost:52140/api/Contents/15',
                [{
                    "op": "replace",
                    "path": "/contentString",
                    "value": this.history_description
                    }]) 
            .then(
                //res => console.log(res.data),
                console.log(this.history_description)
            )
            .catch(e => {
                this.errors.push(e);
            });
      },
      updateHistoryTitle() {
          axios.patch('http://localhost:52140/api/Contents/15',
                [{
                    "op": "replace",
                    "path": "/title",
                    "value": this.history_title
                    }]) 
            .then(
                //res => console.log(res.data),
                console.log(this.history_title)
            )
            .catch(e => {
                this.errors.push(e);
            });
      },
      updateJoinDescription() {
          axios.patch('http://localhost:52140/api/Contents/16',
                [{
                    "op": "replace",
                    "path": "/contentString",
                    "value": this.how_to_join_description
                    }]) 
            .then(
                //res => console.log(res.data),
                console.log(this.how_to_join_description)
            )
            .catch(e => {
                this.errors.push(e);
            });
      },
      updateJoinTitle() {
          axios.patch('http://localhost:52140/api/Contents/16',
                [{
                    "op": "replace",
                    "path": "/title",
                    "value": this.how_to_join_title
                    }]) 
            .then(
                //res => console.log(res.data),
                console.log(this.how_to_join_title)
            )
            .catch(e => {
                this.errors.push(e);
            });
      },
      updateTeamDescription() {
          axios.patch('http://localhost:52140/api/Contents/17',
                [{
                    "op": "replace",
                    "path": "/contentString",
                    "value": this.team_description
                    }]) 
            .then(
                //res => console.log(res.data),
                console.log(this.team_description)
            )
            .catch(e => {
                this.errors.push(e);
            });
      },
      updateTeamTitle() {
          axios.patch('http://localhost:52140/api/Contents/17',
                [{
                    "op": "replace",
                    "path": "/title",
                    "value": this.team_title
                    }]) 
            .then(
                //res => console.log(res.data),
                console.log(this.team_title)
            )
            .catch(e => {
                this.errors.push(e);
            });
      }
  },
  data() {
    return {
      job_description: null,
      job_title: null,
      history_description: null,
      history_title: null,
      how_to_join_description: null,
      how_to_join_title: null,
      team_title: null,
      team_description: null,
      role: null
    };
  },
        async mounted() {
            try {
                const res = await axios.get(
                    "http://localhost:52140/api/Contents?path=aboutus"
                );
                this.job_title = res.data[0].title;
                this.job_description = res.data[0].contentString;
                this.history_title = res.data[1].title;
                this.history_description = res.data[1].contentString;
                this.how_to_join_title = res.data[2].title;
                this.how_to_join_description = res.data[2].contentString;
                this.team_title = res.data[3].title;
                this.team_description = res.data[3].contentString;
                /* var i;
                this.allcontents = res.data;
                for (i = 0; i < this.allcontents.length; i++) {
                  this.contents[i].title = this.allcontents[i].title;
                  this.contents[i].description = this.allcontents[i].contentString;*/
                // }
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
    .title{
        font-weight: 400;
        font-size: 50px;
        line-height: 1;
        letter-spacing: -0.05rem;
        margin-right: 0.6rem;
        margin-left: 0.6rem;
        font-family: -apple-system,BlinkMacSystemFont,"Segoe UI",Roboto,"Helvetica Neue",Arial,"Noto Sans",sans-serif,"Apple Color Emoji","Segoe UI Emoji","Segoe UI Symbol","Noto Color Emoji";
        }
    .description{
        font-size: 1.25rem;
        font-weight: 300;
        margin-top: 0;
        margin-bottom: 1rem;
        font-family: -apple-system,BlinkMacSystemFont,"Segoe UI",Roboto,"Helvetica Neue",Arial,"Noto Sans",sans-serif,"Apple Color Emoji","Segoe UI Emoji","Segoe UI Symbol","Noto Color Emoji";
    }
</style>
