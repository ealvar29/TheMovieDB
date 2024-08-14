import axios from "axios";

const apiClient = axios.create({
  baseURL: "https://localhost:7086",
  headers: {
    "Content-Type": "application/json",
  },
});

export default {
  getMovieCategories() {
    return apiClient.get("/api/Categories");
  },
};
