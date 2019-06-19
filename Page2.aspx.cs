using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.IO;
using System.Drawing;

namespace lab5
{
    public partial class Page2 : System.Web.UI.Page
    {
        private User u = new User();
        
        public static string code = GenerateString();
        private static Random random = new Random();
        public static string GenerateString()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, 8)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            return result;
        }
        public void Check_Click(object sender,EventArgs e)
        {
            if (RadioButtonList.SelectedValue.ToString() == "Cтудент")
            {
                DropDownListCourse.EnableViewState = false;
                DropDownListFaculty.Enabled = true;
                DropDownListStruct.Enabled = false;
                CheckBoxList.Items[1].Enabled = false;
                CheckBoxList.Items[2].Enabled = false;
            }
            else if (RadioButtonList.SelectedValue.ToString() == "Викладач")
            {
                DropDownListCourse.Enabled = false;
                DropDownListFaculty.Enabled = true;
                DropDownListStruct.Enabled = false;
                CheckBoxList.Items[1].Enabled = true;
                CheckBoxList.Items[2].Enabled = true;
            }
            else if (RadioButtonList.SelectedValue.ToString() == "Навчально - допоміжний персонал")
            {

                DropDownListCourse.Enabled = false;
                DropDownListFaculty.Enabled = false;
                DropDownListStruct.Enabled = true;
                CheckBoxList.Items[1].Enabled = true;
                CheckBoxList.Items[2].Enabled = false;
            }
        }
        private string Roles(bool s, bool c, bool d)
        {
            string role = "";

            if (s)
                role += "Майстер спорту ";
            if (c)
                role += "Кандидат наук ";
            if (d)
                role += "Доктор наук";
            return role;
        }
       
        protected void Page_Load(object sender, EventArgs e)
        {
            CheckBoxList.Items.FindByValue("1").Enabled = true;
            CheckBoxList.Items.FindByValue("2").Enabled = true;
            CheckBoxList.Items.FindByValue("3").Enabled = true;

            CheckBoxList.Items.FindByValue("1").Selected = false;
            CheckBoxList.Items.FindByValue("2").Selected = false;
            CheckBoxList.Items.FindByValue("3").Selected = false;

            //ClientScript.RegisterStartupScript(this.GetType(), "change", "", true);

            DropDownListCourse.Enabled = false;
            DropDownListFaculty.Enabled = true;
            DropDownListStruct.Enabled = false;
            if (Request.UrlReferrer==null)
                Response.Redirect("Page1.aspx");

            string[] faculties = { "Механіко-математичний", "Радіофізичний", "Геологічний", "Історичний", "Філософський" };
            string[] structures = { "Наукова бібліотека", "Ботанічний сад", "Інформаційно-обчислювальний центр", "Ректорат"};
            if (DropDownListCourse.Items.Count < 5)
            {
                for (int i = 0; i < 6; i++)
                    DropDownListCourse.Items.Add(i + 1 + " курс");
                for (int i = 0; i < faculties.Length; i++)
                    DropDownListFaculty.Items.Add(faculties[i]);
                for (int i = 0; i < structures.Length; i++)
                    DropDownListStruct.Items.Add(structures[i]);
            }

        }
        public bool CheckPhoto()
        {
            string path = @"C:\Users\Владислав\Downloads\4-ий семестр\Системне програмування\Лабораторні\labs petrovich\Site\lab5\photo\";

            if (FileUpload1.FileName == "")
                return true;
            if (File.Exists(path + Container.GetUser().Photo))
                File.Delete(path + Container.GetUser().Photo);

            FileUpload1.SaveAs(path + FileUpload1.FileName);

            using (Bitmap photo = new Bitmap(path + FileUpload1.FileName))
                if (photo.Height >= 150 && photo.Height <= 300 && photo.Width >= 100 && photo.Width <= 200)
                {
                    u.Photo = FileUpload1.FileName;
                    Container.GetUser().Photo = u.Photo;
                    return true;
                }
            File.Delete(path + FileUpload1.FileName);

            return false;
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        protected void ButtonNext_Click(object sender, EventArgs e)
        {
            if (TextBoxLogin.Text != "" && TextBoxName.Text != "" && TextBoxSurname.Text != "" && FileUpload1.FileName != "" && TextBoxPassword.Text != "" && TextBoxEmail.Text != "")

            {
                LabelError.Text = "";
                string from = "amurahovskiy@gmail.com",
                      mailto = "",
                      caption = "",
                      email = "amurahovskiy@gmail.com",
                      password = "Vl@d11126";

                NetworkCredential loginInfo = new NetworkCredential(email, password);
                MailMessage msg = new MailMessage();
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

                mailto = TextBoxEmail.Text;
                caption = "Code";

                msg.From = new MailAddress(from);
                msg.To.Add(new MailAddress(mailto));
                msg.Subject = caption;
                msg.Body = "Your secret code is: " + code;

                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = loginInfo;
                smtpClient.Send(msg);

                u.Login = TextBoxLogin.Text;
                u.Name = TextBoxName.Text;
                u.Surname = TextBoxSurname.Text;
                u.Photo = FileUpload1.FileName;
                u.Password = TextBoxPassword.Text;
                u.Email = TextBoxEmail.Text;
                if (RadioButtonList.SelectedIndex == 0)
                {
                    u.Role = "Студент";
                    u.Course = DropDownListCourse.SelectedItem.ToString();
                }
                else if (RadioButtonList.SelectedIndex == 1)
                    u.Role = "Викладач";
                else if (RadioButtonList.SelectedIndex == 2)
                    u.Role = "Навчально-допоміжний персонал";

                u.Faculty = DropDownListFaculty.SelectedItem.ToString();
                u.Department = DropDownListStruct.SelectedItem.ToString();
                u.Role = Roles(CheckBoxList.Items[0].Selected, CheckBoxList.Items[1].Selected, CheckBoxList.Items[2].Selected);
                if (FileUpload1.FileName != null) FileUpload1.SaveAs(@"C:\Users\Владислав\Downloads\4-ий семестр\Системне програмування\Лабораторні\labs petrovich\Site\lab5\photo\" + FileUpload1.FileName);
                Container.SetUser(u);

                if (CheckPhoto())
                {
                    Thread.Sleep(2000);
                    Response.Redirect("Page3.aspx");
                }
                else
                {
                    LabelError.Text = "Невірний формат фотографії";
                    System.Threading.Thread.Sleep(5000);
                }
            }else
            {
                LabelError.Text = "Не корректні данні";
                System.Threading.Thread.Sleep(5000);
            }

        }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            Thread.Sleep(2000);
            Response.Redirect("Page1.aspx");
        }
        protected void RadioButtonList_SelectedIndexChanged(object sender,EventArgs e)
        {

        }
        protected void DropDownListCourse_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RadioButtonList.SelectedValue.ToString() == "1")
            {
                CheckBoxList.Items.FindByValue("1").Enabled = true;
                CheckBoxList.Items.FindByValue("2").Enabled = false;
                CheckBoxList.Items.FindByValue("3").Enabled = false;

                CheckBoxList.Items.FindByValue("1").Selected = false;
                CheckBoxList.Items.FindByValue("2").Selected = false;
                CheckBoxList.Items.FindByValue("3").Selected = false;
                //ClientScript.RegisterStartupScript(this.GetType(), "change", "", true);

                DropDownListCourse.Enabled = true;
                DropDownListFaculty.Enabled = true;
                DropDownListStruct.Enabled = false;



            }
            else if (RadioButtonList.SelectedValue.ToString() == "2")
            {
                CheckBoxList.Items.FindByValue("1").Enabled = true;
                CheckBoxList.Items.FindByValue("2").Enabled = true;
                CheckBoxList.Items.FindByValue("3").Enabled = true;

                CheckBoxList.Items.FindByValue("1").Selected = false;
                CheckBoxList.Items.FindByValue("2").Selected = false;
                CheckBoxList.Items.FindByValue("3").Selected = false;

                //ClientScript.RegisterStartupScript(this.GetType(), "change", "", true);

                DropDownListCourse.Enabled = false;
                DropDownListFaculty.Enabled = true;
                DropDownListCourse.Enabled = false;

            }
            else
            {
                CheckBoxList.Items.FindByValue("1").Enabled = true;
                CheckBoxList.Items.FindByValue("2").Enabled = true;
                CheckBoxList.Items.FindByValue("3").Enabled = false;

                CheckBoxList.Items.FindByValue("1").Selected = false;
                CheckBoxList.Items.FindByValue("2").Selected = false;
                CheckBoxList.Items.FindByValue("3").Selected = false;

                //ClientScript.RegisterStartupScript(this.GetType(), "change", "", true);

                DropDownListCourse.Enabled = false;
               DropDownListFaculty.Enabled = false;
                DropDownListStruct.Enabled = true;
            }
            //if (RadioButtonList1.Select == 0)
            //{
            //    chk2.Items[0].enabled = false;
            //}
            //else if (chk1.selectedIndex == 1)
            //{
            //    chk2.Items[1].enabled = false;
            //}

        }


        protected void FileUpload1_Load(object sender, EventArgs e)
        {
        }
    }
}