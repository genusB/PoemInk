<template>
  <div>
    <v-card
      elevation="10"
      class="pa-2"
    >
     <v-overlay
        :absolute="true"
        value="isAuthenticated"
        opacity="0.3"
      >
        <v-btn class="ma-2" color="transparent" to="/login">Login to unlock
          <v-icon right>mdi-lock-outline</v-icon>
        </v-btn>
      </v-overlay>
      <rhymer />
      <v-divider class="pa-3" />
      <synonyms />
      <v-divider class="pa-3" />
      <translator />
    </v-card>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';
import { mapGetters } from 'vuex';
import Rhymer from './Rhymer.vue';
import Synonyms from './Synonyms.vue';
import Translator from './Translator.vue';

@Component({
 computed: mapGetters({
   isAuthenticated: 'auth/isAuthenticated',
 }),
 components: {
    Rhymer,
    Synonyms,
    Translator,
  },
})

export default class InstrumentPanel extends Vue {
}
</script>
