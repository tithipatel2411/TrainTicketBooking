<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DefaultGridView.aspx.cs" Inherits="TrainTicketBooking.DefaultGridView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="UserId" DataSourceID="SqlDataSource1" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="UserId" HeaderText="UserId" ReadOnly="True" SortExpression="UserId" />
                    <asp:BoundField DataField="UserName" HeaderText="UserName" SortExpression="UserName" />
                    <asp:BoundField DataField="Gender" HeaderText="Gender" SortExpression="Gender" />
                    <asp:BoundField DataField="Age" HeaderText="Age" SortExpression="Age" />
                    <asp:BoundField DataField="Wallet" HeaderText="Wallet" SortExpression="Wallet" />
                    <asp:BoundField DataField="Password" HeaderText="Password" SortExpression="Password" />
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Connection %>" SelectCommand="SELECT * FROM [UserDetail]"></asp:SqlDataSource>
        </div>
        <asp:Repeater ID="Repeater1" runat="server">
            <itemtemplate>
                <div class="rptr">
                    <table>
                        <tr><th>user id <%#Eval("userid") %></th></tr>
                        <tr><td>user name</td><td><%#Eval("username") %></td></tr>
                        <tr><td>gender</td><td><%#Eval("gender") %></td></tr>
                        <tr><td>age</td><td><%#Eval("age") %></td></tr>
                        <tr><td>wallet</td><td><%#Eval("wallet") %></td></tr>
                        <tr><td>password</td><td><%#Eval("password") %></td></tr>
                    </table>
                </div>
            </itemtemplate>
        </asp:Repeater>
    </form>
</body>
</html>
