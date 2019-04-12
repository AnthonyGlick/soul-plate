<template>
  <div class="form-block">
    <h1>Home</h1>
    <form>
      <auto-complete name="Cuisine" placeholder="Cuisine" id="Cuisine" :choices="cuisineNames"></auto-complete>
      <google-map/>
    </form>
  </div>
</template>

<script>
import AutoComplete from "@/components/query/AutoComplete.vue";
import GoogleMap from "@/components/maps/GoogleMap.vue";
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
      cuiElement: Object
    };
  },
  
  created() {
    //this.cuiElement = document.getElementById("Cuisine");
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
</script>

<style>
html {
  color: white;
}
</style>
