<template>
<nav class="navbar navbar-inverse">
  <div class="container-fluid">
    <div class="navbar-header">
      <a class="navbar-brand" href="/">Soul Plate</a>
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
</style>
