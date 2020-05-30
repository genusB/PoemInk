<template>
  <div>
    <v-sheet
      elevation="10"
      class="pa-12"
    >
      <rhymer />
    </v-sheet>
  </div>
</template>

<script>
  export default {
    name: 'InstrumentPanel',
    components: {
      Rhymer: () => import('@/components/create/instrumentComponents/Rhymer.vue'),
    },
    data: () => ({
      drawer: false,
      clipped: false,
    }),
  }
</script>
