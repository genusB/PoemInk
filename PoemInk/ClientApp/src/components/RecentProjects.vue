<template>
  <section
    id="recent-projects"
    class="overflow-hidden"
  >
    <v-row no-gutters>
      <v-col
        class="primary text-center pa-5 white--text"
        cols="12"
        md="6"
      >
        <base-bubble-1
          style="transform: rotate(180deg) translateX(25%)"
        />

        <base-heading>
          What do we have here?
        </base-heading>

        <base-text class="mb-5">
          It will be a quick overview of this project<br>
          You also can navigate directly to them to learn more<br>
        </base-text>

        <v-card color="secondary">
          <v-container class="pa-2">
            <v-row>
              <v-col
                v-for="project in projects"
                :key="project.title"
                cols="12"
                md="6"
              >
                <v-hover
                  v-slot:default="{ hover }"
                >
                  <a
                    :href="project.link"
                  >
                    <v-img
                      :src="require(`@/assets/${project.name}.jpeg`)"
                      max-height="300"
                    >
                      <v-expand-transition>
                        <div
                          v-if="hover"
                          class="d-flex transition-fast-in-fast-out black darken-2 v-img--reveal display-3 white--text"
                          style="height: 100%;"
                        >
                          <base-text>
                            {{ project.title }}
                          </base-text>
                        </div>
                      </v-expand-transition>
                    </v-img>
                  </a>
                </v-hover>
              </v-col>
            </v-row>
          </v-container>
        </v-card>
      </v-col>

      <v-col
        class="hidden-sm-and-down"
        md="6"
      >
        <v-img
          :src="require('@/assets/recentprojects.png')"
          height="100%"
        />
      </v-col>
    </v-row>
  </section>
</template>

<script>
  export default {
    name: 'RecentProjects',

    data: () => ({
      projects: [
        { name: 'project1', title: 'Create', link: '/create' },
        { name: 'project2', title: 'Generate', link: '/generate' },
        { name: 'project3', title: 'Inspire', link: '/inspire' },
        { name: 'project4', title: 'Suggest', link: '#get-in-touch' },
      ],
    }),
  };
</script>

<style>
.v-img--reveal {
  align-items: center;
  bottom: 0;
  justify-content: center;
  opacity: .5;
  position: absolute;
  width: 100%;
}
</style>
