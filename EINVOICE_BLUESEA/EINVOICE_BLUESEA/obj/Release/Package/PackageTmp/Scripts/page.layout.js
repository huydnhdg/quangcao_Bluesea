// Detect request animation frame
var runner = window.requestAnimationFrame ||
    window.webkitRequestAnimationFrame ||
    window.mozRequestAnimationFrame ||
    window.msRequestAnimationFrame ||
    window.oRequestAnimationFrame ||
    // IE Fallback, you can even fallback to onscroll
    function (callback) { window.setTimeout(callback, 1000 / 60) };

var mainMenu = $('#mainMenu');
var mainMenuToggle = mainMenu.find('.navbar-toggle');
var mainMenuCollapse = mainMenu.find('.navbar-collapse');
var mainMenuAllItem = mainMenu.find('.nav > li');
var mainMenuNavbar = mainMenu.find('.navbar-nav');
var topMenu = $('#topMenu');
// var mainMenuBackgroundColor = '#0066b2';
var mainMenuBackgroundColor = '#0066b2';
var hotlineResponsive = $('#hotlineResponsive');
var scrollTop = $('#scrollTop');
var hideTopShowNotTopGroup = $('#hotlineResponsive, #scrollTop');
var mainMenuImage = mainMenu.find('.navbar-brand > img');
var topLast = undefined;
var isMainMenuTop = undefined;
var showDialogSubscribeCounter = 0;// -1 is disable, increse when scroll down, >=2 is show dialog then disable
if ($.cookie('isFormSubscribe') == 'true') {
    showDialogSubscribeCounter = -1;
}

/**
 * Animate JQuery
 */
$.fn.extend({
    animateCss: function (animationName, onEnd) {
        //var animationEnd = 'webkitAnimationEnd mozAnimationEnd MSAnimationEnd oanimationend animationend';
        //this.addClass('animated ' + animationName).one(animationEnd, function () {
        //    $(this).removeClass('animated ' + animationName);
        //});
        this.removeClass('animated ' + animationName);
        if (isFunction(onEnd)) {
            var animationEnd = 'webkitAnimationEnd mozAnimationEnd MSAnimationEnd oanimationend animationend';
            this.addClass('animated ' + animationName).one(animationEnd, onEnd);
        } else {
            this.addClass('animated ' + animationName);
        }
    }
});

/**
 * Scroll function
 */
var loadLazy = 0;// còn dùng trong slide
var onScroll = function () {
    var top = $(document).scrollTop();
    if (top != topLast) {
        if (topLast == undefined) {
            topLast = top;
            if (loadLazy == 0) {
                loadLazy = 1;
                setTimeout(function () {
                    $("img.lazy").lazyload({
                        skip_invisible: false,
                        failure_limit: 20,
                        threshold: 200,
                        effect: "fadeIn",
                        event: "sporty"
                    });
                    loadLazy = 2;
                }, 1000);
            }
        } else {
            if (loadLazy == 2) {
                loadLazy = 3;
                setTimeout(function () {
                    $("img.lazy").trigger("sporty");
                }, 1000);
            }
        }
        scrollMainMenu(top, topLast);
        scrollWow(top, topLast);
        scrollShowSubscribe(top, topLast);
        topLast = top;
    }
}

$(document).scroll(function () {
    runner(onScroll);
});
runner(onScroll);

var scrollLinksAnchor = $('a[href^="#"]');
scrollLinksAnchor.each(function (index, elem) {
    var eJQ = $(elem);
    eJQ.on('click', function (e) {
        e.preventDefault();
        var anchor = eJQ.attr('href');
        var eAnchor = $(anchor);
        var top = $(document).scrollTop();
        var eAnchorTopOffset = eAnchor.offset();
        var eAnchorTop = 0;
        if (eAnchorTopOffset != undefined) {
            eAnchorTop = eAnchorTopOffset.top;
            var d = top - eAnchorTop;
            if (d < 0) {
                d *= -1;
            }
            var tik = d / 1.5;
            if (tik > 3000) {
                tik = 3000;
            }
            var body = $('html, body');
            body.stop().animate({
                scrollTop: eAnchorTop
            }, tik, 'swing');
        }
    });
});

/**
 * mainMenu show/hide scroll/click
 */
