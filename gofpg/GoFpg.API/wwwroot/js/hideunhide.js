function change(obj) {
    var selectBox = obj;
    var selected = selectBox.options[selectBox.selectedIndex].value;
    var ta = document.getElementById("inscoinput");
    var ta2 = document.getElementById("dolinput");

    if (selected === "1") {
        ta.style.display = "block";
        ta2.style.display = "block";
    }
    else {
        ta.style.display = "none";
        ta2.style.display = "none";
    }
}