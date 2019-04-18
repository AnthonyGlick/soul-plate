<template>
  <div class="favorite-page">
    <h1 class="favorites">Favorites</h1>
    <div class="user-favorites">
      <favorite v-bind:userFavorites="userFavorites" v-for="favorite in userFavorites" v-bind:key="favorite"/>
    </div>
  </div>
</template>

<script>
import auth from "@/shared/auth";
import Favorite from "@/components/Favorites/Favorite.vue";
export default {
  name: "Favorites",
  components: {
    Favorite
  },
  data() {
    return {
      userFavorites: [],
      username: auth.getUser().sub
    };
  },

  created() {
    fetch(`${process.env.VUE_APP_REMOTE_API}/Favorites/${this.username}`, {
      method: "GET",
      headers: {
        "Authorization": 'Bearer ' + auth.getToken() 
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
  display: flex;
  flex-wrap: wrap;
  justify-content: space-around;
  margin: 0px 100px;
}

.favorite-page {
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
</style>
