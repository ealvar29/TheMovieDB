<template>
  <div>
    <h1>Movie Categories</h1>
    <div v-if="isLoading">Loading...</div>
    <div v-else-if="error">{{ error.message }}</div>
    <div v-else class="card flex flex-wrap gap-2">
      <Chip
        class="border-xl rounded-xl bg-slate-300"
        v-for="category in movieCategories"
        :key="category.id"
        :label="category.name"
      />
    </div>
  </div>
</template>

<script setup>
import { computed, onMounted, ref } from "vue";
import { useStore } from "vuex";
import Chip from "primevue/chip";

const store = useStore();
const selectedGenres = ref([]); // Store selected genres
const movieCategories = computed(() => store.getters.movieCategories);
const isLoading = computed(() => store.getters.isLoading);
const error = computed(() => store.getters.error);

const fetchCategories = () => {
  store.dispatch("fetchMovieCategories");
};

const removeCategory = (categoryId) => {
  // Handle the logic for removing a category
  selectedGenres.value = selectedGenres.value.filter((id) => id !== categoryId);
};

onMounted(fetchCategories);
</script>
