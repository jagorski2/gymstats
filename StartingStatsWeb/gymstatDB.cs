using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace StartingStatsWeb
{
    class gymstatDB
    {
        MySql.Data.MySqlClient.MySqlConnection conn;
        private bool connectToDatabase()
        {
            string myConnectionString;

            myConnectionString = "server=69.204.125.233 ;uid=jim;" +
                "pwd=snowjim;database=gymstat;";

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
                return true;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                //MessageBox.Show(ex.Message.ToString());
                return false;

            }
            
        }
        private bool disconnectFromDatabase()
        {
            conn.Close();
            conn.Dispose();
            conn = null;
            return true;
        }

        internal bool registerNewUser(string username, string password, string verifypassword)
        {
            if (password != verifypassword)
            {
                return false;
            }
            if (connectToDatabase())
            {
                try
                {
                    string sql = "INSERT INTO users (`username`,`password`) VALUES ('" + username + "','" + password + "')";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    int ret = cmd.ExecuteNonQuery();
                    if (ret > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine("Error " + e.Message);
                    return false;
                }

            }
            else
            {
                return false;
            }

        }
        internal string getHashedPassword(string username)
        {
            if (connectToDatabase())
            {
                try
                {
                    string sql = "Select password from users where username='" + username + "'";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader myReader = cmd.ExecuteReader();
                    if (myReader.Read())
                    {
                        return myReader.GetString(0);
                    }
                    return "";
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error " + e.Message);
                    return "";
                }

            }
            else
            {
                return "";
            }

        }
        internal bool startWorkout(string username)
        {

            if (connectToDatabase())
            {
                try
                {
                    string sql = "INSERT INTO workouts (`username`) VALUES ('" + username + "')";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    int ret = cmd.ExecuteNonQuery();
                    if (ret > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine("Error " + e.Message);
                    return false;
                }

            }
            else
            {
                return false;
            }

        }
        internal bool enterStartTimes(string workoutID, string date, string start)
        {

            if (connectToDatabase())
            {
                try
                {
                    string sql = "INSERT INTO times (`workoutID`,`Date`,`Start`) VALUES ('" + workoutID + "','"+date+"','"+start+"')";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    int ret = cmd.ExecuteNonQuery();
                    if (ret > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine("Error " + e.Message);
                    return false;
                }

            }
            else
            {
                return false;
            }

        }
        internal bool startWorkoutA(string workoutID)
        {

            if (connectToDatabase())
            {
                try
                {
                    string sql = "INSERT INTO aorb (`workoutID`,`A`,`B`) VALUES ('" + workoutID + "','1','0')";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    int ret = cmd.ExecuteNonQuery();
                    if (ret > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine("Error " + e.Message);
                    return false;
                }

            }
            else
            {
                return false;
            }

        }

        internal bool startWorkoutB(string workoutID)
        {

            if (connectToDatabase())
            {
                try
                {
                    string sql = "INSERT INTO aorb (`workoutID`,`A`,`B`) VALUES ('" + workoutID + "','0','1')";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    int ret = cmd.ExecuteNonQuery();
                    if (ret > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine("Error " + e.Message);
                    return false;
                }

            }
            else
            {
                return false;
            }

        }
        internal string getLastWorkoutID(string username)
        {
            if (connectToDatabase())
            {
                try
                {
                    string sql = "Select max(WorkoutID) from workouts where username='" + username + "'";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader myReader = cmd.ExecuteReader();
                    if (myReader.Read())
                    {
                        return myReader.GetString(0);
                    }
                    return "";
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error " + e.Message);
                    return "";
                }

            }
            else
            {
                return "";
            }

        }
        private string sendQueryToDatabase(string query)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader myreader = cmd.ExecuteReader();
                DataTable mydt = new DataTable();
                mydt.Load(myreader);
                DataRow myrow = mydt.Rows[0];
                if (disconnectFromDatabase())
                {
                    Console.WriteLine("Disconnected from database");
                }
                if (myrow["Workout_Total"].ToString() == "")
                {
                    return "0";
                }
                return myrow["Workout_Total"].ToString();

            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR " + e.Message);
                return null;
            }
        }


        internal bool insertWorkout(string lift, string workoutID, string sets, string reps, string weight)
        {
            if (connectToDatabase())
            {
                try
                {
                    string sql = "INSERT INTO "+lift+" (`workoutID`,`sets`,`reps`,`weight`) VALUES ('" + workoutID + "','"+sets+"','"+reps+"','"+weight+"')";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    int ret = cmd.ExecuteNonQuery();
                    if (ret > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine("Error " + e.Message);
                    return false;
                }

            }
            else
            {
                return false;
            } 
        }
    }
}
