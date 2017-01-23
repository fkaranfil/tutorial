using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Contact : System.Web.UI.Page
{
    string connectionString = ConfigurationManager.ConnectionStrings["15MY03010DBConnectionString"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection connection = new SqlConnection("Data Source=as.okanUni234.edu.tr;Initial Catalog=15MY03010DB;Persist Security Info=True;User ID=15MY03010;Password=a123b");

        if (!string.IsNullOrEmpty(Session["CUserName"] as string))
        {
        try
        {
            connection.Open();
            SqlCommand command1 = new SqlCommand("SELECT DISTINCT [CompanyName] FROM [Company] where CUserName=@uname", connection);//productname
            SqlCommand command2 = new SqlCommand("SELECT DISTINCT [CompanyEmail] FROM [Company] where  CUserName=@uname", connection); //pro price
            command1.Parameters.AddWithValue("@uname", Session["CUserName"].ToString());
            TextBoxName.Text = command1.ExecuteScalar().ToString();
            command2.Parameters.AddWithValue("@uname", Session["CUserName"].ToString());
            TextBoxEmail.Text = command2.ExecuteScalar().ToString();
            TextBoxName.ReadOnly = true;
            TextBoxEmail.ReadOnly = true;
        }
        catch (Exception exp)
        {
            // LabelEmailWarning.Text = "Message could not be sent !";
            using (StreamWriter _testData = new StreamWriter(Server.MapPath("~/log.txt"), true))
            {
                _testData.WriteLine(DateTime.Now.ToString("[dd/MM/yyyy] [HH:mm:ss]") + exp);
            }
        }
        connection.Close();
        }
        else if (Request.Cookies["CUserName"] != null)
        {

            try
            {
                connection.Open();
                SqlCommand command1 = new SqlCommand("SELECT DISTINCT [CompanyName] FROM [Company] where CUserName=@uname", connection);//productname
                SqlCommand command2 = new SqlCommand("SELECT DISTINCT [CompanyEmail] FROM [Company] where  CUserName=@uname", connection); //pro price
                command1.Parameters.AddWithValue("@uname", Request.Cookies["CUserName"].Value.ToString());
                TextBoxName.Text = command1.ExecuteScalar().ToString();
                command2.Parameters.AddWithValue("@uname", Request.Cookies["CUserName"].Value.ToString());
                TextBoxEmail.Text = command2.ExecuteScalar().ToString();
                TextBoxName.ReadOnly = true;
                TextBoxEmail.ReadOnly = true;
            }
            catch (Exception exp)
            {
                // LabelEmailWarning.Text = "Message could not be sent !";
                using (StreamWriter _testData = new StreamWriter(Server.MapPath("~/log.txt"), true))
                {
                    _testData.WriteLine(DateTime.Now.ToString("[dd/MM/yyyy] [HH:mm:ss]") + exp);
                }
            }
            connection.Close();

        }

    }

    public void SendEmail(String usermail, String name, String subject, String message)
    {
        try
        {
            MailMessage msg = new MailMessage();
            msg.From = (new MailAddress(usermail));
            msg.To.Add(new MailAddress("karanfilfurkan@gmail.com"));
            msg.Subject = subject;
            msg.Body = "User/Company Name:" + name + "\nUser/Company Email:  " + usermail + "" + "\n\n Message: \n" + message;

            SmtpClient mySmtpClient = new SmtpClient();
            System.Net.NetworkCredential myCredential = new System.Net.NetworkCredential("MBLP223proje", "okanUni234");
            mySmtpClient.Host = "smtp.gmail.com";
            mySmtpClient.Port = 587;
            mySmtpClient.EnableSsl = true;
            mySmtpClient.UseDefaultCredentials = false;
            mySmtpClient.Credentials = myCredential;
            mySmtpClient.Send(msg);
            msg.Dispose();
            LabelEmailWarning.Visible = true;
            LabelEmailWarning.Text = "The message sent successfully !";
        }
        catch (Exception exp)
        {
            LabelEmailWarning.Text = "Message could not be sent !";
            using (StreamWriter _testData = new StreamWriter(Server.MapPath("~/log.txt"), true))
            {
                _testData.WriteLine(DateTime.Now.ToString("[dd/MM/yyyy] [HH:mm:ss]") + exp);
            }
        }
    }

    protected void SendButton_Click(object sender, EventArgs e)
    {
        PanelContact.Visible = false;
        SendEmail(TextBoxEmail.Text, TextBoxName.Text, TextBoxSubject.Text,TextAreaMessage.Text);
        
        
    }
}