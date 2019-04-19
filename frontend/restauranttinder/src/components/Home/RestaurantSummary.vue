<template>
  <div class="restaurant-summaries">
    <div class="summary" v-if="summaries.restaurants" :key="restaurantNumber">
      <div class="featuredimage">
        <img :src="getImage">
      <div class="text-infor">
        <div class="text-container" id="text-info">
          <h3 class="name">{{summaries.restaurants[restaurantNumber].restaurant.name}}</h3>
          <h3 class="rating">
            <span class="rating-object">Rating:</span>
            {{summaries.restaurants[restaurantNumber].restaurant.user_rating.aggregate_rating}} out of 5
          </h3>
          <h3 class="location">
            <span class="location-object">Location:</span>
            {{summaries.restaurants[restaurantNumber].restaurant.location.locality}}
          </h3>
          <h3>
            <span class="cuisine-object">Cuisine:</span>
            {{summaries.restaurants[restaurantNumber].restaurant.cuisines}}
          </h3>
          <h3>
            <span class="price-range">Price:</span>
            <span class="dollar-sign">{{dollarprice}}</span>
          </h3>
        </div>
      </div>
    </div>
    <!-- <button v-on:click="nextRestaurant" v-if="summaries.restaurants">Next Restaurant</button> -->
    <div id="buttons">
      <reject-button v-on:Reject="rejectRestaurant" v-if="summaries.restaurants"/>
      <like-button v-on:Like="likeRestaurant" v-if="summaries.restaurants"/>
    </div>
  </div>
  </div>
</template>

<script>
import auth from "@/shared/auth";
import RejectButton from "@/components/Home/RejectButton.vue";
import LikeButton from "@/components/Home/LikeButton.vue";
import { bus } from "../../main.js";
import restaurantimagejson from "../../assets/data/restaurantimage.json";

export default {
  name: "RestaurantSummary",
  props: {
    summaries: Object
  },
  components: {
    RejectButton,
    LikeButton
  },
  computed: {
    dollarprice: function() {
      let dollarsigns = "";

      if (this.summaries && this.summaries.restaurants) {
        for (
          let i = 0;
          i <
          this.summaries.restaurants[this.restaurantNumber].restaurant
            .price_range;
          i++
        ) {
          dollarsigns += "$";
        }
      }
      return dollarsigns;
    },
    getImage() {
      let thisRestaurant = this.summaries.restaurants[this.restaurantNumber].restaurant;
      if (
        thisRestaurant.featured_image
      ) {
        return thisRestaurant.featured_image;
      } 
      
      let filteredList = this.restaurantimage.filter(image => {
          return (image.id == thisRestaurant.id);
        });

      if (filteredList.length > 0) {
        if (filteredList[0].id ==
          thisRestaurant.id
        ) {
          return filteredList[0].featured_image;
        }
      } 
      
      return "https://via.placeholder.com/1200x464";
    }
  },

  data() {
    return {
      restaurantNumber: 0,
      emptyArray: "Still hungry? Search again!",
      username: auth.getUser().sub,
      restaurantimage: restaurantimagejson,
      oneImage: ""
    };
  },
  watch: {
    summaries: function(shuffled) {
      let shuffArray = shuffled.restaurants;
      this.shuffle(shuffArray);
    }
  },
  methods: {
    nextRestaurant() {
      if (this.summaries.restaurants.length < 1) {
        return this.emptyArray;
      }
      if (this.restaurantNumber < this.summaries.restaurants.length - 1) {
        this.restaurantNumber = this.restaurantNumber + 1;
      } else {
        this.restaurantNumber = 0;
      }
    },
    rejectRestaurant() {
      this.summaries.restaurants.splice(this.restaurantNumber, 1);
    },
    likeRestaurant() {
      try {
        const payload = {
          "RestaurantId": this.summaries.restaurants[this.restaurantNumber].restaurant.id,
           "RestaurantName": this.summaries.restaurants[this.restaurantNumber].restaurant.name,
           // "RestaurantAddress": this.summaries.restaurants[this.restaurantNumber].restaurant.address,
           "RestaurantImage": this.summaries.restaurants[this.restaurantNumber].restaurant.featured_image,
           "RestaurantPriceRange": this.summaries.restaurants[this.restaurantNumber].restaurant.price_range
        };
        const url = `${process.env.VUE_APP_REMOTE_API}/favorites/addfavorite`;
        const response = fetch(url, {
          method: "POST",
          headers: {
            "Content-Type": "application/json",
            Authorization: "Bearer " + auth.getToken()
          },
          body: JSON.stringify(payload)
        });

        if (response.status === 400) {
          this.error = "NOPE";
        } else {
          if (this.summaries.restaurants.length < 1) {
            return this.emptyArray;
          }
          if (this.restaurantNumber < this.summaries.restaurants.length - 1) {
            this.restaurantNumber = this.restaurantNumber + 1;
          } else {
            this.restaurantNumber = 0;
          }
        }
      } catch (error) {
        this.error = "There was an error attempting to save this favorite.";
      }
    },
    shuffle(a) {
      var j, x, i;
      for (i = a.length - 1; i > 0; i--) {
        j = Math.floor(Math.random() * (i + 1));
        x = a[i];
        a[i] = a[j];
        a[j] = x;
      }
      return a;
    }
  },
  mounted() {
    bus.$on("rejectSwipe", this.rejectRestaurant);
    bus.$on("likeSwipe", this.likeRestaurant);
  }
};
</script>

