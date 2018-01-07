using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

/// <summary>
/// Application used to track bugs in Software Development.
/// Bugs will be entered by Testers and data viewed by Engineers
/// </summary>
/// <list type="bullet">
/// <item>
/// <term>Insert</term>
/// <description>Adds the data entered into the Bug table</description>
/// </item>
/// <item>
/// <term>Update</term>
/// <description>Updates the selected record in the Bug table</description>
/// </item>
/// <item>
/// <term>Remove</term>
/// <description>Removes the selected record from the Bug table</description>
/// </item>
/// <item>
/// <term>View</term>
/// <description>Allows the data to be viewed in a dataGridView</description>
/// </item>
/// </list>
namespace Bug_Tracking_Application
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// Creates connection to Data Source.
        /// </summary>
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Luke\Documents\BugData.mdf;Integrated Security=True;Connect Timeout=30");
        /// <summary>
        /// Insert Button to insert data into the data table.
        /// </summary>
        private void btnInsert_Click(object sender, EventArgs e)
        {
            connection.Open(); // Open connection to Data Source
            // SQL Insert query saved as string to be used by the Data Adapter
            String query = "INSERT INTO Bug (Tester_ID,Tester_Name,Application_Name,Class_Name,Line_No,Error_Description,Source_Code,Status) VALUES('" + txtID.Text + "','" + txtName.Text + "','" + txtApp.Text + "','" + txtClass.Text + "','" + txtLineNo.Text + "','" + txtDesc.Text + "','" + txtSource.Text + "','" + txtStatus.Text + "')";
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection); // Create Data Adapter, using the Insert query (in this case) and SQL Connection created initially
            adapter.SelectCommand.ExecuteNonQuery(); // Adapter executes Insert query
            connection.Close(); // Close SQL Connection now command has been run
            MessageBox.Show("Data Inserted Successfully."); // Confirmation that the Insert query was run successfully
        }
        /// <summary>
        /// Allows data to be displayed in the dataGridView.
        /// </summary>
        /// <param name="query">SQL Query to Select all stored as a String to be used by SqlDataAdapter</param>
        private void btnView_Click(object sender, EventArgs e)
        {
            connection.Open(); // Open connection to Data Source
            String query = "SELECT Tester_ID,Tester_Name,Application_Name,Class_Name,Line_No,Error_Description,Source_Code,Status FROM Bug "; // Select all from Bug table
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection); // Create Data Adapter, use Query and Connection
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;

            txtCode.Multiline = true;
            txtCode.SelectionStart = txtCode.Text.Length;
            txtCode.ScrollToCaret();
            txtCode.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();

            connection.Close(); // Close Connection after data is displayed
        }
        /// <summary>
        /// Clears data currently entered in TextBoxes
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtID.Clear();
            txtApp.Clear();
            txtDesc.Clear();
            txtClass.Clear();
            txtLineNo.Clear();
            txtSource.Clear();
            txtStatus.Clear();
        }
        /// <summary>
        /// Opens Help page providing basic instructions for use
        /// </summary>
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox2 a1 = new AboutBox2();
            a1.ShowDialog();
        }
        /// <summary>
        /// Update record in Bug table
        /// </summary>
        /// <param name="query">SQL Update query stored in string to be used by Data Adapter</param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            connection.Open(); // Open connection to Data Source
            SqlCommand command = new SqlCommand();
            // SQL Update query stored as string to be used by Data Adapter to update selected record in the data table
            String query = "UPDATE Bug Set Tester_Name = '" + txtName.Text + "',Application_Name = '" + txtApp.Text + "',Class_Name = '" + txtClass.Text + "',Line_No = '" + txtLineNo.Text + "',Error_Description = '" + txtDesc.Text + "',Source_Code = '" + txtSource.Text + "',Status = '" + txtStatus.Text + "' WHERE Tester_ID = '" + txtID.Text +"'";
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection); // Data Adapter using the query created prior and connection
            adapter.SelectCommand.ExecuteNonQuery();
            connection.Close(); // Close connection after query is run
            MessageBox.Show("Data Updated Successfully"); // Confirmation of data updated successfully
        }
        /// <summary>
        /// Double clicking on a field within the dataGridView will put the values into the text boxes to be edited by the user if desired
        /// </summary>
        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txtID.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txtName.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtApp.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txtClass.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            txtLineNo.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            txtDesc.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            txtCode.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            txtSource.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            txtStatus.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
        }
        /// <summary>
        /// Delete selected record from data table
        /// </summary>
        /// <param name="query">SQL Delete query stored as string to be used by Data Adapter</param>
        /// <param name="e"></param>
        private void btnRemove_Click(object sender, EventArgs e)
        {
            connection.Open(); // Open connection to Data Source
            String query = "DELETE FROM Bug WHERE Tester_ID = '"+txtID.Text+"'"; // Delete query to be run by Data Adapter, removing selected record
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection); // Create Data Adapter to use query and connection
            adapter.SelectCommand.ExecuteNonQuery();
            connection.Close(); // Close connection once query is run
            MessageBox.Show("Record Successfully Deleted"); // Confirmation that record was deleted successfully
        }
        /// <summary>
        /// Menu item to exit application
        /// </summary>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// Menu item to open About box
        /// </summary>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 a = new AboutBox1();
            a.ShowDialog();
        }
        /// <summary>
        /// Allows user to search for bugs based on their current status
        private void btnSearch_Click(object sender, EventArgs e)
        {
            connection.Open(); // Open connection to Data Source
            String query = "SELECT Tester_ID,Tester_Name,Application_Name,Class_Name,Line_No,Error_Description,Source_Code,Status FROM Bug WHERE Status='"+txtSearch.Text+"'"; // Select all from Bug table where Status equals what has been entered
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection); // Create Data Adapter, use Query and Connection
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            connection.Close();
        }
    }
}
