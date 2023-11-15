<template>
  <q-page class="flex flex-center">
    <q-card class="my-card">
      <q-card-section>
        <q-input clearable outlined v-model="text" label="Email" ref="usernameRef" style="width: 400px" />
      </q-card-section>
      <q-card-section>
        <q-input outlined v-model="pass" type="password" label="Password" style="width: 400px" />
      </q-card-section>
      <q-card-section>
        <q-btn color="secondary" label="Login" style="width: 400px" @click="login" />
      </q-card-section>
    </q-card>
  </q-page>
</template>

<script>
import { defineComponent } from 'vue';

export default defineComponent({
  name: 'PageIndex',
  methods: {
    login() {
      this.$router.push({path: '/Home'})
    },
    testFocus () {
      console.log(this.$refs.usernameRef);
      this.$refs.usernameRef.focus();
      this.$refs.usernameRef.focus();
    }
  }
})


</script>
