<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkoutA.aspx.cs" Inherits="StartingStatsWeb.WorkoutA" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 41px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" class="auto-style1">
    <div>
    
        <asp:Label ID="welcome" runat="server" Text="Label"></asp:Label>
    
    </div>
        <asp:Label ID="WorkoutIDText" runat="server"></asp:Label><br /><br />
        <asp:DropDownList ID="LiftSelector" runat="server">
            <asp:ListItem>Squat</asp:ListItem>
            <asp:ListItem Value="Press"></asp:ListItem>
            <asp:ListItem Value="Deadlift"></asp:ListItem>
        </asp:DropDownList><br />
        <p id="warmupCheck" aria-haspopup="False" title="asdsad"><asp:Label ID="Label1" runat="server" Text="Set"></asp:Label>
            <asp:TextBox ID="setBox" runat="server"></asp:TextBox>
            <asp:CheckBox ID="Warmup" runat="server" />
                 </p>
        <p>
            <asp:Label ID="Label2" runat="server" Text="Reps"></asp:Label>
            <asp:TextBox ID="repBox" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="Label3" runat="server" Text="Weight"></asp:Label>
            <asp:TextBox ID="weightBox" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="saveButton" runat="server" Text="Save" />
            <asp:Button ID="lastButton" runat="server" Text="Show Last" />
        </p>
    </form>
</body>
</html>
