<template>
 <div id="Home">
   <restaurant-search
      v-on:search-results="performSearch"
   />
   <restaurant-summary
       v-bind:summaries="summaries"
   />
 </div>
</template>

<script>
import RestaurantSearch from "@/components/Home/RestaurantSearch.vue"
import RestaurantSummary from "@/components/Home/RestaurantSummary.vue"

export default {
  name: "Home",
  components: {
    RestaurantSearch,
    RestaurantSummary
  },

  data(){
    return {
      summaries: []
    }
  },
methods: {
  performSearch(summaries) {
    this.summaries = summaries;
  },

}
}
</script>

<style>

h1 {
  font-family: 'Vollkorn', sans-serif;
  padding: 8px;
}

span {
  font-family: 'Vollkorn', sans-serif;
  font-size: 18px;
}

</style>
