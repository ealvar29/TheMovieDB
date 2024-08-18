<script setup>
import { computed } from "vue";
import { useStore } from "vuex";
import Genres from "./components/MovieGenres.vue";
import Button from "primevue/button";

const store = useStore();

const count = computed(() => store.state.count);
const doubleCount = computed(() => store.getters.doubleCount);
const movieGenreList = computed(() => store.state.movieGenreList);
const selectedGenreList = computed(() => store.state.selectedMoviesGenres);

const fetchMovies = () => {
  store.dispatch("fetchMovies");
};
</script>

<template>
  <div>
    <Button>Testing</Button>
    <p>Count: {{ count }}</p>
    <p v-if="selectedGenreList.length > 0">
      Selected Genres:
      <span v-for="genre in selectedGenreList"> {{ genre.name }}, </span>
    </p>
    <p v-else>No Movie Genre</p>
    <p>Double Count: {{ doubleCount }}</p>
    <button class="rounded-xl px-4 bg-blue-400 text-white" @click="fetchMovies">
      Find Movies!
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
