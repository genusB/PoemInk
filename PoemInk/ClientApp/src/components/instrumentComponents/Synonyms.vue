<template>
  <div>
    <v-sheet
      elevation="3"
      class="pa-6"
    >
      <v-textarea
        v-model="text"
        clearable
        height="30"
        :single-line="true"
        solo
        placeholder="Synonyms finder"
        rounded
      />
      <v-dialog
        v-model="dialog"
        scrollable
        max-width="500px"
      >
        <template v-slot:activator="{ on }">
            <base-btn
            @click="fetchSynonyms()"
            v-on="on"
            >
            Find
            </base-btn>
        </template>
        <v-card>
          <v-card-title>Synonyms for "{{ text }}"</v-card-title>
          <v-divider />
          <v-card-text>
            {{ synonyms }}
          </v-card-text>
          <v-divider />
          <v-card-actions>
            <v-spacer />
            <base-btn
              text
              @click="dialog = false"
            >
              Close
            </base-btn>
          </v-card-actions>
        </v-card>
      </v-dialog>
    </v-sheet>
  </div>
</template>

<script lang="ts">
  import axios from 'axios';
  import { Component, Vue } from 'vue-property-decorator';

  @Component({})
    export default class Synonyms extends Vue {
    private text: string = '';
    private dialog: boolean = false;
    private synonyms: string[] = [];
    private async fetchSynonyms() {
      try {
        const url = 'api/Synonyms';
        const response = await axios.get(url, {params: {text: this.text}});
        this.synonyms = response.data;
      } catch (e) {
        this.synonyms = ['Not found'];
      }
    }
  }
  

</script>
