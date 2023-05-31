var contact = {
    init: function () {
        contact.registerEvents();
    },
    registerEvents: function () {
        $('#btnSend').off('click').on('click', function () {
            var name = $('#inputname').val();
            var email = $('#inputemail').val();
            var phone = $('#inputphone').val();
            var service = $('#inputservice').val();
            var note = $('#inputnote').val();

            $.ajax({
                url: '/Lienhe/Send',
                type: 'POST',
                dataType: 'json',
                data: {
                    name: name,
                    email: email,
                    phone: phone,
                    service: service,
                    note: note
                },
                success: function (res) {
                    if (res.status == true) {
                        window.alert('Gửi yêu cầu đã được thực hiện.')
                        contact.resertForm();
                    }
                }
            });
        });
    },
    resertForm: function () {
        $('#inputname').val('');
        $('#inputemail').val('');
        $('#inputphone').val('');
        //$('#inputservice').val('');
        $('#inputnote').val('');
    }
}
contact.init();