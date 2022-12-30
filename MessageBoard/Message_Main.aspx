<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Message_Main.aspx.cs" Inherits="MessageBoard.Message_Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            主題:<asp:Label ID="Message_Topic" runat="server" Text="Label"></asp:Label><br />
            內容:<asp:Label ID="Message_Text" runat="server" Text="Label"></asp:Label><br />
            發表人:<asp:Label ID="Message_Author" runat="server" Text="Label"></asp:Label><br />
            發布時間:<asp:Label ID="Message_InitDate" runat="server" Text="Label"></asp:Label><br />
            <asp:Button ID="Reply" runat="server" Text="回應文章" OnClick="Reply_Click" />&nbsp;
            <asp:Button ID="Homepage" runat="server" Text="回首頁" OnClick="Homepage_Click" />
            <br />

            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ResponseID">
                <Columns>
                    <asp:TemplateField HeaderText="編號" SortExpression="ResponseContent">
                        <ItemTemplate>
                            <%#Container.DataItemIndex+1%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Respondent" HeaderText="暱稱" SortExpression="Respondent" />
                    <asp:BoundField DataField="ResponseContent" HeaderText="回應內容" SortExpression="ResponseContent" />
                    <asp:BoundField DataField="InitDate" HeaderText="留言日期" SortExpression="InitDate" />
                    
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