<style>
.summary {
  display: flex;
  flex-direction: column;
}

h1.question {
  font-size: 2.5rem;
}

div.text-infor {
  font-family: "Vollkorn", sans-serif;
  display: inline-block;
  background-color: white;
}

img.featuredimage {
  height: 300px;
  width: 100%;
}

div.text-infor {
  background-color: rgba(255, 255, 255, 0.8);
}

.featuredimage img {
  width: 100%;
}

.featuredimage {
  width: 100%;
  height: 50%;
}

.restaurant-summaries {
  position: absolute;
  margin-top: 190px;
  left: 0;
  right: 0;
  margin-left: 400px;
  margin-right: 400px;
}

span.dollar-sign {
  color: #28a745;
  font-size: 30px;
}

.text-infor {
  margin-top: 10px;
  width: inherit;
  text-align: left;
  padding: 8px;
}

h3.name {
  font-size: 36px;
  font-weight: bold;
}

span.rating-object {
  font-size: 26px;
  font-weight: 700;
}

span.location-object {
  font-size: 26px;
  font-weight: 700;
}

span.cuisine-object {
  font-size: 26px;
  font-weight: 700;
}

span.price-range {
  font-size: 26px;
  font-weight: 700;
}

#buttons {
  display: flex;
  justify-content: space-around;
  padding-top: 10px;
}

@media screen and (min-width: 1920px) {
  .featuredimage img {
    padding-top: 50px;
  }

  #check-location {
    font-size: 26px;
  }
}

@media screen and (max-width: 1280px) {
  .restaurant-summaries {
    display: flex;
    flex-direction: column;
    margin: 0;
    margin-left: 40%;
    margin-right: 10px;
    margin-top: 10px;
  }
  #text-info > *,
  #text-info > * > * {
    font-size: 1.7rem;
  }
}

@media screen and (max-width: 425px) {
  .restaurant-summaries {
    margin-left: 10px;
    margin-top: 275px;
    padding-top: 0.08%;
  }

  #text-info > *,
  #text-info > * > * {
    font-size: 1.2rem;
  }

  h3.name {
    text-align: center;
  }

  #buttons {
    display: none;
  }
}

@media screen and (max-width: 360px) {
  .restaurant-summaries {
    margin-left: 10px;
    margin-top: 275px;
    padding-top: 0.08%;
  }

  #radius {
    width: 45%;
    height: 30px;
  }

  
  
}
</style>
