using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;

namespace lab5
{
    public partial class Page4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.UrlReferrer == null)
                Response.Redirect("Page1.aspx");

            User u = Container.GetUser();
            if (Page3.success)
            {
                DBManager.Register(u);
                LabelSuccess.Text = "РЕЄСТРАЦІЮ УСПІШНО ЗАВЕРШЕНО!";
                LabelSuccess.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                LabelSuccess.Text = "ПОМИЛКА РЕЄСТРАЦІЇ!";
                LabelSuccess.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void ButtonMain_Click(object sender, EventArgs e)
        {
            Thread.Sleep(2000);
            Response.Redirect("Page1.aspx");
        }
    }
}