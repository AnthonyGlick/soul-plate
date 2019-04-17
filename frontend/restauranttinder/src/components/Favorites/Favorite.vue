<template>
    <div class="user-favorite">
        <img src="https://via.placeholder.com/300x300" />
        <p class="name">Chicken Xperience</p>
    </div>
</template>

<script>
export default {
    name: "Favorite"

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

</style>
