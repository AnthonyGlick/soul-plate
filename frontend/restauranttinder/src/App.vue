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
  background-color: 0;
}
html {
    background-image: url('imgs/knife-2879328.jpg');
    background-size: cover;
}
</style>
