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
              <v-btn
                color="primary"
                @click="fetchRhymes()"
                v-on="on"
              >
                Find
              </v-btn>
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
          <div
            v-for="(rhyme, i) in rhymes"
            :key="i"
            class="mx-auto"
          >
            {{ rhyme }}
          </div>
          <v-divider />
          <v-card-actions>
            <v-spacer />
            <v-btn
              color="grey"
              text
              @click="dialog = false"
            >
              Close
            </v-btn>
          </v-card-actions>
        </v-card>
      </v-dialog>
    </v-sheet>
  </div>
</template>

<script lang="ts">
  import axios from 'axios'

  export default {
    name: 'Rhymer',
    data: () => ({
      text: '',
      dialog: false,
      chosenType: '',
      rhymes: [],
      rhymeTypes: [{ text: 'End Rhymes', param: '' },
                   { text: 'Last-Syllable Rhymes', param: '/last-syllable-rhymes' },
                   { text: 'Double Rhymes', param: '/double-rhymes' },
                   { text: 'Triple Rhymes', param: '/triple-rhymes' },
                   { text: 'Beginning Rhymes', param: '/beginning-rhymes' },
                   { text: 'First-Syllable Rhymes', param: '/first-syllable-rhymes' }],
    }),
    methods: {
      updateType (param) {
        this.chosenType = param
      },
      async fetchRhymes () {
        try {
          const url = 'api/Rhymes' + this.chosenType + '/' + this.text
          const response = await axios.get(url)
          this.rhymes = response.data
        } catch (e) {
          this.showError = true
        }
      },
    },
  }

</script>
