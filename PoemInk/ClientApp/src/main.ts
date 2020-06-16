import 'core-js/stable';
import 'regenerator-runtime/runtime';
import Vue from 'vue';
import store from './store/store';
import axios from 'axios';
import vuetify from './plugins/vuetify';
import App from './App.vue';
import router from './router';
import './plugins/base';
import './registerServiceWorker';
import dateFilter from '@/filters/date.filter';

Vue.config.productionTip = false;

Vue.filter('date', dateFilter);

new Vue({
  vuetify,
  router,
  store,
  render: (h) => h(App),
}).$mount('#app');

axios.interceptors.request.use((config: any) => {

  const authToken = store.getters['auth/authToken'];
  if (authToken) {
    config.headers.Authorization = `Bearer ${authToken}`;
  }
  return config;
}, (err: any) => {
  return Promise.reject(err);
});
