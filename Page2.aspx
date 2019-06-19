<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Page2.aspx.cs" Inherits="lab5.Page2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function hideButton()
        {
            document.getElementById('ButtonNext').style.visibility = 'hidden';
            document.getElementById('ButtonBack').style.visibility = 'hidden';
           

        }
    </script>
    <style type="text/css">

        .col{
            background-color:powderblue;
        }
    </style>
  </head> 
<body class="col">
    <form id="form1" runat="server">
    <div>
    
    </div>
        <p>
            <span lang="UK" style="font-size:10.0pt;line-height:
115%;font-family:&quot;Courier New&quot;;mso-fareast-font-family:Calibri;mso-ansi-language:UK;mso-fareast-language:EN-US;mso-bidi-language:AR-SA">ФОТОГРАФІЯ (JPEG/PNG, min 100x150, max 200x300):</span></p>
        <asp:FileUpload ID="FileUpload1" runat="server" OnLoad="FileUpload1_Load" />
        <asp:Label ID="LabelImg" runat="server"></asp:Label>
        <p>
            <asp:Label ID="LabelName" runat="server" Text="Ім'я:"></asp:Label>
            <asp:TextBox ID="TextBoxName" runat="server" OnTextChanged="TextBox1_TextChanged" Width="143px"></asp:TextBox>
        </p>
        <asp:Label ID="LabelSurname" runat="server" Text="Прізвище:"></asp:Label>
        <asp:TextBox ID="TextBoxSurname" runat="server"></asp:TextBox>
        <p>
            <asp:Label ID="LabelEmail" runat="server" Text="E-mail:"></asp:Label>
            <asp:TextBox ID="TextBoxEmail" runat="server"></asp:TextBox>
        </p>
        <asp:Label ID="LabelLogin" runat="server" Text="Логін:"></asp:Label>
        <asp:TextBox ID="TextBoxLogin" runat="server"></asp:TextBox>
        <p>
            <asp:Label ID="LabelPassword" runat="server" Text="Пароль:"></asp:Label>
            <asp:TextBox ID="TextBoxPassword" runat="server" type="password"></asp:TextBox>
        </p>
        <p>
            <asp:RadioButtonList ID="RadioButtonList" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" AutoPostBack = "true"  runat="server" >
                <asp:ListItem value="1">Студент</asp:ListItem>
                <asp:ListItem value="2" Selected="True">Викладач</asp:ListItem>
                <asp:ListItem value="3">Навчально-допоміжний персонал</asp:ListItem>
            </asp:RadioButtonList>
        </p>
        <p>
            <asp:CheckBoxList ID="CheckBoxList" runat="server"  >
                <asp:ListItem value="1">Майстер спорту</asp:ListItem>
                <asp:ListItem value="2">Кандидат наук</asp:ListItem>
                <asp:ListItem value="3">Доктор наук</asp:ListItem>
            </asp:CheckBoxList>
        </p>
        <p>
            <asp:Label ID="Label7" runat="server" Text="Курс:"></asp:Label>
            <asp:DropDownList ID="DropDownListCourse" runat="server" OnSelectedIndexChanged="DropDownListCourse_SelectedIndexChanged" AutoPostBack="true">
                <asp:ListItem></asp:ListItem>
            </asp:DropDownList>
            <asp:Label ID="Label8" runat="server" Text="Факультет:	"></asp:Label>
            <asp:DropDownList ID="DropDownListFaculty" runat="server">
            </asp:DropDownList>
            <asp:Label ID="Label9" runat="server" Text="Структурний підрозділ:"></asp:Label>
            <asp:DropDownList ID="DropDownListStruct" runat="server">
            </asp:DropDownList>
        </p>
        <asp:Button ID="ButtonNext" runat="server" OnClientClick="hideButton();" OnClick="ButtonNext_Click" Text="ДАЛІ" />
        <asp:Button ID="ButtonBack" runat="server" OnClientClick="hideButton();"  OnClick="ButtonBack_Click" Text="НАЗАД" />
        <asp:Label ID="LabelError" runat="server"></asp:Label>
    </form>
</body>
</html>
