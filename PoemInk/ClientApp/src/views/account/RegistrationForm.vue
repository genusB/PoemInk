<template>
  <v-container grid-list-xl text-xs-center>
    <article class="message is-success" v-if="$route.query.new">
      <div class="message-body">
        <strong>You're all set {{$route.query.firstName}}!</strong> Login with your password to continue.
      </div>
    </article>
    <v-layout row wrap>
        <v-flex xs10 offset-xs1 lg8 offset-lg2>
        <v-card dark color="primary" elevation-24 style="padding: 10px; border-radius: 20px;">
            <v-card-text>
            <h1 class="display-3 text-center">Register</h1>
            <hr>
            <br>
            <v-form>
                <v-text-field 
                clearable
                v-model="user.firstName"
                label="First name"
                type="text"
                >
                </v-text-field>
                <v-text-field 
                clearable
                v-model="user.lastName"
                label="Second name"
                type="text"
                >
                </v-text-field>
                <v-text-field 
                clearable
                v-model="user.email"
                label="Email"
                type="email"
                >
                </v-text-field>
                <v-text-field 
                clearable
                v-model="user.password"
                label="Password"
                type="password"
                >
                </v-text-field>
                <v-text-field 
                clearable
                v-model="user.penName"
                label="Pen name"
                type="text"
                >
                </v-text-field>
            </v-form>
            <br>
            <Spinner v-bind:show="isBusy" />
            <v-btn color="secondary" large @click="handleSubmit()">Register</v-btn>
            <div class="errors-container" v-if="errors">
                {{errors}}
              </div>
            <v-btn text large to="/login">Login</v-btn>
            </v-card-text>
        </v-card>
        </v-flex>
    </v-layout>
  </v-container>
</template>

<script lang="ts">
import Spinner from '@/components/Spinner.vue'; 
import { Component, Vue } from 'vue-property-decorator';
import { UserRegistration } from '../../models/user.registration.interface';
import { accountService } from '../../services/account.service';

@Component({
  components: {
    Spinner,
  },
})
export default class RegistrationForm extends Vue {

private isBusy: boolean = false;
private errors: string = '';
private user = {} as UserRegistration;

private handleSubmit() {
  this.isBusy = true;
  accountService.register(this.user).finally(() => this.isBusy = false)
    .subscribe((result: any) => {
      this.$router.push({name: 'loginForm', query: { new: 'true', firstName: this.user.firstName, email: this.user.email }});
    },
    (errors: any) =>  this.errors = errors);
}
}
</script>
