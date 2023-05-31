var contact = {
    init: function () {
        contact.registerEvent();
    },
    registerEvent: function () {
        $('#btnSend').off('click').on('click', function () {
            var name = $('#name').val();
            var phone = $('#phone').val();
            var email = $('#email').val();
            var company = $('#company').val();
            var text = $('#text').val();

            $.ajax({
                url: '/Default/Contact',
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
contact.init();