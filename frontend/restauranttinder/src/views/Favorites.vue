<template>
  <div class="favorite-page">
    <h1 class="favorites">Favorites</h1>
    <div class="user-favorites">
      <favorite v-for="favorite in dummyData" v-bind:key="favorite"/>
    </div>
  </div>
</template>

<script>
import Favorite from "@/components/Favorites/Favorite.vue";
export default {
  name: "Favorites",
  components: {
    Favorite
  },
  data() {
    return {
      dummyData: [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
    };
  }
};
</script>

<style>
.user-favorites {
  display: flex;
  flex-wrap: wrap;
  justify-content: space-around;
  margin: 0px 100px;
}

.favorite-page {
  margin-top: 25px;
  position: absolute;
  background-color: #ff9933;
  opacity: 0.9;
  border: 1px solid black;
  margin-left: 20px;
  margin-right: 20px;
  border-top-left-radius: 5px;
  border-top-right-radius: 5px;
}

.favorites {
  color: black;
  font-size: 48px;
  font-family: "Vollkorn", sans-serif;
}
</style>
