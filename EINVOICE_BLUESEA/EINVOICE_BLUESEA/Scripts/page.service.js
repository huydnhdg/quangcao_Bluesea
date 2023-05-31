$('.serviceClientSlide .slide').slick({
    dots: false,
    infinite: true,
    autoplay: true,
    autoplaySpeed: 2000,
    arrows: false,
    speed: 300,
    rows: 2,
    slidesToShow: 5,
    slidesToScroll: 5,
    responsive: [
        {
            breakpoint: 992,
            settings: {
                slidesToShow: 4,
                slidesToScroll: 4
            }
        },
        {
            breakpoint: 768,
            settings: {
                slidesToShow: 3,
                slidesToScroll: 3
            }
        },
        {
            breakpoint: 480,
            settings: {
                slidesToShow: 2,
                slidesToScroll: 2
            }
        },
        {
            breakpoint: 320,
            settings: {
                slidesToShow: 2,
                slidesToScroll: 2
            }
        }
    ]
}).on('beforeChange', function (event, slick, currentSlide, nextSlide) {
    if (loadLazy == 2 || loadLazy == 3) {
        loadLazy = 4;
        setTimeout(function () {
            loadLazy = 5;
        }, 1000);
    } else if (loadLazy == 5) {
        loadLazy = 6;
        setTimeout(function () {
            $("img.lazy").trigger("sporty");
            $('.serviceClientSlide .slide').off('beforeChange');
        }, 1000);
    }
});