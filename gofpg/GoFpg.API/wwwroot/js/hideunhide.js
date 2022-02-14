function change(obj) {
    var selectBox = obj;
    var selected = selectBox.options[selectBox.selectedIndex].value;
    var ta = document.getElementById("inscoinput");

    if (selected === "1") {
        ta.style.display = "block";
    }
    else {
        ta.style.display = "none";
    }
}