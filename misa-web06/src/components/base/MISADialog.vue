<template>
    <div class="dialog-container">
        <div class="dialog">
            <div class="dialog-header">
                <div class="title">
                    Thông báo
                </div>
                <div class="icon-container-24px" @click="closeDialogByIcon">
                    <div class="icon"></div>
                </div>

            </div>

            <div class="dialog-content">
                <div class="left">
                    <div class="icon-container-40px">
                        <div class="icon error"></div>
                    </div>
                </div>
                <div class="right">
                    <div class="info" v-for="(msg, index) in errors" :key="index">{{ msg }}</div>
                </div>

            </div>

            <div class="dialog-footer">
                <misa-button type="primary" buttonText="Đồng ý" @click="closeDialogByButton"></misa-button>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    name: 'MISADalog',
    props: {"errors": Array},

    created() {
        
    },
    methods: {

        /**
         * đóng dialog bằng icon
         * Author: NBDUONG (02/08/2023)
         */
        closeDialogByIcon() {
            this.$emit("closeDialogByIcon");
        },

        /**
         * đóng dialog bằng buntton
         * Author: NBDUONG (02/08/2023)
         */
        closeDialogByButton() {
            this.$emit("closeDialogByButton");
        },

    },
    data() {
        return {
        };
    }
}
</script>

<style scoped>
@import url(../../css/base/dialog.css);
</style>