using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace StartingStatsWeb
{
    
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (crypto.validateCookies(Response.Cookies, true))
            {
                Response.Redirect("LoginSuccess.aspx");
            }
            logButton.Click += logButton_Click;
            regButton.Click += regButton_Click;
            
        }

        void regButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        void logButton_Click(object sender, EventArgs e)
        {
            gymstatDB mydb = new gymstatDB();
            if (crypto.sha256_hash(passwordText.Text) == mydb.getHashedPassword(usernameText.Text))
            {
                crypto.installCookies(Response.Cookies, usernameText.Text, crypto.sha256_hash(passwordText.Text));
                Response.Redirect("LoginSuccess.aspx");
            }
        }
    }
}