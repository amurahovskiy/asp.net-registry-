using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.Data.SqlClient;


namespace lab5
{
    public partial class Page5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.UrlReferrer == null)
                Response.Redirect("Page1.aspx");

            User u = Container.GetUser();
             Image1.ImageUrl = @"http://localhost:15627/photo/" + u.Photo;

            LabelHello.Text = "Ваша сторінка";
            LabelName.Text ="Ім'я: "+ u.Name+" "+u.Surname;
            LabelLogin.Text ="Логін: "+ u.Login;
            LabelEmail.Text = "Е-мейл: "+u.Password;
        }

        protected void ButtonExit_Click(object sender, EventArgs e)
        {
            Thread.Sleep(2000);
            Response.Redirect("Page1.aspx");
        }
        
    }
}