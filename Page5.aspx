<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Page5.aspx.cs" Inherits="lab5.Page5" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
    <style type="text/css">

        .col{
            background-color:gray;
        }
    </style>
     <script>
     function hideButton()
        {
            document.getElementById('ButtonExit').style.visibility = 'hidden';
            
           

        }
    </script>
<body class="col">
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="LabelHello" runat="server"></asp:Label>
    
    </div>
        <asp:Image ID="Image1" runat="server" Height="159px" Width="136px" />
        <br />
        <asp:Label ID="LabelName" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Label ID="LabelLogin" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Label ID="LabelEmail" runat="server" Text="Label"></asp:Label>
        <br />
        <p>
            <asp:Button ID="ButtonExit" OnClientClick="hideButton();" runat="server" OnClick="ButtonExit_Click" Text="ВИХІД" />
        </p>
    </form>
</body>
</html>
