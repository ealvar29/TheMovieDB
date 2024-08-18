import { createStore } from "vuex";
import axios from "axios";

const store = createStore({
  state() {
    return {
      count: 0,
      movieGenreList: [],
      selectedMoviesGenres: [],
      loading: false,
      error: null,
    };
  },
  mutations: {
    increment(state) {
      state.count++;
    },
    SET_MOVIE_CATEGORIES(state, genres) {
      state.movieGenreList = genres;
    },
    SET_SELECTED_GENRES(state, selectedGenre) {
      console.log(selectedGenre, "inside Set Selected Movies");
      state.selectedMoviesGenres.push(selectedGenre);
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
    addSelectedGenres({ commit }, genreId) {
      console.log(commit);
      console.log(genreId);
      commit("SET_SELECTED_GENRES", genreId);
    },
    async fetchMovieCategories({ commit }) {
      commit("SET_LOADING", true);
      commit("SET_ERROR", null);

      try {
        const response = await axios.get(
          "https://localhost:7086/api/MovieApi/genres"
        );
        commit("SET_MOVIE_CATEGORIES", response.data.genres);
      } catch (error) {
        commit("SET_ERROR", error);
        console.error("Error fetching movie categories:", error);
      } finally {
        commit("SET_LOADING", false);
      }
    },
    async discoverMoviesByGenre({ commit }, genreId) {
      commit("SET_LOADING", true);
      commit("SET_ERROR", null);

      try {
        const response = await axios.get(
          `https://localhost:7086/api/MovieApi/discover?genreId=${genreId}`
        );
        commit("SET_DISCOVERED_MOVIES", response.data.movies);
      } catch (error) {
        commit("SET_ERROR", error);
        console.error("Error discovering movies:", error);
      } finally {
        commit("SET_LOADING", false);
      }
    },
  },
  getters: {
    movieGenreList: (state) => state.movieGenreList,
    selectedMoviesGenres: (state) => state.selectedMoviesGenres,
    isLoading: (state) => state.loading,
    error: (state) => state.error,
    doubleCount(state) {
      return state.count * 2;
    },
  },
});

export default store;
