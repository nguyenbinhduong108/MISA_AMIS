<template>
    <div class="form-container">
        <div class="form">
            <div class="form-header">
                <div class="left">
                    <div class="title">{{ this.form }}</div>
                </div>
                <div class="right">
                    <div class="icon-container-24px" @click="closeForm">
                        <div class="icon"></div>
                    </div>
                </div>
            </div>


            <div class="form-content">
                <!-- trên -->
                <div class="flex w100 gap-20">
                    <!-- trái -->
                    <div class="w50">
                        <div class="flex gap-4">
                            <div class="w40">
                                <misa-input 
                                :inputTitle="this.$_MISAResource.formTitle.employeeCode" 
                                :textfielderror="validateEmployeeCode" 
                                v-model="employee.employeeCode" 
                                :required="true"
                                ref="focusInput" />
                            </div>
                            <div class="w60">
                                <misa-input 
                                :inputTitle="this.$_MISAResource.formTitle.employeeName" 
                                :textfielderror="validateFullName" 
                                v-model="employee.fullName" 
                                :required="true" />
                            </div>
                        </div>
                        <div class="flex">
                            <div class="w100">
                                <misa-combobox 
                                :isShowTitle="true"
                                :inputTitle="this.$_MISAResource.formTitle.employeeDepartment" 
                                :placeholder="this.$_MISAResource.placeholder.selectDepartment" 
                                iconbutton="down-arrow" 
                                v-model="employee.departmentName"
                                :textfielderror="validateDepartment" 
                                :result="setDepartments" 
                                :required="true"/>
                            </div>
                        </div>
                        <div class="flex">
                            <div class="w100">

                                <misa-combobox 
                                :isShowTitle="true"
                                :inputTitle="this.$_MISAResource.formTitle.employeePosition" 
                                :placeholder="this.$_MISAResource.placeholder.selectPosition" 
                                iconbutton="down-arrow" 
                                v-model="employee.positionName"
                                :result="setPositions" />
                                
                            </div>
                        </div>

                    </div>

                    <!-- phải -->
                    <div class="w50">
                        <div class="flex">
                            <div class="w50">
                                <misa-date 
                                :inputTitle="this.$_MISAResource.formTitle.employeeDateOfBirth" 
                                v-model="employee.dateOfBirth" />
                            </div>


                            <div class="w50">
                                <misa-radio 
                                :data="this.data"
                                :nameRadio="gender"
                                v-model="this.employee.gender"/>
                            </div>
                        </div>
                        <div class="flex gap-4">
                            <div class="w60">
                                <misa-input 
                                :inputTitle="this.$_MISAResource.formTitle.employeeIdentityNumber"
                                :tooltip="true" 
                                :tooltiptext="this.$_MISAResource.tooltip.idNumber" 
                                v-model="employee.identityNumber"/>
                            </div>
                            <div class="w40">
                                <misa-date 
                                :inputTitle="this.$_MISAResource.formTitle.employeeIdentityDate"
                                v-model="employee.identityDate" />
                            </div>
                        </div>
                        <div class="flex">
                            <div class="w100">
                                <misa-input 
                                :inputTitle="this.$_MISAResource.formTitle.employeIdentityPlace"
                                v-model="employee.identityPlace" />
                            </div>
                        </div>
                    </div>
                </div>

                <!-- dưới -->
                <div class="w100">
                    <div class="flex w100">
                        <div class="w100">
                            <misa-input 
                            :inputTitle="this.$_MISAResource.formTitle.employeeAddress"
                            v-model="employee.address" />
                        </div>
                    </div>
                    <div class="flex w100 gap-4">
                        <div class="w25">
                            <misa-input 
                            :inputTitle="this.$_MISAResource.formTitle.employeePhoneNumber" 
                            v-model="employee.phoneNumber" />
                        </div>
                        <div class="w25">
                            <misa-input 
                            :inputTitle="this.$_MISAResource.formTitle.employeeLandingPhone" 
                            v-model="employee.landingPhone" />
                        </div>
                        <div class="w25">
                            <misa-input 
                            :inputTitle="this.$_MISAResource.formTitle.employeeEmail" 
                            v-model="employee.email" />
                        </div>

                        

                        
                    </div>
                    <div class="flex w100 gap-4">

                        <div class="w25">
                            <misa-input 
                            :inputTitle="this.$_MISAResource.formTitle.employeeBankingAccount" 
                            v-model="employee.bankingAccount" />
                        </div>
                        <div class="w25">
                            <misa-input 
                            :inputTitle="this.$_MISAResource.formTitle.employeeBankingName" 
                            v-model="employee.bankingName" />
                        </div>
                        <div class="w25">
                            <misa-input 
                            :inputTitle="this.$_MISAResource.formTitle.employeeBankingBranch" 
                            v-model="employee.bankingBranch" />
                        </div>
                        
                        
                        
                    </div>

                </div>
            </div>



            <div class="form-footer">
                <div class="right">
                    <misa-button type="primary" :buttonText="this.$_MISAResource.button.saveAndAddBtn"
                        @click="saveAndAddCustomer" :tooltip="true"
                        :tooltiptext="this.$_MISAResource.tooltip.saveAndAddBtn"></misa-button>
                    <misa-button type="secondary" :buttonText="this.$_MISAResource.button.saveBtn"
                        @click="saveCustomer" :tooltip="true"
                        :tooltiptext="this.$_MISAResource.tooltip.saveBtn"></misa-button>
                </div>
                <div class="left">
                    <misa-button type="secondary" :buttonText="this.$_MISAResource.button.cancleBtn"
                        @click="closeForm"></misa-button>
                </div>
            </div>
        </div>

    </div>
