<template>
    <div class ="summaries">
        <RestaurantSummary
            v-for="(summary,index) in summaries"
            :key="summary"
            :summary="summary"
            :is-current="index === 0"
        />
    </div>
</template>

<script>
    import RestaurantSummary from "@/components/restaurants/RestaurantSummary";
export default {
    components:{
        RestaurantSummary
    },
    props:{
        summaries:{
            type:Array,
            required:true
        }
    }
};
</script>

<style>

</style>
