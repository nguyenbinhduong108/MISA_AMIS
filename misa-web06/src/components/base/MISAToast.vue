<template>
    <div class="toast-container">
        <div class="toast">
            <div class="icon-container-24px">
                <div class="icon success"></div>
            </div>
            <div class="text">{{ infos }}</div>
            <div class="icon-container-24px close" @click="closeToast">
                <div class="icon"></div>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    name: "MISAToast",
    props: ["infos"],
    created() {
    },
    methods: {
        /**
         * đóng toast bằng buntton
         * Author: NBDUONG (02/08/2023)
         */
        closeToast() {
            this.$emit("closeToast");
        },
    },

    data() {
        return {
        };
    },
}
</script>

<style>
@import url(../../css/base/toast.css);
</style>