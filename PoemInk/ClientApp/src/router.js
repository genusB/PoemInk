import Vue from 'vue'
import Router from 'vue-router'

Vue.use(Router)

export default new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    {
      path: '/',
      name: 'home',
      component: () => import('./components/Home.vue'),
    },
    {
      path: '/create',
      name: 'create',
      component: () => import('./components/create/Create.vue'),
    },
    {
      path: '/generate',
      name: 'generate',
      component: () => import('./components/generate/Generate.vue'),
    },
    {
        path: '/inspire',
        name: 'inspire',
        component: () => import('./components/inspire/Inspire.vue'),
      },
  ],
})
