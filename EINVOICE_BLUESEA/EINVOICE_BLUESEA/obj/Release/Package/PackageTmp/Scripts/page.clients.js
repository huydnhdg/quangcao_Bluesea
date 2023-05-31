// load hinh tang diem nhung van chua duoc
var imgLazy = $('img.lazy');
var clientLoadLazy = 0;
if (imgLazy.length > 0) {
    setTimeout(function () {
        if (clientLoadLazy == 0) {
            clientLoadLazy = 1;
            setTimeout(function () {
                if (clientLoadLazy == 1) {
                    clientLoadLazy = 2;
                    $("img.lazy").lazyload();
                }
            }, 1000);
        }
    }, 1000);
}