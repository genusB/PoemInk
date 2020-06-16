<template> 
  <v-container grid-list-xl text-xs-center>
    <article class="message is-success" v-if="$route.query.new">
      <div class="message-body">
        <strong>You're all set {{$route.query.firstName}}!</strong> Login with your password to continue.
      </div>
    </article>
    <v-layout row wrap>
        <v-flex  xs10 offset-xs1 lg8 offset-lg2>
        <v-card dark color="primary" elevation-24 style="padding: 10px; border-radius: 20px;">
            <v-card-text>
            <h1 class="display-3 text-center">Login</h1>
            <hr>
            <br>
            <v-form>
                <v-text-field 
                clearable
                v-model="credentials.userName"
                label="Email"
                type="email"
                >
                </v-text-field>
                <v-text-field 
                clearable
                v-model="credentials.password"
                label="Password"
                type="password"
                >
                </v-text-field>
            </v-form>
            <br>
            <Spinner v-bind:show="isBusy" />
            <v-btn color="secondary" large @click="handleSubmit()">Login</v-btn>
            <div class="errors-container" v-if="errors">
                 {{errors}}
              </div>
            <v-btn text large to="/register">Sign up</v-btn>
            </v-card-text>
        </v-card>
        </v-flex>
    </v-layout>
  </v-container>
</template>

<script lang="ts">
import Spinner from '@/components/Spinner.vue'; 
import { Component, Vue } from 'vue-property-decorator';
import { Credentials } from '../../models/credentials.interface';
// this.$route.query.page

@Component({
  components: {
    Spinner,
  },
})
export default class RegistrationForm extends Vue {

private isBusy: boolean = false;
private errors: string = '';
private credentials = {} as Credentials;

private created() {
  if (this.$route.query.new) {
    this.credentials.userName = this.$route.query.email.toString();
  }
}

private handleSubmit() {
     this.isBusy = true;
     this.$store.dispatch('auth/authRequest', this.credentials).then((result) => {
     this.$router.push('/dashboard/home');
    })
   .catch((err) => {
    this.errors = err;
  })
  .then(() => {
    this.isBusy = false;
  });
 }
}
</script>

<style lang="scss" scoped> 

</style>
 