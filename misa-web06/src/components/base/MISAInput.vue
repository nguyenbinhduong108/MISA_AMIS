<template>
    <div class="textfield-dialog">
        <div class="title tooltip" 
            :class="{'title-required' : required}" 
            v-if="!isInputButton" 
            @click="onFocus">
            {{ inputTitle }}
            <div class="tooltiptext" v-if="tooltip"> {{ tooltiptext }} </div>
        </div>


        <div class="input" 
            :class="[{'textfielderror' : !valid}, textfielderror, {'green-boder': greenBoder}]">
            <input type="text"
                :placeholder="placeholderText"
                :class="textalign"
                v-model="value" 
                @input='onInput' 
                @blur="onBlur"
                @focusin="onFocusin"
                ref="input"/>
                <button v-if="isInputButton" 
                    @click="onClick" 
                    @blur="onBlur"
                    @focusin="onFocusin"
                    tabindex="-1">
                    <div :class="iconbutton"></div>
                </button>
        </div>
        
        <!-- đây là phần hiển thị thông báo lỗi -->
        <div class="hint">{{ inputTitle + this.$_MISAResource.hint.notEmpty }}</div>

    </div>
</template>

<script>
export default {
    name: "MISAInput",
    emit:['update:modelValue'], 
    props: [
        'inputTitle', 
        'modelValue', 
        'textfielderror', 
        'required', 
        'placeholderText',
        'isInputButton',
        'tooltiptext',
        'tooltip',
        'iconbutton',
        'textalign',
    ],

    methods:{

        /**
         * gửi emit khi click vào button input
         * Author: NBDUONG (21/08/2023)
         */
        onClick(){
            this.$emit('onClick');
        },

        /**
         * gửi giá trị lên lên form
         * Author: NBDUONG (02/08/2023)
         */
        onInput() {
            this.$emit('update:modelValue', this.value);
        },


        /**
         * focus vào ô nhập
         * Author: NBDUONG (03/08/2023)
         */
        onFocus() {
            this.$nextTick(function() {
                this.$refs.input.focus();
            })
        },

        /**
         * focus vào ô input
         * Author: NBDUONG (02/08/2023)
         */
        onFocusin(){
            this.greenBoder = true;
        },

        /**
         * gửi giá trị lên lên form
         * Author: NBDUONG (02/08/2023)
         */
        onBlur(){
            if(!this.value && this.required == true){
                this.valid = false;
            }
            else{
                this.valid = true;
            }
            this.greenBoder = false;
        }
    },

    data() {
        return{
            value: this.modelValue,
            valid: true,
            greenBoder: false,
        }
    },
}
</script>

<style scoped>
@import url(../../css/base/input.css);
@import url(../../css/base/tooltip.css);
</style>