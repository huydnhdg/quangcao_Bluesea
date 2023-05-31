var mcontact = {
    init: function () {
        mcontact.registerEvent();
    },
    registerEvent: function () {
        $('#mbtnSend').off('click').on('click', function () {
            var name = $('#mname').val();
            var phone = $('#mphone').val();
            var email = $('#memail').val();
            var company = $('#mcompany').val();
            var text = $('#mtext').val();

            $.ajax({
                url: '/Default/Popup',
                type: 'POST',
                dataType: 'json',
                data: {
                    name: name,
                    phone: phone,
                    email: email,
                    company: company,
                    text: text
                },
                success: function (res) {
                    if (res.status == true) {
                        window.alert('Gửi yêu cầu đã được thực hiện.')
                        //mcontact.resertForm();
                    } else {
                        window.alert('Yêu cầu của bạn chưa được gửi đi.')
                    }
                }
            });
        });
    },
    //resertForm: function () {
    //    $('#squarespaceModal').modal('hide');
    //}
}
mcontact.init();