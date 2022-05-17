$('body').addClass('menu_dark theme-blue');



$(function () {

    $('.bootstrap-select').children('button').remove();
    $('.bootstrap-select').children('.dropdown-menu').remove();
    $('.bootstrap-select').removeClass('bootstrap-select');
    $('.bootstrap-select').removeClass('bootstrap-select');

    $('select').select2();


    triggerDateTimePicker();

});


var triggerDateTimePicker = function () {
    $('.datetimepicker').datetimepicker({
        //format: 'M/D/Y  HH:mm',
       // format: 'D/M/Y  HH:mm',
        clearButton: false,
        time: true,
        weekStart: 1
    });
    //$('.datetimepicker').datetimepicker();
    $('.datetimepicker').attr('autocomplete', 'off');
};


var fixedFloatVal = 3;

var GetFixedVal = function (val) {
    var x = 0;
    x = parseFloat(val).toFixed(fixedFloatVal);

    return parseFloat(x);
};


function PrintWindowController() {

    var divToPrint = document.querySelector('#modal-trigger .modal-body');

    var popupWin = window.open('', '_blank', 'width=1000,height=1000,location=no,left=400');

    popupWin.document.open();

    popupWin.document.write('<html><head>' +
        '<link rel="stylesheet" href="../assets/plugins/bootstrap/css/bootstrap.min.css">' +
        '<link rel="stylesheet" href="../assets/css/main.css">' +
        '<link rel="stylesheet" href="../assets/css/color_skins.css">' +
        '<link rel="stylesheet" href="../assets/css/rtl.css">' +
        '<link rel="stylesheet" href="../assets/css/style-ar.css">' +
        '<link href="../assets/css/style.css" rel="stylesheet" />' +
        '</head><body class="rtl">' + divToPrint.innerHTML + '<script>setTimeout(function(){window.print()},200)</script></html>');

    popupWin.document.close();
}

(function () {

  
    
   
    if ($('body').hasClass('NoRTL')) {
        $('.lang-icon a:first-of-type').removeClass('d-none');
        $('.lang-icon a:last-of-type').addClass('d-none');
    } else {
        $('.lang-icon a:first-of-type').addClass('d-none');
        $('.lang-icon a:last-of-type').removeClass('d-none');
    }


    $('.icon-add').on('click', function (e) {
        e.preventDefault();
        $(this).toggleClass('active-added');

        if ($(this).hasClass('active-added')) {
            $('.icon-add i').attr('class', 'icofont-close');
            $('.overlay-added').css('zIndex', '999');
            $('.overlay-added').animate({
                opacity: '1'
            }, 500);
            $('.btn-add').animate({
                zIndex: '9999',
                opacity: '1'
            }, 500);

        } else {
            $('.icon-add i').attr('class', 'icofont-ui-add');
            $('.overlay-added').animate({
                opacity: 0,
                zIndex: '-1'
            }, 500);

            $('.btn-add').animate({
                opacity: 0,
                zIndex: '-1'

            }, 500);
        }     
    });



    //$('.modal-content .modal-body').on('click', function (e) {
    //    e.stopPropagation();
    //});

    $('.overlay-added').on('click', function () {
        $('.icon-add i').attr('class', 'icofont-ui-add');
        $('.icon-add').removeClass('active-added');
        $('.overlay-added').animate({
            opacity: 0,
            zIndex: '-1'
        }, 500);
        $('.btn-add').animate({
            opacity: 0,
            zIndex: '-1'
        }, 500);

    });
    //$('.box-added .btn-add').on('click', function (e) {
    //    e.stopPropagation();
    //});

    $('ul.tabs-appointment li a').on('click', function () {
        $(this).addClass('active-bg').parent('li').siblings().children().removeClass('active-bg');
        $('#' + $(this).data('appointment')).siblings().css('display', 'none');
        $('#' + $(this).data('appointment')).fadeIn();
       
    });

    

}());

const __validateSessionForCurrentUser = function (xhr) {
    if (xhr.responseText === undefined) {
        return true;
    }
    if (xhr.responseText.replace(/\s/g, '') === 'SesstionEmpty') {

        window.location.href = '/';
        return false;
    }
    return true;
};
function EmptyForm() {
    $("form")[0].reset();
    //$('form input').val('');
    //$('form select').val('');
    //$('form .select2-selection__rendered').val('');
    //$('form .select2').val('');
    //$('form textarea').val('');
    //$('form file').val('');
}
