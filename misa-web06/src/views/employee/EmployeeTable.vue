<template>
    <div class="table-container">
        <table>
            <thead>
                <tr>
                    <th style="min-width: 36px;" class="th text-align-center">
                        <input type="checkbox" name="" id="">
                    </th>
                    <th style="min-width: 150px;" class="th text-align-left">{{
                        this.$_MISAResource.tableTitle.employeeCode }}</th>
                    <th style="min-width: 250px;" class="th text-align-left">{{
                        this.$_MISAResource.tableTitle.employeeName }}</th>
                    <th style="min-width: 100px;" class="th text-align-left">{{
                        this.$_MISAResource.tableTitle.employeeGender }}</th>
                    <th style="min-width: 100px;" class="th text-align-center">{{
                        this.$_MISAResource.tableTitle.employeeDateOfBirth }}</th>
                    <th style="min-width: 150px;" class="th text-align-left">{{
                        this.$_MISAResource.tableTitle.employeeIdentityNumber }}</th>

                    <th style="min-width: 200px;" class="th text-align-left">{{
                        this.$_MISAResource.tableTitle.employeePosition }}</th>
                    <th style="min-width: 250px;" class="th text-align-left">{{
                        this.$_MISAResource.tableTitle.employeeDepartment }}</th>

                    <th style="min-width: 150px;" class="th text-align-left">{{
                        this.$_MISAResource.tableTitle.employeeBankingAccount }}</th>
                    <th style="min-width: 200px;" class="th text-align-left">{{
                        this.$_MISAResource.tableTitle.employeeBankingName }}</th>
                    <th style="min-width: 250px;" class="th text-align-left">{{
                        this.$_MISAResource.tableTitle.employeeBankingBranch }}</th>

                    <th style="width: 1px; position: relative;"></th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="employee in employees" :key="employee.EmployeeId"
                    :class="{ 'selected': employeeCheck.includes(employee.EmployeeId) }">
                    <td class="th text-align-center">
                        <input type="checkbox" 
                            :checked="employeeCheck.includes(employee.EmployeeId)" 
                            @change="toggleSelection(employee.EmployeeId)">
                    </td>
                    <td class="th text-align-left" @dblclick="rowOnClick(employee)">
                        {{ employee.EmployeeCode }}
                    </td>
                    <td class="th text-align-left" @dblclick="rowOnClick(employee)">
                        {{ employee.FullName }}
                    </td>
                    <td class="th text-align-left" @dblclick="rowOnClick(employee)">
                        {{ $_format.formatGender(employee.Gender) }}
                    </td>
                    <td class="th text-align-center" @dblclick="rowOnClick(employee)">
                        {{ $_format.formatDate(employee.DateOfBirth) }}
                    </td>
                    <td class="th text-align-left" @dblclick="rowOnClick(employee)">
                        {{ employee.IdentityNumber }}
                    </td>
                    <td class="th text-align-left" @dblclick="rowOnClick(employee)">
                        {{ employee.PositionName }}
                    </td>
                    <td class="th text-align-left" @dblclick="rowOnClick(employee)">
                        {{ employee.DepartmentName }}
                    </td>

                    <td class="th text-align-left" @dblclick="rowOnClick(employee)">
                        {{ employee.BankingAccount }}
                    </td>
                    <td class="th text-align-left" @dblclick="rowOnClick(employee)">
                        {{ employee.BankingName }}
                    </td>
                    <td class="th text-align-left" @dblclick="rowOnClick(employee)">
                        {{ employee.BankingBranch }}
                    </td>
                    <div>
                        <div class="icon-container-40px" @click="rowOnClick(employee)">
                            <div class="icon"></div>
                        </div>
                        <div class="icon-container-40px" @click="deleteEmployee(employee.EmployeeId)">
                            <div class="icon"></div>
                        </div>
                    </div>
                </tr>
            </tbody>
        </table>
    </div>
    <div class="paging">
        <div class="paging-left">
            <div>{{ this.$_MISAResource.paging.total }} <span>{{ this.TotalRecord }}</span> {{
                this.$_MISAResource.paging.record }}</div>
        </div>
        <div class="paging-right">
            <div>{{ this.$_MISAResource.paging.recordPerPage }}</div>
            <div class="w20 min-w50">
                <misa-combobox 
                :readonly="true" 
                :result="paging" 
                :isShowTitle="false" 
                iconbutton="down-arrow" 
                :comboboxListTop="true"
                v-model="CurrentPageRecords"></misa-combobox>
            </div>

            <div><span>{{ CurrentPage }}</span> - <span>{{ TotalPage }}</span> 
                {{ this.$_MISAResource.paging.record }}
            </div>

            <button class="num pre-btn" @click="prePage"></button>
            <button class="num back-btn" @click="backPage"></button>
        </div>
    </div>

    <misa-dialog v-if="dialogComponent" 
        @closeDialogByIcon="closeDialogByIcon" 
        @closeDialogByButton="closeDialogByButton"
        :errors="[this.$_MISAResource.noticeDialog.deleteEmployee]"></misa-dialog>
