<template>
  <div class="restaurant-summaries">
    <div class="summary" v-if="summaries.restaurants" :key="restaurantNumber">

      <div v-if="summaries.restaurants[restaurantNumber].restaurant.featured_image" class="featuredimage">
        <img :src="summaries.restaurants[restaurantNumber].restaurant.featured_image">
      </div>
      <div v-else><img class="featuredimage" src= "https://via.placeholder.com/1200x464"></div>

    <div class="text-infor">    
        <h3 class="name"> {{summaries.restaurants[restaurantNumber].restaurant.name}}</h3>
        <h3 class="rating">Rating: {{summaries.restaurants[restaurantNumber].restaurant.user_rating.aggregate_rating}} out of 5</h3>
        <h3 class="location">Location: {{summaries.restaurants[restaurantNumber].restaurant.location.locality}}</h3>
        <h3 class="cuisines"> {{summaries.restaurants[restaurantNumber].restaurant.cuisines}}</h3>
        <h3 class="price-range">Price: {{dollarprice}}</h3>
      </div> 
    </div>
    <button class="next-res" v-on:click="nextRestaurant">Next Restaurant</button>
    <reject-button
      v-on:Reject="rejectRestaurant"/>
  </div>
</template>

<script>
export default {
  name: "RestaurantSummary",
  props: {
    summaries: Object
  },
  computed:{
    dollarprice: function() {
      let dollarsigns= "";

      if (this.summaries && this.summaries.restaurants) {
        for(let i =0;i<this.summaries.restaurants[this.restaurantNumber].restaurant.price_range;i++){
          dollarsigns += "$"
        }
      }
      return dollarsigns;
    },

    // starrating: function(){
      
    // }


  },

  data() {
    return {
      restaurantNumber: 0,
      emptyArray: "Still hungry? Search again!"
    };
  },
  methods: {
    nextRestaurant() {
      if (this.summaries.restaurants.length < 1) {
       return this.emptyArray; 
      }
      if (this.restaurantNumber < this.summaries.restaurants.length) {
        this.restaurantNumber = this.restaurantNumber + 1;
      }
      else {
        this.restaurantNumber = 0;
      }
    },
    
    rejectRestaurant(restaurantNumber){
      this.summaries.restaurants.splice(restaurantNumber,1)
    }

  }
};
</script>

<style>

.summary{
  display:flex;
  flex-direction: column;
}

div.text-infor {
  font-family: 'Vollkorn', sans-serif;
  display: inline-block;
  background-color: white;
}

img.featuredimage {
  height: 100%;
  width: 600px;
}

div.text-infor {
  background-color: rgba(255,255,255,0.8)
}

.restaurant-summaries {
  position: absolute;
  margin-top: 350px;
  left: 0;
  right: 0;
}

.text-infor {
  margin-left: 500px;
  margin-right: 500px;
  margin-top: 10px;
}

</style>
