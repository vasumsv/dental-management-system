using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DMS1
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Doctor dObj = new Doctor();
            dObj.Show();
            this.SetVisibleCore(false);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Patient pObj = new Patient();
            pObj.Show();
            this.SetVisibleCore(false);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Nurses nObj = new Nurses();
            nObj.Show();
            this.SetVisibleCore(false);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Problems prObj = new Problems();
            prObj.Show();
            this.SetVisibleCore(false);
        }
    }
}
