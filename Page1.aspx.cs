using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Timers;
using System.Threading;
using System.Data.SqlClient;

namespace lab5
{
    public class User
    {
        public bool IsEmpty { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
        public string Role { get; set; }
        public string Skill { get; set; }
        public string Course { get; set; }
        public string Faculty { get; set; }
        public string Department { get; set; }

        public User()
        {
            this.IsEmpty = true;
        }

        public User(string name, string surname, string login, string password, string email, string photo,
            string role, string skill, string course, string faculty, string department, bool empty)
        {
            this.Name = name;
            this.Surname = surname;
            this.Login = login;
            this.Password = password;
            this.Email = email;
            this.Photo = photo;
            this.Role = role;
            this.Skill = skill;
            this.Course = course;
            this.Faculty = faculty;
            this.Department = department;
            this.IsEmpty = false;
        }
    }
    class Container
    {
        private static User user;
        private static int pass;
        static public void SetUser(User u)
        {
            user = u;
        }
        static public User GetUser()
        {
            return user;
        }
    }
    class DBManager
    {
        static string Connection = @"Data Source = (localdb)\MSSQLLocalDB;Initial Catalog = laba; Integrated Security = True";

        static SqlCommand Command = new SqlCommand("");
        static SqlDataReader reader;
        public static User Login(string login, string password)
        {
            using (SqlConnection con = new SqlConnection(Connection))
            {
                con.Open();
                User u = new User();
                Command.Connection = con;
                Command.CommandText = "SELECT * FROM Registered WHERE Login='" + login + "' and Password='" + password + "';";
                reader = Command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string photo;
                        string skill;
                        string course;
                        if (reader.GetString(5) == null)
                            photo = "none";
                        else
                            photo = reader.GetString(5);
                        if (reader.GetString(7) == null)
                            skill = "none";
                        else
                            skill = reader.GetString(7);
                        if (reader.GetString(8) == "0")
                            course = "0";
                        else course = reader.GetString(8);

                        u = new User(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), photo, reader.GetString(6), skill, course, reader.GetString(9), reader.GetString(10), false);

                    }
                    reader.Close();
                    con.Close();
                    return u;
                }
                else
                {
                    con.Close();
                    return u;
                }

            }
        }
        public static void Register(User u)
        {
            using (SqlConnection con = new SqlConnection(Connection))
            {
                con.Open();
                Command.Connection = con;
                Command.CommandText = "insert into Registered (Login, Name, Surname, [E-mail], Password, Photo, Role, Skill, Course, Faculty, Department) values ('" + u.Login + "','" + u.Name + "','" + u.Surname + "','" + u.Email + "','" + u.Password + "','" + u.Photo + "','" + u.Role + "','" +
                    u.Skill + "','" + u.Course + "','" + u.Faculty + "','" + u.Department + "')";
                Command.ExecuteNonQuery();
                con.Close();
            }

        }
        public static bool LoginCheck(string login)
        {
            using (SqlConnection con = new SqlConnection(Connection))
            {
                con.Open();

                Command.Connection = con;
                Command.CommandText = "SELECT * FROM Registered WHERE Login='" + login + "';";
                reader = Command.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Close();
                    con.Close();
                    return false;
                }
                else
                {
                    reader.Close();
                    con.Close();
                    return true;
                }
            }
        }

    }
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Enter_Click(object sender, EventArgs e)
        {
            
            Container.SetUser(DBManager.Login(TextBoxLogin.Text, TextBoxPassword.Text));
            if (Container.GetUser().IsEmpty)
            {
                LabelResult.Text = "Такого користувача не існує або пароль невірний!";
                Thread.Sleep(5000);
            }
            else
            {
                LabelResult.Text = "Перехід на персональну сторінку...";
                Thread.Sleep(2000);
                Response.Redirect("page5.aspx");
            }          
        }

        protected void Registration_Click(object sender, EventArgs e)
        {
            Thread.Sleep(2000);
            Response.Redirect("Page2.aspx");
        }
    }
}