<template>
    <div>
        <div class="head">
            <div class="title">{{ this.$_MISAResource.mainTitle.employee  }}</div>
            <misa-button type="primary" :buttonText="this.$_MISAResource.button.addNewEmploy" @click="btnAddOnClick"></misa-button>
        </div>

        <div class="search">
            <div class="search-box w20">
                <misa-input 
                :placeholderText="this.$_MISAResource.searchBox.search" 
                :isInputButton="true"
                iconbutton="search-icon"
                v-model="searchText"
                @onClick="onClickSearch"/>
            </div>

            <div class="icon-container-40px"  @click="onClickReload">
                <div class="icon reaload"></div>
            </div>

            <div class="icon-container-40px"  @click="onExcel">
                <div class="icon execl"></div>
            </div>
        </div>

        <EmployeeTable @rowOnClick="rowOnClick" 
                       :searchText="searchText"
                       ref="reload"></EmployeeTable>

        
        <EmployeeForm v-if="isShowForm" 
                      @closeForm="btnCloseOnClick" 
                      :employeeSelected="employeeSelected" 
                      :form="form"
                      :reload="onClickReload"></EmployeeForm>
    </div>
    
</template>

<script>
import EmployeeTable from './EmployeeTable.vue';
import EmployeeForm from './EmployeeForm.vue';
export default {
    name: "EmployeeList",
    components: {
        EmployeeForm,
        EmployeeTable,
    },
    data() {
        return {
            isShowForm: false,
            employeeSelected: {},
            dialogComponent: false,
            form: '',
            searchText: '',
        }
    },

    methods: {
        /**
         * reload lại table
         * Author: NBDUONG (22/08/2023)
         */
        onClickReload(){
            this.$refs.reload.getEmployeeData();
        },

        /**
         * gửi text xuống table để tìm kiếm
         * Author: NBDUONG (22/08/2023)
         */
        onClickSearch(){
            this.$refs.reload.getCurrentPage();
            this.$refs.reload.getEmployeeData(this.searchText);
        },

        /**
         * hiên thị form khi nhấn vào thêm mới nhân viên
         * Author: NBDUONG (30/07/2023)
         */
        btnAddOnClick() {
            this.form = this.$_MISAResource.form.addEmployee;
            this.isShowForm = true;
        },

        /**
         * ẩn form khi nhấn vào nút close trên form
         * Author: NBDUONG (30/07/2023)
         */
        btnCloseOnClick() {
            this.employeeSelected = {};
            this.isShowForm = false;
        },

        /**
         * hiện thị bảng khi nhấn nút sửa trên dòng
         * Author:NBDUONG (31/07/2023)
         */
        rowOnClick(employee) {
            this.form = this.$_MISAResource.form.editEmployee;
            this.employeeSelected = employee;
            this.isShowForm = true;
        },
    },

}
</script>

<style scoped>
@import url(../../css/base/paging.css);

.head {
    display: flex;
    justify-content: space-between;
    align-items: center;
    margin-bottom: 12px;
}

.head .title {
    font-family: Roboto;
    font-weight: 700;
    font-size: 20px;
}

.search {
    display: flex;
    justify-content: end;
    align-items: center;
    padding: 12px;
    width: 100%;
    background-color: #ffffff;
}

.search .search-box {
    margin-right: 8px;
}


</style>