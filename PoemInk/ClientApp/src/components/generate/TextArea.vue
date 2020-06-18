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
          <base-btn :disabled="!isAuthenticated" @click="postToInspire">
            Post to "Inspire"
          </base-btn>
        </v-col>
        <v-col>
          <base-btn @click="downloadAsPdf">
            Download as pdf 
          </base-btn>
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

  @Component({
    computed: mapGetters({
      isAuthenticated: 'auth/isAuthenticated',
    })
  })

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
