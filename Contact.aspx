<%@ Page Language="C#"  MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="Contact" %>

     <asp:Content ID="Content" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
         <asp:Panel ID="PanelContact" runat="server" BackColor="#459649" Height="347px" Width="606px">
            
             <asp:Label ID="LabelContactPage" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="White" style="text-align: center" Text="Contact Page"></asp:Label>
             <br />
             <br />
             <br />
         
             <asp:Label ID="LabelName" runat="server" Font-Bold="True" ForeColor="White" Text="Name:"></asp:Label>
             <asp:TextBox ID="TextBoxName" runat="server" style="margin-left: 9px" Width="142px"></asp:TextBox>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxName" ErrorMessage="Please fill empty area." ValidationGroup="4"></asp:RequiredFieldValidator>
             <br />
            <asp:Label ID="LabelAddress" runat="server"  Font-Bold="True" ForeColor="White" style= "margin-left: 380px"  Text="Doğuş University" EnableTheming="True" EnableViewState="True" ></asp:Label>
             <br />
             <asp:Label ID="LabelEmail" runat="server" Font-Bold="True" ForeColor="White" Text="E-mail:"></asp:Label>
             <asp:TextBox ID="TextBoxEmail" runat="server" style="margin-left: 16px" Width="142px" TextMode="Email"></asp:TextBox>
             <br />
             <br />

             <asp:Label ID="LabelSubject" runat="server" Font-Bold="True" ForeColor="White" Text="Subject:"></asp:Label>
             <asp:TextBox ID="TextBoxSubject" runat="server" style="margin-left: 11px" TextMode="SingleLine" Width="143px"></asp:TextBox>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxSubject" ErrorMessage="Please fill empty area." ValidationGroup="4"></asp:RequiredFieldValidator>
             <br />
             <br />
             
             <asp:Label ID="LabelMessage" runat="server" Font-Bold="True" ForeColor="White" Text="Message:"></asp:Label>
             <asp:TextBox id="TextAreaMessage" TextMode="multiline" Columns="50" Rows="5" runat="server" EnableTheming="True" Height="100px" Width="400px" />
             <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextAreaMessage" ErrorMessage="Please fill empty area." ValidationGroup="4"></asp:RequiredFieldValidator>
             <br /> 
             <asp:Button ID="SendButton" runat="server" Font-Bold="True" ForeColor="#459649" Height="25px" OnClick="SendButton_Click" style="margin-left: 90px" Text="Send" Width="182px" ValidationGroup="4" />
             <br />
             &nbsp;<br />&nbsp;<br /><br />&nbsp;</asp:Panel>
         <asp:Label ID="LabelEmailWarning" runat="server" Text="Label" Visible="False"></asp:Label>
         <br />
         <div id="map">


         </div>
         <br />
        <br />
             </asp:Content> 
<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
    <style type="text/css">
        #TextArea1 {
            margin-left: 10px;
        }
        #ContactTextArea {
            text-align: center;
            margin-left: 1px;
            margin-top: 0px;
        }
    </style>
</asp:Content>
 