</template>

<script>
export default {
    name: 'EmployeeTable',
    props:['searchText'],
    emits: ["deleteEmployee ", "rowOnClick", "reloadTable", "departments"],
    created() {
        this.getEmployeeData();
        // GỌi Api lấy dữ liệu:
    },

    data() {
        return {
            employees: [],
            dialogComponent: false,
            paging: [10, 20, 30, 50, 100],

            CurrentPageRecords: 10, // CurrentPageRecords
            CurrentPage: 1,// CurrentPage
            TotalPage: 0,
            TotalRecord: 0,
            search: this.searchText,
            employeeCheck: [],
        }
    },

    watch: {
        CurrentPageRecords(newVal) {
            this.CurrentPageRecords = newVal;
            this.CurrentPage = 1;
            this.getEmployeeData();
        },
        
    },

    methods: {
        /**
         * thay đổi check box
         * Author: NBDUONG (10/08/2023)
         */
        toggleSelection(id) {           
            const selectedItem = this.employees.find(item => item.EmployeeId == id);
            if (selectedItem) {
                selectedItem.checked = !selectedItem.checked;

                
                if (selectedItem.checked) {
                    this.employeeCheck.push(id);
                } else {
                    const index = this.employeeCheck.indexOf(id);
                    if (index !== -1) {
                        this.employeeCheck.splice(index, 1);
                    }
                }
            }
        },

        /**
         * lấy dữ liệu từ bảng
         * Author: NBDUONG (09/08/2023)
         */
        async getEmployeeData(searchText) {
            try {
                this.$_commonJs.showLoading();                
                const data = await this.$_employeeApi.getEmployee(this.CurrentPageRecords, this.CurrentPage, searchText == null ? '': searchText);
                this.$_commonJs.closeLoading();

                
                this.TotalRecord = data.data.TotalRecord;
                this.TotalPage = data.data.TotalPage;
                this.employees = data.data.Data;
                
            } catch (error) {
                this.catchError(error);
            }
        },

        /**
         * trả về trang đầu tiên
         * Author: NBDUONG (22/08/2023)
         */
        getCurrentPage(){
            this.CurrentPage =1;
        },

        /**
         * chuyển sang trang sau
         * Author: NBDUONG (09/08/2023)
         */
        async backPage() {
            if(this.CurrentPage == this.TotalPage) return;
            this.CurrentPage++;
            const data = await this.$_employeeApi.getEmployee(this.CurrentPageRecords, this.CurrentPage, this.search);
            this.employees = data.data.Data;
        },

        /**
         * chuyển sang trang trước
         * Author: NBDUONG (09/08/2023)
         */
        async prePage() {
            if(this.CurrentPage == 1) return;
            this.CurrentPage--;
            const data = await this.$_employeeApi.getEmployee(this.CurrentPageRecords, this.CurrentPage, this.search);
            this.employees = data.data.Data;
        },
        /**
         * lấy dữ liệu từ 1 dòng của table
         * Author: NBDUONG (30/07/2023)
         */
        rowOnClick(customer) {
            this.$emit("rowOnClick", customer);
        },


        /**
         * ẩn dialog
         * Author: NBDUONG (03/08/2023)
         */
        closeDialogByIcon() {
            this.dialogComponent = false;
        },

        /**
         * khi nhấn vào button đồng ý trên dialog thì sẽ chạy hàm xoá
         * Author: NBDUONG (03/08/2023)
         */
        async closeDialogByButton() {
            this.$_commonJs.showLoading();
            try {
                this.dialogComponent = false;

                await this.$_employeeApi.deleteEmployee(this.employeeDeleted);


                if(this.employees.length  == 1){
                    this.CurrentPage = 1;
                    this.getEmployeeData();
                }
                else{
                    const data = await this.$_employeeApi.getEmployee(this.CurrentPageRecords, this.CurrentPage, this.search);
                    this.employees = data.data.Data;
                }
            } catch (error) {
                this.catchError(error);
            }
            this.$_commonJs.closeLoading();


        },

        /**
         * hiện thị dialog và lấy id của nhân viên bị xoá
         * Author: NBDUONG (03/08/2023)
         */
        deleteEmployee(employeeId) {
            this.employeeDeleted = employeeId;
            this.dialogComponent = true;
        },


        /**
         * Hiện thị dialog lỗi
         * Author: NBDUONG (22/08/2023)
         */
        catchError(error){
            if (error.response.status >= 500) {
                    this.$_commonJs.showDialog([this.$_MISAResource.noticeDialog.errorServe]);
            }

            if (error.response.status >= 400 && error.response.status < 500) {
                this.$_commonJs.showDialog([error.response.data.UserMessage]);
            }
        },

    },
}
</script>

<style scoped>@import url(../../css/base/table.css);
@import url(../../css/base/paging.css);</style>