import Vue from 'vue'
import App from './App.vue'
import './registerServiceWorker'
import router from './router'
import VueSweetalert2 from 'vue-sweetalert2'
import Swal from 'sweetalert2/dist/sweetalert2.js'
import VMask from 'v-mask'

import './assets/main.css'

import { BootstrapVue, IconsPlugin } from 'bootstrap-vue'

import 'bootstrap/dist/css/bootstrap.css'
import 'bootstrap-vue/dist/bootstrap-vue.css'
import 'sweetalert2/dist/sweetalert2.all'

Vue.use(BootstrapVue)
Vue.use(IconsPlugin)
Vue.use(VueSweetalert2)
Vue.use(VMask)

const Toast = Swal.mixin({
  toast: true,
  position: 'top-end',
  timer: 3000,
  timerProgressBar: true,
  showConfirmButton: false
})
window.Toast = Toast

Vue.config.productionTip = false

new Vue({
  router,
  render: h => h(App)
}).$mount('#app')
