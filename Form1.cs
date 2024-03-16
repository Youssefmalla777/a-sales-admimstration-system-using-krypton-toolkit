using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace invoice_programm_with_krypton_toolkit
{
    public partial class Form1 : KryptonForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //kryptonTextBox2.SelectAll();
            //kryptonTextBox2.Focus();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            youssef y = new youssef();
            if (kryptonTextBox1.Text == InputLanguage.DefaultInputLanguage.ToString())
            {
                y.Show();
            }
            if (kryptonTextBox1.Text == "" && kryptonTextBox2.Text == "")
            {
                MessageBox.Show("fill the textboxses first!!", "alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(kryptonTextBox1.Text == kryptonTextBox1.Text.ToLower())
            {
                MessageBox.Show("the password you loged in is worng!!", "warning",MessageBoxButtons.OK,MessageBoxIcon.Error);
                kryptonTextBox1.SelectAll();
                kryptonTextBox1.Focus();
            }
            else
            {
                y.Show(); 
            }

        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("do you wanna to exit??", "alert", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if(dr==DialogResult.Yes)
            {
                this.Close();
            }
            else
            {
                this.Show();
            }
        }

        private void kryptonTextBox2_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void kryptonTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Enter)
            {
                kryptonTextBox2.Focus();
            }
        }

        private void kryptonTextBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Up)
            {
                kryptonTextBox1.Focus();
            }
        }

        private void kryptonTextBox2_KeyDown_1(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Enter)
            {
                kryptonButton1.PerformClick();
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            
                
        }
    }
}
