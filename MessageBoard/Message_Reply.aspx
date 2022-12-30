<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Message_Reply.aspx.cs" Inherits="MessageBoard.Message_Reply" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <h1>回應留言</h1>
    <form id="form1" runat="server">
        <div>
            標題:<asp:TextBox ID="ReplyTopic" runat="server" ></asp:TextBox><br/>
            暱稱:<asp:TextBox ID="Respondent" runat="server" required="" aria-required="true" oninput="setCustomValidity('')" oninvalid="setCustomValidity('記得填寫暱稱')"></asp:TextBox><br/>
            內容:<asp:TextBox ID="ResponseContent" runat="server" Height="219px" Width="575px" required="" aria-required="true" oninput="setCustomValidity('')" oninvalid="setCustomValidity('記得填寫內容')"></asp:TextBox><br/>
            <asp:Button ID="Reply" runat="server" Text="確定回應" OnClick="Reply_Click" />&nbsp;
            <input id="Reset1" type="reset" value="重新填寫" />
        </div>
    </form>
</body>
</html>