</template>

<script>
export default {
    name: 'EmployeeForm',
    emits: ["closeForm", "reloadTable"],
    props: ['employeeSelected', 'form', 'reload'],
    created() {
        if (!this.isEmployeeSelectedEmpty()) {
            this.employee = {
                employeeId: this.employeeSelected.EmployeeId,   
                employeeCode: this.employeeSelected.EmployeeCode,
                fullName: this.employeeSelected.FullName,
                departmentId: this.employeeSelected.DepartmentId,
                departmentName: this.employeeSelected.DepartmentName,
                positionId: this.employeeSelected.PositionId,
                positionName: this.employeeSelected.PositionName,
                dateOfBirth: this.formatDate(this.employeeSelected.DateOfBirth),
                gender: this.employeeSelected.Gender,
                identityNumber: this.employeeSelected.IdentityNumber,
                identityDate: this.employeeSelected.IdentityDate,
                identityPlace: this.employeeSelected.IdentityPlace,
                address: this.employeeSelected.Address,
                phoneNumber: this.employeeSelected.PhoneNumber,
                landingPhone: this.employeeSelected.LandingPhone,
                email: this.employeeSelected.Email,
                bankingAccount: this.employeeSelected.BankingAccount,
                bankingName: this.employeeSelected.BankingName,
                bankingBranch: this.employeeSelected.BankingBranch,
            }
        };

        this.getDepartments();
        this.getPositions();
    },

    /**
     * focus vào ô input đầu tiên
     * Author: NBDUONG (02/08/2023)
     */
    mounted() {
        this.$refs.focusInput.onFocus();
    },

    computed: {
        /**
         * lấy tên các phòng ban
         * Author: NBDUONG (08/08/2023)
         */
        setDepartments() {
            return this.departments.map((item) => item.name);
        },

        /**
         * lấy tên các phòng ban
         * Author: NBDUONG (08/08/2023)
         */
         setPositions() {
            return this.positions.map((item) => item.name);
        },
    },

    methods: {
        /**
         * lấy danh sách các đơn vị vào cho vào departments
         * Author: NBDUONG (08/08/2023)
         */
        async getDepartments() {
            try {
                let data = await this.$_employeeApi.getDepartment();

                data.data.forEach((item) => {
                    this.departments.push({
                        id: item.DepartmentId,
                        name: item.DepartmentName,
                    });
                });
            } catch (error) {
                this.$_commonJs.showDialog([this.$_MISAResource.noticeDialog.errorServe]);
            }
        },

        /**
         * lấy danh sách các chức danh vào cho vào positions
         * Author: NBDUONG (22/08/2023)
         */
         async getPositions() {
            try {
                let data = await this.$_employeeApi.getPosition();

                data.data.forEach((item) => {
                    this.positions.push({
                        id: item.PositionId,
                        name: item.PositionName,
                    });
                });
            } catch (error) {
                this.$_commonJs.showDialog([this.$_MISAResource.noticeDialog.errorServe]);
            }
        },

        /**
         * đóng form 
         * Author: NBDUONG (31/07/2023)
         */
        closeForm() {
            this.$emit("closeForm");
        },

        /**
         * kiểm tra selected có tồn tại không
         * Author: NBDUONG (02/08/2023)
         */
        isEmployeeSelectedEmpty() {
            return Object.keys(this.employeeSelected).length == 0;
        },

        /**
         * chuyển từ table lên form
         * Author: NBDUONG (31/07/2023)
         */
        formatDate(date) {
            if (date != null) {
                date = new Date(date);
                try {
                    const year = date.getFullYear();
                    const month = String(date.getMonth() + 1).padStart(2, '0');
                    const day = String(date.getDate()).padStart(2, '0');

                    return `${year}-${month}-${day}`;
                } catch (e) {
                    console.log(e);
                    return "";
                }
            }
            else {
                return null;
            }
        },

        /**
         * thêm mới nhân viên hoặc sửa nhân viên
         * Author: NBDUONG (31/07/2023)
         */
        async saveAndAddCustomer() {

            /**
             * validate nhữ trường dữ liệu bắt buộc nhập
             */
            var errors = [];
            if (this.employee.employeeCode == null || this.employee.employeeCode == '') {
                this.validateEmployeeCode = "textfielderror";
                errors.push(this.$_MISAResource.error.employeeCodeNotEmpty);
            } else {
                this.validateEmployeeCode = "";
            }

            if (this.employee.fullName == null || this.employee.fullName == '') {
                this.validateFullName = "textfielderror";
                errors.push(this.$_MISAResource.error.employeeNameNotEmpty);
            } else {
                this.validateFullName = "";
            }

            // lấy ra id của đơn vị đã chọn
            for (const department of this.departments) {
                if (department.name == this.employee.departmentName) {
                    this.employee.departmentId = department.id
                    break;
                }
            }

            // Lấy ra id của chức danh đã chọn
            for (const position of this.positions) {
                if (position.name == this.employee.positionName) {
                    this.employee.positionId = position.id
                    break;
                }
            }

            if (this.employee.departmentName == null || this.employee.departmentName == '') {
                this.validateDepartment = "textfielderror"
                errors.push(this.$_MISAResource.error.employeeDepartmentNotEmpty);
            } else {
                this.validateDepartment = "";
            }


            // thêm
            if (errors.length == 0) {
                this.$_commonJs.showLoading();
                if (this.isEmployeeSelectedEmpty()) {
                    try {
                        await this.$_employeeApi.postEmployee(this.employee);
                        this.reload();    
                        this.$_commonJs.showToast(this.$_MISAResource.noticeToast.successAdd);
                    } catch (error) {
                        this.catchError(error);
                    }
                }
                else {
                    try {
                        await this.$_employeeApi.putEmployee(this.employeeSelected.EmployeeId, this.employee);
                        this.reload();    
                        this.$_commonJs.showToast(this.$_MISAResource.noticeToast.successUpdate);
                    } catch (error) {
                        this.catchError(error);
                    }

                }
                this.$_commonJs.closeLoading();
            }
            else {
                this.$_commonJs.showDialog(errors);
            }

        },

        /**
         * cất thông tin nhân viên đóng form
         * Author: NBDUONG (31/07/2023)
         */
        async saveCustomer() {

            /**
             * validate những trường dữ liệu bắt buộc nhập
             */
             var errors = [];
            if (this.employee.employeeCode == null || this.employee.employeeCode == '') {
                this.validateEmployeeCode = "textfielderror";
                errors.push(this.$_MISAResource.error.employeeCodeNotEmpty);
            } else {
                this.validateEmployeeCode = "";
            }

            if (this.employee.fullName == null || this.employee.fullName == '') {
                this.validateFullName = "textfielderror";
                errors.push(this.$_MISAResource.error.employeeNameNotEmpty);
            } else {
                this.validateFullName = "";
            }

            // lấy ra id của đơn vị đã chọn
            for (const department of this.departments) {
                if (department.name == this.employee.departmentName) {
                    this.employee.departmentId = department.id
                    break;
                }
            }

            // Lấy ra id của chức danh đã chọn
            for (const position of this.positions) {
                if (position.name == this.employee.positionName) {
                    this.employee.positionId = position.id
                    break;
                }
            }

            if (this.employee.departmentName == null || this.employee.departmentName == '') {
                this.validateDepartment = "textfielderror"
                errors.push(this.$_MISAResource.error.employeeDepartmentNotEmpty);
            } else {
                this.validateDepartment = "";
            }

            if (errors.length == 0) {
                this.$_commonJs.showLoading();
                if (this.isEmployeeSelectedEmpty()) {
                    try {
                        await this.$_employeeApi.postEmployee(this.employee);
                        this.reload();
                        this.$emit("closeForm");
                        this.$_commonJs.showToast(this.$_MISAResource.noticeToast.successAdd);
                    } catch (error) {
                        this.catchError(error);
                    }
                }
                else {
                    try {
                        await this.$_employeeApi.putEmployee(this.employeeSelected.EmployeeId, this.employee);
                        this.reload();
                        this.$emit("closeForm");
                        this.$_commonJs.showToast(this.$_MISAResource.noticeToast.successUpdate);
                    } catch (error) {
                        this.catchError(error);
                    }
                }
                this.$_commonJs.closeLoading();
            }
            else {
                this.$_commonJs.showDialog(errors);
            }

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


    data() {
        return {
            employee: {
                employeeCode: null,
                fullName: null,
                departmentId: null,
                departmentName: null,
                positionId: null,
                dateOfBirth: null,
                gender: null,
                identityNumber: null,
                identityDate: null,
                identityPlace: null,
                address: null,
                phoneNumber: null,
                landingPhone: null,
                email: null,
                bankingAccount: null,
                bankingName: null,
                bankingBranch: null,
            },
            toastMessage: '',
            toastIcon: '',
            validateEmployeeCode: '',
            validateFullName: '',
            validateDepartment: '',
            departments: [],
            positions: [],
            data: [
                {value: this.$_MISAEnum.Gender.Male.value, text: this.$_MISAEnum.Gender.Male.text},
                {value: this.$_MISAEnum.Gender.Female.value, text: this.$_MISAEnum.Gender.Female.text},
                {value: this.$_MISAEnum.Gender.Different.value, text: this.$_MISAEnum.Gender.Different.text},
            ]
        }
    },

}
</script>

<style scoped>
@import url(../../css/base/form.css);

.ml24px {
    margin-left: 24px;
}
</style>