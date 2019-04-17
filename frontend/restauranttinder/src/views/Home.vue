<template>
  <v-touch @swipeleft="rejectRestaurant">
    <v-touch @swiperight="likeRestaurant">
  <div id="Home">
    <restaurant-search v-on:search-results="performSearch"/>
    <restaurant-summary v-bind:summaries="summaries"/>
  </div>
    </v-touch>
  </v-touch>
</template>

<script>
import RestaurantSearch from "@/components/Home/RestaurantSearch.vue";
import RestaurantSummary from "@/components/Home/RestaurantSummary.vue";
import {bus} from '@/main.js'

export default {
  name: "Home",
  components: {
    RestaurantSearch,
    RestaurantSummary
  },

  data() {
    return {
      summaries: []
    };
  },
  methods: {
    performSearch(summaries) {
      this.summaries = summaries;
    },
    rejectRestaurant() {
      bus.$emit('rejectSwipe')
    },
    likeRestaurant() {
      bus.$emit('likeSwipe')
    }
  }
};
</script>

<style>
h1 {
  font-family: "Vollkorn", sans-serif;
  padding: 8px;
}

span {
  font-family: "Vollkorn", sans-serif;
  font-size: 18px;
}
</style>
