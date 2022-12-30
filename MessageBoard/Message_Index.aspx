<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Message_Index.aspx.cs" Inherits="MessageBoard.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="MessageID">
                <Columns>
                    <asp:TemplateField HeaderText="編號" SortExpression="Topic">
                        <ItemTemplate>
                        <%#Container.DataItemIndex+1%>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="主題" SortExpression="Topic">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Topic") %>'></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "Message_Main.aspx?id="+Eval("MessageID") %>' Text='<%# Eval("Topic") %>'></asp:HyperLink>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField DataField="Author" HeaderText="發言人" SortExpression="Author" />
                    <asp:BoundField DataField="InitDate" HeaderText="留言日期" SortExpression="InitDate" />
                    <asp:TemplateField HeaderText="回應">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("回應") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Button ID="WantToAdd" runat="server" Text="我要留言" OnClick="WantToAdd_Click" />
        </div>
        
    </form>
</body>
</html>
