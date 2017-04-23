function setNav(id) {
    $(".app-nav").removeClass("active");
    $("#nav-" + id).addClass("active");
}

function setPage(id) {
    $(".app-page").hide();
    $("#page-" + id).show();
}

$(document).bind("statechange", function (event, state) {
    if (state.view == "welcome") {
        setNav("welcome");
        setPage("welcome");
    } else if (state.view == "learn") {
        setNav("learn");
        setPage("learn");
    } else if (state.view == "support") {
        setNav("support");
        setPage("support");
    }
});