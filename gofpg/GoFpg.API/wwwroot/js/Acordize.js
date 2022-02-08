function accordize(target, one) {
    // (A) ADD CSS CLASS TO TARGET
    target.classList.add("awrap");

    // (B) ATTACH ONCLICK
    let all = target.querySelectorAll("li");
    if (typeof one != "boolean") { one = false; }
    for (let i = 0; i < all.length; i++) {
        if (i % 2 == 0) {
            all[i].classList.add("ahead");
            if (one) {
                all[i].onclick = () => {
                    for (let i = 0; i < all.length; i += 2) {
                        all[i].classList.remove("open");
                    }
                    all[i].classList.add("open");
                };
            } else {
                all[i].onclick = () => { all[i].classList.toggle("open"); };
            }
        } else { all[i].classList.add("abody"); }
    }
}

window.addEventListener("load", () => {
    accordize(document.getElementById("demoB"), true);
});