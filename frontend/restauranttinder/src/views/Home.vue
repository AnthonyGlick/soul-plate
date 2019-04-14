<template>
 <div id="Home">
   <restaurant-search/>
   <!-- TODO remove hardcoded restaurant -->
   <restaurant-summary
        name="Bario"
        rating=4.6
        location="Cedar Fairmount"
        cuisines="Mexican fusion"
        price-range=1
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

    }
  },

}
</script>

<style>

</style>
