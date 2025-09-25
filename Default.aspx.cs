using System;
using System.Collections.Generic;
using System.Drawing;
using System.Dynamic;
using System.IO;
//using System.Linq;
using System.Web; 
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

public partial class _Default : System.Web.UI.Page
{
    myDatabaseConnection myDatabaseConnection;
    string userID = "gorgeese728_";

    protected void Page_Load(object sender, EventArgs e)
    {
        

        string file1 = "";
        string file2 = "";
        string file3 = "";
        string file4 = "";
        string file5 = "";
        string file6 = "";
        string file7 = "";
        string file8 = "";
        string file9 = "";
        string FilePath = "";

        FilePath = Server.MapPath("~/App_Data");
        //Response.Write(FilePath);

        file1 = FilePath + "\\course.dat";
        //Response.Write("<br>" +  file1);
        file2 = FilePath + "\\student.dat";
        //Response.Write("<br>" + file2);
        file3 = FilePath + "\\faculty.dat";
        //Response.Write("<br>" + file3);
        file4 = FilePath + "\\location.dat";
        //Response.Write("<br>" + file4);
        file5 = FilePath + "\\frank.dat";
        //Response.Write("<br>" + file5);
        file6 = FilePath + "\\term.dat";
        //Response.Write("<br>" + file6);
        file7 = FilePath + "\\course_section.dat";
        //Response.Write("<br>" + file7);
        file8 = FilePath + "\\enrollment.dat";
       // Response.Write("<br>" + file8);
        file9 = FilePath + "\\state.dat";
       // Response.Write("<br>" + file9);


        if (!IsPostBack)
        {
            readData(file1, lstCourse);
            readData(file2, lstStudent);
            readData(file3, lstFaculty);
            readData(file4, lstLocation);
            readData(file5, lstFrank);
            readData(file6, lstTerm);
            readData(file7, lstCourseSection);
            readData(file8, lstEnrollment);
            readData(file9, lstState);

            checkForTables("Course");
            checkForTables("Student");
            checkForTables("Faculty");
            checkForTables("Location");
            checkForTables("Frank");
            checkForTables("Term");
            checkForTables("CourseSection");
            checkForTables("Enrollment");
            checkForTables("State");
        }

    }
    private void checkForTables(string tableName)
    {
        //throw new NotImplementedException();
        //execute a select statement
        string sqlCommand = "SELECT * FROM " + userID + tableName;
        myDatabaseConnection.executeSQL(sqlCommand, ref gvDisplay, ref lblErrorMessage);
        //turn off gridview and label so users can not see, but we can check condition
        lblErrorMessage.Visible = false;
        gvDisplay.Visible = false;

        int status;
        //check for no table
        if (lblErrorMessage.Text != "")
        {
            status = 0;
        }
        //check for empty table
        else if (gvDisplay.Rows.Count == 0)
        {
            status = 1;
        }
        // the default condition is data loaded
        else
        {
            status = 2;
        }
        switch (status)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;
        }

