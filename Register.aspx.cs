using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;
using System.Net.Mail;
using System.IO;

public partial class Register : System.Web.UI.Page
{
     Boolean errorornot = false;
    protected void Page_Load(object sender, EventArgs e)
    {

  
    }

   /* public static string MD5eDonustur(string metin)
    {
        MD5CryptoServiceProvider pwd = new MD5CryptoServiceProvider();
        return Sifrele(metin, pwd);
    }
    private static string Sifrele(string metin, HashAlgorithm alg)
    {
        MD5 md5 = new MD5CryptoServiceProvider();
        byte[] bsifre = md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(metin));
        //texti(girilen parolayı) Encoding.UTF8 in GetBytes() methodu ile bir byte dizisine çevirdik.
        StringBuilder sb = new StringBuilder();
        // string builder sınıfından bir nesne türetip , byte dizimizdeki değerleri 
        // Append methodu yardımıyla bir string ifadeye çevirdik.
        foreach (var by in bsifre)
        {
            //x2 burda string'e çevirirken vermesini istediğimiz format.
            //çıktısında göreceğimiz gibi sayılar ve harflerden oluşucaktır.
            sb.Append(by.ToString("x2").ToLower());
        }
        //oluşturduğumuz string ifadeyi geri döndürdük.
        return sb.ToString();
    } */

    protected void SaveBtn_Click(object sender, EventArgs e)
    {
        SqlConnection baglanti = new SqlConnection("Data Source=as.okanUni234.edu.tr;Initial Catalog=15MY03010DB;Persist Security Info=True;User ID=15MY03010;Password=a123b");
        baglanti.Open();
        String keepUserName = "";
        do
        {
            SqlCommand testUserName = new SqlCommand("Select CUserName from Company where CUserName=@CUserName", baglanti);
            testUserName.Parameters.AddWithValue("@CUserName", TextBoxUsername.Text.ToString());
            if (testUserName.ExecuteScalar() != null)
            {
                TextBoxUsername.Text = "";
                UserNameWarning.Visible = true;
                keepUserName = testUserName.ExecuteScalar().ToString();
                errorornot = true;
            }
            else
            {
                UserNameWarning.Visible = false;

            }

        } while (TextBoxUsername.Text.Equals(keepUserName));

        String keepUserEmail = "";
        do
        {
            SqlCommand testEmail = new SqlCommand("Select CompanyEmail from Company where CompanyEmail=@CompanyEmail", baglanti);
            testEmail.Parameters.AddWithValue("@CompanyEmail", TextBoxemail.Text);
            if (testEmail.ExecuteScalar() != null)
            {
                TextBoxemail.Text = "";
                EmailWarning.Visible = true;
                keepUserEmail = testEmail.ExecuteScalar().ToString();
                errorornot = true;
            }

            else
            {
                EmailWarning.Visible = false;
            }

        } while (TextBoxemail.Text.Equals(keepUserEmail));


       

        if (errorornot == false)

        { 

        string sqlquery = "INSERT INTO [Company] (CompanyName, CUserName, CUserPassword, CompanyEmail, CompanyPhone,CompanyAddress,CompanyRegisterTime,ContactFName,ContactLName,LoginType) VALUES (@CompanyName, @CUserName, @CUserPassword, @CompanyEmail, @CompanyPhone,@CompanyAddress,@CompanyRegisterTime,@ContactFName,@ContactLName,@LoginType)";
        SqlCommand command = new SqlCommand(sqlquery, baglanti);

        //Company Name
        command.Parameters.AddWithValue("CompanyName", TextBoxCName.Text);
        //userName************
        command.Parameters.AddWithValue("CUserName", TextBoxUsername.Text);
        //Password*************
        command.Parameters.AddWithValue("CUserPassword", TextBoxpassword.Text);
        //Email*************
        command.Parameters.AddWithValue("CompanyEmail", TextBoxemail.Text);
        //Phone*************
        command.Parameters.AddWithValue("CompanyPhone", TextBoxPhone.Text);
        //Address*************
        command.Parameters.AddWithValue("CompanyAddress", AddressID.Text);
        //Register Time*************
        command.Parameters.AddWithValue("CompanyRegisterTime", DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"));
        // Contact Fname*************
        command.Parameters.AddWithValue("ContactFName", CFistTxtField.Text);
        // Contact Lname*************
        command.Parameters.AddWithValue("ContactLName", CLastTxtField.Text);
        // Contact LoginType*************
        command.Parameters.AddWithValue("LoginType", 0);

        command.ExecuteNonQuery();


        PanelID.Visible = false;
        lblBilgi.Text = "Your registeration is successfully saved.E-mail sent!";
        SendEmail(TextBoxemail.Text, TextBoxCName.Text);
        UserNameWarning.Visible = false;
        EmailWarning.Visible = false;
        //Response.Redirect("Index.aspx");
        Response.AddHeader("REFRESH", "5;URL=Index.aspx");
        baglanti.Close();
        baglanti.Dispose();
        }

        else
        {
           
            //????

        }
       
    }

    public void SendEmail(String usermail, String name)
    {
        try
        {
            MailMessage msg = new MailMessage();
            msg.From = (new MailAddress("karanfilfurkan@gmail.com"));
            msg.To.Add(new MailAddress(usermail));
            msg.Subject = "PRODUCT PROVIDER";
            msg.Body = "WELCOME  " + name;

            SmtpClient mySmtpClient = new SmtpClient();
            System.Net.NetworkCredential myCredential = new System.Net.NetworkCredential("MBLP223proje", "okanUni234");
            mySmtpClient.Host = "smtp.gmail.com";
            mySmtpClient.Port = 587;
            mySmtpClient.EnableSsl = true;
            mySmtpClient.UseDefaultCredentials = false;
            mySmtpClient.Credentials = myCredential;
            mySmtpClient.Send(msg);
            msg.Dispose();
        
        }
        catch (Exception exp)
        {
           
            using (StreamWriter _testData = new StreamWriter(Server.MapPath("~/log.txt"), true))
            {
                _testData.WriteLine(DateTime.Now.ToString("[dd/MM/yyyy] [HH:mm:ss]") + exp);
            }
        }
    }

    protected void CleanBtn_Click(object sender, EventArgs e)
    {
        //????? 
    }
}