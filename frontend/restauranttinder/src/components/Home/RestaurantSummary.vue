<template>
  <div class="restaurant-summaries">
    <div
      class="summary"
      v-for="restaurant in summaries.restaurants"
      :key="restaurant.restaurant.id"
    >
      <div v-if="restaurant.restaurant.featured_image" class="featuredimage">
        <img :src="restaurant.restaurant.featured_image">
      </div>
      <div v-else><img class="featuredimage" src= "https://via.placeholder.com/1200x464"></div>

      <div class="text-infor">
        <h3 class="name">{{restaurant.restaurant.name}}</h3>
        <h3 class="rating">Rating: {{restaurant.restaurant.user_rating.aggregate_rating}}</h3>
        <h3 class="location">Location: {{restaurant.restaurant.location.locality}}</h3>
        <h3 class="cuisines">{{restaurant.restaurant.cuisines}}</h3>
        <h3 class="price-range">{{restaurant.restaurant.price_range}}</h3>
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
