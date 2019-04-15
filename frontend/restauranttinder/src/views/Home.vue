<template>
 <div id="Home">
   <restaurant-search/>
   <!-- TODO remove hardcoded restaurant -->
   <restaurant-summary
       v-bind:testurl="test_url"
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
      test_url: "https://developers.zomato.com/api/v2.1/search?entity_type=city&lat=&lon=1&radius=3&cuisines=55"
    }
  },

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
