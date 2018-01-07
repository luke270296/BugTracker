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
/// <summary>
/// Login form authenticating user before allowing access to data table
/// </summary>
namespace Bug_Tracking_Application
{
    public partial class Login : Form
    {
        // Create a new SQL Connection to Data Source
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Luke\Documents\BugData.mdf;Integrated Security=True;Connect Timeout=30");

        public Login()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Allows user to enter their login credentials before accessing data table
        /// </summary>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            String query = "SELECT * from Login WHERE Username = '" + txtUsername.Text + "' and Password = '" + txtPassword.Text + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            if (table.Rows.Count == 1)
            {
                this.Hide(); // Close form once login is successful hiding login details
                Main Main = new Main();
                Main.ShowDialog(); // Open the main application
            }

            else
            {
                MessageBox.Show("Invalid Credentials"); // Inform user that invalid details have been entered, login unsuccessful
            }
        }
    }
}
