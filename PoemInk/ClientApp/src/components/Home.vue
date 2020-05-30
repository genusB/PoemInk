<template>
  <div>
    <core-view />
  </div>
</template>

<script>
  export default {
    name: 'Home',

    components: {
      CoreView: () => import('@/components/core/View'),
    },
  }
</script>
