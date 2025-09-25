using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Class1
/// </summary>
public class myDatabaseConnection
{
    public myDatabaseConnection()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static void executeSQL(string sqlCommand, ref GridView gvDisplay, ref Label lblErrorMessage)
    {
        // turn off the grid display and erase any previous error messages on the parent page
        gvDisplay.Visible = true;
        lblErrorMessage.Text = "";

        // connection string (replaces the static connection from before)
        string connectionString =
            "Data Source=SQL5025.myWindowsHosting.com;" +
            "Initial Catalog=DB_A28DC6_mccSupport;" +
            "User Id=DB_A28DC6_mccSupport_admin;" +
            "Password=passw0rd;";

        try // yes we can nest try catch blocks
        {
            // create and open the connection (using ensures it closes automatically)
            using (SqlConnection conn = new SqlConnection(connectionString))
            // define myCommand, passing it myConnection
            using (SqlCommand myCommand = new SqlCommand(sqlCommand, conn))
            {
                conn.Open(); // open the connection

                try
                {
                    if (sqlCommand.Trim().StartsWith("SELECT", StringComparison.OrdinalIgnoreCase))
                    {
                        // gives the data someplace to land
                        gvDisplay.DataSource = myCommand.ExecuteReader();
                        gvDisplay.DataBind();
                        // turn the grid display back on
                        gvDisplay.Visible = true;
                    }
                    else
                    {
                        // just execute the query
                        myCommand.ExecuteNonQuery();
                    }
                }
                // print any catch conditions in something called lblErrorMessage
                catch (Exception ex)
                {
                    lblErrorMessage.Text = ex.ToString();
                }
            } // connection + command are disposed here automatically
        }
        catch (Exception ex)
        {
            lblErrorMessage.Text = ex.ToString();
        }
    }
}
