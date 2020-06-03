<template>
  <div>
    <v-sheet
      elevation="10"
      class="pa-12"
    >
      <rhymer />
      <v-divider class="pa-3" />
      <translator />
    </v-sheet>
  </div>
</template>

<script>
  export default {
    name: 'InstrumentPanel',
    components: {
      Rhymer: () => import('@/components/create/instrumentComponents/Rhymer.vue'),
      Translator: () => import('@/components/create/instrumentComponents/Translator.vue'),
    },
    data: () => ({
      drawer: false,
      clipped: false,
    }),
  };
</script>
