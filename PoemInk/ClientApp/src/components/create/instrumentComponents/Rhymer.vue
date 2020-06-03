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
        placeholder="Rhymes finder"
        rounded
      />
      <v-dialog
        v-model="dialog"
        scrollable
        max-width="300px"
      >
        <template v-slot:activator="{ on }">
          <v-row
            justify="center"
            no-gutters
          >
            <v-col>
              <base-btn
                @click="fetchRhymes()"
                v-on="on"
              >
                Find
              </base-btn>
            </v-col>
            <v-col>
              <v-select
                lg="6"
                :items="rhymeTypes"
                item-text="text"
                item-value="param"
                solo
                label="Rhyme type"
                @change="updateType"
              />
            </v-col>
          </v-row>
        </template>
        <v-card>
          <v-card-title>Rhymes for "{{ text }}"</v-card-title>
          <v-divider />
          <v-card-text>
            <div
              v-for="(rhyme, i) in rhymes"
              :key="i"
              class="mx-auto"
            >
              {{ rhyme }}
            </div>
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
    export default class Rhymer extends Vue {
    private text: string = '';
    private dialog: boolean = false;
    private chosenType: string = '';
    private rhymes: string[] = [];
    private rhymeTypes = [{ text: 'End Rhymes', param: '' },
                  { text: 'Last-Syllable Rhymes', param: '/last-syllable-rhymes' },
                  { text: 'Double Rhymes', param: '/double-rhymes' },
                  { text: 'Triple Rhymes', param: '/triple-rhymes' },
                  { text: 'Beginning Rhymes', param: '/beginning-rhymes' },
                  { text: 'First-Syllable Rhymes', param: '/first-syllable-rhymes' }];
    private updateType(param: string) {
      this.chosenType = param;
    }
    private async fetchRhymes() {
      try {
        const url = 'api/Rhymes' + this.chosenType + '/' + this.text;
        debugger;
        const response = await axios.get(url);
        this.rhymes = response.data;
      } catch (e) {
        this.rhymes = ['Not found'];
      }
    }
  }
  

</script>
