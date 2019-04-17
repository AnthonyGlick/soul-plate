<template>
<div class="user-favorites">
    <h1>Favorites</h1>
    <favorite v-for="favorite in dummyData" v-bind:key="favorite"/>
</div>
</template>

<script>
import Favorite from "@/components/Favorites/Favorite.vue";
export default {
    name: "Favorites",
    components: {
        Favorite
    },
    data(){
        return {
            dummyData: [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
        }
    }
}

</script>

<style scoped>
.user-favorites {
    display: flex;
    flex-wrap: wrap;
    position: relative;
}

</style>
