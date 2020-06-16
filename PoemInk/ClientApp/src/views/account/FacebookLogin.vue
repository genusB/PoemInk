<template>
    <v-container>
        <div class="text-center">
          <v-btn large color="info" href="javascript:void(0)" v-if="!isBusy"  @click="launchFbLogin">
            Login with facebook
            <v-icon right dark>mdi-facebook</v-icon>
          </v-btn>
          <Spinner v-bind:show="isBusy" />
          <div class="errors-container" v-if="failed">
              <p>Oops! Your facebook login failed.</p>
                <ul>
                    <li>Error: {{error}}</li>
                    <li>Description: {{errorDescription}}</li>
                </ul>
            </div>
        </div>
    </v-container>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';
import Spinner from '@/components/Spinner.vue'; // @ is an alias to /src

@Component({
  components: {
    Spinner,
  },
})
export default class FacebookLogin extends Vue {

 private authWindow: Window | null = null;
 private failed: boolean = false;
 private error: string = '';
 private errorDescription: string = '';
 private isBusy: boolean = false;
 private errors: string = '';

 private created() {
    if (window.addEventListener) {
      window.addEventListener('message', this.handleMessage.bind(this), false);
    } else {
       (window as any).attachEvent('onmessage', this.handleMessage.bind(this));
    }
 }

 private launchFbLogin() {
    this.authWindow = window.open('https://www.facebook.com/v2.11/dialog/oauth?&response_type=token&display=popup&client_id=1528751870549294&display=popup&redirect_uri=http://localhost:8088/facebook-auth.html&scope=email', '', 'width=600,height=400');
  }

 private handleMessage(event: Event) {
        const message = event as MessageEvent;
        // Only trust messages from the below origin.
        if (message.origin !== 'http://localhost:5000') {
            return;
        }

        if (this.authWindow) {
            this.authWindow.close();
        }

        const result = JSON.parse(message.data);
        if (!result.status) {
              this.failed = true;
              this.error = result.error;
              this.errorDescription = result.errorDescription;
        } else {
             this.failed = false;
             this.isBusy = true;
             this.$store.dispatch('auth/facebookAuthRequest', result.accessToken).then((fbResult) => {
                this.$router.push('/dashboard/home');
             })
             .catch((err) => {
                this.errors = err;
                this.failed = true;
             })
             .then(() => {
                this.isBusy = false;
            });
        }
    }
}
</script>