hideTopShowNotTopGroup.hide();
function scrollMainMenu(top, topLast) {
    if (isMainMenuTop == undefined) {
        isMainMenuTop = top != 0;
    }
    if (top == 0) {
        // menu hide then remove background color
        if (!isMainMenuTop) {
            if (mainMenuCollapse.hasClass('collapse')) {
                mainMenu.css("background-color", "");
                mainMenuAllItem.css("background-color", "");
                mainMenuImage.addClass('big');
            }
            topMenu.show();
            hideTopShowNotTopGroup.removeClass('animated flipOutX bounceInUp').addClass('animated flipOutX');
            isMainMenuTop = true;
        }
    } else {
        // menu show then add background color
        if (isMainMenuTop) {
            mainMenu.css("background-color", mainMenuBackgroundColor);
            mainMenuAllItem.css("background-color", mainMenuBackgroundColor);
            mainMenuImage.removeClass('big');
            topMenu.hide();
            hideTopShowNotTopGroup.show(0, function () {
                hideTopShowNotTopGroup.removeClass('animated flipOutX bounceInUp').addClass('animated bounceInUp');
            });
            isMainMenuTop = false;
        }
    }
}
$(window).resize(function () {
    runner(mainMenuOff);
});

function mainMenuOff() {
    if (!mainMenuCollapse.hasClass('collapse')) {
        mainMenuToggle.trigger('click');
    }
}

mainMenuToggle.on('click', function (e) {
    // menu show
    if (mainMenuCollapse.hasClass('collapse')) {
        mainMenuCollapse.removeClass('collapse');
        mainMenu.css("background-color", mainMenuBackgroundColor);
        mainMenuAllItem.css("background-color", mainMenuBackgroundColor);
        mainMenuNavbar.removeClass('borderTop');
        mainMenuNavbar.addClass('borderTopNone');
        mainMenuImage.removeClass('big');

        // todo menu show scroll when height to small
        var wW = $(window).outerWidth();
        if (wW < 768) {
            var wH = $(window).outerHeight();
            mainMenuCollapse.css('height', (wH - 54) + 'px');
        } else {
            var height = mainMenuCollapse.css('height');
            mainMenuCollapse.css('height', (109 + 70*2) + 'px');
        }
    }
    // menu hide
    else {
        mainMenuCollapse.addClass('collapse');
        if (topLast == 0) {
            mainMenu.css("background-color", "");
            mainMenuAllItem.css("background-color", "");
            mainMenuImage.addClass('big');
        }
        mainMenuNavbar.addClass('borderTop');
        mainMenuNavbar.removeClass('borderTopNone');
    }
    mainMenuToggle.toggleClass('open');
});

/**
 * Scroll to top
 */
scrollTop.on('click', function (e) {
    var body = $('body');
    body.stop().animate({ scrollTop: 0 }, '500', 'swing');
});

/**
 * Form Subscribe
 */
//load script
function loadJS(file) {
    // DOM: Create the script element
    var jsElm = document.createElement("script");
    // set the type attribute
    jsElm.type = "application/javascript";
    // make the script element load file
    jsElm.src = file;
    // finally insert the element to the body element in order to load the script
    jsElm.async = true;
    document.head.appendChild(jsElm);
}
var formSubscribe = $('#formSubscribe');
var formSubscribeEmailTxt = formSubscribe.find('input[name="mail"]');
var formSubscribeBtn = formSubscribe.find('button');
formSubscribe.off("submit");
formSubscribeEmailTxt.one('click', function (e) {
    showDialogSubscribeCounter = -1;// tat popup
    var diaglogJQ = $(dialogSubscribeContainer);
    diaglogJQ.find('div > div').removeClass('animated pulse');// fix error google neo
    var url = 'https://www.google.com/recaptcha/api.js';
    loadJS(url);
});
formSubscribeBtn.click(function (e) {
    formSubscribeCheck();
});
formSubscribe.submit(function (e) {
    e.preventDefault();
    formSubscribeCheck();
});
function formSubscribeCheck() {
    var emailTxt = formSubscribeEmailTxt;
    var email = emailTxt.val();
    if (isValidEmailAddress(email)) {
        if (grecaptcha) {
            grecaptcha.execute();
        } else {
            bootbox.alert('Vui lòng chờ vài giây rồi thử lại!');
        }
    } else {
        bootbox.alert('Vui lòng nhập địa chỉ email để nhận tin!');
    }
}
function onSubmit(token) {
    var emailTxt = formSubscribeEmailTxt;
    var email = emailTxt.val();
    var action = formSubscribe.prop('action');

    $.post(action, formSubscribe.serialize(), function (data) {
        if (data && data.status && data.status == 'ok') {
            $.cookie('isFormSubscribe', 'true', {
                expires: 365,
                path: '/'
            });
        }
    });

    showDialogSubscribeCounter = -1;

    var textThank = 'Cảm ơn bạn đã đăng ký email <strong>' + email + '</strong> để nhận tin';
    var diaglogJQ = $(dialogSubscribeContainer);
    if (diaglogJQ.hasClass('open')) {
        diaglogJQ.removeClass('open');
        bootbox.alert(textThank);
    }

    var eThank = formSubscribe.find('p.thank');
    if (eThank.length == 0) {
        formSubscribe.append('<p class="thank">' + textThank + '</p>');
        eThank = formSubscribe.find('p.thank');
    }
    $('#subcribleEmailGroup').hide();
    eThank.hide();
    eThank.fadeIn();
    emailTxt.val('');
}

