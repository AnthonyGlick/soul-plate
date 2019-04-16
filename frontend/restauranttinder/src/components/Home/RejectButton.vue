<template>
    <div class="reject-button">
        <button class="btn btn-primary" v-on:click="RejectRestaurant">Reject</button>
    </div>
</template>

<script>
export default {
    name: "RejectButton",
    methods:{
        RejectRestaurant(){
            this.$emit('Reject')
        }
    }
}

</script>

<style>

</style>
