var blogSelCat = $('.blogSelCat');
var selectCatalogBlog = blogSelCat.find('select.selectpicker');
selectCatalogBlog.on('change', function (ev) {
    var str = "";
    $("select option:selected").each(function () {
        str += $(this).text() + " ";
    });
    //console.log(str);

    selectCatalogBlog.find('option:selected').each(function () {
        var url = $(this).val();
        if (typeof url === 'string' && url != "") {
            window.location.href = url;
            return;
        }
    });
});

var blogSearchFrom = $('.blogSearch');
var blogSearchTxt = blogSearchFrom.find('input[name="s"]');
var blogSearchTxtInit = blogSearchTxt.val();
blogSearchFrom.on('submit', function (e) {
    var s = blogSearchTxt.val();
    if (s == blogSearchTxtInit) {
        e.preventDefault();
    }
});

//$('.blogRoll img').lazyload({
//    //threshold: 200
//    effect: "fadeIn"
//});