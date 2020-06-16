<template>
  <div>
    <v-navigation-drawer
      v-model="drawer"
      :clipped="clipped"
      temporary
      fixed
      app
    >
      <v-list>
        <v-list-item
          v-for="(item, i) in items"
          :key="i"
          :to="item.link"
        >
          <v-icon>{{ item.icon }}</v-icon>

          <v-list-item-content>
            <v-list-item-title v-text="item.title" />
          </v-list-item-content>
        </v-list-item>
      </v-list>
    </v-navigation-drawer>
      <v-app-bar
        absolute
        color="transparent"
        dense
      >
        <v-app-bar-nav-icon @click.stop="drawer = !drawer" />
        <v-spacer />
        <div>
          <v-btn text small href="javascript:void(0)" v-on:click="logoff" v-show="isAuthenticated">Logout {{profile.firstName}}</v-btn>
          <v-btn text small to="/register" v-show="!isAuthenticated"><v-icon right dark>mdi-account-plus</v-icon></v-btn>     
          <v-btn text small to="/login"  v-show="!isAuthenticated"><v-icon right dark>mdi-account-circle</v-icon></v-btn>
          <v-btn text small to="/facebook-login" v-show="!isAuthenticated"><v-icon right dark>mdi-facebook</v-icon></v-btn>
          <v-btn text small to="/dashboard/home"  v-show="isAuthenticated"><v-icon right dark>mdi-view-dashboard</v-icon></v-btn>   
        </div> 
      </v-app-bar>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';
import { EventBus } from '../../event-bus';
import { mapGetters } from 'vuex';

@Component({
 computed: mapGetters({
   isAuthenticated: 'auth/isAuthenticated',
   profile: 'user/profile',
 }),
})
export default class Navigation extends Vue {

  private clipped: boolean =  true;
  private drawer: boolean = true;
  private items = [
    { title: 'Home', icon: 'mdi-home-roof', link: '/' },
    { title: 'Create', icon: 'mdi-pencil-outline', link: '/create' },
    { title: 'Generate', icon: 'mdi-brain', link: '/generate' },
    { title: 'Inspire', icon: 'mdi-lightbulb-outline', link: '/inspire' },
  ];
  private logoff() {
    this.$store.dispatch('auth/authLogout').then(() => {
    this.$router.push('/');
    });
  }
  private created() {
   EventBus.$on('logged-in', (payLoad: any) => {
      // this doesn't currently do anything in this demo but does get fired on successful login.
      // leaving it here to show how to allow communication between unrelated components - ie. Store -> Component
      console.log('logged-in message received...');
    });
  }

  private destroyed() {
    EventBus.$off('logged-in');
  }
}
</script>
