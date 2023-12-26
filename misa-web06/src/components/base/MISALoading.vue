<template>
    <div class="loading">
        <div class="loading-icon"></div>
    </div>
</template>

<script>
export default {
    
}
</script>

<style scope>
.loading{
    width: calc(100% - 200px);
    position: fixed;
    top: 240px;
    bottom: 88px;
    right: 0;
    display: flex;
    justify-content: center;
    align-items: center;
}

.loading-icon{
    background-image: url(../../assets/loading.svg);
    width: 32px;
    height: 32px;
    z-index: 9999;
}
</style>