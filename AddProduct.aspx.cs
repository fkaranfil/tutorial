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

public partial class AddProduct : System.Web.UI.Page
{
    bool iserror = false;
    string file1path, file2path, file3path;
    SqlConnection dbconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["15MY03010DBConnectionString"].ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            SqlCommand commandforcategory;
            SqlDataReader reader;
            commandforcategory = new SqlCommand("SELECT [CategoryName],[CategoryID] FROM [Category]", dbconnection);
            dbconnection.Open();
            reader = commandforcategory.ExecuteReader();
            //DropDownList için verilerimi yazıyorum. Databinding yapıyorum.

            DropDownListPCategory.DataSource = reader;
            DropDownListPCategory.DataValueField = "CategoryID";
            DropDownListPCategory.DataTextField = "CategoryName";
            DropDownListPCategory.DataBind();
            reader.Close();

            DropDownListPCategory.Items.Insert(0, new ListItem("Select Category", "0"));
        }

    }
    protected void ButtonReset_Click(object sender, EventArgs e)
    {
        DropDownListPCategory.SelectedIndex = 0;
        TextBoxPDetails.Text = "";
        TextBoxPName.Text = "";
        TextBoxPrice.Text = "";

    }
    protected void ButtonAddProduct_Click(object sender, EventArgs e)
    {
        if (DropDownListPCategory.SelectedIndex!= 0)
        {
            try
            {
                if (FileUpload1.PostedFile.ContentType == "image/png" && FileUpload2.PostedFile.ContentType == "image/png" && FileUpload3.PostedFile.ContentType == "image/png")
                {
                    if (FileUpload1.PostedFile.ContentLength < 3145728 && FileUpload2.PostedFile.ContentLength < 3145728 && FileUpload3.PostedFile.ContentLength < 3145728) //file should be less than 5 mb
                    {
                        FileUpload1.SaveAs(Server.MapPath("~/attachments/") + Path.GetFileName(FileUpload1.FileName));
                        file1path = ("~/attachments/" + Path.GetFileName(FileUpload1.FileName)).ToString();

                        FileUpload2.SaveAs(Server.MapPath("~/attachments/") + Path.GetFileName(FileUpload2.FileName));
                        file2path = ("~/attachments/" + Path.GetFileName(FileUpload2.FileName)).ToString();

                        FileUpload3.SaveAs(Server.MapPath("~/attachments/") + Path.GetFileName(FileUpload3.FileName));
                        file3path = ("~/attachments/" + Path.GetFileName(FileUpload3.FileName)).ToString();

                        LabelAttachmentWarning.Visible = true;
                        LabelAttachmentWarning.Text = "The Attachment files uploaded.";
                    }
                    else
                    {
                        LabelAttachmentWarning.Visible = true;
                        LabelAttachmentWarning.Text = "The file has to be less than 3 MB! Please choose file or create ticket without attachment.";
                        iserror = true;
                    }
                }
                else
                {
                    LabelAttachmentWarning.Visible = true;
                    LabelAttachmentWarning.Text = "Error: Only PNG files are accepted!";
                    iserror = true;
                }
            }
            catch (Exception ex)
            {
                LabelAttachmentWarning.Visible = true;
                LabelAttachmentWarning.Text = "The file could not be uploaded. The following error occured: " + ex.Message;
                iserror = true;
                using (StreamWriter _testData = new StreamWriter(Server.MapPath("~/log.txt"), true))
                {
                    _testData.WriteLine(DateTime.Now.ToString("[dd/MM/yyyy] [HH:mm:ss]") + ex);
                }

            }
            if (iserror == false)
            {
                try
                {
                    if (dbconnection.State == ConnectionState.Closed)
                    {
                        dbconnection.Open();
                    }
                    SqlCommand cmd = new SqlCommand("INSERT INTO [Product] (ProductName,ProductDetails,ProductDate,CategoryID,ProductState,ProductImagePath,ProductImagePath2,ProductImagePath3,ProductPrice,CompanyID) VALUES (@ProductName,@ProductDetails,@ProductDate,@CategoryID,@ProductState,@ProductImagePath,@ProductImagePath2,@ProductImagePath3,@ProductPrice,@CompanyID)", dbconnection);
                    // int productno; chechandgenerateProductNO();
                    //cmd.Parameters.AddWithValue("@ProductNo", 10); // db tarafından oto artıs yap
                    cmd.Parameters.AddWithValue("@ProductName", TextBoxPName.Text);
                    cmd.Parameters.AddWithValue("@ProductDetails", TextBoxPDetails.Text);
                    cmd.Parameters.AddWithValue("@ProductDate", DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"));
                    cmd.Parameters.AddWithValue("@CategoryID", DropDownListPCategory.SelectedIndex.ToString());
                    cmd.Parameters.AddWithValue("@ProductState", 1);
                    cmd.Parameters.AddWithValue("@ProductPrice", TextBoxPrice.Text);
                    cmd.Parameters.AddWithValue("@CompanyID", 1); // it comes query string 
                    if (FileUpload1.HasFile)
                        cmd.Parameters.AddWithValue("@ProductImagePath", file1path);
                    else
                        cmd.Parameters.AddWithValue("@ProductImagePath", DBNull.Value);

                    if (FileUpload2.HasFile)
                        cmd.Parameters.AddWithValue("@ProductImagePath2", file2path);
                    else
                        cmd.Parameters.AddWithValue("@ProductImagePath2", DBNull.Value);

                    if (FileUpload3.HasFile)
                        cmd.Parameters.AddWithValue("@ProductImagePath3", file3path);
                    else
                        cmd.Parameters.AddWithValue("@ProductImagePath3", DBNull.Value);

                    cmd.ExecuteNonQuery();
                    dbconnection.Close();
                }
                catch (SqlException NoSend)
                {
                    LabelResult.Visible = true;
                    LabelResult.Text = "There is a error. Your product can not be added.";
                    iserror = true;
                    using (StreamWriter _testData = new StreamWriter(Server.MapPath("~/log.txt"), true))
                    {
                        _testData.WriteLine(DateTime.Now.ToString("[dd/MM/yyyy] [HH:mm:ss]") + NoSend);
                    }

                }
                if (iserror == false)
                {
                    LabelResult.Visible = true;
                    LabelResult.Text = "Your product added to system successfully.";
                    ButtonAddProduct.Enabled = false;
                    LabelWarning.Visible = false;
                    Panel2.Visible = false;
                }

            }

        }
        else
        {
            LabelResult.Visible = true;
            LabelResult.Text = "Please Select Category...";

        }


    }
}