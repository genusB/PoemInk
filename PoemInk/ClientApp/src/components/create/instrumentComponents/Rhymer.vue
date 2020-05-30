<template>
  <div>
    <v-sheet
      elevation="3"
      class="pa-8"
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
          <v-btn
            color="primary"
            @click="fetchRhymes()"

            v-on="on"
          >
            Find
          </v-btn>
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
      rhymes: [],
    }),
    methods: {
      async fetchRhymes () {
        try {
          const url = 'api/Rhymes/' + this.text
          const response = await axios.get(url)
          this.rhymes = response.data
          debugger
        } catch (e) {
          this.showError = true
        }
      },
    },
  }

</script>
