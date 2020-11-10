<template>
  <div>
    <v-expansion-panels :popout="true">
      <v-expansion-panel>
        <v-expansion-panel-header
          >Your profile information</v-expansion-panel-header
        >
        <v-expansion-panel-content>
          <v-card>
            <v-card-title
              >Hello, {{ profile.firstName }}
              {{ profile.lastName }}</v-card-title
            >
            <Spinner v-bind:show="isBusy" />
            <v-card-subtitle
              ><strong>Your account info:</strong></v-card-subtitle
            >
            <v-card-text v-if="homeData.firstName"
              ><strong>Name:</strong> {{ name }}</v-card-text
            >
            <v-card-text v-if="homeData.penName"
              ><strong>Pen name:</strong> {{ homeData.penName }}</v-card-text
            >
            <v-card-text v-if="homeData.gender"
              ><strong>Gender:</strong> {{ homeData.poems.count }}</v-card-text
            >
            <div v-if="homeData.pictureUrl">
              <img :src="homeData.pictureUrl" />
            </div>
          </v-card>
        </v-expansion-panel-content>
      </v-expansion-panel>
      <v-expansion-panel>
        <v-expansion-panel-header>Color settings</v-expansion-panel-header>
        <v-expansion-panel-content>
          <v-card :flat="true">
            <v-row>
              <v-col>
                <p>Primary color:</p>
                <v-color-picker
                  v-model="$vuetify.theme.themes.light.primary"
                ></v-color-picker>
              </v-col>
              <v-col>
                <p>Secondary color:</p>
                <v-color-picker
                  v-model="$vuetify.theme.themes.light.secondary"
                ></v-color-picker>
              </v-col>

              <v-col>
                <p>Accent color:</p>
                <v-color-picker
                  v-model="$vuetify.theme.themes.light.accent"
                ></v-color-picker>
              </v-col>
              <v-col>
                <p>Info color:</p>
                <v-color-picker
                  v-model="$vuetify.theme.themes.light.info"
                ></v-color-picker>
              </v-col>
            </v-row>
          </v-card>
        </v-expansion-panel-content>
      </v-expansion-panel>
      <v-expansion-panel>
        <v-expansion-panel-header>Name settings</v-expansion-panel-header>
        <v-expansion-panel-content>
          <v-card> </v-card>
        </v-expansion-panel-content>
      </v-expansion-panel>
    </v-expansion-panels>
  </div>
</template>

<script lang="ts">
import Spinner from "@/components/Spinner.vue"; // @ is an alias to /src
import { Component, Vue } from "vue-property-decorator";
import { mapGetters } from "vuex";
import { dashboardService } from "../../services/dashboard.service";

@Component({
  computed: mapGetters({
    profile: "user/profile",
  }),
  components: {
    Spinner,
  },
})
export default class DashboardHome extends Vue {
  private isBusy: boolean = false;
  private homeData = {} as any;
  private type: any = "hex";
  private hex: any = "#FF00FF";

  get name() {
    return this.homeData.firstName + " " + this.homeData.lastName;
  }

  private created() {
    this.isBusy = true;
    dashboardService.getHomeDetails().then((resp: any) => {
      this.homeData = resp.data;
      this.isBusy = false;
    });
  }
}
</script>

<style scoped>
p {
  font-size: 0.8em;
}
</style>