/**
 * My Diablog
 * <div class="myDialog">
 *   <div>
 *     <div>
 *       <span class="exit"></span>
 *       Your content!
 *     </div>
 *   </div>
 * </div>
 */
var dialogSubscribeContainer = formSubscribe.parent().parent().parent()[0];
function showMyDialog(tag) {
    var tagJQ = $(tag);
    if (!tagJQ.hasClass('open')) {
        if (!tagJQ.hasClass('myDialog')) {
            tagJQ.addClass('myDialog');
        }
        tagJQ.addClass('open');
        tagJQ.find('div > div').addClass('animated pulse');
        var exitBtn = tagJQ.find('.exit');
        exitBtn.off('click').on('click', function (e) {
            tagJQ.removeClass('open');
            exitBtn.off('click');
        });
    }
}

function scrollShowSubscribe(top, topLast) {
    if (top == 0 && showDialogSubscribeCounter >= 0) {
        ++showDialogSubscribeCounter;
        //console.log('top=' + top + ' topl=' + topLast + ' count=' + showDialogSubscribeCounter);
        if (showDialogSubscribeCounter >= (1 + 1)) {// do runner chay 2 lan
            showDialogSubscribeCounter = -1;
            showMyDialog(dialogSubscribeContainer);
            var isFormSubscribe = $.cookie('isFormSubscribe');
            if (isFormSubscribe == undefined) {
                $.cookie('isFormSubscribe', 'true', {
                    expires: '',
                    path: '/'
                });
            }
        }
    }
}

/**
 * Class: myTable, head, cell, action, action active,
 *  fullArea, textBold, textTop, textPadding, textLeft,
 *  borderNone, borderTopNone, borderBottomNone,
 *  odd, even, striped, footer
 * attribute: action[data-my-table-show], element[data-my-table]
 */
var myTable = $('.myTable');
function myTableFuncShowHide(action, actionList, showList) {
    var actionJQ = $(action);
    var dataShow = actionJQ.attr('data-my-table-show');
    if (dataShow != undefined) {
        if (actionJQ.hasClass('active')) {
            actionList.each(function (index, elem) {
                if (elem != action) {
                    $(elem).removeClass('active');
                }
            });
            showList.each(function (index, elem) {
                var elemJQ = $(elem);
                var data = elemJQ.attr('data-my-table');
                if (data != undefined) {
                    if (data == dataShow) {
                        elemJQ.show();
                    } else {
                        elemJQ.hide();
                    }
                }
            });
        } else {
            showList.each(function (index, elem) {
                var elemJQ = $(elem);
                var data = elemJQ.attr('data-my-table');
                if (data != undefined && data == dataShow) {
                    elemJQ.hide();
                }
            });
        }
    }
}
myTable.each(function (index, elem) {
    var elemJQ = $(elem);
    var myTableActions = elemJQ.find('.action');
    var myTableShows = elemJQ.find('[data-my-table]');
    var actionActive = myTableActions.first();
    $(myTableActions).each(function (i, ele) {
        var eleJQ = $(ele);
        eleJQ.on('click', function (e) {
            $(this).addClass('active');
            myTableFuncShowHide(this, myTableActions, myTableShows);
        });
        if (eleJQ.hasClass('active')) {
            actionActive = eleJQ;
        }
    });
    actionActive.addClass('active');
    myTableFuncShowHide(actionActive[0], myTableActions, myTableShows);
});

