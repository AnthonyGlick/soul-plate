<template>
  <div class="restaurant-summaries">
    <div class="summary" v-for="summary in summaries" :key="summary.id">
      <div class="featuredimage">
          <img :src ="summary.featured_image">
      </div>

    <div class="text-infor">    
        <h3 class="name">{{summary.name}}</h3>
        <h3 class="rating">{{summary.user_rating.aggregate_rating}}</h3>
        <h3 class="location">{{summary.location.locality}}</h3>
        <h3 class="cuisines">{{summary.cuisines}}</h3>
        <h3 class="price-range">{{summary.price_range}}</h3>
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
      method: 'GET',
      headers: {
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
