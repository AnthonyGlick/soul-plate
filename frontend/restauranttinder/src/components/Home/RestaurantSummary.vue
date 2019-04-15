<template>
  <div class="restaurant-summaries">
    <div class="summary" :key="restaurantNumber">
      <div class="featuredimage">
          <img :src ="summaries.restaurants[restaurantNumber].restaurant.featured_image">
      </div>

    <div class="text-infor">    
        <h3 class="name">{{summaries.restaurants[restaurantNumber].restaurant.name}}</h3>
        <h3 class="rating">{{summaries.restaurants[restaurantNumber].restaurant.user_rating.aggregate_rating}}</h3>
        <h3 class="location">{{summaries.restaurants[restaurantNumber].restaurant.location.locality}}</h3>
        <h3 class="cuisines">{{summaries.restaurants[restaurantNumber].restaurant.cuisines}}</h3>
        <h3 class="price-range">{{summaries.restaurants[restaurantNumber].restaurant.price_range}}</h3>
      </div> 
    </div>
  </div>
</template>

<script>
export default {
  name: "RestaurantSummary",
  props: {
    testurl: String
  },
  data() {
    return {
      restaurantNumber: 0,
      summaries: []
    };
  },
  created() {
    fetch(this.testurl, {
      method: 'GET',
      headers: {
        "Content-Type": "application/json",
        "user-key": `${process.env.VUE_APP_ZOMATO_KEY}`
      }
    }).then( (response) => {
      return response.json();
    }).then( (json) => {
      this.summaries = json;
    }).catch( (error) => console.error(error));
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
</style>
