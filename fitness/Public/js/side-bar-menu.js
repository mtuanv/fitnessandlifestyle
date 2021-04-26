$(function () {
    var path = window.location.href;
    $('.about .nav-link').each(function () {
        if (this.href === path) {
            $(this).addClass('active_sidebar');
        }
    });
})