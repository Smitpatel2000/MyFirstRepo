using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication9
{
    public partial class DefaultPage : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (Gender.SelectedIndex == -1)
            { Response.Write("<script>alert('Please select your Gender');</script>"); return; }
            if (Hobbies.SelectedIndex == -1)
            { Response.Write("<script>alert('Please Select your Hobbies');</script>"); return; }

            if (Name.Visible)
            {
                string FileName = "";
                string hobbies = string.Join(",", Hobbies.Items.Cast<ListItem>().Where(x => x.Selected).Select(x => x.Text).ToArray());
                if (FileUpload1.HasFile)
                {
                    FileName = FileUpload1.FileName;
                    FileUpload1.SaveAs(Server.MapPath("~/Images/") + FileUpload1.FileName);
                }
                else if (Image1.ImageUrl != "")
                    FileName = Image1.ImageUrl.Substring(Image1.ImageUrl.LastIndexOf('/'));
                else
                {
                    Response.Write("<script>alert('Please Upload a Image file');</script>");
                    return;
                }
                Student s = new Student(Name.Text, Convert.ToInt32(Age.Text), Email.Text, Password.Text, Convert.ToInt32(Gender.SelectedValue), hobbies, FileName);
                s.Insert(new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString));
                Response.Write("<script>alert('The User is registered succesfully in the database');</script>");               
            }
            else
                Response.Write("<script>alert('Please click on exit display mode to save record');</script>");
        }

        protected void AddStudentBtn_Click(object sender, EventArgs e)
        {
            Name.Text = "";
            Name.Visible = false;
            Names.Visible = true;
            List<string> names = Student.GetStudentNames(new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString));
            names.Insert(0, "---Select---");
            Names.DataSource = names;
            Names.DataBind();
        }


        /// <summary>
        /// DropDown List of Names
        /// </summary>       
        protected void Names_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Names.SelectedIndex != 0)
            {
                Student s = Student.GetStudent(Names.SelectedValue, new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString));
                Age.Text = s.Age.ToString();
                Email.Text = s.Email;
                Password.TextMode = TextBoxMode.SingleLine;
                Password.Text = s.Password;
                Gender.SelectedIndex = s.Gender;
                foreach (ListItem item in Hobbies.Items)
                    if (s.Hobbies.Contains(item.Text))
                        item.Selected = true;
                Image1.ImageUrl = "~/Images/" + s.PhotoUrl;
            }
            else
                Response.Write("<script>alert('Please select a name');</script>");
        }

        protected void ExitModeBtn_Click(object sender, EventArgs e)
        {
            Name.Visible = true;
            Names.Visible = false;
            Image1.ImageUrl = "";
            Password.TextMode = TextBoxMode.Password;
        }

        protected void ValidateBtn_Click(object sender, EventArgs e)
        {            
            if (!IsValid)
            {
                Response.Write("<script>alert('Please fill all the enteries');</script>");
                return;
            }
            if (Gender.SelectedIndex == -1)
                Response.Write("<script>alert('Please select your Gender');</script>");
            if (Hobbies.SelectedIndex == -1)
                Response.Write("<script>alert('Please Select your Hobbies');</script>");

        }

        protected void ImgDisplayBtn_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFiles)
            {
                string path = Server.MapPath("~/Images/");
                FileUpload1.SaveAs(path + FileUpload1.FileName);
                Image1.ImageUrl = "~/Images/" + FileUpload1.FileName;
            }
            else
                Response.Write("<script>alert('Please Upload a Image file');</script>");
        }

        protected void RedirectBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("DropdownCascade.aspx");
        }              
    }
}