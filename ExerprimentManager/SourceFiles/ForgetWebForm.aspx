<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgetWebForm.aspx.cs" Inherits="ExerprimentManager.SourceFiles.ForgetWebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            修改密码<br />
            账号:<asp:TextBox ID="Account" runat="server"></asp:TextBox>
            <br />
            密保问题:<asp:DropDownList ID="VerfiyQuestionList" runat="server" Height="25px" Width="139px">
                <asp:ListItem>你的小学地址</asp:ListItem>
                <asp:ListItem>你的小学老师名字</asp:ListItem>
                <asp:ListItem>你的偶像</asp:ListItem>
            </asp:DropDownList>
            <asp:TextBox ID="VerfiyTB" runat="server"></asp:TextBox>
            <br />
            新密码:<asp:TextBox ID="PwdSettingTB" runat="server"></asp:TextBox>
            <br />
            确认密码:<asp:TextBox ID="ConfirmTB" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="SubmitBtn" runat="server" OnClick="SubmitBtn_Click" Text="确认" />
            <asp:Button ID="PublishBtn" runat="server" Text="提交" OnClick="PublishBtn_Click" />
            <asp:Button ID="CancelBtn" runat="server" OnClick="CancelBtn_Click" Text="取消" />
            <asp:LinkButton ID="ReturnLoginWeb" runat="server" OnClick="ReturnLoginWeb_Click">返回登录</asp:LinkButton>
        </div>
    </form>
</body>
</html>
