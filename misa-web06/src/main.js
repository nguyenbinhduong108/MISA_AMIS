import { createApp } from "vue";
import App from "./App.vue";

// components
import MISAButton from './components/base/MISAButton.vue';
import MISAComboBox from './components/base/MISAComboBox.vue';
import MISADate from './components/base/MISADate.vue'
import MISADialog from './components/base/MISADialog.vue';
import MISAInput from './components/base/MISAInput.vue';
import MISALoading from './components/base/MISALoading.vue';
import MISARadio from './components/base/MISARadio.vue';
import MISAToast from './components/base/MISAToast.vue';

// js dùng chung
import format from './helper/format.js';
import employeeApi from "./apis/EmployeeApi";
import clickOutSide from "./directive/clickOutSide.js";

// css dung chung
import './css/main.css';
import './css/base/icon.css'

// các thư viện dùng chung
import router from "./router/index.js";
import commonJs from "./helper/common.js";
import MISAEnum from "./helper/enum.js";
import MISAResource from "./helper/resource.js";
import emitter from "tiny-emitter/instance";



const lang = "VI";


const app = createApp(App);

app.directive('outside', clickOutSide);

app.use(router);
app.config.globalProperties.$_format = format;
app.config.globalProperties.$_commonJs = commonJs;
app.config.globalProperties.$_MISAEnum = MISAEnum;
app.config.globalProperties.$_MISAResource = MISAResource['VI'];
app.config.globalProperties.$_emitter = emitter;
app.config.globalProperties.$_employeeApi = employeeApi;

app.component("misa-button", MISAButton);
app.component("misa-combobox", MISAComboBox);
app.component("misa-date", MISADate);
app.component("misa-dialog", MISADialog);
app.component("misa-input", MISAInput);
app.component("misa-loading", MISALoading);
app.component("misa-radio", MISARadio)
app.component("misa-toast", MISAToast);
app.mount("#app");