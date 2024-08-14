<template>
  <div>
    <h1>Movie Categories</h1>
    <ul>
      <li v-for="category in movieCategories" :key="category.id">
        {{ category.name }}
      </li>
    </ul>
  </div>
</template>

<script>
import { ref, onMounted } from "vue";
import apiService from "../apiService";

export default {
  setup() {
    const movieCategories = ref([]);

    const fetchMovieCategories = async () => {
      try {
        const response = await apiService.getMovieCategories();
        console.log(response, "response");
        movieCategories.value = response.data.genres;
      } catch (error) {
        console.error("Error fetching movie categories:", error);
      }
    };

    onMounted(fetchMovieCategories);

    return {
      movieCategories,
    };
  },
};
</script>
