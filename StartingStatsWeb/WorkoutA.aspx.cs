using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StartingStatsWeb
{
    public partial class WorkoutA : System.Web.UI.Page
    {
        string lastWorkout = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            string username = crypto.validateCookies(Request.Cookies);
            saveButton.Click += saveButton_Click;
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            string start = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            welcome.Text = "Welcome " + username + " " + date + " " + start;
            gymstatDB mydb = new gymstatDB();
            if (mydb.startWorkout(username))
            {
               lastWorkout = mydb.getLastWorkoutID(username);
                if (mydb.startWorkoutA(lastWorkout))
                {

                    if (mydb.enterStartTimes(lastWorkout, date, start))
                    {
                        WorkoutIDText.Text = "Created New Workout with Workout ID: " + lastWorkout + " " + LiftSelector.SelectedIndex.ToString(); ;
                    }
                }
            }
            else
            {
                WorkoutIDText.Text = "Failed to create workout";
            }
            LiftSelector.SelectedIndex.ToString();

        }

        void saveButton_Click(object sender, EventArgs e)
        {
            string lift = "";
            gymstatDB mydb = new gymstatDB();
            switch (LiftSelector.SelectedIndex)
            {
                case 0:
                    lift = "squats";
                    break;
                case 1:
                    lift = "press";
                    break;
                case 2:
                    lift = "deadlift";
                    break;
                default:
                    break;
            }
            WorkoutIDText.Text = "Submitted that you did set " + setBox.Text + " for " + repBox.Text + " reps at " + weightBox.Text + " doing " + lift;
            if (mydb.insertWorkout(lift, lastWorkout, setBox.Text, repBox.Text, weightBox.Text))
            {
                WorkoutIDText.Text = "Submitted that you did set " + setBox.Text + " for " + repBox.Text + " reps at " + weightBox.Text + " doing " + lift;
            }
        }
    }
}