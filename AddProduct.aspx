<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddProduct.aspx.cs" Inherits="AddProduct" %>



    <asp:Content ID="Content" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">

        
        <asp:Panel ID="Panel2" runat="server">

            <asp:Label ID="LabelPName" runat="server" Text="Product Name:"></asp:Label>
&nbsp;
        <asp:TextBox ID="TextBoxPName"  Width="300px" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxPName" ErrorMessage="Please type product name." ValidationGroup="1"></asp:RequiredFieldValidator>
        <br />

        <br />
        <asp:Label ID="LabelPDetails" runat="server" Text="Product Details:"></asp:Label>
&nbsp;<asp:TextBox ID="TextBoxPDetails" runat="server" Height="52px" Width="300px" TextMode="MultiLine"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxPDetails" ErrorMessage="Please type product detail." ValidationGroup="1"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Label ID="LabelPCategory" runat="server" Text="Category:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="DropDownListPCategory" runat="server">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="LabelPImages" runat="server" Text="Product Images"></asp:Label>
        <br />
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="FileUpload1" ErrorMessage="Please select image file." ValidationGroup="1"></asp:RequiredFieldValidator>
        <br />
        <asp:FileUpload ID="FileUpload2" runat="server" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="FileUpload2" ErrorMessage="Please select image file." ValidationGroup="1"></asp:RequiredFieldValidator>
        <br />
        <asp:FileUpload ID="FileUpload3" runat="server" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="FileUpload3" ErrorMessage="Please select image file." ValidationGroup="1"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Label ID="LabelWarning" runat="server" Text="LabelWarning" Visible="False"></asp:Label>
        <br />
        <br />
        <asp:Label ID="LabelPPrice" runat="server" Text="Price:"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBoxPrice" runat="server" TextMode="Number"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBoxPrice" ErrorMessage="Please type price." ValidationGroup="1"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Button ID="ButtonReset" runat="server" OnClick="ButtonReset_Click" Text="Reset" />
&nbsp;<asp:Button ID="ButtonAddProduct" runat="server" Text="Add Product" OnClick="ButtonAddProduct_Click" ValidationGroup="1" />
        </asp:Panel>

        
        <br />
        <asp:Label ID="LabelAttachmentWarning" runat="server" Text="LabelAttachmentWarning" Visible="False"></asp:Label>
        <br />
        <asp:Label ID="LabelResult" runat="server" Text="LabelResult" Visible="False"></asp:Label>
        <br />
    </asp:Content> 