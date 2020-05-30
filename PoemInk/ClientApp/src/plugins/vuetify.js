import Vue from 'vue'
import Vuetify from 'vuetify/lib'

Vue.use(Vuetify)

export default new Vuetify({
  theme: {
    themes: {
      light: {
        primary: '#D3C3BC',
        secondary: '#BFADA5',
        accent: '#D8EBF1',
        info: '#5B5C79',
      },
    },
  },
})
