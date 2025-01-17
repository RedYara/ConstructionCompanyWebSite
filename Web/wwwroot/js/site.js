$(document).bind('mousewheel', function (e) {
    var nt = $(document.body).scrollTop() - (e.deltaY * e.deltaFactor * 5);
    e.preventDefault();
    e.stopPropagation();
    $(document.body).stop().animate({
        scrollTop: nt
    }, 5000, 'easeInOutCubic');
})