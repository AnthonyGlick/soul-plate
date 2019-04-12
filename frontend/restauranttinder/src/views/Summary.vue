<template>
    <div id="summary-view">
    <h3> Summary test title restaurant</h3>
        <RestaurantStack
        :summaries="visibleSummaries"
        @summaryAccepted ="handleSummaryAccepted"
        @summaryRejected = "handleSummaryRejected"
        @summaryRemove = "handleSummaryRemove"
        />
    </div>
</template>

<script>
import RestaurantStack from "@/components/restaurants/RestaurantStack.vue";
import auth from "@/shared/auth";

export default {
    name:"Summary",
    components: {
        RestaurantStack
    },
    data() {
        return{
            visibleSummaries: ["testTitle1","testTitle2","testTitle3","testTitle4"]
        };
    },
    methods: {
        handleSummaryAccepted() {
            console.log("handleSummaryAccepted");
        },
        handleSummaryRejected() {
            console.log("handleSummaryRejected");
        },
        handleSummaryRemove() {
            this.visibleSummaries.shift();
        }
    }
};
</script>

<style>

</style>
