<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="StartingStatsWeb.Login" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        Username:<p>
            <asp:TextBox ID="usernameText" runat="server"></asp:TextBox>
        </p>
        Password:<p>
            <asp:TextBox ID="passwordText" TextMode="Password" runat="server"></asp:TextBox>
        </p>
        <asp:Button ID="logButton" runat="server" Text="Login" />
        <asp:Button ID="regButton" runat="server" Text="Register" />
    </form>
        
</body>
</html>
