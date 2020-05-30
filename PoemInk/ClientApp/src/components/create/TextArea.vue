<template>
  <div>
    <v-sheet
      elevation="10"
      class="pa-12"
    >
      <v-textarea
        v-model="text"
        auto-grow
        clearable
        placeholder="Your next masterpiece"
        rounded
        solo
      />
      <div class="mt-12 text-center" />
    </v-sheet>
  </div>
</template>

<script>
  export default {
    name: 'TextArea',
    data: () => ({
      text: '',
    }),
  }
</script>
