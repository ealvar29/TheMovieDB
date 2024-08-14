import { createApp } from "vue";
import "./style.css";
import App from "./App.vue";
import PrimeVue from "primevue/config";
import Aura from "@primevue/themes/aura";
import store from "./store";

const app = createApp(App).use(store).mount("#app");
app.use(PrimeVue, {
  theme: {
    preset: Aura,
  },
});
