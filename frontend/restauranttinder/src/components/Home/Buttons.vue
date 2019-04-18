<template>
  <div>
    <reject-button></reject-button>
    <like-button></like-button>
  </div>
</template>

<script>
import RejectButton from "@/components/Home/RejectButton.vue";
import LikeButton from "@/components/Home/LikeButton.vue";

export default {
  components: {
    RejectButton,
    LikeButton
  },
  name: "Buttons"
};
</script>

<style>
</style>
