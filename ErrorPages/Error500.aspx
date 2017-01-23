<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Error500.aspx.cs" Inherits="Error500" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 580px;
            height: 393px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
        500 Server Error<br />
        <img class="auto-style1" src="img/505.jpg" /><br />
        <br />
        <br />
        <asp:Button ID="ButtonGoMain" runat="server" OnClick="ButtonGoMain_Click" Text="Go Mainpage" />
        <br />
    
    </div>
    </form>
</body>
</html>
