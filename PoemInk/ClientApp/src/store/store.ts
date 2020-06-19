import Vue from 'vue';
import Vuex from 'vuex';
import auth from './modules/auth';
import user from './modules/user';
import generatedPoem from './modules/generatedPoem';
import createdPoem from './modules/createdPoem';

Vue.use(Vuex);

export default new Vuex.Store({
  state: {

  },
  mutations: {

  },
  actions: {

  },
  modules: {
    auth: {
      namespaced: true,
      state: auth.state,
      mutations: auth.mutations,
      getters: auth.getters,
      actions: auth.actions,
 },
    user: {
      namespaced: true,
      state: user.state,
      actions: user.actions,
      mutations: user.mutations,
      getters: user.getters,
  },
    createdPoem: {
      namespaced: true,
      state: createdPoem.state,
      mutations: createdPoem.mutations,
      getters: createdPoem.getters,
  },
    generatedPoem: {
      namespaced: true,
      state: generatedPoem.state,
      mutations: generatedPoem.mutations,
      getters: generatedPoem.getters,
  },
},
});
