<template>
  <div>
    <v-row>
      <v-col
        cols="12"
        sm="6"
        md="8"
      >
        <text-area />
      </v-col>
      <v-col
        cols="6"
        md="4"
      >
        <instrument-panel />
      </v-col>
    </v-row>
  </div>
</template>

<script>
  export default {
    name: 'Generate',
    components: {
      InstrumentPanel: () => import('@/components/instrumentComponents/InstrumentPanel.vue'),
      TextArea: () => import('@/components/generate/TextArea.vue'),
    },
  };
</script>