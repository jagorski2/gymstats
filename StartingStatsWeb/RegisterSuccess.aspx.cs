using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StartingStatsWeb
{
    public partial class RegisterSuccess : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (crypto.validateCookies(Request.Cookies, true))
            {
                loginlabel.Text = "Valid User Detected";
                Response.Redirect("http://www.google.com");
            }

        }
    }
}