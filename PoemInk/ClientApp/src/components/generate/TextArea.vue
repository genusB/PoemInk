<template>
  <div>
    <v-sheet
      elevation="10"
      class="pa-12"
    >
      <v-textarea
        v-model="generatedPoem"
        auto-grow
        clearable
        placeholder="Your next masterpiece"
        rounded
        solo
      />
      <v-row>
        <v-col>
           <base-btn :disabled="!isAuthenticated" @click="generate">
            Generate
          </base-btn>
        </v-col>
        <v-col>
           <base-btn :disabled="!isAuthenticated" @click="fetchSpelling">
            Check Spelling
          </base-btn>
        </v-col>
        <v-spacer></v-spacer>
        <v-spacer></v-spacer>
        <v-col>
          <base-btn :disabled="!isAuthenticated">
            Post to "Inspire"
          </base-btn>
        </v-col>
        <v-col>
          <base-btn>
            Download as pdf 
          </base-btn>
        </v-col>
      </v-row>
      <v-row>
        <v-col lg="4">
          <v-container>
            <v-text-field v-model="lines" type="number" label="Amount of lines in generated poem"></v-text-field>
          </v-container>
        </v-col>
      </v-row>
      <div class="mt-12 text-center" />
    </v-sheet>
  </div>
</template>

<script lang="ts">
  import axios from 'axios';
  import { mapGetters } from 'vuex';
  import { Component, Vue } from 'vue-property-decorator';
  import store from '../../store/store';

  @Component({
    computed: mapGetters({
      isAuthenticated: 'auth/isAuthenticated',
    }),
  })

export default class TextArea extends Vue {
  get generatedPoem() {
    return this.$store.getters['generatedPoem/generatedPoem'];
  }
  set generatedPoem(value) {
    this.$store.commit('generatedPoem/updateGeneratedPoem', value);
  }
  private lines: number = 10;
  private async fetchSpelling() {
    try {
      const url = 'api/Spelling';
      const response = await axios.get(url, {params: {misspellingsText: this.generatedPoem}});
      this.generatedPoem = response.data;
    } catch (e) {
      alert('Not found');
    }
  }
  private async generate() {
    try {
      const url = 'api/Generate';
      const response = await axios.get(url, {params: {number: this.lines}});
      this.generatedPoem = response.data;
    } catch (e) {
      alert('Not found');
    }
  }
}
</script>
