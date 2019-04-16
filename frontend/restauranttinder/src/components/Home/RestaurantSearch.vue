<template>
  <div class="form-block">
    <h1>Home</h1>
    <form method="GET" @submit.prevent="onSubmit()">
      <auto-complete
        name="Cuisine"
        placeholder="Cuisine"
        id="Cuisine"
        :choices="cuisineNames"
      ></auto-complete>
      <section>
        <input id="checkbox" type="checkbox" @change="toggleCoords">
        <span>Check for current location, uncheck for saved address</span>
      </section>
      <select v-model="radius" name id>
        <option value="100">100</option>
        <option value="200">200</option>
        <option value="300">300</option>
        <option value="400">400</option>
        <option value="500">500</option>
      </select>
      <input type="submit" v-on:click.prevent="performSearch" value="Submit">
      <input type="hidden" id="lat" :value="currentCoords.lat">
      <input type="hidden" id="lon" :value="currentCoords.lon">
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
        lon: ""
      },
      addressCoords: {},
      radius: "",
      chosenCuisine: "",
      restaurants: {}
    };
  },
  props: {
    searchUrl: String
  },
  methods: {
    toggleCoords() {
      this.latToggle();
      this.lonToggle();
    },
    latToggle() {
      if (document.getElementById("lat").value == this.currentCoords.lat) {
        document.getElementById(
          "lat"
        ).value = this.addressCoords.results.geometry.location.lat;
      } else {
        document.getElementById("lat").value = this.currentCoords.lat;
      }
    },
    lonToggle() {
      if (document.getElementById("lon").value == this.currentCoords.lon) {
        document.getElementById(
          "lon"
        ).value = this.addressCoords.results.geometry.location.lng;
      } else {
        document.getElementById("lon").value = this.currentCoords.lon;
      }
    },
    performSearch() {
      const currentLat = document.getElementById("lat").value;
      const currentLon = document.getElementById("lon").value;
      this.endpoint =
        "/search?lat=" +
        currentLat +
        "&lon=" +
        currentLon +
        "&radius=" +
        this.radius +
        "&cuisines=" +
        (document.getElementById('Cuisine').value); /** TODO convert miles meters */
      fetch(`${process.env.VUE_APP_ZOMATO_API}${this.endpoint}`, {
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
          this.$emit("search-results", json);
        })
        .catch(error => console.error(error));
    },
    getCuisineId(cuisineName) {
    let tempCuisine = this.cuisines.filter(cuisine => {
      return cuisine.name.toLowerCase() === cuisineName.toLowerCase();
    });
    this.chosenCuisine = tempCuisine.cuisine_id;
  },
  getLocation() {
    if (navigator.geolocation) {
      navigator.geolocation.getCurrentPosition(this.showPosition);
    }
  },
  showPosition(position) {
    console.log(position.coords.latitude);
    // var currentCoords = {
    //   lat: 0,
    //   lon: 0
    // }
    this.currentCoords.lat = position.coords.latitude;
    this.currentCoords.lon = position.coords.longitude;
    console.log(this.currentCoords);
  },
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
        "Content-Type": "application/json"
      }
    })
      .then(response => {
        return response.json();
      })
      .then(json => {
        this.currentUser = json;
      });
    /** TODO NOT HARD CODE vvvvv */
    fetch(
      `https://maps.googleapis.com/maps/api/geocode/json?address=311+Bettie+Lane,+Brunswick,+OH&key=${
        process.env.VUE_APP_GOOGLE_KEY
      }`,
      {
        method: "GET",
        headers: {}
      }
    )
      .then(response => {
        return response.json();
      })
      .then(json => {
        this.addressCoords = json;
      });

    this.getLocation();
  }
};
</script>

<style>
html {
  color: white;
}
</style>
