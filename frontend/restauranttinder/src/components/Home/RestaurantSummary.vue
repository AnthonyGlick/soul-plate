<template>
  <div class="restaurant-summaries">
    <div class="summary" v-if="summaries.restaurants" :key="restaurantNumber">
      <div v-if="summaries.restaurants[restaurantNumber].restaurant.featured_image" class="featuredimage">
        <img :src="summaries.restaurants[restaurantNumber].restaurant.featured_image">
      </div>
      <div v-else><img class="featuredimage" src= "https://via.placeholder.com/1200x464"></div>

    <div class="text-infor">    
        <h3 class="name">{{summaries.restaurants[restaurantNumber].restaurant.name}}</h3>
        <h3 class="rating">Rating:{{summaries.restaurants[restaurantNumber].restaurant.user_rating.aggregate_rating}} out of 5</h3>
        <h3 class="location">Location:{{summaries.restaurants[restaurantNumber].restaurant.location.locality}}</h3>
        <h3 class="cuisines">{{summaries.restaurants[restaurantNumber].restaurant.cuisines}}</h3>
        <h3 class="price-range">Price: {{dollarprice}}</h3>
      </div> 
    </div>
    <button v-on:click="rejectRestaurant">Next Restaurant</button>
  </div>
</template>

<script>
export default {
  name: "RestaurantSummary",
  props: {
    testurl: String
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
      emptyArray: "Still hungry? Search again!",
      summaries: []
    };
  },
  created() {
    fetch(this.testurl, {
      method: "GET",
      headers: {
        "Content-Type": "application/json",
        "user-key": `${process.env.VUE_APP_ZOMATO_KEY}`
      }
    })
      .then(response => {
        return response.json();
      })
      .then(json => {
        this.summaries = json;
      })
      .catch(error => console.error(error));
  },
  methods: {
    rejectRestaurant() {
      if (this.summaries.restaurants.length < 1) {
       return this.emptyArray; 
      }
      if (this.restaurantNumber < this.summaries.restaurants.length) {
        this.restaurantNumber = this.restaurantNumber + 1;
      }
      else {
        this.restaurantNumber = 0;
      }
    }
  }
  //TODO // methods:{
  //        removeReviewFromArray(id) {
  //       const reviewsMinusDeleted = this.reviews.filter((review) => {
  //         return review.id !== id;
  //       });
  //       this.reviews = reviewsMinusDeleted;
  // },
  // }
};
</script>

<style>

.summary{
  border: 1px solid black;
  display:flex;
  flex-direction: column;
}


</style>
