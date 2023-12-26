<template>
    <div class="tooltip">
        <button class="btn" :class="classObj">{{ buttonText }}</button>
    <div class="tooltiptext" v-if="tooltip"> {{ tooltiptext }} </div>
    </div>
    
</template>

<script>
export default {
    name: "MISAButton",
    props:[
        'buttonText',
        'tooltip',
        'tooltiptext',
        'type',
    ],   
    computed: {
        classObj() {
            if(this.type == "primary"){
                return "btn-primary";
            }
            if(this.type == "secondary"){
                return "btn-secondary";
            }
        }
    }
    
}
</script>

<style scoped>
@import url(../../css/base/button.css);
@import url(../../css/base/tooltip.css);
</style>