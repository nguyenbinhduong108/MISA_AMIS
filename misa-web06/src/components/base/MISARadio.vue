<template>
    <div class="radio-container ml24px">
        <div class="title">{{ this.$_MISAResource.formTitle.employeeGender }}</div>
        <div class="radio-ground">
            <div v-for="(item, index) in data" :key="index">
                <div><input type="radio" 
                    :name="nameRadio" 
                    :value="item.value" 
                    v-model="value"
                    @change="handleRadioChange"></div>
                <div>{{ item.text }}</div>
            </div>
            
        </div>
    </div>
</template>

<script>
    export default{
        name: 'MISARadio',
        emit:['update:modelValue'], 
        props:{
            modelValue: '',
            nameRadio: '',
            data: [],
        },

        data() {
            return{
                value: this.modelValue,
            }
        },

        computed: {
            modelValue() {
                this.value = this.modelValue;
            }
        },
        methods: {
        /**
         * cập nhật giá trị của radio dđã chọn
         * Author: NBDUONG (01/08/2023)
         */
         handleRadioChange() {
            this.$emit('update:modelValue', this.value);
        },
    },
    }
</script>

<style>
@import url(../../css/base/radio.css);
</style>