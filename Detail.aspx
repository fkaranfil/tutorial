<%@ Page Language="C#"  MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Detail.aspx.cs" Inherits="Detail" %>



<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder2">
    <br />
    <asp:Image ID="ImageProduct" runat="server" Height="182px" Width="158px" />
    &nbsp;&nbsp;
    <asp:Image ID="ImageProduct2" runat="server" Height="182px" Width="158px" />
    &nbsp;&nbsp;
    <asp:Image ID="ImageProduct3" runat="server" Height="182px" Width="158px" />
    <br />
    <br />
    <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Product Name:"></asp:Label>
    <asp:Label ID="PNameLbl" runat="server" Text="Label"></asp:Label>
    <br />
    <br />
    <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Category:"></asp:Label>
    <asp:Label ID="CategoryLbl" runat="server" Text="Label"></asp:Label>
    <br />
    <br />
    <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Stock:"></asp:Label>
    <asp:Label ID="PStateLbl" runat="server" Text="Label"></asp:Label>
    <br />
    <br />
    <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="Date:"></asp:Label>
    <asp:Label ID="DateLbl" runat="server" Text="Label"></asp:Label>
    <br />
    <br />
    <asp:Label ID="Label5" runat="server" Font-Bold="True" Text="Description:"></asp:Label>
    <asp:Label ID="DescriptionLbl" runat="server" Text="Label"></asp:Label>
    <br />
    <br />
    <asp:Label ID="Label6" runat="server" Font-Bold="True" Text="Price:"></asp:Label>
    <asp:Label ID="PriceLbl" runat="server" Text="Label"></asp:Label>
    <br />
    <br />
    <br />
    <asp:Button ID="Button1" runat="server" BackColor="Lime" ForeColor="#0033CC" Height="29px" OnClick="Button1_Click" Text="BUY" Width="85px" />
    <br />
    <br />
    <div id="gridviewcomment">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" DataSourceID="SqlDataSource2" AllowPaging="True" GridLines="None" PageSize="4" CssClass="gridView" AllowSorting="True">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <strong>Date:</strong><asp:Label ID="Label8" runat="server" Text='<%# Eval("CommentDate") %>'></asp:Label>
                        <br />
                        <strong>Name:</strong><asp:Label ID="Label9" runat="server" Text='<%# Eval("CommenterName") %>'></asp:Label>
                        <br />
                        <strong>Message:</strong><asp:Label ID="Label10" runat="server" Text='<%# Eval("CommentText") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
           
            </Columns>
            <EditRowStyle BackColor="#2461BF" Width="100px"/>
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" height="80px"/>
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
         
    <br />
            
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:15MY03010DBConnectionString %>" SelectCommand="SELECT DISTINCT Comment.CommentDate, Comment.CommenterName, Comment.CommentText, Comment.ProductID FROM Comment INNER JOIN Product ON Comment.ProductID = @Pno ORDER BY Comment.CommentDate ASC">
            <SelectParameters>
                <asp:QueryStringParameter Name="Pno" QueryStringField="ProductNo" />
            </SelectParameters>
    </asp:SqlDataSource>
        <br />
    Your name:<br />
    <asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label7" runat="server" Text="You can write comment:"></asp:Label>
    <br />
    <asp:TextBox ID="TextBoxComment" runat="server" Height="63px" TextMode="MultiLine" Width="402px"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="ButtonSendComment" runat="server" BackColor="Lime" ForeColor="#0033CC" OnClick="ButtonSendComment_Click" Text="Send Button" />
    <br />
    <p>
    </p>
             </div>
    <script type="text/javascript">
        function showImage(number) {
            var img = document.getElementById("imgBig");
            img.src = "~/images/" + number + ".png";//
        }
	</script>
</asp:Content>


