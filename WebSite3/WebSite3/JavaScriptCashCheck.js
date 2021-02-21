//JavaScriptCashCheck.js
function chkCashierName() {
    var name = document.getElementById("cashierName");
    return name.value.Length > 0;
}
function chkCashierPwd() {
    var pwd = document.getElementById("cashierPassword");
    return pwd.value.Length > 5;
}

function clickName() {
    alert('Please input your name');
    var dom = document.getElementById("cashierName");
    dom.style.backgroundColor = "yellow";
}
//DOM1第2种方式
//document.getElementById("cashierName").onmouseover = function () { this.style.backgroundColor = 'red'; }

//DOM2事件注册
//var ddom = document.getElementById("cashierPassword");
//ddom.addEventListener("change", chkCashierPwd, false);