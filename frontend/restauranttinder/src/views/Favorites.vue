<template>
  <div class="favorite-page">
    <h1 class="favorites">Favorites</h1>
    <div class="user-favorites" v-for="(favorite, i) in userFavorites" :key="i">
      <!-- <div v-for="favorite in userFavorites" :key="favorite.restaurantId"/> -->
      <div class="user-favorite">
        <img class="pic" v-bind:src="userFavorites[i].restaurantImage">
        <h2 class="name">{{userFavorites[i].restaurantName}}</h2>
        <div>
        <span class="dollar-sign" v-if="userFavorites[i].restaurantPriceRange === 1">$</span>
        <span class="dollar-sign" v-else-if="userFavorites[i].restaurantPriceRange === 2">$$</span>
        <span class="dollar-sign" v-else-if="userFavorites[i].restaurantPriceRange === 3">$$$</span>
        <span class="dollar-sign" v-else-if="userFavorites[i].restaurantPriceRange === 4">$$$$</span>
        <span class="dollar-sign" v-else>$$$$$</span>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import auth from "@/shared/auth";
// import Favorite from "@/components/Favorites/Favorite.vue";
export default {
  name: "Favorites",
  // components: {
  //   Favorite
  // },
  data() {
    return {
      userFavorites: [],
      username: auth.getUser().sub
    };
  },
  computed: {
    dollarprice: function() {
      let dollarsigns = "";

      if (this.userFavorites) {
        for (
          let i = 0;
          i <
          this.userFavorites[i].restaurantPriceRange;
          i++
        ) {
          dollarsigns += "$";
        }
      }
      return dollarsigns;
    }
  },
  created() {
    fetch(`${process.env.VUE_APP_REMOTE_API}/Favorites/${this.username}`, {
      method: "GET",
      headers: {
        Authorization: "Bearer " + auth.getToken()
      }
    })
      .then(response => {
        return response.json();
      })
      .then(json => {
        this.userFavorites = json;
        console.log(this.userFavorites);
      });
  }
};
</script>

<style>
.user-favorites {
  justify-content: space-around;
  margin: 5%;
  border: 5px dotted white;
}

.favorite-page { 
  display: flex;
  flex-wrap:wrap;
  width:100%;
  margin: 20px;
  position: absolute;
  background-color: #ff9933;
  opacity: 0.9;
  border: 1px solid black;
  border-radius: 5px;
}

.favorites {
  color: black;
  font-size: 48px;
  font-family: "Vollkorn", sans-serif;
}

@media screen and (max-width: 425px) {
  .user-favorites {
    margin: 0;
  }
}
.user-favorite {
  display: flex;
  flex-wrap: wrap;
  flex-direction: column;
}

.name {
  color: black;
  font-family: "Vollkorn", sans-serif;
  font-size: 1.2em;
}

.pic {
  width:100%;
  padding-bottom: 5px;
  border-radius: 10px;
}
</style>
