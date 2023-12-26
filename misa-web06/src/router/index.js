// import 
import { createRouter, createWebHistory } from 'vue-router'

// import trang 
import CustomerList from '../views/employee/EmployeeList.vue';
import MoneyList from '../views/money/MoneyList.vue';
import ReportList from '../views/report/ReportList.vue';

// Tạo 1 router
const routesList = [
    {path: '/customerList', component: CustomerList},
    {path: '/money', component: MoneyList},
    {path: '/report', component: ReportList},
];

const router = createRouter({
    history: createWebHistory(),
    routes: routesList,
})


export default router;