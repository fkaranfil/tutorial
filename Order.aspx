<%@ Page Language="C#"  MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Order.aspx.cs" Inherits="Order" %>


 <asp:Content ID="Content" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
       
  
        

        <asp:Panel ID="PanelID" runat="server">
            
            <table style="width: 522px">

                <tr>
                    <td class="auto-style21">Informations</td>
                    <td class="auto-style26"></td>
                    <td class="auto-style11">&nbsp;</td>
                </tr>

                <tr><td class="auto-style21">
                    First Name</td><td class="auto-style24">
                        <asp:TextBox ID="TxtFname" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style10">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter FirstName" ControlToValidate="TxtFname"></asp:RequiredFieldValidator>
                    </td>

                </tr>
                <tr>
                    <td class="auto-style22">
                        Last Name</td><td class="auto-style26">
                        <asp:TextBox ID="TxtLastname" runat="server"></asp:TextBox>
                    </td>
                   <td class="auto-style11">
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter LastName" ControlToValidate="TxtLastname"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style22">
                        E-Mail</td><td class="auto-style26">
                        <asp:TextBox ID="TxtEmail" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style11">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Enter E-mail" ControlToValidate="TxtEmail"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                <tr>
                <td class="auto-style22">
                    Phone</td>
                    <td class="auto-style26">
                        <asp:TextBox ID="TxtPhone" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style11">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Enter Phone" ControlToValidate="TxtPhone"></asp:RequiredFieldValidator>
                    </td>
                </tr>
   <tr>
       <td class="auto-style3"> 
           Adress</td>
       <td class="auto-style25">
           <asp:TextBox ID="TxtAddress" runat="server" Width="128px"></asp:TextBox>
       </td>
       <td class="auto-style13">
           <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Enter Address" ControlToValidate="TxtAddress"></asp:RequiredFieldValidator>
       </td>
               </tr>
               
                <tr>
                    <td class="auto-style22">
                        <asp:Label ID="lblBilgi" runat="server"></asp:Label>
                    </td>
                    <td class="auto-style26"><asp:Button ID="btnID" runat="server" Text="Devam Et" OnClick="btnID_Click" /></td>

                </tr>
               
            </table>
        </asp:Panel>
     

      <asp:Panel ID="Panel2" runat="server">

          <table>

              <tr>
                  <td class="auto-style6">
                      Ürün adı:
                      <asp:Label ID="LabelProductName" runat="server" Text="Label"></asp:Label>
                  </td>
                  <td class="auto-style5">Ürün fiyatı:<asp:Label ID="LabelProductPrice" runat="server" Text="Label"></asp:Label>
                  </td>
              </tr>

          </table>
           </asp:Panel>

        
    </asp:Content> 
<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style3 {
            height: 26px;
            width: 78px;
        }
        .auto-style5 {
            width: 258px;
        }
        .auto-style6 {
            width: 246px;
        }
        .auto-style10 {
            width: 41px;
            height: 23px;
        }
        .auto-style11 {
            width: 41px;
        }
        .auto-style13 {
            width: 41px;
            height: 26px;
        }
        .auto-style21 {
            height: 23px;
            width: 78px;
        }
        .auto-style22 {
            width: 78px;
        }
        .auto-style24 {
            height: 23px;
            width: 43px;
        }
        .auto-style25 {
            height: 26px;
            width: 43px;
        }
        .auto-style26 {
            width: 43px;
        }
    </style>
</asp:Content>
 