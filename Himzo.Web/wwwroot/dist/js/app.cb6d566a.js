(function(t){function e(e){for(var s,l,n=e[0],o=e[1],c=e[2],m=0,u=[];m<n.length;m++)l=n[m],Object.prototype.hasOwnProperty.call(r,l)&&r[l]&&u.push(r[l][0]),r[l]=0;for(s in o)Object.prototype.hasOwnProperty.call(o,s)&&(t[s]=o[s]);d&&d(e);while(u.length)u.shift()();return i.push.apply(i,c||[]),a()}function a(){for(var t,e=0;e<i.length;e++){for(var a=i[e],s=!0,n=1;n<a.length;n++){var o=a[n];0!==r[o]&&(s=!1)}s&&(i.splice(e--,1),t=l(l.s=a[0]))}return t}var s={},r={app:0},i=[];function l(e){if(s[e])return s[e].exports;var a=s[e]={i:e,l:!1,exports:{}};return t[e].call(a.exports,a,a.exports,l),a.l=!0,a.exports}l.m=t,l.c=s,l.d=function(t,e,a){l.o(t,e)||Object.defineProperty(t,e,{enumerable:!0,get:a})},l.r=function(t){"undefined"!==typeof Symbol&&Symbol.toStringTag&&Object.defineProperty(t,Symbol.toStringTag,{value:"Module"}),Object.defineProperty(t,"__esModule",{value:!0})},l.t=function(t,e){if(1&e&&(t=l(t)),8&e)return t;if(4&e&&"object"===typeof t&&t&&t.__esModule)return t;var a=Object.create(null);if(l.r(a),Object.defineProperty(a,"default",{enumerable:!0,value:t}),2&e&&"string"!=typeof t)for(var s in t)l.d(a,s,function(e){return t[e]}.bind(null,s));return a},l.n=function(t){var e=t&&t.__esModule?function(){return t["default"]}:function(){return t};return l.d(e,"a",e),e},l.o=function(t,e){return Object.prototype.hasOwnProperty.call(t,e)},l.p="/";var n=window["webpackJsonp"]=window["webpackJsonp"]||[],o=n.push.bind(n);n.push=e,n=n.slice();for(var c=0;c<n.length;c++)e(n[c]);var d=o;i.push([0,"chunk-vendors"]),a()})({0:function(t,e,a){t.exports=a("56d7")},"56d7":function(t,e,a){"use strict";a.r(e);a("e260"),a("e6cf"),a("cca6"),a("a79d");var s=a("2b0e"),r=function(){var t=this,e=t.$createElement,a=t._self._c||e;return a("div",{attrs:{id:"app"}},[a("router-view")],1)},i=[],l={name:"app"},n=l,o=a("2877"),c=Object(o["a"])(n,r,i,!1,null,null,null),d=c.exports,m=a("8c4f"),u=function(){var t=this,e=t.$createElement,a=t._self._c||e;return a("div",[a("Header"),a("Title"),a("MainPageBody"),a("Footer")],1)},p=[],v=function(){var t=this,e=t.$createElement,a=t._self._c||e;return a("div",[a("div",[a("nav",{staticClass:"navbar navbar-expand-md navbar-dark fixed-top bg-dark"},[a("a",{staticClass:"navbar-brand",attrs:{href:"index.html"}},[t._v(t._s(t.titleHimzo))]),t._m(0),a("div",{staticClass:"collapse navbar-collapse",attrs:{id:"navbarCollapse"}},[a("ul",{staticClass:"navbar-nav mr-auto"},[a("li",{staticClass:"nav-item"},[a("a",{staticClass:"nav-link",attrs:{href:"index.html"}},[t._v(t._s(t.order))])]),a("li",{staticClass:"nav-item"},[a("a",{staticClass:"nav-link",attrs:{href:"index.html#/userorder"}},[t._v(t._s(t.myOrders))])]),a("li",{staticClass:"nav-item"},[a("a",{staticClass:"nav-link",attrs:{href:"index.html#/aboutus"}},[t._v(t._s(t.aboutUs))])]),a("li",{staticClass:"dropdown nav-item"},[a("a",{staticClass:"dropbtn nav-link",attrs:{href:"#"}},[t._v(t._s(t.username))]),a("div",{staticClass:"dropdown-content"},[a("a",{attrs:{href:"index.html#/profile"}},[t._v(t._s(t.profile))]),a("a",{attrs:{href:"index.html"}},[t._v(t._s(t.signOut))])])]),a("a",{staticClass:"nav-link",attrs:{href:"index.html#/signin"}},[t._v(t._s(t.signIn))]),a("li",{staticClass:"nav-item"})])])])])])},f=[function(){var t=this,e=t.$createElement,a=t._self._c||e;return a("button",{staticClass:"navbar-toggler",attrs:{type:"button","data-toggle":"collapse","data-target":"#navbarCollapse","aria-controls":"navbarCollapse","aria-expanded":"false","aria-label":"Toggle navigation"}},[a("span",{staticClass:"navbar-toggler-icon"})])}],b={name:"Header",props:{},data:function(){return{titleHimzo:"Hímző",order:"Rendelés",myOrders:"Rendeléseim",aboutUs:"Rólunk",username:"Önnönmagam",profile:"Profilom",signOut:"Kilépés",signIn:"Bejelentkezés"}}},h=b,_=(a("b1c5"),Object(o["a"])(h,v,f,!1,null,"3a7f94ea",null)),g=_.exports,y=function(){var t=this,e=t.$createElement,a=t._self._c||e;return a("div",[a("div",{staticClass:"jumbotron"},[a("div",{staticClass:"container"},[a("h1",{staticClass:"display-3"},[t._v(t._s(t.title))]),a("p",[t._v(t._s(t.titleDescription))]),a("p",[a("a",{staticClass:"btn btn-primary btn-lg",attrs:{href:"aboutUsUser.html",role:"button"}},[t._v(t._s(t.moreButton)+"»")])])])])])},C=[],x={name:"Title",props:{},components:{},data:function(){return{title:"Pulcsi és FoltMéKör",titleDescription:"Mi, a Pulcsi és FoltMékör, tevékenységünkkel próbáljuk elősegíteni, hogy a Schönherzes rendezvények rendezői, résztvevői és a körök tagjai egy több 10 év múlva is megmaradó emlékekkel gazdagodhassanak.",moreButton:"Tudj meg többet"}}},k=x,w=Object(o["a"])(k,y,C,!1,null,null,null),z=w.exports,j=function(){var t=this,e=t.$createElement,a=t._self._c||e;return a("body",[a("main",{attrs:{role:"main"}},[a("div",{staticClass:"container marketing"},[a("hr",{staticClass:"featurette-divider"}),a("div",{staticClass:"row featurette"},[a("div",{staticClass:"col-md-7"},[a("h2",{staticClass:"featurette-heading"},[t._v(t._s(t.patchTitle))]),a("p",{staticClass:"lead"},[t._v(t._s(t.patchDescription))]),a("a",{staticClass:"btn btn-lg btn-block btn-outline-primary",attrs:{href:"signin.html"}},[t._v("Rendelés")])]),a("div",{staticClass:"col-md-5"},[a("svg",{staticClass:"bd-placeholder-img bd-placeholder-img-lg featurette-image img-fluid mx-auto",attrs:{width:"500",height:"500",xmlns:"http://www.w3.org/2000/svg",preserveAspectRatio:"xMidYMid slice",focusable:"false",role:"img","aria-label":"Placeholder: 500x500"}},[a("title",[t._v("Placeholder")]),a("rect",{attrs:{width:"100%",height:"100%",fill:"#eee"}})])])]),a("hr",{staticClass:"featurette-divider"}),a("div",{staticClass:"row featurette"},[a("div",{staticClass:"col-md-7 order-md-2"},[a("h2",{staticClass:"featurette-heading"},[t._v(t._s(t.embroideredPatternTitle))]),a("p",{staticClass:"lead"},[t._v(t._s(t.embroideredPatternDescription))]),a("a",{staticClass:"btn btn-lg btn-block btn-outline-primary",attrs:{href:"signin.html"}},[t._v("Rendelés")])]),a("div",{staticClass:"col-md-5 order-md-1"},[a("svg",{staticClass:"bd-placeholder-img bd-placeholder-img-lg featurette-image img-fluid mx-auto",attrs:{width:"500",height:"500",xmlns:"http://www.w3.org/2000/svg",preserveAspectRatio:"xMidYMid slice",focusable:"false",role:"img","aria-label":"Placeholder: 500x500"}},[a("title",[t._v("Placeholder")]),a("rect",{attrs:{width:"100%",height:"100%",fill:"#eee"}})])])]),a("hr",{staticClass:"featurette-divider"}),a("div",{staticClass:"row featurette"},[a("div",{staticClass:"col-md-7"},[a("h2",{staticClass:"featurette-heading"},[t._v(t._s(t.sweaterTitle))]),a("p",{staticClass:"lead"},[t._v(t._s(t.sweaterDescription))])]),a("div",{staticClass:"col-md-5"},[a("img",{staticClass:"bd-placeholder-img bd-placeholder-img-lg featurette-image img-fluid mx-auto",attrs:{src:t.photo,width:"500",height:"500",preserveAspectRatio:"xMidYMid slice",focusable:"false",role:"img","aria-label":"Placeholder: 500x500"}})])]),t._m(0),a("hr",{staticClass:"featurette-divider"})])])])},M=[function(){var t=this,e=t.$createElement,a=t._self._c||e;return a("div",{attrs:{id:"coverflow"}},[a("section",{attrs:{"data-cover":"../images/picture.jpg"}}),a("section",{attrs:{"data-cover":"http://a3.mzstatic.com/us/r1000/102/Music/95/45/3f/mzi.xqnmexwi.170x170-75.jpg"}}),a("section",{attrs:{"data-cover":"http://a4.mzstatic.com/us/r1000/014/Music/ea/6f/96/mzi.egqrvlca.170x170-75.jpg"}}),a("section",{attrs:{"data-cover":"http://a3.mzstatic.com/us/r1000/096/Music/1a/86/1f/mzi.dcotnnwo.170x170-75.jpg"}}),a("section",{attrs:{"data-cover":"http://a4.mzstatic.com/us/r1000/094/Music/a8/8b/db/mzi.dyzjtwow.170x170-75.jpg"}}),a("section",{attrs:{"data-cover":"http://a1.mzstatic.com/us/r1000/024/Music/81/54/3b/mzi.cceuzwlz.170x170-75.jpg"}}),a("section",{attrs:{"data-cover":"http://a5.mzstatic.com/us/r1000/103/Music/2f/08/9e/mzi.gxjxokia.170x170-75.jpg"}})])}],P={name:"MainPageBody",props:{},data:function(){return{patchTitle:"Foltok",patchDescription:"Foltot igy meg igy kell rendelni. Nem csak rendezvényekre készítjük őket, hanem egyéni megrendeléseket is fogadunk!",embroideredPatternTitle:"Hímzett minták",embroideredPatternDescription:"Hozott anyagokra tudunk neked hímeztetni, ez meg ez kell hozzá, tök jó lesz.",sweaterTitle:"VIK-es pulcsik",sweaterDescription:"Több féle színben elérhetőek a VIK-es pulóverek. Ha megtetszett valamelyik, a himzo.sch.bme.hu email címen kaphatsz több információt róla.",photo:"../images/picture.jpg"}},components:{}},T=P,F=Object(o["a"])(T,j,M,!1,null,"3195b275",null),E=F.exports,B=function(){var t=this,e=t.$createElement;t._self._c;return t._m(0)},O=[function(){var t=this,e=t.$createElement,a=t._self._c||e;return a("footer",{staticClass:"page-footer font-small special-color-dark pt-4"},[a("div",{staticClass:"container"},[a("p",{staticClass:"float-right row"},[a("a",{attrs:{href:""}},[t._v("Vissza a tetejére")])])]),a("div",{staticClass:"container logo"},[a("a",[a("a",{attrs:{"data-tooltip":"",title:"himzo@sch.bme.hu"}},[a("i",{staticClass:"fas fa-envelope mx-3 fa-2x"})])]),a("a",[a("a",{attrs:{"data-html":"true","data-tooltip":"",title:"<b>Schönherz Kollégium</b> \\n 819. szoba \\n Irinyi József utca 42."}},[a("i",{staticClass:"fas fa-home mx-3 fa-2x"})])]),a("a",{attrs:{href:"https://www.facebook.com/pulcsi.es.foltmekor/"}},[a("i",{staticClass:"fab fa-facebook-f mx-3 fa-2x"})])]),a("div",{staticClass:"footer-copyright text-center py-3"},[t._v("© Pulcsi és FoltMéKör ")])])}],A={name:"Footer",props:{},data:function(){return{scrollBackToTop:"Vissza a  tetejére"}}},$=A,I=Object(o["a"])($,B,O,!1,null,null,null),H=I.exports,q={name:"Index",props:{},components:{Header:g,Title:z,MainPageBody:E,Footer:H}},N=q,R=Object(o["a"])(N,u,p,!1,null,null,null),K=R.exports,S=function(){var t=this,e=t.$createElement,a=t._self._c||e;return a("div",[a("Header"),a("Title"),a("AboutUsBody"),a("Footer")],1)},L=[],D=function(){var t=this,e=t.$createElement,a=t._self._c||e;return a("body",[a("main",{attrs:{role:"main"}},[a("div",{staticClass:"container marketing"},[a("div",{staticClass:"row featurette"},[a("div",{staticClass:"col-md-5"},[a("h2",{staticClass:"featurette-heading"},[t._v(t._s(t.job_title))])]),a("div",{staticClass:"col-md-7"},[a("p",{staticClass:"lead"},[t._v(t._s(t.job_description))])])]),a("hr",{staticClass:"featurette-divider"}),a("div",{staticClass:"row featurette"},[a("div",{staticClass:"col-md-7"},[a("p",{staticClass:"lead"},[t._v(t._s(t.history_description))])]),a("div",{staticClass:"col-md-5"},[a("h2",{staticClass:"featurette-heading"},[t._v(t._s(t.history_title))])])]),a("hr",{staticClass:"featurette-divider"}),a("div",{staticClass:"row featurette"},[a("div",{staticClass:"col-md-5"},[a("h2",{staticClass:"featurette-heading"},[t._v(t._s(t.how_to_join_title))])]),a("div",{staticClass:"col-md-7"},[a("p",{staticClass:"lead"},[t._v(t._s(t.how_to_join_description))])])]),a("hr",{staticClass:"featurette-divider"}),a("div",{staticClass:"text-center"}),a("div",{staticClass:"text-center"},[a("h2",{staticClass:"featurette-heading"},[t._v(t._s(t.team_title))]),a("p",{staticClass:"lead"},[t._v(t._s(t.team_description))])]),a("hr",{staticClass:"featurette-divider"})])])])},U=[],J={name:"AboutUsBody",props:{},data:function(){return{job_description:"Mit csinál a kör, blabla. Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",job_title:"Amivel foglalkozunk",history_description:"Kör története, Pellentesque elit ullamcorper dignissim cras. Faucibus turpis in eu mi bibendum neque egestas. Tellus molestie nunc non blandit massa. Ornare arcu dui vivamus arcu felis bibendum ut. Volutpat diam ut venenatis tellus in. ",history_title:"A kör története",how_to_join_description:"Csatlakozási lehetőség: Auctor elit sed vulputate mi. Ullamcorper eget nulla facilisi etiam dignissim diam quis enim. Dui ut ornare lectus sit. Lobortis feugiat vivamus at augue eget arcu dictum varius duis.",how_to_join_title:"Csatlakozási lehetőség",team_title:"Tagok",team_description:"Valami szép leírás rólunk + csapatkép"}}},V=J,W=Object(o["a"])(V,D,U,!1,null,"b8fdd0a6",null),Y=W.exports,G={name:"AboutUs",props:{},components:{Header:g,Title:z,AboutUsBody:Y,Footer:H}},X=G,Z=Object(o["a"])(X,S,L,!1,null,null,null),Q=Z.exports,tt=function(){var t=this,e=t.$createElement;t._self._c;return t._m(0)},et=[function(){var t=this,e=t.$createElement,s=t._self._c||e;return s("div",[s("header",[s("link",{attrs:{href:"signin_reg.css",rel:"stylesheet"}})]),s("body",{staticClass:"text-center"},[s("form",{staticClass:"form-signin"},[s("img",{staticClass:"rounded-circle",attrs:{src:a("6ee4"),alt:"",width:"100",height:"100"}}),s("h1",{staticClass:"h3 mb-3 font-weight-normal"},[t._v("Bejelentkezés")]),s("label",{staticClass:"sr-only",attrs:{for:"inputEmail"}},[t._v("E-mail cím")]),s("input",{staticClass:"form-control",attrs:{type:"email",id:"inputEmail",placeholder:"E-mail cím",required:"",autofocus:""}}),s("label",{staticClass:"sr-only",attrs:{for:"inputPassword"}},[t._v("Jelszó")]),s("input",{staticClass:"form-control",attrs:{type:"password",id:"inputPassword",placeholder:"Jelszó",required:""}}),s("button",{staticClass:"btn btn-lg btn-primary btn-block",attrs:{type:"submit"}},[t._v("Bejelentkezés")]),s("label",[t._v(" Nincs fiókod? "),s("a",{attrs:{href:"index#/registration"}},[t._v("Regisztrálj")])]),s("p",{staticClass:"mt-5 mb-3 text-muted"},[t._v("© Pulcsi és FoltMéKör")])])])])}],at={name:"SignIn",props:{}},st=at,rt=Object(o["a"])(st,tt,et,!1,null,null,null),it=rt.exports,lt=function(){var t=this,e=t.$createElement;t._self._c;return t._m(0)},nt=[function(){var t=this,e=t.$createElement,s=t._self._c||e;return s("div",[s("header",[s("link",{attrs:{href:"signin_reg.css",rel:"stylesheet"}})]),s("body",{staticClass:"text-center"},[s("form",{staticClass:"form-register"},[s("img",{staticClass:"rounded-circle",attrs:{src:a("6ee4"),alt:"",width:"100",height:"100"}}),s("h1",{staticClass:"h3 mb-3 font-weight-normal"},[t._v("Regisztrálás")]),s("label",{staticClass:"sr-only",attrs:{for:"inputEmail"}},[t._v("Név")]),s("input",{staticClass:"form-control",attrs:{type:"name",id:"inputName",placeholder:"Név",required:"",autofocus:""}}),s("label",{staticClass:"sr-only",attrs:{for:"inputEmail"}},[t._v("E-mail cím")]),s("input",{staticClass:"form-control",attrs:{type:"email",id:"inputEmail",placeholder:"E-mail cím",required:"",autofocus:""}}),s("input",{staticClass:"form-control",attrs:{type:"uni",id:"inputUni",placeholder:"Egyetem",required:"",autofocus:""}}),s("label",{staticClass:"sr-only",attrs:{for:"inputUni"}},[t._v("Egyetem")]),s("label",{staticClass:"sr-only",attrs:{for:"inputPassword"}},[t._v("Jelszó")]),s("input",{staticClass:"form-control",attrs:{type:"password",id:"inputPassword",placeholder:"Jelszó",required:"",autofocus:""}}),s("label",{staticClass:"sr-only",attrs:{for:"inputPassword2"}},[t._v("Jelszó2")]),s("input",{staticClass:"form-control",attrs:{type:"password",id:"inputPassword2",placeholder:"Jelszó megerősítése",required:"",autofocus:""}}),s("button",{staticClass:"btn btn-lg btn-primary btn-block",attrs:{type:"submit"}},[t._v("Regisztrálás")]),s("label",[t._v(" Már van fiókod? "),s("a",{attrs:{href:"index.html#/signin"}},[t._v("Jelenkezz be")])]),s("p",{staticClass:"mt-5 mb-3 text-muted"},[t._v("© Pulcsi és FoltMéKör")])])])])}],ot={name:"Registration",props:{}},ct=ot,dt=Object(o["a"])(ct,lt,nt,!1,null,null,null),mt=dt.exports,ut=function(){var t=this,e=t.$createElement,a=t._self._c||e;return a("div",[a("Header"),a("Title"),a("MembersBody"),a("Footer")],1)},pt=[],vt=function(){var t=this,e=t.$createElement,a=t._self._c||e;return a("body",{staticClass:"bg-light"},[a("main",{attrs:{role:"main"}},[a("div",{staticClass:"jumbotron"},[a("div",{staticClass:"container"},[a("h1",{staticClass:"display-3"},[t._v(t._s(t.membersTitle))]),a("p",[t._v(t._s(t.membersDescription))])])]),a("div",{staticClass:"container"},[a("div",{staticClass:"row"},[a("input",{staticClass:"form-control form-control-dark w-75",attrs:{type:"text",placeholder:"Search","aria-label":"Search"}}),a("hr",{staticClass:"mb-4"}),a("button",{staticClass:"btn btn-primary",attrs:{type:"submit"}},[t._v(" "+t._s(t.searchButton)+" ")])]),a("div",{staticClass:"table-responsive"},[a("table",{staticClass:"table table-striped table-sm"},[a("thead",[a("tr",[a("th",[t._v(t._s(t.usernameTitle))]),a("th",[t._v(t._s(t.emailTitle))]),a("th",[t._v(t._s(t.himzoMemberTitle))]),a("th",[t._v(t._s(t.adminTitle))])])]),a("tbody",[a("tr",t._b({},"tr",t.person in t.people,!1),[a("td",[t._v(t._s(t.person.name))]),a("td",[t._v(t._s(t.person.email))]),a("td",[a("input",{directives:[{name:"model",rawName:"v-model",value:t.himzoMembers,expression:"himzoMembers"}],attrs:{type:"checkbox",id:t.person.id},domProps:{value:t.person.name,checked:Array.isArray(t.himzoMembers)?t._i(t.himzoMembers,t.person.name)>-1:t.himzoMembers},on:{change:function(e){var a=t.himzoMembers,s=e.target,r=!!s.checked;if(Array.isArray(a)){var i=t.person.name,l=t._i(a,i);s.checked?l<0&&(t.himzoMembers=a.concat([i])):l>-1&&(t.himzoMembers=a.slice(0,l).concat(a.slice(l+1)))}else t.himzoMembers=r}}})]),a("td",[a("input",{directives:[{name:"model",rawName:"v-model",value:t.admins,expression:"admins"}],attrs:{type:"checkbox",id:t.person.id},domProps:{value:t.person.name,checked:Array.isArray(t.admins)?t._i(t.admins,t.person.name)>-1:t.admins},on:{change:function(e){var a=t.admins,s=e.target,r=!!s.checked;if(Array.isArray(a)){var i=t.person.name,l=t._i(a,i);s.checked?l<0&&(t.admins=a.concat([i])):l>-1&&(t.admins=a.slice(0,l).concat(a.slice(l+1)))}else t.admins=r}}})])])])]),a("span",[t._v("Körtagok: "+t._s(t.himzoMembers))]),a("span",[t._v("Adminok: "+t._s(t.admins))])]),a("div",{staticClass:"row"},[a("hr",{staticClass:"mb-4"}),a("button",{staticClass:"btn btn-primary",attrs:{type:"submit"}},[t._v(" "+t._s(t.saveButton)+" ")])])])])])},ft=[],bt={name:"MembersBody",props:{},data:function(){return{membersTitle:"Tagok",membersDescription:"Valami szép leírás rólunk",usernameTitle:"Név",emailTitle:"E-mail cím",adminTitle:"Admin",himzoMemberTitle:"Körtag",username:"Önnönmagam Én Vagykok",email:"email@cim.hu",adminOption:"admin",himzoMemberOption:"körtag",saveButton:"Mentés",searchButton:"Keresés",admins:[],himzoMembers:[],people:[{name:"Dörner Virág",email:"virag@dorner.hu",id:"elso"},{name:"Nagy Krisztina",email:"krisztina@nagy.hu",id:"masodik"},{name:"Demjén Klaudia",email:"klaudia@demjen.hu",id:"harmadik"},{name:"Sinkó Sára",email:"sara@sinko.hu",id:"negyedik"}]}}},ht=bt,_t=Object(o["a"])(ht,vt,ft,!1,null,"201cb2f9",null),gt=_t.exports,yt={name:"MembersBody",props:{},components:{Header:g,Title:z,MembersBody:gt,Footer:H}},Ct=yt,xt=Object(o["a"])(Ct,ut,pt,!1,null,null,null),kt=xt.exports,wt=function(){var t=this,e=t.$createElement,a=t._self._c||e;return a("div",[a("Header"),a("ProfileBody"),a("Footer")],1)},zt=[],jt=function(){var t=this,e=t.$createElement,a=t._self._c||e;return a("body",{staticClass:"bg-light"},[a("main",{attrs:{role:"main"}},[a("form",{staticClass:"needs-validation",attrs:{novalidate:""}},[a("div",{staticClass:"jumbotron"},[a("div",{staticClass:"container"},[a("h1",{staticClass:"display-3"},[t._v(t._s(t.username))])])]),a("div",{staticClass:"container"},[a("div",{staticClass:"row"},[a("div",{staticClass:"col-md-6 mb-3"},[a("label",{attrs:{for:"email"}},[t._v(t._s(t.email))]),a("input",{staticClass:"form-control",attrs:{type:"text",id:"email",placeholder:"",value:"",required:""}})]),a("div",{staticClass:"invalid-feedback"},[t._v(" Kérlek add meg az e-mail címed! ")])]),a("div",{staticClass:"row"},[a("div",{staticClass:"col-md-6 mb-3"},[a("label",{attrs:{for:"university"}},[t._v(t._s(t.university))]),a("input",{staticClass:"form-control",attrs:{type:"text",id:"university",placeholder:"",value:""}})])]),a("div",{staticClass:"row"},[a("div",{staticClass:"col-md-6 mb-3"},[a("label",{attrs:{for:"newPassword"}},[t._v(t._s(t.newPassword))]),a("input",{staticClass:"form-control",attrs:{type:"text",id:"newPassword",placeholder:"",value:"",required:""}})]),a("div",{staticClass:"invalid-feedback"},[t._v(" Kérlek add meg az új jelszavad! ")])]),a("div",{staticClass:"row"},[a("div",{staticClass:"col-md-6 mb-3"},[a("label",{attrs:{for:"newPasswordAgain"}},[t._v(t._s(t.newPasswordAgain))]),a("input",{staticClass:"form-control",attrs:{type:"text",id:"newPasswordAgain",placeholder:"",value:"",required:""}})]),a("div",{staticClass:"invalid-feedback"},[t._v(" Kérlek add meg mégegyszer az új jelszavad! ")])]),a("div",{staticClass:"row"},[a("div",{staticClass:"col-md-6 mb-3"},[a("label",{attrs:{for:"oldPassword"}},[t._v(t._s(t.oldPassword))]),a("input",{staticClass:"form-control",attrs:{type:"text",id:"oldPassword",placeholder:"",value:"",required:""}})]),a("div",{staticClass:"invalid-feedback"},[t._v(" Kérlek add meg a régi jelszavad! ")])]),a("div",{staticClass:"row"},[a("hr",{staticClass:"mb-4"}),a("button",{staticClass:"btn btn-primary",attrs:{type:"reset"}},[t._v(" "+t._s(t.cancelButton)+" ")]),a("button",{staticClass:"btn btn-primary",attrs:{type:"submit"}},[t._v(" "+t._s(t.saveButton)+" ")])])])])])])},Mt=[],Pt={name:"ProfileBody",props:{},data:function(){return{username:"Önnönmagam",email:"E-mail cím",university:"Egyetem",newPassword:"Új jelszó",newPasswordAgain:"Új jelszó mégegyszer",oldPassword:"Régi jelszó",cancelButton:"Mégse",saveButton:"Adatok mentése"}}},Tt=Pt,Ft=Object(o["a"])(Tt,jt,Mt,!1,null,"95a6d7da",null),Et=Ft.exports,Bt={name:"Profile",props:{},components:{Header:g,ProfileBody:Et,Footer:H}},Ot=Bt,At=Object(o["a"])(Ot,wt,zt,!1,null,null,null),$t=At.exports,It=function(){var t=this,e=t.$createElement,a=t._self._c||e;return a("div",[a("Header"),a("PatchFormBody"),a("Footer")],1)},Ht=[],qt=function(){var t=this,e=t.$createElement,a=t._self._c||e;return a("body",{staticClass:"bg-light"},[a("main",{attrs:{role:"main"}},[a("div",{staticClass:"jumbotron"},[a("div",{staticClass:"container"},[a("h1",{staticClass:"display-3"},[t._v(t._s(t.patchFormTitle))]),a("p",[t._v(t._s(t.patchFormDescription))])])]),a("div",{staticClass:"container"},[a("div",{staticClass:"row"},[a("div",{staticClass:"col-md-8 order-md-1"},[a("form",{staticClass:"needs-validation",attrs:{novalidate:""}},[a("div",{staticClass:"row"}),a("div",{staticClass:"col-md-6 mb-3"},[a("input",{staticClass:"custom-file-input",attrs:{type:"file",id:"customFile"}}),a("label",{staticClass:"custom-file-label",attrs:{for:"customFile"}},[t._v(t._s(t.chooseFile))])]),a("div",{staticClass:"row"},[a("div",{staticClass:"col-md-3 mb-3"},[a("label",{attrs:{for:"cc-name"}},[t._v(t._s(t.size))]),a("input",{staticClass:"form-control",attrs:{type:"number",id:"size",placeholder:"",required:""}})]),a("div",{staticClass:"col-md-3 mb-3"},[a("label",{attrs:{for:"cc-name"}},[t._v(t._s(t.amount))]),a("input",{staticClass:"form-control",attrs:{type:"number",id:"amount",placeholder:"",required:""}})]),a("div",{staticClass:"col-md-4 mb-3"},[a("label",{attrs:{for:"cc-number"}},[t._v(t._s(t.deadline))]),a("input",{staticClass:"form-control",attrs:{type:"date",id:"deadline",placeholder:"",required:""}})])]),a("div",{staticClass:"row"},[a("div",{staticClass:"col-md-6 mb-3"},[a("label",{attrs:{for:"firstName"}},[t._v(t._s(t.fonts))]),a("input",{staticClass:"form-control",attrs:{type:"text",id:"patternLocation",placeholder:"",value:"",required:""}}),a("div",{staticClass:"invalid-feedback"},[t._v(" Kérlek add meg a mintában használt fontot! ")])])]),a("div",{staticClass:"row"},[a("div",{staticClass:"col-md-6 mb-3"},[a("label",{attrs:{for:"firstName"}},[t._v(t._s(t.comment))]),a("input",{staticClass:"form-control",attrs:{type:"text",id:"patternLocation",placeholder:"",value:""}})])]),a("div",{staticClass:"row"},[a("hr",{staticClass:"mb-4"}),a("button",{staticClass:"btn btn-primary",attrs:{type:"reset"}},[t._v(" "+t._s(t.cancelButton)+" ")]),a("button",{staticClass:"btn btn-primary",attrs:{type:"submit"}},[t._v(" "+t._s(t.orderButton)+" ")])])])])])])])])},Nt=[],Rt={name:"PatchFormBody",props:{},data:function(){return{patchFormTitle:"Folt rendelés",patchFormDescription:"Foltot így meg így tudsz rendelni, ezt meg ezt kell tudni róla.",chooseFile:"Válaszd ki a fájlt",pattern:"Minta",patternLocation:"Minta helye",size:"Méret (cm)",amount:"Mennyiség",deadline:"Határidő",fonts:"Mintában használt fontok",comment:"Megjegyzés",cancelButton:"Mégse",orderButton:"Megrendelem"}}},Kt=Rt,St=Object(o["a"])(Kt,qt,Nt,!1,null,"0269bf0e",null),Lt=St.exports,Dt={name:"Index",props:{},components:{Header:g,PatchFormBody:Lt,Footer:H}},Ut=Dt,Jt=Object(o["a"])(Ut,It,Ht,!1,null,null,null),Vt=Jt.exports,Wt=function(){var t=this,e=t.$createElement,a=t._self._c||e;return a("div",[a("Header"),a("PatternFormBody"),a("Footer")],1)},Yt=[],Gt=function(){var t=this,e=t.$createElement,a=t._self._c||e;return a("body",{staticClass:"bg-light"},[a("main",{attrs:{role:"main"}},[a("div",{staticClass:"jumbotron"},[a("div",{staticClass:"container"},[a("h1",{staticClass:"display-3"},[t._v(t._s(t.patternFormTitle))]),a("p",[t._v(t._s(t.patternFormDescription))])])]),a("div",{staticClass:"container"},[a("div",{staticClass:"row"},[a("div",{staticClass:"col-md-8 order-md-1"},[a("form",{staticClass:"needs-validation",attrs:{novalidate:""}},[a("div",{staticClass:"row"},[a("div",{staticClass:"col-md-6 mb-3"},[a("input",{staticClass:"custom-file-input",attrs:{type:"file",id:"customFile"}}),a("label",{staticClass:"custom-file-label",attrs:{for:"customFile"}},[t._v(t._s(t.chooseFile))])])]),a("div",{staticClass:"row"},[a("div",{staticClass:"col-md-3 mb-3"},[a("label",{attrs:{for:"cc-name"}},[t._v(t._s(t.size))]),a("input",{staticClass:"form-control",attrs:{type:"number",id:"size",placeholder:"",required:""}})]),a("div",{staticClass:"col-md-3 mb-3"},[a("label",{attrs:{for:"cc-name"}},[t._v(t._s(t.amount))]),a("input",{staticClass:"form-control",attrs:{type:"number",id:"amount",placeholder:"",required:""}})]),a("div",{staticClass:"col-md-4 mb-3"},[a("label",{attrs:{for:"cc-number"}},[t._v(t._s(t.deadline))]),a("input",{staticClass:"form-control",attrs:{type:"date",id:"deadline",placeholder:"",required:""}})])]),a("div",{staticClass:"row"},[a("div",{staticClass:"col-md-6 mb-3"},[a("label",{attrs:{for:"firstName"}},[t._v(t._s(t.patternLocation))]),a("input",{staticClass:"form-control",attrs:{type:"text",id:"patternLocation",placeholder:"",value:"",required:""}}),a("div",{staticClass:"invalid-feedback"},[t._v(" Kérlek add meg a minta helyét! ")])])]),a("div",{staticClass:"row"},[a("div",{staticClass:"col-md-6 mb-3"},[a("label",{attrs:{for:"font"}},[t._v(t._s(t.fonts))]),a("input",{staticClass:"form-control",attrs:{type:"text",id:"font",placeholder:"",value:"",required:""}}),a("div",{staticClass:"invalid-feedback"},[t._v(" Kérlek add meg a mintában használt fontot! ")])])]),a("div",{staticClass:"row"},[a("div",{staticClass:"col-md-6 mb-3"},[a("label",{attrs:{for:"firstName"}},[t._v(t._s(t.comment))]),a("input",{staticClass:"form-control",attrs:{type:"text",id:"patternLocation",placeholder:"",value:""}})])]),a("div",{staticClass:"row"},[a("hr",{staticClass:"mb-4"}),a("button",{staticClass:"btn btn-primary",attrs:{type:"reset"}},[t._v(" "+t._s(t.cancelButton)+" ")]),a("button",{staticClass:"btn btn-primary",attrs:{type:"submit"}},[t._v(" "+t._s(t.orderButton)+" ")])])])])])])])])},Xt=[],Zt={name:"PatternFormBody",props:{},data:function(){return{patternFormTitle:"Minta hímeztetése",patternFormDescription:"Mintát hozott anyagra így meg amúgy tudsz hímeztetni.",chooseFile:"Válaszd ki a fájlt",pattern:"Minta",size:"Méret (cm)",amount:"Mennyiség",deadline:"Határidő",fonts:"Mintában használt fontok",comment:"Megjegyzés",cancelButton:"Mégse",orderButton:"Megrendelem"}}},Qt=Zt,te=Object(o["a"])(Qt,Gt,Xt,!1,null,"344afdf4",null),ee=te.exports,ae={name:"Index",props:{},components:{Header:g,PatternFormBody:ee,Footer:H}},se=ae,re=Object(o["a"])(se,Wt,Yt,!1,null,null,null),ie=re.exports,le=function(){var t=this,e=t.$createElement,a=t._self._c||e;return a("div",[a("Header"),a("Title"),a("AllOrderBody"),a("Footer")],1)},ne=[],oe=function(){var t=this,e=t.$createElement,a=t._self._c||e;return a("body",[a("main",{staticClass:"container",attrs:{role:"main"}},[t._l(t.orders,(function(t){return a("order",{key:t.id,attrs:{order:t}})})),a("hr",{staticClass:"featurette-divider"})],2)])},ce=[],de=function(){var t=this,e=t.$createElement,a=t._self._c||e;return a("div",{staticClass:"order"},[a("div",{staticClass:"jumbotron"},[a("div",[a("h1",[t._v(t._s(t.order.name))]),a("h2",[t._v(t._s(t.order.amount)+" db "+t._s(t.order.productType))])]),t._m(0),a("div",[t._m(1),a("p",{staticClass:"lead"},[t._v(t._s(t.order.time))])]),a("a",{staticClass:"btn btn-lg btn-primary",attrs:{href:"/docs/4.3/components/navbar/",role:"button"}},[t._v("Rendelés adatai »")]),a("a",{staticClass:"btn btn-lg btn-primary",attrs:{href:"/docs/4.3/components/navbar/",role:"button"}},[t._v("Mentés")])])])},me=[function(){var t=this,e=t.$createElement,a=t._self._c||e;return a("select",{staticClass:"fa",attrs:{name:"sample",id:"sample"}},[a("option",{attrs:{value:"fas fa-cog "}},[t._v(" Rendelés feldolgozás alatt")]),a("option",{attrs:{value:"fas fa-clock "}},[t._v(" Folyamatban")]),a("option",{attrs:{value:"fas fa-check-circle "}},[t._v(" Kész")]),a("option",{attrs:{value:"fas fa-times-circle "}},[t._v(" Rendelés elutasítva")])])},function(){var t=this,e=t.$createElement,a=t._self._c||e;return a("div",{staticClass:"form-group shadow-textarea"},[a("textarea",{staticClass:"form-control z-depth-1",attrs:{id:"exampleFormControlTextarea6",rows:"3"}})])}],ue={name:"order",props:["order"]},pe=ue,ve=Object(o["a"])(pe,de,me,!1,null,null,null),fe=ve.exports,be={name:"AllOrderBody",props:{},components:{order:fe},data:function(){return{orders:[{id:1,name:"Sinkó Sára",statusIcon:"fas fa-check-circle  fa-3x",amount:"51",productType:"folt",statusText:"Kész",message:"Jöhetsz érte.",time:"2025-03-03"},{id:2,name:"Egy Másik Ember",statusIcon:"fas fa-clock  fa-3x",amount:"5",productType:"minta",statusText:"Folyamatban",message:"A mintád fele van kész",time:"2018-03-03"},{id:3,name:"Gutai Auguszta Matild",statusIcon:"fas fa-times-circle  fa-3x",amount:"10",productType:"folt",statusText:"Rendelés elutasítva",message:"Jelenleg nem fogadunk rendeléseket.",time:"2019-10-13"},{id:4,name:"Random Megrendelő",statusIcon:"fas fa-cog  fa-3x",amount:"450",productType:"folt",statusText:"Rendelés feldolgozás alatt",message:"",time:""}]}}},he=be,_e=Object(o["a"])(he,oe,ce,!1,null,"efc239a0",null),ge=_e.exports,ye={name:"AllOrder",props:{},components:{Header:g,Title:z,AllOrderBody:ge,Footer:H}},Ce=ye,xe=Object(o["a"])(Ce,le,ne,!1,null,null,null),ke=xe.exports,we=function(){var t=this,e=t.$createElement,a=t._self._c||e;return a("div",[a("Header"),a("UserOrderBody"),a("Footer")],1)},ze=[],je=function(){var t=this,e=t.$createElement,a=t._self._c||e;return a("body",[a("main",{attrs:{role:"main"}},[a("div",{staticClass:"jumbotron"},[a("div",{staticClass:"container"},[a("h1",{staticClass:"display-3"},[t._v(t._s(t.title))]),a("p",[t._v(t._s(t.titleDescription))]),a("p",[a("a",{staticClass:"btn btn-primary btn-lg",attrs:{href:"#",role:"button"}},[t._v(" "+t._s(t.moreButton)+"» ")])])])])]),a("main",{staticClass:"container",attrs:{role:"main"}},[a("hr",{staticClass:"featurette-divider"}),t._l(t.orders,(function(t){return a("userorder",{key:t.id,attrs:{order:t}})})),a("hr",{staticClass:"featurette-divider"})],2)])},Me=[],Pe=function(){var t=this,e=t.$createElement,a=t._self._c||e;return a("div",{staticClass:"order"},[a("div",{staticClass:"jumbotron"},[a("div",{staticClass:"icon"},[a("i",{class:t.order.statusIcon})]),a("div",{staticClass:"status"},[a("h2",[t._v(t._s(t.order.amount)+" db "+t._s(t.order.productType))]),a("h1",[t._v(t._s(t.order.statusText))])]),a("div",[a("p",{staticClass:"lead"},[t._v(t._s(t.order.message))]),a("p",{staticClass:"lead"},[t._v(t._s(t.order.time))])]),a("a",{staticClass:"btn btn-lg btn-primary",attrs:{href:"/docs/4.3/components/navbar/",role:"button"}},[t._v("Rendelés adatai »")])])])},Te=[],Fe={name:"userorder",props:["order"]},Ee=Fe,Be=Object(o["a"])(Ee,Pe,Te,!1,null,null,null),Oe=Be.exports,Ae={name:"ProfileBody",props:{},components:{userorder:Oe},data:function(){return{username:"Önnönmagam",email:"E-mail cím",university:"Egyetem",newPassword:"Új jelszó",newPasswordAgain:"Új jelszó mégegyszer",oldPassword:"Régi jelszó",cancelButton:"Mégse",saveButton:"Adatok mentése",orders:[{id:1,statusIcon:"fas fa-check-circle  fa-3x",amount:"51",productType:"folt",statusText:"Kész",message:"Jöhetsz érte.",time:"2025-03-03"},{id:2,statusIcon:"fas fa-clock  fa-3x",amount:"5",productType:"minta",statusText:"Folyamatban",message:"A mintád fele van kész",time:"2018-03-03"},{id:3,statusIcon:"fas fa-times-circle  fa-3x",amount:"10",productType:"folt",statusText:"Rendelés elutasítva",message:"Jelenleg nem fogadunk rendeléseket.",time:"2019-10-13"},{id:4,statusIcon:"fas fa-cog  fa-3x",amount:"450",productType:"folt",statusText:"Rendelés feldolgozás alatt",message:"",time:""}]}}},$e=Ae,Ie=Object(o["a"])($e,je,Me,!1,null,"29f1fd92",null),He=Ie.exports,qe={name:"Index",props:{},components:{Header:g,UserOrderBody:He,Footer:H}},Ne=qe,Re=Object(o["a"])(Ne,we,ze,!1,null,null,null),Ke=Re.exports;s["a"].use(m["a"]);var Se=new m["a"]({routes:[{path:"/",name:"Index",component:K},{path:"/aboutus",name:"AboutUs",component:Q},{path:"/signin",name:"SignIn",component:it},{path:"/registration",name:"Registration",component:mt},{path:"/patchform",name:"PatchForm",component:Vt},{path:"/patternform",name:"PatternForm",component:ie},{path:"/profile",name:"Profile",component:$t},{path:"/allorder",name:"AllOrder",component:ke},{path:"/members",name:"Members",component:kt},{path:"/userorder",name:"UserOrder",component:Ke}]}),Le=(a("b0c0"),function(){var t=this,e=t.$createElement,a=t._self._c||e;return a("div",{directives:[{name:"coverflow",rawName:"v-coverflow"}],staticClass:"coverflow"},t._l(t.coverList,(function(t,e){return a("img",{key:e,attrs:{src:t.cover}})})),0)}),De=[];a("a9e3"),a("c975"),a("e25e");function Ue(t,e,a,s){e=Math.max(Math.min(e,90),-90),s-=5,t.style["-webkit-perspective"]=t.style["perspective"]=t.style["-moz-perspective"]=a+"px",t.style["-webkit-transform"]=t.style["transform"]="rotateY("+e+"deg) translateZ("+s+"px)"}function Je(t,e,a,s,r,i,l,n,o){for(var c=.5*(l-t)-e*(r+1)-.5*t,d=0;d<=r;d++)s[d].style.left=a+d*e+e+"px",s[d].style.marginLeft=c+"px",s[d].style["-webkit-filter"]="brightness(0.65)",s[d].style.zIndex=d+1,Ue(s[d],i?0:10*(r-d)+45,300,i?10*-(r-d):30*-(r-d)-20);if(s[r].style["-webkit-filter"]="none",s[r].style.marginLeft=c+.5*t+"px",s[r].style.zIndex=s.length,n.style.visibility="hidden",o.context.coverList[r].title){n.style.visibility="visible";var m=o.context.coverList[r].title;n.innerHTML=m,n.style.left=a+r*e+e+10+"px",n.style.marginLeft=c+.5*t+"px"}Ue(s[r],0,0,5);for(var u=r+1;u<s.length;++u)s[u].style.left=a+u*e+e+"px",s[u].style.marginLeft=c+t+"px",s[u].style["-webkit-filter"]="brightness(0.7)",s[u].style.zIndex=s.length-u,Ue(s[u],i?0:10*(r-u)-45,300,i?10*(r-u):30*(r-u)-20);o.context.coverIndex!==r&&o.context.handleChange(r)}var Ve={bind:function(t,e,a){var s=parseInt(a.context.coverWidth),r=parseInt(a.context.coverSpace),i=a.context.coverShadow,l=a.context.bgColor,n=a.context.coverFlat,o=a.context.width,c=a.context.index;a.context.coverIndex=c;for(var d,m=Math.max(a.context.coverHeight,a.context.coverWidth),u=[],p=0;p<t.childNodes.length;++p)u.push(t.childNodes[p]);for(var v=0;v<u.length;v++)u[v].style.position="absolute",u[v].style.width=s+"px",u[v].style.height="auto",u[v].style.bottom="60px",u[v].style.transition="transform .4s ease, margin-left .4s ease, -webkit-filter .4s ease";t.style.overflowX="hidden",t.style.backgroundColor=l;var f=document.createElement("SPAN");if(i||(f.className="coverflow-title-box",f.style.position="absolute",f.style.width=s-20+"px",f.style.height="20px",f.style.lineHeight="20px",f.style.fontSize="14px",f.style.padding="0 3px",f.style.color="#222",f.style.background="#ddd",f.style.borderRadius="10px",f.style.fontWeight="normal",f.style.fontFamily='"Helvetica Neue", Helvetica, Arial, sans-serif',f.style.bottom="28px",f.style.textAlign="center",f.style.display="block",t.appendChild(f)),Ue(t,0,600,0),d=document.createElement("DIV"),d.style.width=2*o+"px",d.style.height="1px",t.appendChild(d),t.style.width=o+"px",i){t.style.height=2*m+80+"px",t.style["-webkit-perspective-origin"]=t.style["perspective-origin"]=t.style["-moz-perspective-origin"]="50% 25%";for(var b=0;b<u.length;b++)u[b].style.bottom=20+m+"px",u[b].style["-webkit-box-reflect"]="below 0 -webkit-gradient(linear, 30% 20%, 30% 100%, from(transparent), color-stop(0.3, transparent), to(rgba(0, 0, 0, 0.8)))"}else t.style.height=m+80+"px";function h(e){if(e.target&&"IMG"===e.target.nodeName.toUpperCase()){var i=u.indexOf(e.target);Je(s,r,t.scrollLeft,u,i,n,parseInt(t.style.width),f,a)}}t.style.position="relative",Je(s,r,t.scrollLeft,u,c,n,parseInt(t.style.width),f,a),t.addEventListener("click",h,!1),t.$destroy=function(){t.removeEventListener("click",h,!1)}},unbind:function(t){t.$destroy()}},We={name:"coverflow",data:function(){return{coverIndex:0}},props:{coverList:{type:Array,required:!0},width:{type:Number,default:980},bgColor:{type:String,default:"transparent"},index:{type:Number,default:0},coverWidth:{type:Number,default:100},coverHeight:{type:Number,default:0},coverSpace:{type:Number,default:50},coverShadow:{type:Boolean,default:!1},coverFlat:{type:Boolean,default:!1}},methods:{handleChange:function(t){this.coverIndex=t,this.$emit("change",t)}},directives:{coverflow:Ve}},Ye=We,Ge=Object(o["a"])(Ye,Le,De,!1,null,null,null),Xe=Ge.exports;Xe.install=function(t){t.component(Xe.name,Xe)};var Ze=Xe;s["a"].use(Ze),s["a"].config.productionTip=!1,new s["a"]({render:function(t){return t(d)},router:Se}).$mount("#app")},"6ee4":function(t,e,a){t.exports=a.p+"img/logo.d226b55b.png"},"7de0":function(t,e,a){},b1c5:function(t,e,a){"use strict";var s=a("7de0"),r=a.n(s);r.a}});
//# sourceMappingURL=app.cb6d566a.js.map