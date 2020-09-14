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
    public partial class Doctor : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\Documents\Dental_System.mdf;Integrated Security=True;Connect Timeout=30");

        public Doctor()
        {
            InitializeComponent();
            doctorTable();
        }

        private void Insert_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(" INSERT INTO Doctor (did,dname,dmob) VALUES " +
                    "( '" + textBox11.Text.ToString().Trim().Replace("'", "''") +
                    "','" + textBox10.Text.ToString().Trim().Replace("'", "''") +
                    "','" + textBox9.Text.ToString().Trim().Replace("'", "''") +
                    "')", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Added Doctor");

                textBox11.Text = "";
                textBox10.Text = "";
                textBox9.Text = "";

                con.Close();

                doctorTable();


            }
            catch (Exception)
            {
                MessageBox.Show("Enter Valid Data");
            }
        }

        private void GroupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Button5_Click(object sender, EventArgs e)
        {
            Home hObj = new Home();
            hObj.Show();
            this.SetVisibleCore(false);
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            textBox11.Text = "";
            textBox10.Text = "";
            textBox9.Text = "";
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Doctor WHERE did= '" + textBox11.Text + "'", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Removed Sucessfully");

                textBox11.Text = "";
                textBox10.Text = "";
                textBox9.Text = "";

                con.Close();

                doctorTable();

            }
            catch (Exception)
            {
                MessageBox.Show("Please check the ID");
            }
        }

        private void update_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Doctor SET dname= '" + textBox10.Text.ToString().Trim().Replace("'", "''")
                    + "',dmob='" + textBox9.Text.ToString().Trim().Replace("'", "''")
                    + "' WHERE did='" + textBox11.Text + "'", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show(" Details Updated Sucessfully");

                textBox11.Text = "";
                textBox10.Text = "";
                textBox9.Text = "";

                con.Close();

                doctorTable();



            }


            catch (Exception)
            {
                MessageBox.Show("something went wrong");
            }


        }


        private void doctorTable()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Doctor", con);
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

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                textBox11.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox10.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox9.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
