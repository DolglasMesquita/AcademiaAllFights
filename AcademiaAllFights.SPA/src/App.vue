<template>
  <div id="app">
    <router-view />
  </div>
</template>
<script>
import { defineComponent } from 'vue';

export default defineComponent({
  name: 'App'
})
</script>

<style scoped>
  #app {
    background: rgba(229,229,229,1) ;
    /* background-color: #FFF; */
  }
</style>