//JavaScriptCheck.js

function chkPhoneNum() {
    var phone = document.getElementById("custLoginPhoneNum");
    var res = /^1[3|4|5|7|8][0-9]-\d{4}-\d{4}$/.test(phone.value);
    if (res) {
        return true;
    }
    else {
        alert('手机号码格式必须为ddd-dddd-dddd，并且不能是空号！');
        phone.value = "";
        return false;
    }
}