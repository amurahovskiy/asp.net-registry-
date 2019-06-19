using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;

namespace lab5
{
    public partial class Page3 : System.Web.UI.Page
    {
        public static bool success = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.UrlReferrer == null)
                Response.Redirect("Page1.aspx");   
        }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            Thread.Sleep(2000);
            Response.Redirect("Page2.aspx");
        }

        protected void ButtonRegister_Click(object sender, EventArgs e)
        {
            if (TextBoxCode.Text == Page2.code)
                success = true;
            else
                success = false;
            Thread.Sleep(2000);
            Response.Redirect("Page4.aspx");
        }
    }
}