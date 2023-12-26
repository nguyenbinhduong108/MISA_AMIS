import axios from "../lib/index.js";

// const baseApi = "https://cukcuk.manhnv.net/api/v1";
const baseApi = "https://localhost:7215/api/v1";

const EmployeeApi = {
    getEmployee: async (CurrentPageRecords, CurrentPage, search) => {
        const data = await axios.get(`${baseApi}/Employees/filter?pageSize=${CurrentPageRecords}&pageNumber=${CurrentPage}&search=${search}`);
        return data;
    },

    postEmployee: async (employee) => {
        const data = await axios.post(`${baseApi}/Employees`, employee);
        return data;
    },

    putEmployee: async (employeeSelectedId ,employee) => {
        const data = await axios.put(`${baseApi}/Employees/${employeeSelectedId}`, employee);
        return data;
    },

    deleteEmployee: async (employeeDeleted) => {
        const data = await axios.delete(`${baseApi}/Employees/${employeeDeleted}`);
        return data;
    },

    getDepartment: async() => {
        const data = await axios.get(`${baseApi}/Departments`);
        return data;
    },

    getPosition: async() => {
        const data = await axios.get(`${baseApi}/Positions`);
        return data;
    },

    getNewEmployeeCode: async() => {
        const data = await axios.get(`${baseApi}/Employees/NewEmployeeCode`);
        return data;
    }

}

export default EmployeeApi;