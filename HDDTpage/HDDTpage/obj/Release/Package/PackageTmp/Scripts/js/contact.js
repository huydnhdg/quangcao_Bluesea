var contact = {
    init: function () {
        contact.registerEvent();
    },
    registerEvent: function () {
        $('#btnSend').off('click').on('click', function () {
            var name = $('#full-name').val();
            var phone = $('#phone-number').val();
            var email = $('#email').val();
            var text = $('#text').val();
            var company = $('#company').val();

            $.ajax({
                url: '/Home/Contact',
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
                        //contact.resertForm();
                    } else {
                        window.alert('Yêu cầu của bạn chưa được gửi đi.')
                    }
                }
            });
        });        
    },
    resertForm: function () {
        //$('#squarespaceModal').modal('hide');
    }
}
contact.init();