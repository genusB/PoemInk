<template>
  <div>
    <v-sheet
      elevation="3"
      class="pa-6"
    >
      <v-textarea
        v-model="originalText"
        auto-grow
        clearable
        placeholder="Text for translation"
        rounded
        solo
      />
      <v-row>
        <v-col>
          <v-select
            v-model="from"
            lg="6"
            :items="languagesFrom"
            solo
            label="From"
          />
        </v-col>
        <v-col>
          <v-select
            v-model="to"
            lg="6"
            :items="languagesTo"
            solo
            label="To"
          />
        </v-col>
      </v-row>
      <v-dialog
        v-model="dialog"
        width="600px"
      >
        <template v-slot:activator="{ on }">
          <base-btn
            class="m-auto"
            v-on="on"
            @click="fetchTranslation"
          >
            Translate
          </base-btn>
        </template>
        <v-card>
          <v-card-title>
            Translation
          </v-card-title>
          <v-card-text>{{ translatedText }}</v-card-text>
          <v-card-actions>
            <v-spacer />
            <base-btn @click="dialog = false">
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
  import { Translation } from '../../../models/Translation';
  import { Component, Vue } from 'vue-property-decorator';

  @Component({})
  export default class Translator extends Vue {
      private from: string = '';
      private to: string = '';
      private originalText: string = '';
      private translatedText: string = '';
      private dialog: boolean = false;
      private translation: Translation = new Translation('', '', '');
      private languagesFrom: string[] = [
        'Auto', 'Afrikaans', 'Albanian', 'Amharic', 'Arabic', 'Armenian', 'Azerbaijani', 'Basque', 'Belarusian',
        'Bengali', 'Bosnian', 'Bulgarian', 'Catalan', 'Cebuano', 'Chichewa', 'ChineseSimplified', 'ChineseTraditional',
        'Corsican', 'Croatian', 'Czech', 'Danish', 'Dutch', 'English', 'Esperanto', 'Estonian', 'Filipino', 'Finnish',
        'French', 'Frisian', 'Galician', 'Georgian', 'German', 'Greek', 'Gujarati', 'HaitianCreole', 'Hausa', 'Hawaiian',
        'Hebrew', 'Hindi', 'Hmong', 'Hungarian', 'Icelandic', 'Igbo', 'Indonesian', 'Irish', 'Italian', 'Japanese',
        'Javanese', 'Kannada', 'Kazakh', 'Khmer', 'Korean', 'KurdishKurmanji', 'Kyrgyz', 'Lao', 'Latin', 'Latvian',
        'Lithuanian', 'Luxembourgish', 'Macedonian', 'Malagasy', 'Malay', 'Malayalam', 'Maltese', 'Maori', 'Marathi',
        'Mongolian', 'MyanmarBurmese', 'Nepali', 'Norwegian', 'Pashto', 'Persian', 'Polish', 'Portuguese', 'Punjabi',
        'Romanian', 'Russian', 'Samoan', 'ScotsGaelic', 'Serbian', 'Sesotho', 'Shona', 'Sindhi', 'Sinhala', 'Slovak',
        'Slovenian', 'Somali', 'Spanish', 'Sundanese', 'Swahili', 'Swedish', 'Tajik', 'Tamil', 'Telugu', 'Thai',
        'Turkish', 'Ukrainian', 'Urdu', 'Uzbek', 'Vietnamese', 'Welsh', 'Xhosa', 'Yiddish', 'Yoruba', 'Zulu'];
      private languagesTo: string[] = [
        'Afrikaans', 'Albanian', 'Amharic', 'Arabic', 'Armenian', 'Azerbaijani', 'Basque', 'Belarusian',
        'Bengali', 'Bosnian', 'Bulgarian', 'Catalan', 'Cebuano', 'Chichewa', 'ChineseSimplified', 'ChineseTraditional',
        'Corsican', 'Croatian', 'Czech', 'Danish', 'Dutch', 'English', 'Esperanto', 'Estonian', 'Filipino', 'Finnish',
        'French', 'Frisian', 'Galician', 'Georgian', 'German', 'Greek', 'Gujarati', 'HaitianCreole', 'Hausa', 'Hawaiian',
        'Hebrew', 'Hindi', 'Hmong', 'Hungarian', 'Icelandic', 'Igbo', 'Indonesian', 'Irish', 'Italian', 'Japanese',
        'Javanese', 'Kannada', 'Kazakh', 'Khmer', 'Korean', 'KurdishKurmanji', 'Kyrgyz', 'Lao', 'Latin', 'Latvian',
        'Lithuanian', 'Luxembourgish', 'Macedonian', 'Malagasy', 'Malay', 'Malayalam', 'Maltese', 'Maori', 'Marathi',
        'Mongolian', 'MyanmarBurmese', 'Nepali', 'Norwegian', 'Pashto', 'Persian', 'Polish', 'Portuguese', 'Punjabi',
        'Romanian', 'Russian', 'Samoan', 'ScotsGaelic', 'Serbian', 'Sesotho', 'Shona', 'Sindhi', 'Sinhala', 'Slovak',
        'Slovenian', 'Somali', 'Spanish', 'Sundanese', 'Swahili', 'Swedish', 'Tajik', 'Tamil', 'Telugu', 'Thai',
        'Turkish', 'Ukrainian', 'Urdu', 'Uzbek', 'Vietnamese', 'Welsh', 'Xhosa', 'Yiddish', 'Yoruba', 'Zulu'];
        private async fetchTranslation() {
        try {
          this.translation = new Translation(this.from, this.to, this.originalText);
          const url = 'api/Translation';
          debugger;
          const response = await axios.get(url, {params: {from: this.from, TO: this.to, text: this.originalText}});
          debugger;
          this.translatedText = response.data;
        } catch (e) {
          this.translatedText = 'Not found';
        }
    }
  }
</script>
