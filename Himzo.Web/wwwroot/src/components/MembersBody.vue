 <template>
     <div>
         <!-- Main jumbotron for a primary marketing message or call to action -->
         <div class="jumbotron">
             <div class="container">
                 <h1 class="display-3">{{ membersTitle }}</h1>
                 <p>{{ membersDescription }}</p>
             </div>
         </div>

         <body class="bg-light">
             <main role="main">


                 <div class="container">
                     <div class="row">
                         <input class="form-control form-control-dark w-75" type="text" placeholder="Search" aria-label="Search">
                         <hr class="mb-4" />
                         <button class="btn btn-primary" type="submit">
                             {{searchButton}}
                         </button>
                     </div>

                     <div class="table-responsive">
                         <table class="table table-striped table-sm">
                             <thead>
                                 <tr>
                                     <th>{{usernameTitle}}</th>
                                     <th>{{emailTitle}}</th>
                                     <th>{{himzoMemberTitle}}</th>
                                     <th>{{adminTitle}}</th>
                                 </tr>
                             </thead>
                             <tbody>
                                 <tr v-bind="person in people">

                                     <td>{{person.name}}</td>
                                     <td>{{person.email}}</td>
                                     <td> <input type="checkbox" :id="person.id" :value="person.name" v-model="himzoMembers"></td>
                                     <td> <input type="checkbox" :id="person.id" :value="person.name" v-model="admins"></td>
                                 </tr>

                             </tbody>
                         </table>
                         <span>Körtagok: {{ himzoMembers }}</span>
                         <span>Adminok: {{ admins }}</span>
                     </div>

                     <div class="row">
                         <hr class="mb-4" />
                         <button class="btn btn-primary" type="submit">
                             {{saveButton}}
                         </button>
                     </div>
                 </div>
             </main>
         </body>
     </div>
 </template>


 <script>
export default {
  name: "MembersBody",
  props: {},
  data() {
    return {
      membersTitle: "Tagok",
      membersDescription: "Valami szép leírás rólunk",
      usernameTitle: "Név",
      emailTitle: "E-mail cím",
      adminTitle: "Admin",
      himzoMemberTitle: "Körtag",
      username: "Önnönmagam Én Vagykok",
      email: "email@cim.hu",
      adminOption: "admin",
      himzoMemberOption: "körtag",
      saveButton: "Mentés",
      searchButton: "Keresés",
      admins: [],
      himzoMembers: [],
      people: [
        { name: "Dörner Virág", email: "virag@dorner.hu", id: "elso" },
        { name: "Nagy Krisztina", email: "krisztina@nagy.hu", id: "masodik" },
        { name: "Demjén Klaudia", email: "klaudia@demjen.hu", id: "harmadik" },
        { name: "Sinkó Sára", email: "sara@sinko.hu", id: "negyedik" }
      ]
    };
  }
};
</script>

<style scoped>
</style>
