import Axios from "axios";

const axios = Axios.create({
    headers: {
        "Content-Type": "application/json",
        "Access-Control-Allow-Origin": "*"
    },
    paramsSerializer: params => queryString.stringify(params),
});

axios.interceptors.response.use(
    response => {
        return response;
    }
);

export default axios;