using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StartingStatsWeb
{
    public partial class LoginSuccess : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            welcome.Text = "Welcome " +crypto.validateCookies(Request.Cookies);
            workoutAButton.Click += workoutAButton_Click;
            workoutBButton.Click += workoutBButton_Click;
            continueButton.Click += continueButton_Click;
        }

        void continueButton_Click(object sender, EventArgs e)
        {
          //  Response.Redirect("WorkoutA.aspx");
        }

        void workoutBButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("WorkoutB.aspx");
        }

        void workoutAButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("WorkoutA.aspx");
        }
    }
}