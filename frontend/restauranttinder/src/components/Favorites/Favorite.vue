<template>
    <div class="user-favorite">
        <img class="pic" src="https://via.placeholder.com/300x300" />
        <p class="name">Chicken Xperience</p>
        <h4>{{userFavorites[0].restaurantName}}</h4>
    </div>
</template>

<script>
export default {
    name: "Favorite",
    props: {
        userFavorites: Array
    }

}
</script>

<style scoped>
.user-favorite {
    display: flex;
    flex-wrap: wrap;
    flex-direction: column;
}

.name {
    color: black;
    font-family: 'Vollkorn', sans-serif;
    font-size: 1.2em;
}

.pic {
    padding-bottom: 5px;
    border-radius: 10px;
}
</style>
