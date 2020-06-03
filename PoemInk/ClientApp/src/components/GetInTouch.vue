<template>
  <section
    id="get-in-touch"
    class="overflow-hidden"
  >
    <v-row
      class="info white--text"
      no-gutters
    >
      <v-col
        class="pa-5"
        cols="12"
        md="6"
      >
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

      <v-col
        class="hidden-sm-and-down"
        md="6"
      >
        <v-img
          :src="require('@/assets/contact.png')"
          height="100%"
        />
      </v-col>
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
