<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="form.aspx.cs" Inherits="MyApplication.Module.form" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../Scripts/jquery-1.11.3.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Name :<asp:TextBox runat="server" ID="txtName" Text="" MaxLength="255" CssClass="form-control" placeholder="Enter Name"></asp:TextBox>
            Country :<asp:TextBox runat="server" ID="txtCountry" Text="" MaxLength="255" CssClass="form-control" placeholder="Enter Name"></asp:TextBox>
        </div>
        <asp:Button runat="server" ID="btnSave" Text="Save" CssClass="btn btn-redM" Style="min-width: 110px;" />
        <div>
             Select file : (Name must have keywords like 'Salary', 'Account', 'Statutory')
                    <input type="file" name="fileUpload[]" id="txtFileUpload" accept=".csv" multiple /><br>
                    <input type='button' class='btn btn-info' value='Upload' id='upload'/>
            </div>
    </form>
    <script type="text/javascript">
        var uploadData = "../../service.asmx/insertRecord";
        var btnSave = $("#btnSave");
        var txtName = $("[id$='txtName']").val();
        var txtAddress1 = $("[id$='txtCountry']").val();
        var returnedMsg = "";
        $('#upload').click(function () {
            //debugger;
            var file = $('#txtFileUpload')[0].files[0];
            alert(file.name);

        });
        btnSave.click(function () {
            var customer = {};
            customer.Name = $("#txtName").val();
            customer.Country = $("#txtCountry").val();
            console.log(customer);

            $.ajax({
                url: "../../service.asmx/insertRecord",
                type: "POST",
                async: false,
                data: JSON.stringify({ input: JSON.stringify(customer) }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    returnedMsg = data.d;
                    
                },
                error: function (x, y, z) {
                    alert(x.responseText + "  " + x.status);
                }
            });
            if(returnedMsg.indexOf("successfully"))
            {
                alert("success");
            }

        });

    </script>
</body>
</html>