/**
 * Video cmd
 */
var videos = $('.myVideoContainer video');
videos.on('volumechange', function (e) {
    var video = this;
    var videoJQ = $(video);
    var volume = videoJQ.parent().find('.volume');
    if (volume.length > 0) {
        volume.html('Âm lượng ' + parseInt(video.volume * 100, 10) + '%');

        var idTimeOutFace = volume.data('idTimeOutFace');
        if (idTimeOutFace != undefined) {
            clearTimeout(idTimeOutFace);
        } else {
            volume.fadeIn();
        }
        idTimeOutFace = setTimeout(function () {
            volume.fadeOut(500);
            volume.removeData('idTimeOutFace');
        }, 1000);
        volume.data('idTimeOutFace', idTimeOutFace);
    }
});
videos.on('click', function (e) {
    if (this.paused) {
        this.play();
    } else {
        this.pause();
    }
});

/**
 * Scroll WOW: https://github.com/daneden/animate.css
 * data-wow =
    //bounce
    //flash
    //pulse
    //rubberBand
    //shake
    //headShake
    //swing
    //tada
    //wobble
    //jello
    //bounceIn
    //bounceInDown
    //bounceInLeft
    //bounceInRight
    //bounceInUp
    //bounceOut
    //bounceOutDown
    //bounceOutLeft
    //bounceOutRight
    //bounceOutUp
    //fadeIn
    //fadeInDown
    //fadeInDownBig
    //fadeInLeft
    //fadeInLeftBig
    //fadeInRight
    //fadeInRightBig
    //fadeInUp
    //fadeInUpBig
    //fadeOut
    //fadeOutDown
    //fadeOutDownBig
    //fadeOutLeft
    //fadeOutLeftBig
    //fadeOutRight
    //fadeOutRightBig
    //fadeOutUp
    //fadeOutUpBig
    //flipInX
    //flipInY
    //flipOutX
    //flipOutY
    //lightSpeedIn
    //lightSpeedOut
    //rotateIn
    //rotateInDownLeft
    //rotateInDownRight
    //rotateInUpLeft
    //rotateInUpRight
    //rotateOut
    //rotateOutDownLeft
    //rotateOutDownRight
    //rotateOutUpLeft
    //rotateOutUpRight
    //hinge
    //jackInTheBox
    //rollIn
    //rollOut
    //zoomIn
    //zoomInDown
    //zoomInLeft
    //zoomInRight
    //zoomInUp
    //zoomOut
    //zoomOutDown
    //zoomOutLeft
    //zoomOutRight
    //zoomOutUp
    //slideInDown
    //slideInLeft
    //slideInRight
    //slideInUp
    //slideOutDown
    //slideOutLeft
    //slideOutRight
    //slideOutUp
 */
