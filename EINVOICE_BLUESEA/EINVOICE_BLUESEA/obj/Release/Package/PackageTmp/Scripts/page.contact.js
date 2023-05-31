var formContact = $('#formContact');
formContact.submit(function (e) {
    e.preventDefault();
    if (formContact.valid()) {
        var action = formContact.prop('action');
        //var name = formContact.find('[name="Name"]').val();
        //var email = formContact.find('[name="Email"]').val();
        //var phone = formContact.find('[name="Phone"]').val();
        //var companyWebsite = formContact.find('[name="CompanyWebsite"]').val();
        //var body = formContact.find('[name="Body"]').val();
        //var token = $('input[name="__RequestVerificationToken"]', formContact).val();
        //$.post(action, { Name: name, Email: email, Phone: phone, CompanyWebsite: companyWebsite, Body: body, __RequestVerificationToken: token }, function (data) {
        //    // do nothing because security
        //    //if (data && data.status && data.status == 'ok') {
        //    //    var div = formContact.parent();
        //    //    formContact.hide();
        //    //    div.html('<p>' + data.content + '</p>');
        //    //    var divP = div.find('p');
        //    //    divP.hide();
        //    //    divP.fadeIn();
        //    //} else {
        //    //    formContact.find('input, button').attr('disabled', false);
        //    //    var mess = data && data.content ? data.content : 'Lỗi không xác định';
        //    //    bootbox.alert(mess);
        //    //}
        //});
        $.post(action, formContact.serialize(), function (data) {
            //if (data && data.status && data.status == 'ok') {
            //} else {
            //}
            console.log(arguments);
        });

        formContact.find('input, button').attr('disabled', true);

        // doing here for fast feel
        var div = formContact.parent();
        formContact.hide();
        div.html('<p class="text-center mySectionText">Cảm ơn bạn đã liên hệ với VNPT Einvoice!<br/>' +
            'Chúng tôi sẽ liên hệ với bạn trong thời gian sớm nhất</p>');
        var divP = div.find('p');
        divP.hide();
        divP.fadeIn();
    }
})