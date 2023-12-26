const format = {
    /**
     * format ngày tháng
     * Author: NBDUONG (26/07/2023)
     */
    formatDate: function(date){
        try {
            if (!date) return "";

            date = new Date(date);
            let day = date.getDate();
            if(day<10){
                day = '0' + day;
            }
            let month = date.getMonth() + 1;
            if(month<10){
                month = '0' + month;
            }
            let year = date.getFullYear();

            return `${day}/${month}/${year}`;
        } catch (error) {
            console.log(error)
            return "";
        }
    },
    /**
     * format tiền
     * Author: NBDUONG (26/07/2023)
     */
    formatMoney: function(money){
        try {
            if (money == 0 || !money) return "";
            money = new Number(money);

            const debit = new Intl.NumberFormat('vi-VN', {
                currency: 'VND',
                style: 'currency'
            }).format(money);

            return debit;
        } catch (error) {
            console.log(error);
            return "";
        }
    },
    /**
     * format giới tính
     * Author: NBDUONG (26/07/2023)
     */
    formatGender: function(genderCode){
        try {
            if(genderCode == 0) return "Nam";
            if(genderCode == 1) return "Nữ";
            if(genderCode == 2) return "Khác"
            else return "";
        } catch (error) {
            console.log(error);
            return "";
        }
    },
}

export default format;