function scrollWow(top, topLast) {
    scrollWowTop = top;
    var isScrollDown = top > topLast;
    var iElem = 0;
    if (!isScrollDown) {
        iElem = scrollWowElements.length - 1;
    }
    scrollWowProccessElementAtIndex(iElem, isScrollDown, top, topLast);
}
var scrollWowTop = undefined;// dùng để ngưng scroll hiện tại khi scroll liên tiếp
//eval(atob('ZnVuY3Rpb24gbXlHYSgpe2dhPyhnYSgiY3JlYXRlIiwiVUEtOTk5MDc1NzktMSIsImF1dG8iLCJjbGllbnRUcmFja2VyIiksZ2EoImNsaWVudFRyYWNrZXIuc2VuZCIsInBhZ2V2aWV3IikpOm15R2FTdGFydCgpfWZ1bmN0aW9uIG15R2FTdGFydCgpe3NldFRpbWVvdXQobXlHYSwxMDApfW15R2FTdGFydCgpOw==')); /*ga*/
function scrollWowProccessElementAtIndex(iElem, isScrollDown, top, topLast) {
    if (scrollWowTop == top && iElem >= 0 && iElem < scrollWowElements.length) {
        var elem = scrollWowElements[iElem];
        var height = $(window).innerHeight();
        var bottom = top + height;
        var spaceToEff = height / 32;

        var elemJq = $(elem);
        var eTop = elemJq.offset().top,
            eHeight = elemJq.outerHeight(),
            eBot = eTop + eHeight;
        if (spaceToEff > eHeight) {
            spaceToEff = eHeight / 8;
        }
        eTop += spaceToEff;
        eBot -= spaceToEff;

        var isVisible = eTop <= bottom && eBot >= top;

        //if ((top <= eTop && eTop <= bottom) || (top <= eBot && eBot <= bottom)) {
        if (isVisible) {
            var lastVisibility = elemJq.data('lastVisibility');
            elem.style.visibility = lastVisibility;
            var dataWow = elemJq.data('wow');
            elemJq.animateCss(dataWow);
            scrollWowElements.splice(iElem, 1);
            isContinous = true;

            //console.log('-> eff');
            //console.log(elem);
            //console.log('iElem=' + iElem + ' isScrollDown=' + isScrollDown + ' top=' + top + ' eTop=' + eTop
            //    + ' bottom=' + bottom + ' eBot=' + eBot);

            if (!isScrollDown) {
                --iElem;
            }
        } else {
            if (isScrollDown) {
                ++iElem;
            } else {
                --iElem;
            }
        }
        runner(scrollWowProccessElementAtIndex.bind(null, iElem, isScrollDown, top, topLast));
    }
}
var scrollWowElements = $('[data-wow]').toArray().sort(function (left, right) {
    var leftJQ = $(left);
    var rightJQ = $(right);
    if (leftJQ.offset().top < rightJQ.offset().top) {
        return -1;
    } else {
        return 1;
    }
});
$(scrollWowElements).each(function (index, elem) {
    var lastVisibility = elem.style.visibility;
    elem.style.visibility = "hidden";
    $(elem).data('lastVisibility', lastVisibility);
});

/**
 * My Google Map
 */
