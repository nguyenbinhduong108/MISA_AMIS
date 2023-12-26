<template>
  <div class="container">
    <TheHeader></TheHeader>
    <div class="content">
      <TheMenu></TheMenu>
      <TheMain></TheMain>
    </div>

  </div>
</template>

<script>
import TheHeader from './components/layout/TheHeader.vue';
import TheMenu from './components/layout/TheMenu.vue';
import TheMain from './components/layout/TheMain.vue';



export default {
  name: "App",
  components: { TheHeader, TheMenu, TheMain},
  
};
</script>

<style scoped>
.container {
  width: 100vw;
  height: 100vh;
  display: flex;
  flex-direction: column;
}
.content{
    height: calc(100vh - 56px);
    display: flex;
    background-color: #f4f5f7;
    flex: 1;
}
</style>
