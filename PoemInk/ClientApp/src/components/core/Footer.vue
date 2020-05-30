<template>
  <v-footer
    height="88"
    class="justify-center"
  >
    <social-media large />
  </v-footer>
</template>

<script>
  export default {
    name: 'CoreFooter',

    components: {
      SocialMedia: () => import('@/components/SocialMedia'),
    },
  }
</script>
