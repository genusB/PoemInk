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
            <v-dialog v-model="dialog" persistent max-width="600px">
              <template v-slot:activator="{ on, attrs }">
                <base-btn
                  :disabled="!isAuthenticated"
                  v-bind="attrs"
                  v-on="on"
                >
                  Save your poem
                </base-btn>
              </template>
                <v-card>
              <v-card-title>
                <span class="headline">Save your poem</span>
              </v-card-title>
              <v-card-text>
                <v-container>
                  <v-row>
                    <v-col cols="12" sm="6" md="4">
                      <v-text-field label="Poem title" required v-model="poem.title"></v-text-field>
                    </v-col>
                    <v-col cols="12">
                      <v-text-field label="Body" required auto-grow v-model="generatedPoem"></v-text-field>
                    </v-col>
                    <v-col>
                      <v-checkbox label="Post To Inspire" v-model="poem.postToInspire"></v-checkbox>
                    </v-col>
                  </v-row>
                </v-container>
              </v-card-text>
              <v-card-actions>
                <v-spacer></v-spacer>
                <base-btn color="second" text @click="dialog = false">Close</base-btn>
                <base-btn color="second" text @click="savePoem()">Save</base-btn>
              </v-card-actions>
            </v-card>
          </v-dialog>
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
  import { PoemInterface } from '../../models/poem.interface';
  import { poemService } from '../../services/poem.service';
  import store from '../../store/store';

  @Component({
    computed: mapGetters({
      isAuthenticated: 'auth/isAuthenticated',
    }),
  })

export default class TextArea extends Vue {
  private lines: number = 10;
  private dialog: boolean = false;
  private isBusy: boolean = false;
  private poem = {} as PoemInterface;

  get generatedPoem() {
    return this.$store.getters['generatedPoem/generatedPoem'];
  }
  set generatedPoem(value) {
    this.$store.commit('generatedPoem/updateGeneratedPoem', value);
  }

  private async savePoem() {
    this.dialog = false;
    this.isBusy = false;
    this.poem.body = this.generatedPoem;

    poemService.save(this.poem).finally(() => this.isBusy = false);
  }

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
