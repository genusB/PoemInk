<template>
  <div>
    <v-sheet
      elevation="10"
      class="pa-12"
    >
      <rhymer />
      <v-divider class="pa-3" />
      <synonyms />
      <v-divider class="pa-3" />
      <translator />
    </v-sheet>
  </div>
</template>

<script>
  export default {
    name: 'InstrumentPanel',
    components: {
      Rhymer: () => import('./Rhymer.vue'),
      Synonyms: () => import('./Synonyms.vue'),
      Translator: () => import('./Translator.vue'),
    },
  };
</script>
