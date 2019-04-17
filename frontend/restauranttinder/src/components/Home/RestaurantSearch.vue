<template>
  <div class="form-block">
    <h1 class="question">What are you in the mood for?</h1>
    <form method="GET" @submit.prevent="onSubmit()">
      <!-- <label class="Food-search">Food Search</label> -->
      <auto-complete
        v-on:input="setCuisineString"
        name="Cuisine"
        placeholder="Cuisine"
        id="Cuisine"
        :choices="cuisineNames"
      ></auto-complete>
      <section>
        <input id="checkbox" type="checkbox" @change="toggleCoords">
        <span id="check-location">Check for saved address, uncheck for current location</span>
      </section>
      <select v-model="radius" name id>
        <option value="1609">1 mile</option>
        <option value="8046">5 miles</option>
        <option value="16093">10 miles</option>
        <option value="40233">25 miles</option>
        <option value="80467">50 miles</option>
      </select>
      <input 
        id="submit-button"
        class="btn btn-success"
        type="submit"
        v-on:click.prevent="performSearch"
        value="Submit"
      >
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
      currentUser: {},
      cuisineString: "",
      username: auth.getUser().sub,
      currentCoords: {
        lat: "",
        lon: ""
      },
      addressCoords: {},
      radius: "",
      //chosenCuisine: "",
      restaurants: {}
    };
  },
  props: {
    searchUrl: String
  },
  methods: {
    setCuisineString(value) {
      this.cuisineString = value;
    },
    toggleCoords() {
      this.latToggle();
      this.lonToggle();
    },
    latToggle() {
      if (document.getElementById("lat").value == this.currentCoords.lat) {
        document.getElementById(
          "lat"
        ).value = this.addressCoords.results[0].geometry.location.lat;
      } else {
        document.getElementById("lat").value = this.currentCoords.lat;
      }
    },
    lonToggle() {
      if (document.getElementById("lon").value == this.currentCoords.lon) {
        document.getElementById(
          "lon"
        ).value = this.addressCoords.results[0].geometry.location.lng;
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
        this.cuisineId;
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

    getLocation() {
      if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(this.showPosition);
      }
    },
    showPosition(position) {
      console.log(position.coords.latitude);
      this.currentCoords.lat = position.coords.latitude;
      this.currentCoords.lon = position.coords.longitude;
      console.log(this.currentCoords);
    }
  },

  computed: {
    cuisineId() {
      let tempCuisine = this.cuisines.filter(cuisine => {
        return (
          cuisine.cuisine.cuisine_name.toLowerCase() ===
          this.cuisineString.toLowerCase()
        );
      });
      if (tempCuisine.length === 0) {
        return "";
      } else {
        return tempCuisine[0].cuisine.cuisine_id;
      }
    }
  },

  created() {
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
        console.log(this.currentUser);
      });
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

    /** TODO NOT HARD CODE vvvvv */

    this.getLocation();
  },
  watch: {
    currentUser: function(newId, oldId) {
      if (newId !== oldId) {
        fetch(
          `https://maps.googleapis.com/maps/api/geocode/json?address=
      ${this.currentUser.addressOne.replace(" ", "+")},+
      ${this.currentUser.city.replace(" ", "+")},+
      ${this.currentUser.state}&key=
      ${process.env.VUE_APP_GOOGLE_KEY}`,
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
            console.log(this.addressCoords);
          });
      }
    }
  }
};
</script>

<style scoped>
html {
  color: white;
}

div.form-block {
  border: 1px solid black;
  position: absolute;
  padding: 50px;
  background-color: #ff9933;
  opacity: 0.8;
  border-top-left-radius: 5px;
  border-top-right-radius: 5px;
  right: 0;
  left: 0;
  margin-left: 400px;
  margin-right: 400px;
  margin-top: 10px;
}

form {
  display: flex;
  justify-content: space-around;
}

input:focus {
  border: 2px solid blue;
}

@media screen and (max-width: 1280px) {
  div.form-block {
    margin: 0;
    display: flex;
    flex-direction: column;
    margin-right: 62%;
    margin-top: 10px;
    margin-left: 10px;
    padding-top: 13px;
  }

  form {
    display: flex;
    flex-direction: column;
    align-items: center;
    height: 79px;
  }

  form > * {
    margin-bottom: 15px;
  }

  input[type="submit"],
  select {
    width: 36%;
  }

  h1 {
    font-size: 2em;
    padding-bottom: 65px;
  }

  #Cuisine {
    margin-top: 20px;
  }
}

@media screen and (max-width: 768px) {
  div.form-block {
    padding-bottom: 50px;
    padding-left: 0;
    padding-right: 0;
  }

  #submit-button {
    width: 50%;
  }
}

@media screen and (max-width: 425px) {
  div.form-block{
    margin-right: 10px;
  }

  .question {
    font-size: 24px;
  }

}
</style>
