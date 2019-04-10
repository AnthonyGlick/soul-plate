<template>
  <header>
    <div>
        <nav>
      <li v-if="isAuthenticated">
        <button class="btn btn-primary" href="/logout" v-on:click.prevent="logout">Logout</button>
      </li>
      <li v-else>
        <router-link to="/login">Login</router-link>
      </li>
      </nav>
    </div>
  </header>
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
</style>
