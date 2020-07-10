<template>
  <div>
    <v-btn
      v-for="(item, i) in items.slice(0, large ? items.length : 3)"
      :key="i"
      fab
      class="ma-2"
      color="info"
      :small="!large"
      
    >
      <v-icon
        dark
        v-text="item.icon"
      />
      <a :href="item.link"></a>
    </v-btn>
  </div>
</template>

<script>
  export default {
    props: {
      large: {
        type: Boolean,
        default: false,
      },
    },

    data: () => ({
      items: [
        {
          name: 'Vk',
          icon: 'mdi-vk',
          link: 'https://vk.com/genusb',
        },
        {
          name: 'Github',
          icon: 'mdi-github',
          link: 'https://github.com/genusB',
        },
      ],
    }),
  };
</script>
