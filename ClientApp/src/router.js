import Vue from "vue";
import Router from "vue-router";
import Home from "./components/Home/Home.vue";
import MyPets from "./components/MyPets/MyPets.vue";
import FoundAPet from "./components/FoundAPet/FoundAPet.vue";
import FoundPet from "./components/FoundPet/FoundPet.vue";

Vue.use(Router);

export default new Router({
  routes: [
    {
      path: "/",
      nome: "Home",
      component: Home,
    },
    {
      path: "/MyPets",
      nome: "MyPets",
      component: MyPets,
    },
    {
      path: "/FoundAPet",
      nome: "FoundAPet",
      component: FoundAPet,
    },
    {
      path: "/FoundPet",
      nome: "FoundPet",
      component: FoundPet,
    },
    {
      path: "/FoundPet/:pet_id",
      nome: "FoundPet",
      component: FoundPet,
    }
  ],
});