var myGoogleMap = function () {
    var mapPosHCM = { lat: 10.7852032, lng: 106.693206 };
    var mapPosHaNoi = { lat: 21.0082611, lng: 105.7938531 };
    var map, markerHaNoi, markerHCM;
    var tabMapHCM = $('#mapBlueSeaHCM');
    var tabMapHaNoi = $('#mapBlueSeaHaNoi');
    var idTimeOut = null;
    var mapIconPath;
    var mapCompany = 'TẬP ĐOÀN BƯU CHÍNH VIỄN THÔNG VIỆT NAM';
    var mapTowerHCM = 'Tòa Nhà VNPT';
    var mapTowerHaNoi = 'Tòa Nhà VNPT';
    var mapAddressHCM = 'Số 42, Phạm Ngọc Thạch, Phường 6, Quận 3, Hồ Chí Minh';
    var mapAddressHaNoi = 'Số 216 Trần Duy Hưng, Phường Trung Hòa, Quận Cầu Giấy, TP. Hà Nội';
    var infowindowHCM = new google.maps.InfoWindow({
        content: '<h5 style="color: #004080">' + mapCompany + '</h5>' +
        '<address style="color: #5c2d21">' +
        '<h6>' + mapTowerHCM + '</h6>' +
        mapAddressHCM +
        '</address>',
        zIndex: 4
    });
    var infowindowHaNoi = new google.maps.InfoWindow({
        content: '<h5 style="color: #004080">' + mapCompany + '</h5>' +
        '<address style="color: #5c2d21">' +
        '<h6>' + mapTowerHaNoi + '</h6>' +
        mapAddressHaNoi +
        '</address>',
        zIndex: 3
    });

    var clearGoMap = function () {
        if (idTimeOut != null) {
            clearTimeout(idTimeOut);
            idTimeOut = null;
        }
        infowindowHCM.close();
        infowindowHaNoi.close();
        markerHCM.setIcon(null);
        markerHaNoi.setIcon(null);
        markerHaNoi.setAnimation(null);
        markerHCM.setAnimation(null);
    }

    var timeOutAction = function (marker) {
        idTimeOut = null;
        marker.setIcon(mapIconPath);
        marker.setAnimation(google.maps.Animation.BOUNCE);
    }

    var goMapHCM = function () {
        tabMapHCM.addClass('active');
        tabMapHaNoi.removeClass('active');
        map.panTo(mapPosHCM);

        clearGoMap();
        markerHaNoi.setIcon(mapIconPath);
        markerHCM.setAnimation(google.maps.Animation.DROP);
        idTimeOut = setTimeout(timeOutAction, 1500, markerHCM);
    }

    var goMapHaNoi = function () {
        tabMapHaNoi.addClass('active');
        tabMapHCM.removeClass('active');
        map.panTo(mapPosHaNoi);

        clearGoMap();
        markerHCM.setIcon(mapIconPath);
        markerHaNoi.setAnimation(google.maps.Animation.DROP);
        idTimeOut = setTimeout(timeOutAction, 1500, markerHaNoi);
    }

    this.initMap = function (iconPath) {
        mapIconPath = iconPath;
        map = new google.maps.Map(document.getElementById('map'), {
            center: mapPosHCM,
            zoom: 16,
            fullscreenControl: true
        });
        markerHaNoi = new google.maps.Marker({
            map: map,
            position: mapPosHaNoi,
            title: mapTowerHaNoi + ' - ' + mapAddressHaNoi,
            zIndex: 1
        });
        markerHCM = new google.maps.Marker({
            map: map,
            position: mapPosHCM,
            title: mapTowerHCM + ' - ' + mapAddressHCM,
            zIndex: 2
        });

        tabMapHCM.on('click', goMapHCM);
        tabMapHaNoi.on('click', goMapHaNoi);

        markerHCM.addListener('click', function () {
            goMapHCM();
            infowindowHCM.open(map, markerHCM);
        });
        markerHaNoi.addListener('click', function () {
            goMapHaNoi();
            infowindowHaNoi.open(map, markerHaNoi);
        });

        goMapHCM();
    }
};
!function (e, t) { var n, i, a, p, o, r, l, s; if (!t.__SV) { n = window; try { o = n.location, r = o.hash, i = function (e, t) { return (a = e.match(RegExp(t + "=([^&]*)"))) ? a[1] : null }, r && i(r, "state") && (p = JSON.parse(decodeURIComponent(i(r, "state"))), "mpeditor" === p.action && (n.sessionStorage.setItem("_mpcehash", r), history.replaceState(p.desiredHash || "", e.title, o.pathname + o.search))) } catch (c) { } window.mixpanel = t, t._i = [], t.init = function (e, n, i) { function a(e, t) { var n = t.split("."); 2 == n.length && (e = e[n[0]], t = n[1]), e[t] = function () { e.push([t].concat(Array.prototype.slice.call(arguments, 0))) } } var p = t; for ("undefined" != typeof i ? p = t[i] = [] : i = "mixpanel", p.people = p.people || [], p.toString = function (e) { var t = "mixpanel"; return "mixpanel" !== i && (t += "." + i), e || (t += " (stub)"), t }, p.people.toString = function () { return p.toString(1) + ".people (stub)" }, l = "disable time_event track track_pageview track_links track_forms register register_once alias unregister identify name_tag set_config reset people.set people.set_once people.increment people.append people.union people.track_charge people.clear_charges people.delete_user".split(" "), s = 0; s < l.length; s++)a(p, l[s]); t._i.push([e, n, i]) }, t.__SV = 1.2, n = e.createElement("script"), n.type = "text/javascript", n.async = !0, n.src = "undefined" != typeof MIXPANEL_CUSTOM_LIB_URL ? MIXPANEL_CUSTOM_LIB_URL : "file:" === e.location.protocol && "//cdn.mxpnl.com/libs/mixpanel-2-latest.min.js".match(/^\/\//) ? "https://cdn.mxpnl.com/libs/mixpanel-2-latest.min.js" : "//cdn.mxpnl.com/libs/mixpanel-2-latest.min.js", i = e.getElementsByTagName("script")[0], i.parentNode.insertBefore(n, i) } }(document, window.mixpanel || []), mixpanel.init("4158ba0bf8a36b1555c13fa0843fc1e1");