<%@ Page Language="C#"  MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

    <asp:Content ID="Content" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">

        <script type="text/javascript">
            jQuery(function ($) {
                $("#ContentPlaceHolder2_TextBoxPhone").mask("(999) 999-9999");
            });
    </script>
   

        <asp:Panel ID="PanelID" runat="server" BackColor="#459649">
           

             <table class="auto-style1">
            <tr>
                <td class="auto-style2">
        <asp:Label ID="LabelCompanyName" runat="server" Text="Company Name:" Font-Bold="True" ForeColor="White"></asp:Label>
                </td>
                <td class="auto-style17">
        <asp:TextBox ID="TextBoxCName" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style19">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxCName" ErrorMessage="Enter Company Name" ForeColor="Red" ValidationGroup="5"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style14">
        <asp:Label ID="LabelCompanyUsername" runat="server" Text="Username:" Font-Bold="True" ForeColor="White"></asp:Label>
                </td>
                <td class="auto-style18">
        <asp:TextBox ID="TextBoxUsername" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style20">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxUsername" ErrorMessage="Enter UserName " ForeColor="Red" ValidationGroup="5"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
        <asp:Label ID="LabelPassword" runat="server" Text="Password:" Font-Bold="True" ForeColor="White"></asp:Label>
                </td>
                <td class="auto-style17">
        <asp:TextBox ID="TextBoxpassword" runat="server" TextMode="Password"></asp:TextBox>
                </td>
                <td style="margin-left: 40px" class="auto-style19">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxpassword" ErrorMessage="Enter Password" ForeColor="Red" ValidationGroup="5"></asp:RequiredFieldValidator>
                    &nbsp;&nbsp;&nbsp;
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBoxpassword" ControlToValidate="TextBoxRetypepassword" ErrorMessage="Wrong Password"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
        <asp:Label ID="LabelRetypePassword" runat="server" Text="Re-type Password:" Font-Bold="True" ForeColor="White"></asp:Label>
                </td>
                <td class="auto-style17">
        <asp:TextBox ID="TextBoxRetypepassword" runat="server" TextMode="Password"></asp:TextBox>
                </td>
                <td class="auto-style19">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBoxRetypepassword" ErrorMessage="Enter-Re Password" ForeColor="Red" ValidationGroup="5"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
        <asp:Label ID="Labelemail" runat="server" Text="E-Mail:" Font-Bold="True" ForeColor="White"></asp:Label>
                </td>
                <td class="auto-style17">
        <asp:TextBox ID="TextBoxemail" runat="server" TextMode="Email"></asp:TextBox>
                </td>
                <td class="auto-style19">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBoxemail" ErrorMessage="Enter E-Mail" ForeColor="Red" ValidationGroup="5"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
        <asp:Label ID="LabelPhone" runat="server" Text="Phone:" Font-Bold="True" ForeColor="White"></asp:Label>
                </td>
                <td class="auto-style17">

        <asp:TextBox ID="TextBoxPhone" runat="server"></asp:TextBox>
              
                </td>
                <td class="auto-style19">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBoxPhone" ErrorMessage="Enter Phone Number" ForeColor="Red" ValidationGroup="5"></asp:RequiredFieldValidator>
                </td>
            </tr>

            <tr>
                <td class="auto-style3">
                    <asp:Label ID="Label4" runat="server" ForeColor="White" Font-Bold="True" Text="Address:"></asp:Label>
                </td>
                <td class="auto-style4">
                    <asp:TextBox ID="AddressID" runat="server" Height="47px" TextMode="MultiLine" Width="174px"></asp:TextBox>
                </td>
                <td class="auto-style19">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="AddressID" ErrorMessage="Enter Addres " ForeColor="Red" ValidationGroup="5"></asp:RequiredFieldValidator>
                </td>
            </tr>
                 <tr>
                   
                     <td class="auto-style8"><asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="White" Text="Contact First Name:"></asp:Label>
                     </td>
                     <td class="auto-style18">
                         <asp:TextBox ID="CFistTxtField" runat="server"></asp:TextBox>
                     </td>
                     <td class="auto-style19">
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="CFistTxtField" ErrorMessage="Enter First Name" ForeColor="Red" ValidationGroup="5"></asp:RequiredFieldValidator>
                     </td>
                 </tr>

                 <tr>
                     <td class="auto-style9">
                         <asp:Label ID="Label3" runat="server"  Font-Bold="True" ForeColor="White" Text="Contact Last Name:"></asp:Label>
                     </td>
                     <td class="auto-style12">
                         <asp:TextBox ID="CLastTxtField" runat="server"></asp:TextBox>
                     </td>
                     <td class="auto-style19">
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="CLastTxtField" ErrorMessage="Enter Last Name" ForeColor="Red" ValidationGroup="5"></asp:RequiredFieldValidator>
                     </td>
                 </tr>
            <tr>
                <td class="auto-style2">
                    &nbsp;</td>
                <td class="auto-style17">
                    <asp:Button ID="SaveBtn" runat="server" Text="Save" Width="96px" OnClick="SaveBtn_Click" ValidationGroup="5" />
                &nbsp;<asp:Button ID="CleanBtn" runat="server" OnClick="CleanBtn_Click" Text="Clean" Width="96px" ValidationGroup="5" />
                </td>
                <td class="auto-style19">
                    <asp:Label ID="UserNameWarning" runat="server" Text="The same User Name" Visible="False"></asp:Label>
                    <asp:Label ID="EmailWarning" runat="server" Text="The same email" Visible="False"></asp:Label>
                </td>
            </tr>
        </table>

             

        </asp:Panel>

        <asp:Label ID="lblBilgi" runat="server"></asp:Label>
    </asp:Content> 
<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style1 {
            width: 613px;
            height: 224px;
        }
        .auto-style2 {
            width: 177px;
        }
        #TextArea1 {
            width: 204px;
            height: 89px;
        }
        .auto-style3 {
            width: 177px;
            height: 99px;
        }
        .auto-style4 {
            height: 99px;
            width: 182px;
        }
        .auto-style8 {
            height: 26px;
        }
        .auto-style9 {
            height: 30px;
        }
        #txtAreaID {
            height: 56px;
            width: 176px;
        }
        .auto-style12 {
            height: 30px;
            width: 182px;
        }
        .auto-style14 {
        width: 177px;
        height: 26px;
    }
        .auto-style17 {
            width: 182px;
        }
        .auto-style18 {
            height: 26px;
            width: 182px;
        }
        .auto-style19 {
            width: 306px;
        }
        .auto-style20 {
            height: 26px;
            width: 306px;
        }
    </style>
</asp:Content>
 