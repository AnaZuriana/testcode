<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="insert.aspx.cs" Inherits="MyApplication.Module.insert" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="http://code.jquery.com/jquery-1.8.2.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table>
<tr>
<td>Name:</td>
<td><input type="text" id="txtname" /></td>
</tr>
<tr>
<td>Country:</td>
<td> <input type="text" id="txtsubject" /></td>
</tr>
<tr>
<td>&nbsp;</td>
<td> &nbsp;</td>
</tr>
<tr>
<td>&nbsp;</td>
<td> &nbsp;</td>
</tr>
<tr>
<td></td>
<td>
<input type="button" id="btnSubmit" value="Submit" />
</td>
</tr>
</table>
    </div>
    </form>
    <script type="text/javascript">
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
                        var obj = data.d;
                        if (obj == 'true') {
                            $('#txtname').val('');
                            $('#txtsubject').val('');
                          
                           // $('#lblmsg').html("Details Submitted Successfully");
                            //window.location.reload();
                            alert("successfully update!")
                        }
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
</script>
</body>
</html>
