<template>
<nav class="navbar navbar-inverse">
  <div class="container-fluid">
    <div class="navbar-header">
      <a class="navbar-brand" href="/"><img class="logo" v-bind:src='image'>  Soul Plate</a>
    </div>
    <ul class="header-right">
      <li><button href="/" class="btn btn-primary">View Favorites</button></li>
        <router-link to="/createprofile">
          <li><button href="/createprofile" class="btn btn-primary">Edit Profile</button></li>
        </router-link>
      <li v-if="isAuthenticated">
        <router-link to="/login">
        <button class="btn btn-primary" v-on:click.prevent="logout">Logout</button>
        </router-link>
        </li>
    </ul>
  </div>
</nav>
</template>

<script>
import auth from "@/shared/auth";

export default {
  name: "the-header",
  data() {
    return {
      image: require('../../assets/imgs/restaurant-1724294_1280.png'),
      isAuthenticated: auth.getUser() !== null
    };
  },
  methods: {
    /**
     * Logs the user out and takes them to the login page
     * @function
     */
    logout() {
      auth.destroyToken();
      this.$router.push("/login");
    }
  },
  computed: {
    getUser() {
      return auth.getUser();
    }
  }
};
</script>

<style scoped>
.header-right {
  display: flex;
  justify-content: flex-end;
}
li {
  list-style: none;
  padding: 5px;
}

.logo {
  height: 75px;
  width:auto;
  padding-bottom: 10px;
  filter: grayscale(100%)
  
}

.navbar.navbar-inverse {
  background-color: #ff9933;
}

.navbar-brand {
  font-family: 'Vollkorn', sans-serif;
  color: black;
  font-size: 35px;
}

.btn.btn-primary {
  font-family: 'Vollkorn', sans-serif;
  background: black;
  font-size: 18px;
}

@-webkit-keyframes rotating /* Safari and Chrome */ {
  from {
    -webkit-transform: rotate(0deg);
    -o-transform: rotate(0deg);
    transform: rotate(0deg);
  }
  to {
    -webkit-transform: rotate(360deg);
    -o-transform: rotate(360deg);
    transform: rotate(360deg);
  }
}
@keyframes rotating {
  from {
    -ms-transform: rotate(0deg);
    -moz-transform: rotate(0deg);
    -webkit-transform: rotate(0deg);
    -o-transform: rotate(0deg);
    transform: rotate(0deg);
  }
  to {
    -ms-transform: rotate(360deg);
    -moz-transform: rotate(360deg);
    -webkit-transform: rotate(360deg);
    -o-transform: rotate(360deg);
    transform: rotate(360deg);
  }
}
.logo:hover {
  -webkit-animation: rotating 2s linear infinite;
  -moz-animation: rotating 2s linear infinite;
  -ms-animation: rotating 2s linear infinite;
  -o-animation: rotating 2s linear infinite;
  animation: rotating 2s linear infinite;
}

</style>
