<template>
  <div class="form-block">
    <h1>Home</h1>
    <form>
      <auto-complete name="Cuisine" placeholder="Cuisine" id="Cuisine" :choices="cuisineNames"></auto-complete>
      <section>
      <input type="checkbox" @change="toggleCoords"/>
      <span>Check for current location, uncheck for saved address</span>
      </section>
      <input type="hidden" id="lat" :value="latToggle"/>
      <input type="hidden" id="lon" :value="lonToggle"/>
    </form>
  </div>
</template>

<script>
import AutoComplete from "@/components/query/AutoComplete.vue";
import GoogleMap from "@/components/maps/GoogleMap.vue";
import auth from "@/shared/auth";
export default {
  name: "home",
  components: {
    AutoComplete, 
    GoogleMap
  },
  data() {
    return {
      cuisines: [],
      cuisineNames: [],
      currentUser: {
        username: auth.getUser().sub,
        address1: "",
        city: "",
        state: "",
        country: USA
      },
      currentCoords: {
        lat: "",
        long: ""
      },
      addressCoords: {
        lat: "",
        long: ""
      }
    };
  },
  method: {
    toggleCoords(){
      this.latToggle();
      this.lonToggle();
    },
    latToggle(){
      if (document.getElementById("lat").value == this.currentCoords.lat){
        document.getElementById("lat").value = this.addressCoords.lat;
      } else {
        document.getElementById("lat").value = this.currentCoords.lat;
      }
    },
    lonToggle(){
      if (document.getElementById("lon").value == this.currentCoords.lon){
        document.getElementById("lon").value = this.addressCoords.lon;
      } else {
        document.getElementById("lon").value = this.currentCoords.lon;
      }
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
        this.cuisineNames = this.cuisines.map(cuisine => cuisine.cuisine.cuisine_name);
      })
      .catch(error => console.error(error));
  }
};
function getLocation() {
  if (navigator.geolocation) {
    navigator.geolocation.getCurrentPosition(showPosition);
  }
}
</script>

<style>
html {
  color: white;
}
</style>
