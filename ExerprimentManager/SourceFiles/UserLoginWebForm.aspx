<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserLoginWebForm.aspx.cs" Inherits="ExerprimentManager.SourceFiles.UserLoginWebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            姓名:<asp:TextBox ID="uNameTB" runat="server"></asp:TextBox>
        </div>
        密码:<asp:TextBox ID="uPwdTB" runat="server"></asp:TextBox>
        <br />
        身份选择:<asp:DropDownList ID="DropDownList1" runat="server" BackColor="#CCFFFF" Font-Size="Medium" Height="106px" Width="70px">
            <asp:ListItem Selected="True">学生</asp:ListItem>
            <asp:ListItem>教师</asp:ListItem>
        </asp:DropDownList>
    </form>
</body>
</html>
