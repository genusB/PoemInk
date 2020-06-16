import Vue from 'vue';
import Router from 'vue-router';
import store from './store/store';

Vue.use(Router);

const router = new Router({
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
    {
      path: '/register',
      name: 'registrationForm',
      component: () => import('./views/account/RegistrationForm.vue'),
    },
    {
      path: '/login',
      name: 'loginForm',
      component: () => import('./views/account/LoginForm.vue'),
    },
    {
      path: '/facebook-login',
      name: 'facebookLogin',
      component: () => import('./views/account/FacebookLogin.vue'),
    },
    {
      path: '/dashboard',
      component: () => import('./views/dashboard/Root.vue'),
      children: [
        {
          path: 'home',
          component: () => import('./views/dashboard/Home.vue'),
          // a meta field
          meta: { requiresAuth: true },
        },
      ],
    },
  ],
});

router.beforeEach((to: any, from: any, next: any) => {
  if (to.matched.some((record: any) => record.meta.requiresAuth)) {
    // this route requires auth, check if logged in
    // if not, redirect to login page.
    if (!store.getters['auth/isAuthenticated']) {
      next({
        path: '/login',
        query: { redirect: to.fullPath },
      });
    } else {
      next();
    }
  } else {
    next(); // make sure to always call next()!
  }
});

export default router;
