<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="~/Category.aspx.cs" Inherits="Category" %>


<asp:Content ID="Content" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">


     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" DataSourceID="SqlDataSource3" AllowPaging="True" GridLines="None" PageSize="4" CssClass="gridView">
         <AlternatingRowStyle BackColor="White" />
         <Columns>
             <asp:ImageField DataImageUrlField="ProductImagePath" NullImageUrl="~/images/noimg.png">
             </asp:ImageField>
             <asp:TemplateField HeaderText="Product Details">
                 <ItemTemplate>
                     <asp:Label ID="LabelPName" runat="server" Text='<%# Eval("ProductName") %>' CssClass="lblPName"></asp:Label>
                        &nbsp;<br />
                     <asp:Label ID="LabelPdetail" runat="server" CssClass="lblPDetail" Text='<%# Eval("ProductDetails") %>'></asp:Label>
                     <asp:HyperLink ID="HyperLink1" runat="server" CssClass="pdbtndetail" NavigateUrl='<%# Eval("ProductNo", "Detail.aspx?ProductNo={0}") %>' Text="Details..."></asp:HyperLink>
                 </ItemTemplate>
             </asp:TemplateField>
         </Columns>
         <EditRowStyle BackColor="#2461BF" />
         <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
         <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
         <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
         <RowStyle BackColor="#EFF3FB" height="140px"  />
         <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
         <SortedAscendingCellStyle BackColor="#F5F7FB" />
         <SortedAscendingHeaderStyle BackColor="#6D95E1" />
         <SortedDescendingCellStyle BackColor="#E9EBEF" />
         <SortedDescendingHeaderStyle BackColor="#4870BE" />
     </asp:GridView>
     <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:15MY03010DBConnectionString %>" SelectCommand="SELECT DISTINCT Product.ProductImagePath, Product.ProductName, Product.ProductDetails, Product.ProductNo FROM Product INNER JOIN Category ON  Product.CategoryID =@cate ORDER BY Product.ProductNo DESC">
         <SelectParameters>
             <asp:QueryStringParameter Name="cate" QueryStringField="CategoryID" />
         </SelectParameters>
     </asp:SqlDataSource>


     </asp:Content> 