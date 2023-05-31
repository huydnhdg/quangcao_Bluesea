$('#homeClients .slide').slick({
    dots: true,
    infinite: true,
    speed: 300,
    slidesToShow: 5,
    slidesToScroll: 5,
    autoplay: true,
    responsive: [
        {
            breakpoint: 992,
            settings: {
                slidesToShow: 4,
                slidesToScroll: 4,
                dots: true,
                infinite: true
            }
        },
        {
            breakpoint: 768,
            settings: {
                slidesToShow: 3,
                slidesToScroll: 3,
                dots: true,
                infinite: true
            }
        },
        {
            breakpoint: 480,
            settings: {
                slidesToShow: 2,
                slidesToScroll: 2,
                dots: false,
                infinite: true
            }
        },
        {
            breakpoint: 320,
            settings: {
                slidesToShow: 1,
                slidesToScroll: 1,
                dots: false,
                infinite: true
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
        }, 1000);
    } else if (loadLazy == 6) {
        loadLazy = 7;
        setTimeout(function () {
            $("img.lazy").trigger("sporty");
        }, 1000);
    } else if (loadLazy == 7) {
        loadLazy = 8;
        setTimeout(function () {
            $("img.lazy").trigger("sporty");
        }, 1000);
    } else if (loadLazy == 8) {
        loadLazy = 9;
        setTimeout(function () {
            $("img.lazy").trigger("sporty");
            $('#homeClients .slide').off('beforeChange');
        }, 1000);
    }
});;