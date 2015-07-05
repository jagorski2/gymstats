using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StartingStatsWeb
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            registerButton.Click += registerButton_Click;
        }

        void registerButton_Click(object sender, EventArgs e)
        {
            gymstatDB mydb = new gymstatDB();

            if (mydb.registerNewUser(usernameText.Text, crypto.sha256_hash(passwordText.Text), crypto.sha256_hash(vpasswordText.Text)))
            {
                crypto.installCookies(Response.Cookies, usernameText.Text, crypto.sha256_hash(passwordText.Text));

                Response.Redirect("RegisterSuccess.aspx");

            }
            else
            {
                usernameText.Text = "";
                passwordText.Text = "";
                vpasswordText.Text = "";
                registerError.Text ="Username already Taken or passwords did not match, Try Again";

            }
        }
    }
}