<template>
    <div class="main">
        <router-view></router-view>
    </div>

    <misa-dialog 
        v-if="dialogComponent" 
        @closeDialogByIcon="closeDialogByIcon" 
        @closeDialogByButton="closeDialogByButton"
        :errors="errors"></misa-dialog>

    <misa-toast 
        v-if="toastComponent"
        @closeToast="closeToast" 
        :infos="infos" ></misa-toast>

    <misa-loading v-if="loadingComponent"></misa-loading>
</template>

<script>


export default {
    name: "TheMain",
    created() {
        this.$_emitter.on('showDialog', this.onShowDialog);
        this.$_emitter.on('showToast', this.onShowToast);
        this.$_emitter.on('showLoading', this.onShowLoading);
        this.$_emitter.on('closeLoading', this.onCloseLoading);
    },

    unmounted() {
        this.$_emitter.off('showDialog');
        this.$_emitter.off('showToast');
        this.$_emitter.off('showLoading');
        this.$_emitter.off('closeLoading');
    },
    methods: {
        /**
         * đóng dialog bằng icon 
         * Author: NBDUONG (02/08/2023)
         */
        closeDialogByIcon() {
            this.dialogComponent = false;
        },

        /**
         * đóng dialog bằng buntton
         * Author: NBDUONG (02/08/2023)
         */
        closeDialogByButton() {
            this.dialogComponent = false;
        },


        /**
         * đóng toast bằng icon
         * Author: NBDUONG (02/08/2023)
         */
         closeToast() {
            this.toastComponent = false;
        },

        /**
         * hiện thị toast mesage và tự đóng sau 3s
         * Author: NBDUONG (02/08/2023)
         */
         onShowToast(info) {
            this.infos = info;
            this.toastComponent = true;
            setTimeout(() => {
                this.toastComponent = false;
            }, 3000);
        },

        /**
         * hiển thị dialog
         * Author: NBDUONG (03/08/2023)
         */
        onShowDialog(error) {
            this.errors = error;
            this.dialogComponent = true;
        },

        /**
         * hiển thị loading
         * Author: NBDUONG (04/08/2023)
         */
        onShowLoading(){
            this.loadingComponent = true;
        },

        /**
         * ẩn loading
         * Author: NBDUONG (04/08/2023)
         */
        onCloseLoading(){
            this.loadingComponent = false;
        }
    },
    data() {
        return {
            dialogComponent: false,
            toastComponent: false,
            loadingComponent: false,
            errors: '',
            infos: '',
        }
    }
}
</script>

<style scoped>
.main {
    width: 100%;
    flex: 1;
    display: flex;
    flex-direction: column;
    margin: 24px;
    position: relative;
}
</style>