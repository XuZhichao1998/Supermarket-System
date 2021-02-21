//JavaScriptPicture.js
var oldId = "id_1";
function toTop(NewId) {
	if(NewId!=oldId) {
		var newTp = document.getElementById(NewId).style;
		var oldTp = document.getElementById(oldId).style;
		oldTp.zIndex = 0;
		newTp.zIndex = 40;
		oldId = NewId;
	}
}
var dom, finalx = 0, finaly = 0, tag = 0;

function moveText(x, y) {
    if (tag % 100 == 0) {
        dom.color = "blue";
    }
    else if (tag % 100 == 50) {
        dom.color = "red";
    }
    tag = tag + 1;
    if (x != finalx) {
        if (x > finalx) --x;
        else if (x < finalx) ++x;
    }
    if (y != finaly) {
        if (y > finaly) --y;
        else if (y < finaly) ++y;
    }
    dom.left = x + "px";
    dom.top = y + "px";
    if ((x != finalx) || (y != finaly)) {
        setTimeout("moveText(" + x + "," + y + ")", 1);
    }
    else {
        if (finalx == 1300) finalx = 800;
        else finalx = 1300;
        setTimeout("moveText(" + x + "," + y + ")", 3);
    }
}

function initText() {
    dom = document.getElementById("pText").style;
    var xv = dom.left;
    var yv = dom.top;
    var x = xv.match(/\d+/);
    var y = yv.match(/\d+/);
    finalx = 1300;
    finaly = 600;
    moveText(x, y);
}
