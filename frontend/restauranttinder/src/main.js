import Vue from 'vue'
import App from './App.vue'
import router from "./router";
import BootstrapVue from 'bootstrap-vue';
import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
import Vuelidate from 'vuelidate'
import * as VueGoogleMaps from 'vue2-google-maps';

Vue.config.productionTip = false
Vue.use(BootstrapVue)
Vue.use(Vuelidate);
Vue.use(VueGoogleMaps, {
  load: {
    key:`${process.env.VUE_APP_GOOGLE_KEY}`, 
    libraries: "places"
  }
});

new Vue({
  router,
  render: h => h(App),
}).$mount('#app')
