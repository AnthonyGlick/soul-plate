<template>
  <div class="summary" :class="{isCurrent:isCurrent}">
    <h2 class="summaryTitle">{{summary.name}}</h2>
  </div>
</template>

<script>
export default {
    props:{
        summary:{
            type: Object,
            required:true
        },
        isCurrent:{
            type:Boolean,
            required:true
        }
    }
};
</script>

<style>

</style>
