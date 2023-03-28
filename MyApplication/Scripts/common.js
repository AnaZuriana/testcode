$(function () {
    $('#btnSubmit').click(function () {
        var name = $('#txtname').val();
        var subject = $('#txtsubject').val();
        var customer = {};
        customer.Name = $('#txtname').val();
        customer.Country = $('#txtsubject').val();


        if (customer.Name != '' && customer.Country != '') {
            $.ajax({
                type: "POST",
                contentType: "application/json; charset=utf-8",
                url: "../../Service.asmx/InsertData",
                data: "{'Name':'" + name + "','Country':'" + subject + "'}",
                dataType: "json",
                success: function (data) {
                    
                        $('#txtname').val('');
                        $('#txtsubject').val('');

                        // $('#lblmsg').html("Details Submitted Successfully");
                        //window.location.reload();
                        alert("successfully update!")
                   
                },
                error: function (result) {
                    alert("Error");
                }
            });
        }
        else {
            alert('Please enter all the fields')
            return false;
        }
    })
});