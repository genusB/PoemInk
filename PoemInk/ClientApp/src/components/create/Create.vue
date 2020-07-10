<template>
  <div>
    <v-row>
      <v-col
        cols="12"
        md="8"
      >
        <text-area />
      </v-col>
      <v-col
        cols="md-4 sm-12"
        md="4"
      >
        <instrument-panel />
      </v-col>
    </v-row>
  </div>
</template>

<script>
  export default {
    name: 'Create',
    components: {
      InstrumentPanel: () => import('@/components/instrumentComponents/InstrumentPanel.vue'),
      TextArea: () => import('@/components/create/TextArea.vue'),
    },
  };
</script>
