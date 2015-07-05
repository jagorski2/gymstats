using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StartingStatsWeb
{
    public partial class WorkoutB : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            welcome.Text = "Welcome " + crypto.validateCookies(Request.Cookies);
        }
    }
}