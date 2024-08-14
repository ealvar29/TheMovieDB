import { createStore } from "vuex";
import axios from "axios";

const store = createStore({
  state() {
    return {
      count: 0,
      movieCategories: [],
      loading: false,
      error: null,
    };
  },
  mutations: {
    increment(state) {
      state.count++;
    },
    SET_MOVIE_CATEGORIES(state, categories) {
      state.movieCategories = categories;
    },
    SET_LOADING(state, isLoading) {
      state.loading = isLoading;
    },
    SET_ERROR(state, error) {
      state.error = error;
    },
  },
  actions: {
    increment(context) {
      context.commit("increment");
    },
    async fetchMovieCategories({ commit }) {
      commit("SET_LOADING", true);
      commit("SET_ERROR", null);

      try {
        const response = await axios.get(
          "https://localhost:7086/api/Categories"
        );
        commit("SET_MOVIE_CATEGORIES", response.data.genres);
      } catch (error) {
        commit("SET_ERROR", error);
        console.error("Error fetching movie categories:", error);
      } finally {
        commit("SET_LOADING", false);
      }
    },
  },
  getters: {
    movieCategories: (state) => state.movieCategories,
    isLoading: (state) => state.loading,
    error: (state) => state.error,
    doubleCount(state) {
      return state.count * 2;
    },
  },
});

export default store;
