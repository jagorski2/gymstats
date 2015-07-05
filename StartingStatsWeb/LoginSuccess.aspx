<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginSuccess.aspx.cs" Inherits="StartingStatsWeb.LoginSuccess" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="welcome" runat="server"></asp:Label>
    
    </div>
        <asp:Button ID="workoutAButton" runat="server" Text="Start Workout A" />
        <asp:Button ID="workoutBButton" runat="server" Text="Start Workout B" />
        <asp:Button ID="continueButton" runat="server" Text="Continue Workout" />
    </form>
</body>
</html>
