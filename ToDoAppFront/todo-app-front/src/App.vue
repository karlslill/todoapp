<script setup lang="ts">
import { RouterLink, RouterView } from 'vue-router'
</script>

<template>
  <nav>
      <RouterLink to="/">Tasks</RouterLink>
      <RouterLink to="/add">Add</RouterLink>
  </nav>

  <RouterView />
</template>

<style scoped>
* {
  margin: 0;
  padding: 0;
  box-sizing: border-box;
}

body {
  font-family: Arial, sans-serif;
  background: #f4f4f4;
}

nav {
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  background: #333;
  color: white;
  padding: 1rem 0;
  text-align: center;
}

nav a {
  color: white;
  text-decoration: none;
  padding: 0 1.5rem;
  font-size: 1rem;
}

nav a:hover {
  text-decoration: underline;
}

main {
  display: flex;
  align-items: center;
  justify-content: center;
  width: 100%;
  height: calc(100vh - 60px); 
  padding-top: 60px;
}
</style>
