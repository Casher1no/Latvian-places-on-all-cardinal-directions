<template>
  <LatvianMap msg="Welcome to Your Vue.js App"/>
</template>

<script>
import LatvianMap from './components/LatvianMap.vue'

export default {
  name: 'App',
  components: {
    LatvianMap 
  }
}
</script>

<style>
#app {
  font-family: 'Source Code Pro', monospace;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
