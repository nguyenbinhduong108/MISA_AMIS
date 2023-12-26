import emitter from "tiny-emitter/instance";

const commonJs = {
    /**
     * hiện thị dialog với giá trị nhận vào là các lỗi
     * Author: NBDUONG (03/08/2023)
     */
    showDialog(errors) {
        emitter.emit("showDialog", errors)
    },


    /**
     * hiện thị toast với giá trị nhận vào là thông tin hiển thị
     * Author: NBDUONG (03/08/2023)
     */
    showToast(info) {
        emitter.emit("showToast", info);
    },

    /**
     * hiển thị loading
     * Author: NBDUONG (04/08/2023)
     */
    showLoading(){
        emitter.emit("showLoading");
    },

    /**
     * ẩn loading
     * Author: NBDUONG (04/08/2023)
     */
    closeLoading(){
        emitter.emit("closeLoading");
    }

    
}

export default commonJs;