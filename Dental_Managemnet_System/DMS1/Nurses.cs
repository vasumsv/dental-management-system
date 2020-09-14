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
    public partial class Nurses : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\Documents\Dental_System.mdf;Integrated Security=True;Connect Timeout=30");

        public Nurses()
        {
            InitializeComponent();
            nurseTable();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(" INSERT INTO Nurses (nid,nname,nmob,naddress) VALUES " +
                    "( '" + textBox1.Text.ToString().Trim().Replace("'", "''") +
                    "','" + textBox2.Text.ToString().Trim().Replace("'", "''") +
                    "','" + textBox3.Text.ToString().Trim().Replace("'", "''") +
                    "','" + textBox4.Text.ToString().Trim().Replace("'", "''") +
                    "')", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Added");

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";


                con.Close();
                nurseTable();


            }
            catch (Exception)
            {
                MessageBox.Show("Enter Valid Data");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Nurses SET nname= '" + textBox2.Text.ToString().Trim().Replace("'", "''")
                    + "',nmob='" + textBox3.Text.ToString().Trim().Replace("'", "''")
                     + "',naddress='" + textBox4.Text.ToString().Trim().Replace("'", "''")
                    + "' WHERE nid='" + textBox1.Text + "'", con);

                cmd.ExecuteNonQuery();

                MessageBox.Show(" Details Updated Sucessfully");

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";

                con.Close();

                nurseTable();

            }

            catch (Exception)
            {
                MessageBox.Show("Details Updated Sucessfully");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Nurses WHERE nid= '" + textBox1.Text + "'", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Removed Sucessfully");

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";

                con.Close();

                nurseTable();

            }

            catch (Exception)
            {
                MessageBox.Show("Please check the ID");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Home hObj = new Home();
            hObj.Show();
            this.SetVisibleCore(false);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();

            }
        }

        private void nurseTable()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Nurses", con);
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
    }
}
