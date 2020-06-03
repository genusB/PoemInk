<template>
  <v-app>
    <core-navigation />
    <v-content>
      <router-view />
    </v-content>
    <core-footer />
  </v-app>
</template>

<script lang="ts">
import CoreFooter from '@/components/core/Footer.vue';
import CoreNavigation from '@/components/core/Navigation.vue';
import { Component, Vue } from 'vue-property-decorator';

@Component({
  components: { CoreFooter, CoreNavigation },
})
  export default class App extends Vue { }

</script>