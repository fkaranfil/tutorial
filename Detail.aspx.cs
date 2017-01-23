using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Detail : System.Web.UI.Page
{
    string connectionString = ConfigurationManager.ConnectionStrings["15MY03010DBConnectionString"].ConnectionString;
    SqlConnection dbconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["15MY03010DBConnectionString"].ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
        if (dbconnection.State == ConnectionState.Closed)
        {
            dbconnection.Open();
        }

        SqlCommand cmd2 = new SqlCommand("SELECT DISTINCT [ProductName] FROM [Product] where ProductNo=@pno", dbconnection);//productname
        cmd2.Parameters.AddWithValue("@pno", Request.QueryString[0]);
        PNameLbl.Text = cmd2.ExecuteScalar().ToString();
        SqlCommand cmd = new SqlCommand("  SELECT DISTINCT [CategoryName] FROM [Product],[Category] where [Product].CategoryID=[Category].CategoryID AND ProductNo=@pno", dbconnection);// category name
        cmd.Parameters.AddWithValue("@pno", Request.QueryString[0]);
        CategoryLbl.Text = cmd.ExecuteScalar().ToString();
        SqlCommand cmd3 = new SqlCommand("SELECT DISTINCT [ProductState] FROM [Product] where ProductNo=@pno", dbconnection);// product state
        cmd3.Parameters.AddWithValue("@pno", Request.QueryString[0]);
        PStateLbl.Text = cmd3.ExecuteScalar().ToString();
        SqlCommand cmd4 = new SqlCommand("SELECT DISTINCT [ProductDate] FROM [Product] where ProductNo=@pno", dbconnection); //product date
        cmd4.Parameters.AddWithValue("@pno", Request.QueryString[0]);
        DateLbl.Text = cmd4.ExecuteScalar().ToString();
        SqlCommand cmd5 = new SqlCommand("SELECT DISTINCT [ProductDetails] FROM [Product] where ProductNo=@pno", dbconnection); // pro details
        cmd5.Parameters.AddWithValue("@pno", Request.QueryString[0]);
        DescriptionLbl.Text = cmd5.ExecuteScalar().ToString();
        SqlCommand cmd6 = new SqlCommand("SELECT DISTINCT [ProductPrice] FROM [Product] where ProductNo=@pno", dbconnection); //pro price
        cmd6.Parameters.AddWithValue("@pno", Request.QueryString[0]);
        PriceLbl.Text =Convert.ToInt32( cmd6.ExecuteScalar()).ToString();
        SqlCommand cmd7 = new SqlCommand("SELECT DISTINCT [ProductImagePath] FROM [Product] where ProductNo=@pno", dbconnection); //pro ımage
        cmd7.Parameters.AddWithValue("@pno", Request.QueryString[0]);
        ImageProduct.ImageUrl =cmd7.ExecuteScalar().ToString();
        SqlCommand cmd8 = new SqlCommand("SELECT DISTINCT [ProductImagePath2] FROM [Product] where ProductNo=@pno", dbconnection); //pro ımage
        cmd8.Parameters.AddWithValue("@pno", Request.QueryString[0]);
        ImageProduct2.ImageUrl = cmd8.ExecuteScalar().ToString();
        SqlCommand cmd9 = new SqlCommand("SELECT DISTINCT [ProductImagePath3] FROM [Product] where ProductNo=@pno", dbconnection); //pro ımage
        cmd9.Parameters.AddWithValue("@pno", Request.QueryString[0]);
        ImageProduct3.ImageUrl = cmd9.ExecuteScalar().ToString();


        if (!string.IsNullOrEmpty(Session["CUserName"] as string))
        {
            try
            {
                SqlCommand command1 = new SqlCommand("SELECT DISTINCT [CompanyName] FROM [Company] where  CUserName=@uname", dbconnection); //pro price
                command1.Parameters.AddWithValue("@uname", Session["CUserName"].ToString());
                TextBoxName.Text = command1.ExecuteScalar().ToString();
                TextBoxName.ReadOnly = true;
            }
            catch (Exception exp)
            {
                // LabelEmailWarning.Text = "Message could not be sent !";
                using (StreamWriter _testData = new StreamWriter(Server.MapPath("~/log.txt"), true))
                {
                    _testData.WriteLine(DateTime.Now.ToString("[dd/MM/yyyy] [HH:mm:ss]") + exp);
                }
            }
            dbconnection.Close();
        }
        else if (Request.Cookies["CUserName"] != null)
        {

            try
            {
                SqlCommand command1 = new SqlCommand("SELECT DISTINCT [CompanyName] FROM [Company] where  CUserName=@uname", dbconnection); //pro price
                command1.Parameters.AddWithValue("@uname", Request.Cookies["CUserName"].Value.ToString());
                TextBoxName.Text = command1.ExecuteScalar().ToString();
                TextBoxName.ReadOnly = true;
            }
            catch (Exception exp)
            {
                // LabelEmailWarning.Text = "Message could not be sent !";
                using (StreamWriter _testData = new StreamWriter(Server.MapPath("~/log.txt"), true))
                {
                    _testData.WriteLine(DateTime.Now.ToString("[dd/MM/yyyy] [HH:mm:ss]") + exp);
                }
            }
            dbconnection.Close();

        }

    }

         protected void Button1_Click(object sender, EventArgs e)
     {

         Response.Redirect("~/Order.aspx?ProductNo=" + Request.QueryString[0]);

     }

         protected void ButtonSendComment_Click(object sender, EventArgs e)
         {

             if (dbconnection.State == ConnectionState.Closed)
             {
                 dbconnection.Open();
             }
             SqlCommand cmd = new SqlCommand("INSERT INTO [Comment] (CommentText,CommenterName,CommentDate,ProductID) VALUES (@CommentText,@CommenterName,@CommentDate,@ProductID)", dbconnection);
             cmd.Parameters.AddWithValue("@CommentText", TextBoxComment.Text);
             cmd.Parameters.AddWithValue("@CommenterName", TextBoxName.Text);
             cmd.Parameters.AddWithValue("@CommentDate", DateTime.Now.ToString());
             cmd.Parameters.AddWithValue("@ProductID", Request.QueryString[0]);

             cmd.ExecuteNonQuery();
             dbconnection.Close();
             Response.Redirect("~/Detail.aspx?ProductNo="+Request.QueryString[0]);
         }
}
