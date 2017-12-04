using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bug_Tracker
{
    public partial class Form1 : Form
    {
        String[] bugid = new String[6]; // unique identifer for each bug being logged
        int testerid; // unique identifer for the tester responsible for bug report
        string testername; // name of tester inputting bug report
        string application; // name of application where error exists, allows dev to narrow down problem
        string classname; // class that bug exists within
        int lineno; // the line number of the bug
        string source; // link to the source code (bitbucket, pastebin)
        string errordesc; // description of error, used by developer to recreate problem
        string status; // has the error been resolved? has it been acknowledged by dev team?
        DateTime date = DateTime.Now;

        public Form1()
        {
            InitializeComponent();
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit(); 
        }

        public void dataInsert()
        {
            // items will be added to database to log error
            SqlConnection mySqlConnection;

            mySqlConnection =
            new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Luke\source\repos\Bug Tracker\BugTracker.accdb;Integrated Security=True;Connect Timeout=30");
            String select = "SELECT BugID FROM Bug";
            SqlCommand selectcmd = new SqlCommand(select, mySqlConnection);

            mySqlConnection.Open();

            SqlDataReader mySqlDataReader = selectcmd.ExecuteReader();
            int i = 0;
            while (mySqlDataReader.Read())
            {
                Console.WriteLine(mySqlDataReader["BugID"]);
            }



        }

        public void dataUpdate()
        {
            // make amendments to database table when saving changes to code
            // use of button to edit table records? 'save' menu item saves local file for further development?
            // change current status (as above)
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dataInsert();
        }
    }

}
