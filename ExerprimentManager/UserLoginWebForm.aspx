<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserLoginWebForm.aspx.cs" Inherits="ExerprimentManager.SourceFiles.UserLoginWebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 247px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">
        <div>
            账号:<asp:TextBox ID="Account" runat="server"></asp:TextBox>
        </div>
        密码:<asp:TextBox ID="uPwdTB" runat="server"></asp:TextBox>
        <br />
        身份选择:<asp:DropDownList ID="IDSelectList" runat="server" BackColor="#CCFFFF" Font-Size="Medium" Height="25px" Width="79px">
            <asp:ListItem Selected="True">学生</asp:ListItem>
            <asp:ListItem>教师</asp:ListItem>
        </asp:DropDownList>
                </td>
                <td>
                    <asp:Button ID="SubmitBtn" runat="server" Font-Size="Large" Height="67px" OnClick="SubmitBtn_Click" Text="登录" Width="112px" />
                    <br />
                    <asp:LinkButton ID="ForgetBtn" runat="server" OnClick="ForgetBtn_Click">忘记密码</asp:LinkButton>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
