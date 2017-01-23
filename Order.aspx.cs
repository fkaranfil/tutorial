using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Order : System.Web.UI.Page
{
    SqlConnection connection = new SqlConnection("Data Source=as.okanUni234.edu.tr;Initial Catalog=15MY03010DB;Persist Security Info=True;User ID=15MY03010;Password=a123b");
    protected void Page_Load(object sender, EventArgs e)
    {
        try { 
        connection.Open();
        SqlCommand command2 = new SqlCommand("SELECT DISTINCT [ProductName] FROM [Product] where ProductNo=@pno", connection);//productname
        SqlCommand command3 = new SqlCommand("SELECT DISTINCT [ProductPrice] FROM [Product] where ProductNo=@pno", connection); //pro price
        command2.Parameters.AddWithValue("@pno", Request.QueryString[0]);
        LabelProductName.Text = command2.ExecuteScalar().ToString();
        command3.Parameters.AddWithValue("@pno", Request.QueryString[0]);
        LabelProductPrice.Text = Convert.ToInt32(command3.ExecuteScalar()).ToString();
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
  
    protected void btnID_Click(object sender, EventArgs e)
    {

       
        connection.Open();

        SqlCommand command = new SqlCommand("INSERT INTO [CustomerOrder] (ProductID,CustomerFName, CustomerLName, CustomerEmail, CustomerPhone, CustomerAddress,OrderDate,OrderDetails) VALUES (@ProductID,@CustomerFName,@CustomerLName,@CustomerEmail,@CustomerPhone,@CustomerAddress,@OrderDate,@OrderDetails)", connection);

        command.Parameters.AddWithValue("ProductID", Request.QueryString[0]);

        command.Parameters.AddWithValue("CustomerFName", TxtFname.Text);

        command.Parameters.AddWithValue("CustomerLName", TxtLastname.Text);

        command.Parameters.AddWithValue("CustomerEmail", TxtEmail.Text);

        command.Parameters.AddWithValue("CustomerPhone", TxtPhone.Text);

        command.Parameters.AddWithValue("CustomerAddress",TxtAddress.Text );

        command.Parameters.AddWithValue("OrderDate", DateTime.Now.ToString());

        command.Parameters.AddWithValue("OrderDetails", DBNull.Value);

        command.ExecuteNonQuery();


        PanelID.Visible = false;
        lblBilgi.Text = "Kayıt Başarılı Şekilde Eklenmiştir."; 
        connection.Close();
        connection.Dispose();
    }
    public void SendEmail(String usermail, String name, String subject, String message)
    {
        try
        {
            MailMessage msg = new MailMessage();
            msg.From = (new MailAddress(usermail));
            msg.To.Add(new MailAddress("karanfilfurkan@gmail.com")); //degıstır aynen orda da bı maıl olucak
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
        /*    LabelEmailWarning.Visible = true;
            LabelEmailWarning.Text = "The message sent successfully !";*/
        }
        catch (Exception exp)
        {
           // LabelEmailWarning.Text = "Message could not be sent !";
            using (StreamWriter _testData = new StreamWriter(Server.MapPath("~/log.txt"), true))
            {
                _testData.WriteLine(DateTime.Now.ToString("[dd/MM/yyyy] [HH:mm:ss]") + exp);
            }
        }
    }
}