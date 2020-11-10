<template>
  <v-container fluid>
    <v-row dense>
      <v-col v-for="poem in poems" :key="poem.title" :cols="3">
        <v-card>
          <v-card-title>
            {{ poem.title }}
          </v-card-title>
          <v-card-text>
            {{ poem.body }}
          </v-card-text>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
</template>

<script lang="ts">
import axios from "axios";
import { Component, Vue } from "vue-property-decorator";
import { PoemInterface } from "../../models/poem.interface";

@Component({})
export default class Inspire extends Vue {
  private poems: PoemInterface[] = [];
  private async created() {
    try {
      const url = "api/Poem/";
      const response = await axios.get(url);
      this.poems = response.data;
    } catch (e) {
      this.poems = [];
    }
  }
}
</script>
