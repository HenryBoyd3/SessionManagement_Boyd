<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SessionManagement.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="font-family:'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif">
    <form id="form1" runat="server">
        <div style="height:90%;">
            <div style="float:right;width:300px;border:1px solid black;padding:10px;">
                Username: <asp:TextBox ID="txtUser" runat="server" /><br />
                Password: <asp:TextBox ID="txtPassword" runat="server" /><br />
                <asp:Label ID ="lblMessage" runat="server" ForeColor="Red" />
                <div style="float:right;width:300px;padding:5px; text-align:right;">
                    <asp:Button ID="btnLogIn" runat="server" Text="Log In" OnClick="btnLogIn_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
