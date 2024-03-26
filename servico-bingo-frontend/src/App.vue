<template>
  <v-app id="app">
    <router-view ></router-view>
  </v-app>
</template>

<script lang="ts">
import { Component, Vue, Prop } from 'vue-property-decorator';
@Component({

})
export default class App extends Vue {
}
</script>
<style>

#app {
background: #F2F2F2;
  font-family: Avenir, Helvetica, Arial, sans-serif;
  text-align: center;
  height:100vh ;
}

</style>
