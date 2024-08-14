<template>
  <div>
    <h1>Movie Categories</h1>
    <div v-if="isLoading">Loading...</div>
    <div v-else-if="error">{{ error.message }}</div>
    <ul v-else>
      <li v-for="category in movieCategories" :key="category.id">
        {{ category.name }}
      </li>
    </ul>
  </div>
</template>

<script setup>
import { computed, onMounted } from "vue";
import { useStore } from "vuex";

const store = useStore();
const movieCategories = computed(() => store.getters.movieCategories);
const isLoading = computed(() => store.getters.isLoading);
const error = computed(() => store.getters.error);
const fetchCategories = () => {
  store.dispatch("fetchMovieCategories");
};

onMounted(fetchCategories);
</script>
