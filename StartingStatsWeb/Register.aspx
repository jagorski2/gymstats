<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="StartingStatsWeb.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="Username:"></asp:Label>
    
    </div>
        <asp:TextBox ID="usernameText" runat="server"></asp:TextBox>
        <p>
            <asp:Label ID="Label2" runat="server" Text="Password:"></asp:Label>
        </p>
        <asp:TextBox ID="passwordText" TextMode="Password" runat="server"></asp:TextBox>
        <p>
            <asp:Label ID="Label3" runat="server" Text="Verify Password:"></asp:Label>
        </p>
        <asp:TextBox ID="vpasswordText" TextMode="Password" runat="server"></asp:TextBox>
        <p>
            <asp:Button ID="registerButton" runat="server" Text="Register" />
        </p>
        <p>
            <asp:Label ID="registerError" runat="server"></asp:Label>
        </p>
    </form>
</body>
</html>
