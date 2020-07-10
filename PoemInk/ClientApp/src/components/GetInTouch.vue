<template>
  <section
    id="get-in-touch"
    class="primary white--text center pa-10"
  >
    <v-row>
      <v-col></v-col>
      <v-col cols="lg-5 xs-14">
        <base-heading class="mb-5">
          Get In Touch
        </base-heading>

        <v-spacer />

        <v-sheet
          color="transparent"
          max-width="600"
        >
          <v-text-field
            v-model="subject"
            color="info"
            label="Subject"
            solo
            flat
          />

          <v-textarea
            v-model="message"
            color="info"
            label="Message"
            solo
            flat
          />

          <base-btn @click="sendEmail()">
            Send
          </base-btn>
        </v-sheet>
      </v-col>
      <v-col></v-col>
    </v-row>
  </section>
</template>

<script>
  export default {
    name: 'GetInTouch',

    data: () => ({
      subject: '',
      message: '',
    }),

    methods: {
      sendEmail() {
        window.open('mailto:pasteyourtext@gmail.com?subject=' + this.subject + '&body=' + this.message);
      },
    },
  };
</script>
