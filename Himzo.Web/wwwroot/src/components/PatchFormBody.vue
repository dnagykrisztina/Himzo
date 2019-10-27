<template>
<body class="bg-light">
  <main role="main">
    <!-- Main jumbotron for a primary marketing message or call to action -->

    <div class="jumbotron">
      <div class="container">
        <h1 class="display-3">{{ patchFormTitle }}</h1>
        <p>{{ patchFormDescription }}</p>
      </div>
    </div>

    <div class="container">
      <div class="row">
        <div class="col-md-8 order-md-1">
          <form class="needs-validation" novalidate>
            <div class="row"></div>

            <div class="col-md-6 mb-3">
              <input type="file" class="custom-file-input" id="customFile" />
              <label class="custom-file-label" for="customFile">{{chooseFile}}</label>
            </div>

            <div class="row">
              <div class="col-md-3 mb-3">
                <label for="cc-name">{{size}}</label>
                <input type="number" class="form-control" id="size" placeholder required />
              </div>
              <div class="col-md-3 mb-3">
                <label for="cc-name">{{amount}}</label>
                <input type="number" class="form-control" id="amount" placeholder required />
              </div>
              <div class="col-md-4 mb-3">
                <label for="cc-number">{{deadline}}</label>
                <input type="date" class="form-control" id="deadline" placeholder required />
              </div>
            </div>

            <div class="row">
              <div class="col-md-6 mb-3">
                <label for="firstName">{{fonts}}</label>
                <input
                  type="text"
                  class="form-control"
                  id="patternLocation"
                  placeholder
                  value
                  required
                />
                <div class="invalid-feedback">Kérlek add meg a mintában használt fontot!</div>
              </div>
            </div>
            <div class="row">
              <div class="col-md-6 mb-3">
                <label for="firstName">{{comment}}</label>
                <input type="text" class="form-control" id="patternLocation" placeholder value />
              </div>
            </div>

            <div class="row">
              <hr class="mb-4" />
              <a class="btn btn-primary" type="reset" href="index.html">{{cancelButton}}</a>
              <a class="btn btn-primary" type="submit" href="index.html#/userorder">{{orderButton}}</a>
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
  name: "PatchFormBody",
  props: {},
  data() {
    return {
      patchFormTitle: "Folt rendelés",
      patchFormDescription:
        "Foltot így meg így tudsz rendelni, ezt meg ezt kell tudni róla.",
      chooseFile: "Válaszd ki a fájlt",
      pattern: "Minta",
      patternLocation: "Minta helye",
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