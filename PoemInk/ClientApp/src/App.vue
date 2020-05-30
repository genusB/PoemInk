<template>
  <v-app>
    <core-navigation />
    <v-content>
      <router-view />
    </v-content>
    <core-footer />
  </v-app>
</template>

<script>
  export default {
    name: 'App',

    components: {
      CoreFooter: () => import('@/components/core/Footer.vue'),
      CoreNavigation: () => import('@/components/core/Navigation.vue'),
    },
  }
</script>
