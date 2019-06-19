<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Page3.aspx.cs" Inherits="lab5.Page3" %>

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

        .col{
            background-color:darkgrey;
        }
    </style>
    <script>
     function hideButton()
        {
            document.getElementById('ButtonRegister').style.visibility = 'hidden';
            document.getElementById('ButtonBack').style.visibility = 'hidden';
           

        }
        </script>
</head>
<body class="col">
    <p class="MsoNormal" style="margin-bottom:0in;margin-bottom:.0001pt;line-height:
normal">
        <span lang="UK" style="font-size:10.0pt;font-family:&quot;Courier New&quot;">ВЕРИФІКАЦІЯ АДРЕСИ ЕЛЕКТРОННОЇ ПОШТИ<o:p></o:p></span></p>
    <form id="form1" runat="server">
    <div>
    
        <p class="MsoNormal">
            <span lang="UK" style="font-size:10.0pt;font-family:&quot;Courier New&quot;">На Вашу адресу направлений одноразовий пароль.<o:p></o:p></span></p>
        <p class="MsoNormal">
            <span lang="UK" style="font-size:10.0pt;font-family:&quot;Courier New&quot;">Введіть його в поле і натисніть &quot;ДАЛІ&quot;:<o:p></o:p></span></p>
    
    </div>
        <asp:TextBox ID="TextBoxCode" runat="server" Width="232px"></asp:TextBox>
        <p>
            <asp:Button ID="ButtonRegister" runat="server" OnClientClick="hideButton();" OnClick="ButtonRegister_Click" Text="ЗАРЕЄСТРУВАТИ" />
        </p>
        <p>
            <asp:Button ID="ButtonBack" runat="server" OnClientClick="hideButton();" OnClick="ButtonBack_Click" Text="НАЗАД " />
        </p>
    </form>
</body>
</html>
