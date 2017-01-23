using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    HttpCookie usercookie = new HttpCookie("CUserName");
    SqlConnection dbconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["15MY03010DBConnectionString"].ToString());
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            TextBoxUsername.Attributes["placeholder"] = "Enter a Username";
            TextBoxPassword.Attributes["placeholder"] = "Enter a Password";
            TextBoxSearch.Attributes["placeholder"] = "Enter text here...";

            DataSet ds = GetDataSetForMenu();
            Menu menu = new Menu();
            foreach (DataRow parentItem in ds.Tables["Category"].Rows)
            {
                MenuItem categoryItem = new MenuItem((parentItem["CategoryName"]).ToString());
                string cid=(parentItem["CategoryID"]).ToString();
              //  Menu1.Items.Add(categoryItem);
                Menu2.Items.Add(new MenuItem { Text = categoryItem.Text, NavigateUrl = "~/Category.aspx?CategoryID="+cid});
            }
        }
        if (Request.Cookies["CUserName"] != null)
        {
            LabelUsername.Text = "Welcome to PP " + Request.Cookies["CUserName"].Value.ToString();
            LabelPassword.Visible = false;
            TextBoxPassword.Visible = false;
            TextBoxUsername.Visible = false;
            CheckBoxRemember.Visible = false;
            ButtonLogin.Text = "Log out";
        }
        else if (!string.IsNullOrEmpty(Session["CUserName"] as string))
        {
        //    LabelUsername.Text = "Welcome to PP " + Request.Cookies["CUserName"].Value.ToString();
            LabelUsername.Text = "Welcome to PP " + Session["CUserName"].ToString();
            LabelPassword.Visible = false;
            TextBoxPassword.Visible = false;
            TextBoxUsername.Visible = false;
            CheckBoxRemember.Visible = false;
            ButtonLogin.Text = "Log out";
        }
       
    }

    private DataSet GetDataSetForMenu()
    {
        SqlDataAdapter adCat = new SqlDataAdapter("SELECT * FROM Category", dbconnection);
        DataSet ds = new DataSet();
        adCat.Fill(ds, "Category");
        return ds;
    }
    protected void ButtonSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Search.aspx?search=" + TextBoxSearch.Text);
    }
    protected void ButtonLogin_Click(object sender, EventArgs e)
    {

       if (Request.Cookies["CUserName"] != null)
        {
            usercookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(usercookie);
            ButtonLogin.Text = "Login";
            LabelUsername.Text = "Username:";
            LabelPassword.Visible = true;
            TextBoxPassword.Visible = true;
            TextBoxUsername.Visible = true;
            CheckBoxRemember.Visible = true;

          //  Response.Redirect("~/Index.aspx");

        }
       else if (!string.IsNullOrEmpty(Session["CUserName"] as string))
            {
                Session.Abandon();
                ButtonLogin.Text = "Login";
                LabelUsername.Text = "Username:";
                LabelPassword.Visible = true;
                TextBoxPassword.Visible = true;
                TextBoxUsername.Visible = true;
                CheckBoxRemember.Visible = true;

                // Response.Redirect("~/Index.aspx");
            }
        else
        {
            try
            {
                SqlCommand cmd1 = new SqlCommand("SELECT CUserName FROM [15MY03010DB].[dbo].[Company] WHERE CUserName=@uname AND CUserPassword=@upass", dbconnection);
                cmd1.Parameters.AddWithValue("@uname", TextBoxUsername.Text);
                cmd1.Parameters.AddWithValue("@upass", TextBoxPassword.Text);
                if (dbconnection.State == ConnectionState.Closed)
                {
                    dbconnection.Open();
                }
                if (cmd1.ExecuteScalar() != null)
                {
                    if (CheckBoxRemember.Checked)
                    {
                        usercookie.Value = cmd1.ExecuteScalar().ToString();
                        usercookie.Expires = DateTime.Now.AddDays(30);
                        Response.Cookies.Add(usercookie);
                        Session["CUserName"] = cmd1.ExecuteScalar().ToString();
                    }
                    else
                    {
                        Session["CUserName"] = cmd1.ExecuteScalar().ToString();
                      
                        /*
                        usercookie.Value = cmd1.ExecuteScalar().ToString();
                        Response.Cookies.Add(usercookie);*/
                    }

                }
                else
                {
                    /* LabelWarning.Visible = true;
                     LabelWarning.Text = "Inccorrect information please enter again.";*/
                    Response.Write("Inccorrect information please enter again.");
                }
            }
            catch (Exception expl)
            {
                /*LabelWarning.Visible = true;
                LabelWarning.Text = expl.ToString();*/

            }
            finally
            {
                if (Request.Cookies["CUserName"] != null)
                {
                    LabelUsername.Text = "Welcome to PP " + Request.Cookies["CUserName"].Value.ToString();
                    LabelPassword.Visible = false;
                    TextBoxPassword.Visible = false;
                    TextBoxUsername.Visible = false;
                    CheckBoxRemember.Visible = false;
                    ButtonLogin.Text = "Log out";
                }
                else if (!string.IsNullOrEmpty(Session["CUserName"] as string))
                {
                    LabelUsername.Text = "Welcome to PP " + Session["CUserName"].ToString();
                    LabelPassword.Visible = false;
                    TextBoxPassword.Visible = false;
                    TextBoxUsername.Visible = false;
                    CheckBoxRemember.Visible = false;
                    ButtonLogin.Text = "Log out";
                }
                dbconnection.Close();
            }
        }
    }
}
