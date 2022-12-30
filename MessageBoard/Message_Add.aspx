<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Message_Add.aspx.cs" Inherits="MessageBoard.Add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            標題:<asp:TextBox ID="Topic" runat="server" ></asp:TextBox><br/>
            暱稱:<asp:TextBox ID="Author" runat="server" required="" aria-required="true" oninput="setCustomValidity('')" oninvalid="setCustomValidity('記得填寫暱稱')"></asp:TextBox><br/>
            內容:<asp:TextBox ID="Text" runat="server" Height="183px" TextMode="MultiLine" Width="529px" required="" aria-required="true" oninput="setCustomValidity('')" oninvalid="setCustomValidity('記得填寫內容')"></asp:TextBox><br/>
            <asp:Button ID="Confirm" runat="server" Text="確定留言" OnClick="Confirm_Click"/>
            &nbsp;<input id="Reset" type="reset" value="重新填寫" /></div>
    </form>
</body>
</html>
