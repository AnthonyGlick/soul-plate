<template>
  <div class="form-block">
    <h1>Home</h1>
    <form method="GET" @submit.prevent="onSubmit()">
      <auto-complete name="Cuisine" placeholder="Cuisine" id="Cuisine" :choices="cuisineNames" 
      @change="getCuisineId(document.getElementById(Cuisine).value)"></auto-complete>
      <section>
        <input id="checkbox" type="checkbox" @change="toggleCoords">
        <span>Check for current location, uncheck for saved address</span>
      </section>
      <select v-model="radius" name="" id="">
        <option value="100">100</option>
        <option value="200">200</option>
        <option value="300">300</option>
        <option value="400">400</option>
        <option value="500">500</option>
      </select>
      <input type="hidden" id="lat" :value="latToggle">
      <input type="hidden" id="lon" :value="lonToggle">
    </form>
  </div>
</template>

<script>
import AutoComplete from "@/components/query/AutoComplete.vue";
import auth from "@/shared/auth";
export default {
  name: "RestaurantSearch",
  components: {
    AutoComplete
  },
  data() {
    return {
      cuisines: [],
      cuisineNames: [],
      currentUser: [],
      username: auth.getUser().sub,
      currentCoords: {
        lat: "",
        long: ""
      },
      addressCoords: {},
      radius: "",
      chosenCuisine: "",
      restaurants: {}
    };
  },
  methods: {
    toggleCoords() {
      this.latToggle();
      this.lonToggle();
    },
    latToggle() {
      if (document.getElementById("lat").value == this.currentCoords.lat) {
        document.getElementById("lat").value = this.addressCoords.results.geometry.location.lat;
      } else {
        document.getElementById("lat").value = this.currentCoords.lat;
      }
    },
    lonToggle() {
      if (document.getElementById("lon").value == this.currentCoords.lon) {
        document.getElementById("lon").value = this.addressCoords.results.geometry.location.lng;
      } else {
        document.getElementById("lon").value = this.currentCoords.lon;
      }
    },
    onSubmit() {
      const currentLat = document.getElementById("lat").value;
      const currentLon = document.getElementById("lon").value;
      const endpoint =
        "/search?lat=" + currentLat + "&lon=" + currentLon + "&radius=" + this.radius + "&cuisine=" + this.chosenCuisine /** TODO convert miles meters */;
      fetch(`${process.env.VUE_APP_ZOMATO_API}${endpoint}`, {
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
          this.restaurants = json;
        }).catch(error => console.error(error));
    },
    getCuisineId(cuisineName) {
      let tempCuisine = this.cuisines.filter(cuisine => {
        return cuisine.name.toLowerCase() === cuisineName.toLowerCase();
      })
      this.chosenCuisine = tempCuisine.cuisine_id;
    }
  },
  created() {
    fetch(`${process.env.VUE_APP_ZOMATO_API}/cuisines?city_id=1033`, {
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
        this.cuisines = json.cuisines;
        this.cuisineNames = this.cuisines.map(
          cuisine => cuisine.cuisine.cuisine_name
        );
      })
      .catch(error => console.error(error));

      fetch(`${process.env.VUE_APP_REMOTE_API}/Account/${this.username}`, {
        method: "GET",
      headers: {
        "Content-Type": "application/json",
      }
      }).then(response => {
        return response.json();
      }).then(json => {
        this.currentUser = json;
      });
      /** TODO NOT HARD CODE vvvvv */
      fetch(`https://maps.googleapis.com/maps/api/geocode/json?address=311+Bettie+Lane,+Brunswick,+OH&key=${process.env.VUE_APP_GOOGLE_KEY}`,{
        method: "GET",
      headers: {
        "Content-Type": "application/json",
      }
      }).then(response => {
        return response.json();
      }).then(json => {
        this.addressCoords = json;
      })

      getLocation();
  }
};
function getLocation() {
  if (navigator.geolocation) {
    navigator.geolocation.getCurrentPosition(showPosition);
  }
}
function showPosition(position) {
  this.currentCoords.lat = position.coords.latitude;
  this.currentCoords.lon = position.coords.longitude;
}
</script>

<style>
html {
  color: white;
}
</style>
