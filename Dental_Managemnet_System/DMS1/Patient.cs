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
    public partial class Patient : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\DELL\Documents\Dental_System.mdf;Integrated Security=True;Connect Timeout=30");

        public Patient()
        {
            InitializeComponent();
            patientTable();
            doctordetails();
            nursedetails();
            feverdetails();


        }
    

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(" INSERT INTO Patient (pid,pname,doctor_id,nurse_id,problem_id,mobile,address) VALUES " +
                    "( '" + textBox1.Text.ToString().Trim().Replace("'", "''") +
                    "','" + textBox2.Text.ToString().Trim().Replace("'", "''") +
                    "','" + textBox5.Text.ToString().Trim().Replace("'", "''") +
                    "','" + textBox7.Text.ToString().Trim().Replace("'", "''") +
                     "','" + textBox6.Text.ToString().Trim().Replace("'", "''") +
                      "','" + textBox3.Text.ToString().Trim().Replace("'", "''") +
                       "','" + textBox4.Text.ToString().Trim().Replace("'", "''") +
                    "')", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Added Patient");

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";


                con.Close();

                patientTable();


            }
            catch (Exception)
            {
                MessageBox.Show("Enter Valid Data");
            }

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Patient SET pname= '" + textBox2.Text.ToString().Trim().Replace("'", "''")
                    + "',doctor_id='" + textBox5.Text.ToString().Trim().Replace("'", "''")
                     + "',nurse_id='" + textBox7.Text.ToString().Trim().Replace("'", "''")
                      + "',problem_id='" + textBox6.Text.ToString().Trim().Replace("'", "''")
                       + "',mobile='" + textBox3.Text.ToString().Trim().Replace("'", "''")
                        + "',address='" + textBox4.Text.ToString().Trim().Replace("'", "''")
                    + "' WHERE pid='" + textBox1.Text + "'", con);

                cmd.ExecuteNonQuery();

                MessageBox.Show(" Details Updated Sucessfully");

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";

                con.Close();

                patientTable();

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
                SqlCommand cmd = new SqlCommand("DELETE FROM Patient WHERE pid= '" + textBox1.Text + "'", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Removed Sucessfully");

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";

                con.Close();

                patientTable();

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

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        private void patientTable()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Patient", con);
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

        public void doctordetails()
        {
            ComboBox5.Items.Clear();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select dname from Doctor";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                ComboBox5.Items.Add(dr["dname"].ToString());
            }
            con.Close();
           


        }
        public void nursedetails()
        {
            comboBox2.Items.Clear();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select nname from Nurses";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                comboBox2.Items.Add(dr["nname"].ToString());
            }
            con.Close();
           

        }
        public void feverdetails()
        {
            comboBox1.Items.Clear();
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select prtype from problems";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                comboBox1.Items.Add(dr["prtype"].ToString());
            }
            con.Close();


        }

        private void ComboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ComboBox5_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Doctor where dname ='" + ComboBox5.SelectedItem.ToString() + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                textBox5.Text = dr["did"].ToString();
            }
            con.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Nurses where nname ='" + comboBox2.SelectedItem.ToString() + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                textBox7.Text = dr["nid"].ToString();
            }
            con.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from problems where prtype ='" + comboBox1.SelectedItem.ToString() + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                textBox6.Text = dr["prid"].ToString();
            }
            con.Close();
        }
    }
}
