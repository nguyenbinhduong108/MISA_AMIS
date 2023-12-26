<template>
    <div class="textfield-dialog">
        <div class="title tooltip" :class="{'title-required' : required}" v-if="!isInputButton" @click="focusInput">
            {{ inputTitle }}
            <div class="tooltiptext" v-if="tooltip"> {{ tooltiptext }} </div>
        </div>


        <div class="input" :class="[inputWidth, {'textfielderror' : !valid}, inputerror]">
            <input type="date"
                :placeholder="placeholderText"
                :class="textalign"
                v-model="value" 
                @input='onInput' 
                ref="input"
                @blur="onBlur"
                />
                <button class="input-button" v-if="isInputButton">
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
        'inputWidth', 
        'modelValue', 
        'textfielderror', 
        'required', 
        'inputerror', 
        'placeholderText',
        'isInputButton',
        'tooltiptext',
        'tooltip',
        'iconbutton',
        'textalign',
    ],

    methods:{

         /**
         * nhấn vào title thì focus vào input
         * Author: NBDUONG (09/08/2023)
         */
        focusInput() {
            this.onFocus();
        },

        /**
         * gửi giá trị lên lên form
         * Author: NBDUONG (02/08/2023)
         */
        onInput() {
            this.$emit('update:modelValue', this.value)
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
        }
    },

    data() {
        return{
            value: this.modelValue,
            valid: true,
        }
    },
}
</script>

<style scoped>
@import url(../../css/base/input.css);
@import url(../../css/base/tooltip.css);
</style>