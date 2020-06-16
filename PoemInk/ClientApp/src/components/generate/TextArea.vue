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
      <base-btn @click="fetchSpelling">
      Check Spelling
      </base-btn>
      <div class="mt-12 text-center" />
    </v-sheet>
  </div>
</template>

<script lang="ts">
  import axios from 'axios';
  import { Component, Vue } from 'vue-property-decorator';

  @Component({})
    export default class TextArea extends Vue {
    private text: string = '';
    private async fetchSpelling() {
      try {
        const url = 'api/Spelling';
        const response = await axios.get(url, {params: {misspellingsText: this.text}});
        this.text = response.data;
      } catch (e) {
        alert('Not found');
      }
    }
  }
  

</script>
