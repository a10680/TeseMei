using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProjetoMei
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }


        private void adicionarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "AddFatura")
                {
                    isOpen = true;
                    f.Focus();
                    break;
                }
            }

            if (isOpen == false)
            {
                
                AddFatura f2 = new AddFatura();
                f2.MdiParent = this;
                f2.Show();
            }
        }
    }
}
