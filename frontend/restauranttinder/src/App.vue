<template>
  <div id="app">
    <the-header v-if="showHeader"/>
    <router-view />
  </div>
</template>

<script>
import HelloWorld from './components/HelloWorld.vue'
import TheHeader from './components/layout/TheHeader.vue'

export default {
  name: 'app',
  components: {
    HelloWorld,
    TheHeader
  },
  computed: {
    /**
     * Indicates if the header should be visible.
     */
    showHeader() {
      const noHeaderPages = ["login"];
      return noHeaderPages.indexOf(this.$route.name) === -1;
    }
  }
}
</script>

<style>
@import url('https://fonts.googleapis.com/css?family=Vollkorn');

#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}
body {
  margin: 0;
}
html {
    background-image: url('assets/imgs/platter-2009590_1280.jpg');
    background-size: cover;
    background-repeat: no-repeat;
    background-attachment: fixed;
    background-color: rgb(255,153,110, .5);
    background-blend-mode: screen;
}

@media screen and (max-width: 360px) {
  background-repeat: repeat;
}
  
</style>