             //case 0: set create button to "on", rest of buttons to "off"
             //case 1: set create off, load on, view and delete to off
            //case 2: set create off, load off, view and delete on
            switch (status)
                {
                    case 0:
                        changeColor(tableName, 1, 0, 0, 0);
                        break;
                    case 1:
                        changeColor(tableName, 0, 1, 0, 0);
                        break;
                    case 2:
                        changeColor(tableName, 0, 0, 1, 1);
                        break;
                }
}



                    void readData(string fileName, ListBox listboxName)
    {
        try
        {
            if (File.Exists(fileName))
                using (StreamReader sr = new StreamReader(fileName))
                {
                    while (sr.Peek() >= 0)
                    {
                        listboxName.Items.Add(sr.ReadLine());
                    }
                }
        }
        catch (Exception f) 
        {
            Console.WriteLine("The process failed: {0}", f.ToString());
        }
    }

    private void checkForData(string tableName)
    {
        //throw new NotImplementedException();
        string sqlCommand = "SELECT * FROM " + userID + tableName;
        myDatabaseConnection.executeSQL(sqlCommand, ref gvDisplay, ref lblErrorMessage);
        //turn off gridview and label so users can not see, but we can check condition
        lblErrorMessage.Visible = false;
        gvDisplay.Visible = false;
        int status;
        //check for no table
        if (lblErrorMessage.Text != "")
        {
            status = 0;
        }
        //check for empty table
        else if (gvDisplay.Rows.Count == 0)
        {
            status = 1;
        }
        // the default condition is data loaded
        else
        {
            status = 2;
        }
        switch (status)
        {
            case 0:
                changeColor(tableName, 1, 0, 0, 0);
                break;
            case 1:
                changeColor(tableName, 0, 1, 0, 0);
                break;
            case 2:
                changeColor(tableName, 0, 0, 1, 1);
                break;
        }
    }


    protected void btnLoadCourse_Click(object sender, EventArgs e)
    {
        createSqlInsertStatements(lstCourse.ID, "Course");
        changeColor(btnCreateCourse, 0);
        changeColor(btnLoadCourse, 0);
        changeColor(btnViewCourse, 1);
        changeColor(btnDeleteCourse, 1);
    }

    private void createSqlInsertStatements(string listboxId, string tableName)
    {
        //throw new NotImplementedException();

        string[] fields;
        // connection to the listboxID 
        ListBox listbox = (ListBox)FindControl(listboxId);

        //temporary string to hold the new SQL statement
        string sqlInserts;

        //for loop to split each record on the comma. 
        for (int index = 0; index < listbox.Items.Count; index++)
        {
            // visual break
            //Response.Write("<HR />");
            // split record
            fields = listbox.Items[index].Text.Split(',');
            sqlInserts = "INSERT INTO " + userID + tableName + " VALUES (";

            // standard part of the insert SQL statement:
            sqlInserts = "INSERT INTO " + tableName + " VALUES (";

            // write each individual fields to the console 
            for (int fieldIndex = 0; fieldIndex < fields.Length; fieldIndex++)
            {
                //Response.Write(fields[fieldIndex] + "<BR />");

                // move the individual field into currentField (temp val)
                string currentField = fields[fieldIndex];
                // attempt to convert the value to an integer
                int tempResult;
                //check to see if the field can be converted to a number
                if (Int32.TryParse(currentField, out tempResult))
                {
                    sqlInserts += currentField;
                }
                else
                // single quotes around non numeric fields
                {
                    sqlInserts += "'" + currentField + "'";
                }
                //add a comma if we are not on the last field otherwise add a )
                if (fieldIndex <fields.Length - 1)
                {
                    sqlInserts += ", ";
                }
                else
                {
                    sqlInserts += ")";
                }

            }
            //segment of the code to execute the SQL statement in HW 2

            //Response.Write("<BR />" + sqlInserts);
            myDatabaseConnection.executeSQL(sqlInserts, ref gvDisplay, ref lblErrorMessage);
            changeColor(tableName, 0, 0, 1, 1);
        }
        //Response.Write("<HR/>");
        checkForError();
    }

    private void checkForError()
    {
        //throw new NotImplementedException();
        if (lblErrorMessage.Text == "")
        {
            lblErrorMessage.Text = "Command Complete";
        }
    }

    protected void btnLoadStudent_Click(object sender, EventArgs e)
    {
        createSqlInsertStatements(lstStudent.ID, "Student");
    }

    protected void btnLoadFaculty_Click(object sender, EventArgs e)
    {
        createSqlInsertStatements(lstFaculty.ID, "Faculty");
    }

    protected void btnLoadLocation_Click(object sender, EventArgs e)
    {
        createSqlInsertStatements(lstLocation.ID, "Location");
    }

    protected void btnLoadFrank_Click(object sender, EventArgs e)
    {
        createSqlInsertStatements(lstFrank.ID, "Frank");
    }

    protected void btnLoadTerm_Click(object sender, EventArgs e)
    {
        createSqlInsertStatements(lstTerm.ID, "Term");
    }

    protected void btnLoadCourseSection_Click(object sender, EventArgs e)
    {
        createSqlInsertStatements(lstCourseSection.ID, "Course_Section");
    }

    protected void btnLoadEnrollment_Click(object sender, EventArgs e)
    {
        createSqlInsertStatements(lstEnrollment.ID, "Enrollment");
    }

    protected void btnLoadState_Click(object sender, EventArgs e)
    {
        createSqlInsertStatements(lstState.ID, "State");
    }
    private void createTable(string tableName, string sqlCommand)
    {
        myDatabaseConnection.executeSQL(sqlCommand, ref gvDisplay, ref lblErrorMessage);
        changeColor(tableName, 0, 1, 0, 0);
    }
    private void viewTable(string tableName)
    {
        string sqlCommand = "SELECT * FROM " + userID + tableName;
        myDatabaseConnection.executeSQL(sqlCommand, ref gvDisplay, ref lblErrorMessage);
    }
    private void dropTable(string tableName)
    {
        string sqlCommand = "DROP TABLE " + userID + tableName;
        myDatabaseConnection.executeSQL(sqlCommand, ref gvDisplay, ref lblErrorMessage);
        changeColor(tableName, 1, 0, 0, 0);
    }
    private void changeColor(Button button, int flag)
    {
        //throw new NotImplementedException();
        switch (flag)
        {
            case 0:
                button.BackColor = Color.MintCream;
                button.Enabled = false;
                break;
            case 1:
                button.BackColor = Color.SkyBlue;
                button.Enabled = true;
                break;
        }
    }
    protected void changeColor(string rootID, int bCFlag, int bLFlag, int bVFlag, int bDFlag)
    {
        // Map rootID to correct suffix
        var idMap = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { "COURSE", "Course" },
            { "STUDENT", "Student" },
            { "FACULTY", "Faculty" },
            { "LOCATION", "Location" },
            { "FRANK", "Frank" },
            { "TERM", "Term" },
            { "COURSE_SECTION", "CourseSection" },
            { "ENROLLMENT", "Enrollment" },
            { "STATE", "State" }
        };

        string normalizedRootID = rootID.Trim().Replace(" ", "").ToUpper();
        string suffix = idMap.ContainsKey(normalizedRootID) ? idMap[normalizedRootID] : normalizedRootID;

        string bC = "btnCreate" + suffix;
        string bL = "btnLoad" + suffix;
        string bV = "btnView" + suffix;
        string bD = "btnDelete" + suffix;

        Button button;
        button = (Button)FindControl(bC);
        changeColor(button, bCFlag);
        button = (Button)FindControl(bL);
        changeColor(button, bLFlag);
        button = (Button)FindControl(bV);
        changeColor(button, bVFlag);
        button = (Button)FindControl(bD);
        changeColor(button, bDFlag);
    }

    protected void btnCreateCourse_Click(object sender, EventArgs e)
    {
        createTable("COURSE", "CREATE TABLE " + userID +
        "COURSE(COURSEID INTEGER UNIQUE, CALL_ID CHAR(8), " +
        "COURSE_NAME CHAR(30), CREDITS INTEGER)");
        checkForError();

    }


    protected void btnDeleteCourse_Click(object sender, EventArgs e)
    {
        dropTable("COURSE");
        checkForError();
    }

    protected void btnViewCourse_Click(object sender, EventArgs e)
    {
        viewTable("COURSE");
        checkForError();
    }

    protected void btnCreateStudent_Click(object sender, EventArgs e)
    {
        createTable( "STUDENT", "CREATE TABLE " + userID + "STUDENT (SID INTEGER UNIQUE, SLNAME CHAR(15), " +
        "SFNAME CHAR(15), SMI CHAR(2), SADD CHAR(30), SCITY CHAR(20), SSTATE CHAR(2), " +
        "SZIP CHAR(10), SPHONE CHAR(14), SDOB DATE, SCLASS CHAR(2), SPIN INTEGER, FID INTEGER)");
        checkForError();

    }

    protected void btnViewStudent_Click(object sender, EventArgs e)
    {
        viewTable("STUDENT");
        checkForError();
    }

    protected void btnCreateFaculty_Click(object sender, EventArgs e)
    {
        createTable ("FACULTY", "CREATE TABLE " + userID + "FACULTY (FID INTEGER UNIQUE, FLNAME CHAR(15), FFNAME CHAR(15), FMI CHAR(2), LOCID INTEGER, FPHONE CHAR(14), FRANK CHAR(5), FPIN INTEGER, FIMAGE CHAR(20))");
        checkForError();
    }

    protected void btnViewFaculty_Click(object sender, EventArgs e)
    {
        viewTable("FACULTY");
        checkForError();
    }

    protected void btnDeleteStudent_Click(object sender, EventArgs e)
    {
        dropTable("STUDENT");
        checkForError();
    }

    protected void btnDeleteFaculty_Click(object sender, EventArgs e)
    {
        dropTable("FACULTY");
        checkForError();
    }

    protected void btnCreateLocation_Click(object sender, EventArgs e)
    {
        createTable ("LOCATION", "CREATE TABLE " + userID + "LOCATION(LOCID INTEGER UNIQUE, BLDG_CODE CHAR(4), ROOM CHAR(4), CAPACITY INTEGER)");
        checkForError();
    }

    protected void btnViewLocation_Click(object sender, EventArgs e)
    {
        viewTable("LOCATION");
        checkForError();
    }

    protected void btnDeleteLocation_Click(object sender, EventArgs e)
    {
        dropTable("LOCATION");
        checkForError();
    }

    protected void btnCreateFrank_Click(object sender, EventArgs e)
    {
       createTable ( "FRANK", "CREATE TABLE " + userID + "FRANK (FRANK CHAR(5) UNIQUE, FRANKDESC CHAR(15))");
        checkForError();
    }

    protected void btnViewFrank_Click(object sender, EventArgs e)
    {
        viewTable("FRANK");
        checkForError();
    }

    protected void btnDeleteFrank_Click(object sender, EventArgs e)
    {
        dropTable("FRAMK");
        checkForError();
    }

    protected void btnCreateTerm_Click(object sender, EventArgs e)
    {
        createTable("TERM","CREATE TABLE" + userID + "TERM(TERMID INTEGER, TERM_DESC CHAR(12), STATUS CHAR (7))");
        checkForError();
    }

    protected void btnViewTerm_Click(object sender, EventArgs e)
    {
        viewTable("TERM");
        checkForError();
    }

    protected void btnDeleteTerm_Click(object sender, EventArgs e)
    {
        dropTable("TERM");
        checkForError();
    }

    protected void btnCreateCourseSection_Click(object sender, EventArgs e)
    {
        createTable("COURSE_SECTION", "CREATE TABLE " + userID + "COURSE_SECTION(CSEC_ID INTEGER UNIQUE, COURSEID INTEGER, TERMID INTEGER,SEC_NUM INTEGER, FID INTEGER, CSEC_DAY CHAR(6), CSEC_TIME DATE, LOCID INTEGER, MAX_ENRL INTEGER)");
        checkForError();
    }

    protected void btnViewCourseSection_Click(object sender, EventArgs e)
    {
        viewTable("COURSE_SECTION");
        checkForError();
    }

    protected void btnDeleteCourseSection_Click(object sender, EventArgs e)
    {
        dropTable("COURSE_SECTION");
        checkForError();
    }

    protected void btnCreateEnrollment_Click(object sender, EventArgs e)
    {
        createTable( "ENROLLMENT", "CREATE TABLE " + userID + "ENROLLMENT (SID INTEGER, CSEC_ID INTEGER, GRADE CHAR(2), CONSTRAINT " +userID + "ENROLLMENT_UN UNIQUE (SID, CSEC_ID) ) ");
        checkForError();
    }

    protected void btnViewEnrollment_Click(object sender, EventArgs e)
    {
        viewTable("ENROLLMENT");
        checkForError();
    }

    protected void btnDeleteEnrollment_Click(object sender, EventArgs e)
    {
        dropTable("ENROLLMENT");
        checkForError();
    }

    protected void btnCreateState_Click(object sender, EventArgs e)
    {
        createTable( "STATE", "CREATE TABLE " + userID + "STATE (S_ABBREVIATION CHAR(3) UNIQUE, S_NAME CHAR(100))");
        checkForError();
    }
    
    protected void btnViewState_Click(object sender, EventArgs e)
    {
        viewTable("STATE");
        checkForError();
    }

    protected void btnDeleteState_Click(object sender, EventArgs e)
    {
        dropTable("STATE");
        checkForError();
    }
}