<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Page1.aspx.cs" Inherits="lab5.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

 p.MsoNormal
	{margin-top:0in;
	margin-right:0in;
	margin-bottom:10.0pt;
	margin-left:0in;
	line-height:115%;
	font-size:11.0pt;
	font-family:"Calibri","sans-serif";
	}
        #Text1 {
            width: 155px;
        }
        #Text2 {
            width: 153px;
        }
        #Password1 {
            width: 150px;
        }
        .col{
            background-color:pink;
        }
    </style>
    <script type="text/javascript">
        function hideButton()
        {
            document.getElementById('Enter').style.visibility = 'hidden';
            document.getElementById('Registration').style.visibility = 'hidden';
           

        }
    </script>
</head>
<body class="col">
    <form id="form1" runat="server">
    <div>
        <p class="MsoNormal" style="margin-bottom:0in;margin-bottom:.0001pt;line-height:
normal">
            <span lang="UK" style="font-size: 10.0pt; font-family: &quot;Courier New&quot;; text-align: center;">САЙТ З АВТОРИЗОВАНИМ ДОСТУПОМ</span></p>
    </div>
    <div>
        ЛОГІН:
    </div>
        <p>
            <asp:TextBox ID="TextBoxLogin" runat="server"></asp:TextBox>
        </p>
        <div>
            ПАРОЛЬ:</div>
        <p>
            <asp:TextBox ID="TextBoxPassword" runat="server" type="password"></asp:TextBox>
        </p>
        <asp:Button ID="Enter" runat="server" OnClientClick="hideButton();"  OnClick="Enter_Click" Text="ВХІД" />
        <asp:Label ID="LabelResult" runat="server"></asp:Label>
        <p>
            <asp:Button ID="Registration" runat="server" OnClientClick="hideButton();" OnClick="Registration_Click" Text="РЕЄСТРАЦІЯ" />
        </p>
    </form>
    </body>
</html>
