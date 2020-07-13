using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myNotePad
{
    public partial class FormAbout : Form
    {
        public FormAbout()
        {
            InitializeComponent();
        }

        private void buttonOkay_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormAbout_Load(object sender, EventArgs e)
        {
            lblProductName.Text = string.Format("Product: {0}", Application.ProductName);
            lblProductVersion.Text = string.Format("Version: {0}", Application.ProductVersion);
            lblProductVersion.Text = "Copyright ©  2020 by DannDiaz10";
        }
    }
}
