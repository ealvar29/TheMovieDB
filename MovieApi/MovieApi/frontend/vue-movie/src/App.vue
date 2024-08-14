<script setup>
import HelloWorld from "./components/HelloWorld.vue";
import { computed } from "vue";
import { useStore } from "vuex";
import Genres from "./components/MovieGenres.vue";
const store = useStore();

const count = computed(() => store.state.count);
const doubleCount = computed(() => store.getters.doubleCount);

const increment = () => {
  store.dispatch("increment");
};
</script>

<template>
  <div>
    <a href="https://vitejs.dev" target="_blank">
      <img src="/vite.svg" class="logo" alt="Vite logo" />
    </a>
    <a href="https://vuejs.org/" target="_blank">
      <img src="./assets/vue.svg" class="logo vue" alt="Vue logo" />
    </a>
  </div>
  <div>
    <p>Count: {{ count }}</p>
    <p>Double Count: {{ doubleCount }}</p>
    <button class="rounded-xl bg-blue-300 text-white" @click="increment">
      Increment
    </button>
  </div>
  <Genres />
</template>

<style scoped>
.logo {
  height: 6em;
  padding: 1.5em;
  will-change: filter;
  transition: filter 300ms;
}
.logo:hover {
  filter: drop-shadow(0 0 2em #646cffaa);
}
.logo.vue:hover {
  filter: drop-shadow(0 0 2em #42b883aa);
}
</style>
