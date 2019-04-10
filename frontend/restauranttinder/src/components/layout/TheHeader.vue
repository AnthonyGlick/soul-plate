<template>
    <header>
    <div>
    <nav>
    <ul>
        <li v-if="isAuthenticated">
            <a href="/logout" v-on:click.prevent="logout">Logout</a>
        </li>
        <li v-else>
            <router-link to="/login">Login</router-link>
        </li>
    </ul>
    </nav>
    </div>
    </header>
</template>

<script>
export default {
  name: "the-header",
data() {
    return {
        isAuthenticated: getUser() !== null
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
}
</script>

<style>

</style>
