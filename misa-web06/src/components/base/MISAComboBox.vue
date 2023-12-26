<template>
    <div class="combobox-dialog" v-outside='clickOut'>
        <div class="title" 
            :class="{ 'title-required': required }" 
            v-if="isShowTitle" 
            @click="onFocus">
            {{ inputTitle }}
        </div>


        <div class="input" 
            :class="[{ 'textfielderror': !valid }, textfielderror, {'green-boder': greenBoder}]" 
            @click="onShowList">
            <input :readonly="readonly" 
                :placeholder="placeholder" 
                type="text" 
                v-model="value" 
                @input="onInput" 
                @focusin="onFocus"
                @blur="onBlur"/>
            <button tabindex="-1" 
                    @focusin="onFocus"
                    @blur="onBlur">
                <div :class="iconbutton"></div> 
            </button>
        </div>

        <div class="combobox-list" :class="{ 'combobox-list-top': comboboxListTop }" v-if="comboboxList">
            <div class="combobox-item" 
                v-for="(item, index) in result" 
                :key="index"
                :class="{ 'selected': selectedIndex == index }" 
                @mousedown="onClickResult(item, index)">
                {{ item }}
                <div class="icon"></div>
            </div>
        </div>

        <!-- đây là phần hiển thị thông báo lỗi -->
        <div class="hint">{{ inputTitle + this.$_MISAResource.hint.notEmpty }}</div>

    </div>
</template>

<script>
export default {
    name: "MISACombobox",
    emit: ['update:modelValue'],
    props: [
        'result',
        'inputTitle',
        'modelValue',
        'textfielderror',
        'required',
        'placeholder',
        'isShowTitle',
        'iconbutton',
        'comboboxListTop',
        'readonly',
    ],

    watch:{
        value(){
            if(this.valid != null){
                this.valid = true;
            }
        }
    },

    methods: {
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
            this.comboboxList = true;
            this.greenBoder = true;
        },


        onBlur() {
            if (!this.value && this.required == true) {
                this.valid = false;
            }
            else {
                this.valid = true;
            }
            this.comboboxList = false;
            this.greenBoder = false;
        },

        /**
         * hiển thị list của combo
         * Author: NBDUONG (08/08/2023)
         */
        onShowList() {
            this.comboboxList = true;
        },

        /**
         * khi click vào 1 option của box list thì sẽ chọn option đó
         * Author: NBDUONG (09/08/2023)
         */
        onClickResult(item, index) {
            this.selectedIndex = index;
            this.value = item;
            this.comboboxList = false;
            this.$emit("update:modelValue", this.value);
        },

        /**
         * kh click ra ngoài combobox thì box list sẽ ẩn đi
         * Author: NBDUONG (10/08/2023)
         */
        clickOut() {
            if (this.comboboxList == true) {
                this.comboboxList = false;
                if (!this.value && this.required == true) {
                    this.valid = false;
                }
                else {
                    this.valid = true;
                }
            }

            
            if(this.comboboxList == false){
                if (this.value && this.required == true) {
                    this.valid = true;
                }
            }

            this.greenBoder = false;

        }
    },

    data() {
        return {
            value: this.modelValue,
            valid: true,
            comboboxList: false,
            selectedIndex: null,
            greenBoder: false, 
        }
    },
}
</script>

<style scoped>
@import url(../../css/base/combobox.css);
</style>