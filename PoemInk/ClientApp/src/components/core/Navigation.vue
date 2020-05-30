<template>
  <div>
    <v-navigation-drawer
      v-model="drawer"
      :clipped="clipped"
      temporary
      fixed
      app
    >
      <v-list>
        <v-list-item
          v-for="(item, i) in items"
          :key="i"
          :to="item.link"
        >
          <v-icon>{{ item.icon }}</v-icon>

          <v-list-item-content>
            <v-list-item-title v-text="item.title" />
          </v-list-item-content>
        </v-list-item>
      </v-list>
    </v-navigation-drawer>
    <v-app-bar
      :clipped-left="clipped"
      color="transparent"
      fixed
      flat
    >
      <v-app-bar-nav-icon @click.stop="drawer = !drawer" />
    </v-app-bar>
  </div>
</template>

<script>
  export default {
    name: 'Navigation',

    data: () => ({
      clipped: true,
      drawer: true,
      items: [
        { title: 'Home', icon: 'mdi-home-roof', link: '/' },
        { title: 'Create', icon: 'mdi-pencil-outline', link: '/create' },
        { title: 'Generate', icon: 'mdi-brain', link: '/generate' },
        { title: 'Inspire', icon: 'mdi-lightbulb-outline', link: '/inspire' },
      ],
    }),
    methods: {
      onScroll () {
        const offset = window.pageYOffset
        this.isScrolling = offset > 50
        this.showLogo = offset > 200
      },
    },
  }
</script>
