<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Error404.aspx.cs" Inherits="Error" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 592px;
            height: 344px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Page is not found !<br />
        <br />
        <img class="auto-style1" src="img/404.png" /><br />
        <br />
        <asp:Button ID="ButtonGoMain" runat="server" OnClick="ButtonGoMain_Click" Text="Go Mainpage" />
        <br />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
