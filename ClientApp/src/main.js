import Vue from 'vue'
import App from './App.vue'
import router from './router.js'
import easyqrcode from 'easyqrcodejs'

Vue.config.productionTip = false

new Vue({router, easyqrcode,
  render: h => h(App),
}).$mount('#app')

Object.defineProperty(Vue.prototype, '$easyqrcode', { value: easyqrcode });