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

namespace Bug_Tracking_Application
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Luke\Documents\BugData.mdf;Integrated Security=True;Connect Timeout=30");


        private void btnInsert_Click(object sender, EventArgs e)
        {
            connection.Open();
            String query = "INSERT INTO Bug (Tester_ID,Tester_Name,Application_Name,Class_Name,Line_No,Error_Description,Source_Code,Status) VALUES('" + txtID.Text + "','" + txtName.Text + "','" + txtApp.Text + "','" + txtClass.Text + "','" + txtLineNo.Text + "','" + txtDesc.Text + "','" + txtSource.Text + "','" + txtStatus.Text + "')";
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            adapter.SelectCommand.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Data Inserted Successfully.");
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            connection.Open();
            String query = "SELECT * FROM Bug ";
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            connection.Close();
        }

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

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            connection.Open();
            String query = "UPDATE Bug SET Tester_Name = '" + txtName.Text + "',Application_Name = '" + txtApp.Text + "',Class_Name = '" + txtClass.Text + "', Line_No = '" + txtLineNo.Text + "',Error_Description = '" + txtDesc.Text + "',Source_Code = '" + txtSource.Text + "',Status = '" + txtStatus.Text + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            adapter.SelectCommand.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Data Updated Successfully");
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txtID.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txtName.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtApp.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txtClass.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            txtLineNo.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            txtDesc.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            txtSource.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            txtStatus.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            connection.Open();
            String query = "DELETE FROM Bug WHERE Tester_ID = '"+txtID+"";
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Record Successfully Deleted");
        }
    }
}
