<template>
<body class="bg-light">
      <main role="main">
        <!-- Main jumbotron for a primary marketing message or call to action -->
        <div class="jumbotron">
          <div class="container">
            <h1 class="display-3">{{ patternFormTitle }}</h1>
            <p>{{ patternFormDescription }}</p>
            
          </div>
        </div>

      <div class="container">


        <div class="row">

          
    
          <div class="col-md-8 order-md-1">
            <form class="needs-validation" novalidate>
              <div class="row">
                <div class="col-md-6 mb-3">
                  <input type="file" class="custom-file-input" id="customFile">
                  <label class="custom-file-label" for="customFile">{{chooseFile}}</label>
                </div>
              </div>

                  <div class="row">
                  <div class="col-md-3 mb-3">
                  <label for="cc-name">{{size}}</label>
                  <input
                    type="number"
                    class="form-control"
                    id="size"
                    placeholder=""
                    required
                  />
                </div>
                <div class="col-md-3 mb-3">
                  <label for="cc-name">{{amount}}</label>
                  <input
                    type="number"
                    class="form-control"
                    id="amount"
                    placeholder=""
                    required
                  />
                </div>
                <div class="col-md-4 mb-3">
                  <label for="cc-number">{{deadline}}</label>
                  <input
                    type="date"
                    class="form-control"
                    id="deadline"
                    placeholder=""
                    required
                  />
                </div>
              </div>

              <div class="row">
                <div class="col-md-6 mb-3">
                  <label for="firstName">{{patternLocation}}</label>
                  <input
                    type="text"
                    class="form-control"
                    id="patternLocation"
                    placeholder=""
                    value=""
                    required
                  />
                  <div class="invalid-feedback">
                    Kérlek add meg a minta helyét!
                  </div>
              </div>
              </div>
              
              <div class="row">
                <div class="col-md-6 mb-3">
                  <label for="font">{{fonts}}</label>
                  <input
                    type="text"
                    class="form-control"
                    id="font"
                    placeholder=""
                    value=""
                    required
                  />
                  <div class="invalid-feedback">
                    Kérlek add meg a mintában használt fontot!
                  </div>
              </div>
              </div>
            
              <div class="row">
                <div class="col-md-6 mb-3">
                  <label for="firstName">{{comment}}</label>
                  <input
                    type="text"
                    class="form-control"
                    id="patternLocation"
                    placeholder=""
                    value=""
                  />
              </div>
          </div>

            
                
              <div class = "row">
              <hr class="mb-4" />
              <button class="btn btn-primary" type="reset">
                {{cancelButton}}
              </button>
              <button class="btn btn-primary"  type="submit">
                {{orderButton}}
              </button>
              </div>
            </form>
          </div>
          </div>
        </div>
      </main>
    </body>

 </template>

 
 <script>
export default {
  name: "PatternFormBody",
  props: {},
  data() {
    return {
      patternFormTitle: "Minta hímeztetése",
      patternFormDescription:
        "Mintát hozott anyagra így meg amúgy tudsz hímeztetni.",

      chooseFile: "Válaszd ki a fájlt",
      pattern: "Minta",
      size: "Méret (cm)",
      amount: "Mennyiség",
      deadline: "Határidő",
      fonts: "Mintában használt fontok",
      comment: "Megjegyzés",
      cancelButton: "Mégse",
      orderButton: "Megrendelem"
    };
  }
};
</script>

<style scoped>
</style>