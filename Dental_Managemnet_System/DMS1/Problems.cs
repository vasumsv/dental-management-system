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

namespace DMS1
{
    public partial class Problems : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\Documents\Dental_System.mdf;Integrated Security=True;Connect Timeout=30");

        public Problems()
        {
            InitializeComponent();
            problemTable();
        }

        private void Insert_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO problems (prid,prtype,pdesc) VALUES" +
                    "( '" + textBox11.Text.ToString().Trim().Replace("'", "''") +
                    "','" + comboBox1.Text.ToString().Trim().Replace("'", "''") +
                    "','" + textBox9.Text.ToString().Trim().Replace("'", "''") +
                    "')", con);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Added Problem");

                textBox11.Text = "";
                comboBox1.Text = "";
                textBox9.Text = "";

                con.Close();

                problemTable();


            }
            catch (Exception)
            {
                MessageBox.Show("Enter Valid Data");
            }
        }

        private void update_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Problems SET prtype= '" + comboBox1.Text.ToString().Trim().Replace("'", "''")
                    + "',pdesc='" + textBox9.Text.ToString().Trim().Replace("'", "''")
                    + "' WHERE prid='" + textBox11.Text + "'", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show(" Details Updated Sucessfully");

                textBox11.Text = "";
                textBox9.Text = "";
                comboBox1.Text = "";

                con.Close();

                problemTable();



            }


            catch (Exception)
            {
                MessageBox.Show("something went wrong");
            }
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Problems WHERE prid= '" + textBox11.Text + "'", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Removed Sucessfully");
                textBox11.Text = "";
                textBox9.Text = "";
                comboBox1.Text = "";

                con.Close();

                problemTable();

            }
            catch (Exception)
            {
                MessageBox.Show("Please check the ID");
            }
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            textBox11.Text = "";
            textBox9.Text = "";
            comboBox1.Text = "";
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            Home hObj = new Home();
            hObj.Show();
            this.SetVisibleCore(false);
        }

        private void problemTable()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Problems", con);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "ss");
                dataGridView1.DataSource = ds.Tables["ss"];
                con.Close();

            }
            catch
            {
                MessageBox.Show("No Record Found");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                textBox11.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                comboBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox9.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

}
