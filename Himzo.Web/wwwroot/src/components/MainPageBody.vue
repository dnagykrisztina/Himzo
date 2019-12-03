<template>
    <body>
        <main role="main">
            <div class="container marketing">
                <!-- START THE FEATURETTES -->
                <!--<img :src="dataUrl" />-->

                <div class="row featurette">
                    <div class="col-md-7">
                        <div v-if="role==='Admin'">
                            <textarea class="form-control title"
                                      id="inputpatchTitle"
                                      for="inputpatchTitle"
                                      v-model="patchTitle"
                                      placeholder="Amivel foglalkozun"
                                      @change="updatePatchTitle"></textarea>
                        </div>
                        <div v-if="role !=='Admin'">
                            <h2 class="featurette-heading">{{ patchTitle }}</h2>
                        </div>
                        <div v-if="role==='Admin'">
                            <textarea class="form-control description"
                                      id="inputpatchDescription"
                                      rows="3"
                                      for="inputpatchDescription"
                                      v-model="patchDescription"
                                      placeholder="Add meg mivel foglalkoztok!"
                                      @change="updatePatchDescription"></textarea>
                        </div>
                        <div v-if="role !=='Admin'">
                            <p class="lead">{{ patchDescription }}</p>
                        </div>
                        <a v-on:click="patchForm" class="btn btn-lg btn-block btn-outline-primary">Rendelés</a>
                    </div>

                    <div class="col-md-5">
                        <div class="demo">
                            <!-- <coverflow :coverList="coverList" :coverWidth="100" :index="2" @change="handleChange"></coverflow> -->
                            <coverflow :coverList="coverList0" :width="400" :coverWidth="300" :index="1"></coverflow>
                        </div>
                    </div>
                </div>

                <hr class="featurette-divider" />

                <div class="row featurette">
                    <div class="col-md-7 order-md-2">

                        <div v-if="role==='Admin'">
                            <textarea class="form-control title"
                                      id="inputPatternTitle"
                                      for="inputPatternTitle"
                                      v-model="embroideredPatternTitle"
                                      placeholder="Amivel foglalkozunk"
                                      @change="updatePatternTitle"></textarea>
                        </div>
                        <div v-if="role !=='Admin'">
                            <h2 class="featurette-heading">{{ embroideredPatternTitle }}</h2>
                        </div>

                        <div v-if="role==='Admin'">
                            <textarea class="form-control description"
                                      id="inputPatternDescription"
                                      rows="3"
                                      for="inputPatternDescription"
                                      v-model="embroideredPatternDescription"
                                      placeholder="Add meg mivel foglalkoztok!"
                                      @change="updatePatternDescription"></textarea>
                        </div>
                        <div v-if="role !=='Admin'">
                            <p class="lead">{{ embroideredPatternDescription }}</p>
                        </div>
                        <a v-on:click="patternForm" class="btn btn-lg btn-block btn-outline-primary">Rendelés</a>
                    </div>
                    <div class="col-md-5 order-md-1">
                        <coverflow :coverList="coverList1" :width="400" :coverWidth="300" :index="0"></coverflow>
                    </div>
                </div>

                <hr class="featurette-divider" />

                <div class="row featurette" id="down">
                    <div class="col-md-7">

                        <div v-if="role==='Admin'">
                            <textarea class="form-control title"
                                      id="inputsewaterTitle"
                                      for="inputsewaterTitle"
                                      v-model="sweaterTitle"
                                      placeholder="Amivel foglalkozunk"
                                      @change="updateSweaterTitle"></textarea>
                        </div>
                        <div v-if="role !=='Admin'">
                            <h2 class="featurette-heading">{{ sweaterTitle }}</h2>
                        </div>

                        <div v-if="role==='Admin'">
                            <textarea class="form-control description"
                                      id="inputsweaterDescription"
                                      rows="3"
                                      for="inputsweaterDescription"
                                      v-model="sweaterDescription"
                                      placeholder="Add meg mivel foglalkoztok!"
                                      @change="updateSweaterDescription"></textarea>
                        </div>
                        <div v-if="role !=='Admin'">
                            <p class="lead">{{ sweaterDescription }}</p>
                        </div>
                    </div>
                    <div class="col-md-5">
                        <coverflow :coverList="coverList2" :width="400" :coverWidth="300" :index="1"></coverflow>
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
    import coverflow from "vue-coverflow";
    import axios from "axios";

    export default {
        name: "MainPageBody",
        props: {},
        datat: {
            username: null
        },
        methods: {
            patchForm: function () {
                if (this.auth) {
                    this.$router.push("/patchform");
                } else {
                    this.$router.push("/signin");
                }
            },
            patternForm: function () {
                console.log("patternform");

                if (this.auth) {
                    this.$router.push("/patternform");
                } else {
                    this.$router.push("/signin");
                }
            },
            updatePatchTitle() {
                axios.patch('http://localhost:52140/api/Contents/1',
                    [{
                        "op": "replace",
                        "path": "/title",
                        "value": this.patchTitle
                    }])
                    .then(
                        //res => console.log(res.data),
                        console.log(this.patchTitle)
                    )
                    .catch(e => {
                        this.errors.push(e);
                    });
            },
            updatePatchDescription() {
                axios.patch('http://localhost:52140/api/Contents/1',
                    [{
                        "op": "replace",
                        "path": "/contentString",
                        "value": this.patchDescription
                    }])
                    .then(
                        //res => console.log(res.data),
                        console.log(this.patchDescription)
                    )
                    .catch(e => {
                        this.errors.push(e);
                    });
            },
            updatePatternTitle() {
                axios.patch('http://localhost:52140/api/Contents/2',
                    [{
                        "op": "replace",
                        "path": "/title",
                        "value": this.embroideredPatternTitle
                    }])
                    .then(
                        //res => console.log(res.data),
                        console.log(this.embroideredPatternTitle)
                    )
                    .catch(e => {
                        this.errors.push(e);
                    });
            },
            updatePatternDescription() {
                axios.patch('http://localhost:52140/api/Contents/2',
                    [{
                        "op": "replace",
                        "path": "/contentString",
                        "value": this.embroideredPatternDescription
                    }])
                    .then(
                        //res => console.log(res.data),
                        console.log(this.embroideredPatternDescription)
                    )
                    .catch(e => {
                        this.errors.push(e);
                    });
            }, updateSweaterDescription() {
                axios.patch('http://localhost:52140/api/Contents/3',
                    [{
                        "op": "replace",
                        "path": "/contentString",
                        "value": this.sweaterDescription
                    }])
                    .then(
                        //res => console.log(res.data),
                        console.log(this.sweaterDescription)
                    )
                    .catch(e => {
                        this.errors.push(e);
                    });
            },
            updateSweaterTitle() {
                axios.patch('http://localhost:52140/api/Contents/3',
                    [{
                        "op": "replace",
                        "path": "/title",
                        "value": this.sweaterTitle
                    }])
                    .then(
                        //res => console.log(res.data),
                        console.log(this.sweaterTitle)
                    )
                    .catch(e => {
                        this.errors.push(e);
                    });
            }
        },
        data() {
            return {
                //allcontents: [],
                auth: false,
                patchTitle: null,
                patchDescription: null,
                embroideredPatternTitle: null,
                embroideredPatternDescription: null,
                sweaterTitle: null,
                sweaterDescription: null,
                image: null,
                role: null,
                coverList0: [
                    {
                        cover: null
                    },
                    {
                        cover: null
                    },
                    {
                        cover: null
                    },
                    {
                        cover: null
                    },
                    {
                        cover: null
                    }
                ],
                coverList1: [
                    {
                        cover: null
                    },
                    {
                        cover: null
                    },
                    {
                        cover: null
                    },
                    {
                        cover: null
                    },
                    {
                        cover: null
                    },
                    {
                        cover: null
                    }
                ],
                coverList2: [
                    {
                        cover: null
                    },
                    {
                        cover: null
                    },
                    {
                        cover: null
                    }
                ]
            };
        },

        async mounted() {
            try {
                const res = await axios.get(
                    "http://localhost:52140/api/Contents?path=welcome"
                );
                this.patchTitle = res.data[0].title;
                this.patchDescription = res.data[0].contentString;
                this.embroideredPatternTitle = res.data[1].title;
                this.embroideredPatternDescription = res.data[1].contentString;
                this.sweaterTitle = res.data[2].title;
                this.sweaterDescription = res.data[2].contentString;
            } catch (e) {
                console.log(e);
            }
            try {
                const img0 = await axios.get(
                    "http://localhost:52140/api/Images/?path=welcome&type=0"
                );
                const arrayLength0 = img0.data.length;
                for (var i = 0; i < arrayLength0; i++) {
                    let cover0 = "data:image/jpg;base64,".concat(img0.data[i].byteImage);
                    this.coverList0[i].cover = cover0;
                }

                const img1 = await axios.get(
                    "http://localhost:52140/api/Images/?path=welcome&type=1"
                );
                const arrayLength1 = img1.data.length;
                for (var j = 0; j < arrayLength1; j++) {
                    let cover1 = "data:image/jpg;base64,".concat(img1.data[j].byteImage);
                    this.coverList1[j].cover = cover1;
                }
                const img2 = await axios.get(
                    "http://localhost:52140/api/Images/?path=welcome&type=2"
                );
                const arrayLength2 = img2.data.length;
                for (var k = 0; k < arrayLength2; k++) {
                    let cover2 = "data:image/jpg;base64,".concat(img2.data[k].byteImage);
                    this.coverList2[k].cover = cover2;
                }
            } catch (e) {
                console.log(e);
            }
            try {
                const response = await axios.get("http://localhost:52140/api/User");
                if (response.status === 200) {
                    this.auth = true;
                } else {
                    this.auth = false;
                }
            } catch (e) {
                console.log(e);
            }
            try {
                const response = await axios.get("http://localhost:52140/api/User");
                this.role = response.data.roles[0]
            } catch (e) {
                console.log(e);
            }
        },
        components: {
            coverflow
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
          height: 65px;
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
