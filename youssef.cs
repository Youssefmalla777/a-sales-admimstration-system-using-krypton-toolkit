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
using System.IO;
using System.Text.RegularExpressions;

namespace invoice_programm_with_krypton_toolkit
{
    public partial class youssef : KryptonForm
    {
        
        public youssef()
        {
            InitializeComponent();
        }

        private void youssef_Load(object sender, EventArgs e)
        {
            // this code for explianing how to show the date immaditly when we run the programm
            krytxtdate.Text = DateTime.Now.ToString();
            krytxtinvoice.SelectAll();
            krytxtinvoice.Focus();
            // taking tow values from type double and string and name as a data
            // and store all the data inside the programm when we run it 
            Dictionary<double, String> data = new Dictionary<double, string>();
            data.Add(5, "ملوس عادي");
            data.Add(10,"ماوس gaming");
            data.Add(5.4, "ماوس سلكي");
            data.Add(12, "ماوس لاسلكي");
            data.Add(2, "سماعات عادية ");
            data.Add(10.1, "سماعات rgb");
            data.Add(20, "سماعات أذن كبيرة");
            data.Add(50, "سماعات سلكية");
            data.Add(3, "سماعات لاسلكية");
            data.Add(40, "هارديسك ssd 128gb");
            data.Add(40.5, "هارديسك ssd 256gb");
            data.Add(50.4, "هارديسك ssd 512gb");
            data.Add(60, "هارديسك ssd 1tb");
            data.Add(12.3, "هارديسك hdd 128gb");
            data.Add(13, "هارديسك hdd 256gb");
            data.Add(15, "هارديسك hdd 512gb");
            data.Add(40.3, "هارديسك hdd 1tb");
            data.Add(12.2, "كيبورد عادي");
            data.Add(20.3, "كيبورد gaming");
            data.Add(500, "لابتوب hp");
            data.Add(700, "لابتوب dell");
            data.Add(1000, "لابتوب lenovo");
            data.Add(1100, "لابتوب asus");
            data.Add(1200, "لابتوب acer");
            data.Add(1300, "لابتوب toshipa");
            data.Add(2000, "لابتوب hp gaming");
            data.Add(2500, "لابتوب dell gaming");
            data.Add(2600, "لابتوب lenovo gaming");
            data.Add(2700, "لابتوب asus gaming");
            data.Add(20.1, "حقائب لابتوب");
            data.Add(1.5, "لصقات حماية");
            data.Add(2.3, "لصقات كيبورد");
            data.Add(400.3, "كاميرات مراقبة");
            data.Add(3.7, "ستندة لابتوب");
            data.Add(4.8, "cover حماية");
            // this code for explianing how to put the data inside the combobox 
            krycbx.DataSource = new BindingSource(data, null);
            // showin the price of the product
            krycbx.ValueMember = "key";
            // showin the name of the product
            krycbx.DisplayMember = "value";
            krytxtprice.Text = krycbx.SelectedValue.ToString();
        }

        private void krycbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            // showin the price inside the txtprice box 
            krytxtprice.Text = krycbx.SelectedValue.ToString();
        }

        private void krytxtinvoice_KeyDown(object sender, KeyEventArgs e)
        {
            // this step ot get one step down by movin from box to box..
            if (e.KeyData == Keys.Enter)
                krytxtname.Focus();
        }

        private void krytxtname_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                krycbx.Focus();
        }

        private void krycbx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                krytxtmount.Focus();
        }

        private void krytxtmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                krytxtprice.Focus();
        }

        private void krytxtprice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                krytxttotal.Focus();
        }

        private void krytxttotal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                krybtnadd.PerformClick();
            krytxtinvoice.Focus();
        }

        private void krybtnadd_Click(object sender, EventArgs e)
        {
            try
            {
                // show the worng message if the textboxses were empty..
                if (krytxtinvoice.Text == "" || krytxtname.Text == "" || krytxtmount.Text == "" || krytxtprice.Text == "")
                {
                    MessageBox.Show("please fill the textboxses first!!", "alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // do not excuate the code if we did not pick one of the product
                if (krycbx.SelectedIndex <= -1)
                    return;
                // define a variables form different types and store it inside an array from tyoe object..(cause it takes all the variables)
                string strinvoice = krytxtinvoice.Text;
                string strname = krytxtname.Text;
                string strtype = krycbx.Text;
                int strmount = Convert.ToInt16(krytxtmount.Text);
                double strprice = Convert.ToDouble(krytxtprice.Text);
                double strtotal = strmount * strprice;

                object[] all = { strinvoice, strname, strtype, strmount, strprice, strtotal };
                MessageBox.Show("your data is added..", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.Rows.Add(all);
                // ccollecte the number inside the textbox with the total price and show it inside the txttotal
                krytxttotal.Text = Convert.ToDouble(krytxttotal.Text) + strtotal + "";
                // savin the data inside a folder ..
                StreamWriter sr = new StreamWriter("sales.txt", true);
                string strsales = krytxtinvoice.Text + "- "
                    + krytxtname.Text + "- "
                    + krycbx.Text + "- "
                    + krytxtmount.Text + "- "
                    + krytxtprice.Text + "- "
                    + krytxttotal.Text + "- ";
                sr.WriteLine(strsales);
                sr.Close();

                krytxtinvoice.Text = "";
                krytxtname.Text = "";
                krytxtmount.Text = "";
                krytxtprice.Text = "";

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void krytxttotal_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Up)
                krytxtprice.Focus();
        }
        
        private void krytxtprice_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Up)
                krytxtmount.Focus();
        }

        private void krytxtmount_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Up)
                krycbx.Focus();
        }

        private void krycbx_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Up)
                krytxtname.Focus();
        }

        private void krytxtname_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void krytxtname_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Up)
                krytxtinvoice.Focus();
        }

        private void krytxtinvoice_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void krytxtmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            // this code for not editin at the data form the textboxses..
            e.Handled = true;
        }

        private void krytxtprice_KeyPress(object sender, KeyPressEventArgs e)
        {
            // like the same last code ..
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void krytxttotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // this code if we pick one of the data form datagridview ..then show it inside hte textboxses
            // each one of it ..
            if(dataGridView1.CurrentRow != null)
            {
                krytxtinvoice.Text = dataGridView1.CurrentRow.Cells[0].Value + "";
                krytxtname.Text = dataGridView1.CurrentRow.Cells[1].Value + "";
                krycbx.Text = dataGridView1.CurrentRow.Cells[2].Value + "";
                krytxtmount.Text = dataGridView1.CurrentRow.Cells[3].Value + "";
                krytxtprice.Text = dataGridView1.CurrentRow.Cells[4].Value + "";
            }
        }

        private void krybtnedit_Click(object sender, EventArgs e)
        {
            if(dataGridView1.CurrentRow != null)
            {
                MessageBox.Show("your data is edited!!", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.CurrentRow.Cells[0].Value = krytxtinvoice.Text;
                dataGridView1.CurrentRow.Cells[1].Value = krytxtname.Text;
                dataGridView1.CurrentRow.Cells[2].Value = krycbx.Text;
                dataGridView1.CurrentRow.Cells[3].Value = krytxtmount.Text;
                dataGridView1.CurrentRow.Cells[4].Value = krytxtprice.Text;

                string newmount = dataGridView1.CurrentRow.Cells[3].Value + "";
                string newprice = dataGridView1.CurrentRow.Cells[4].Value + "";

                double mount = Convert.ToDouble(newmount);
                double price = Convert.ToDouble(newprice);

                dataGridView1.CurrentRow.Cells[5].Value = mount * price;

                double newtotal = 0;
                foreach(DataGridViewRow d in dataGridView1.Rows)
                {
                    newtotal += Convert.ToDouble(d.Cells[5].Value);
                    krytxttotal.Text = newtotal.ToString();
                }
            }
        }
        // define a varaiables form type string for if we edit at the data from datagridview
        // like if we entered a symbols or any other things un understood
        // bring the last value back ..
        // and the str means the last value ..
        string str = "";
        string str2 = "";
        string str3 = "";
        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if(dataGridView1.CurrentRow != null)
            {
                // like the last explainig..
                str = dataGridView1.CurrentRow.Cells[3].Value + "";
                str2 = dataGridView1.CurrentRow.Cells[4].Value + "";
                str3 = dataGridView1.CurrentRow.Cells[0].Value + "";
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView1.CurrentRow != null)
            {
                string newmount = dataGridView1.CurrentRow.Cells[3].Value + "";
                string newprice = dataGridView1.CurrentRow.Cells[4].Value + "";
                string newinvoice = dataGridView1.CurrentRow.Cells[0].Value + "";
                if(!Regex.IsMatch(newmount, "^\\d+$") || !Regex.IsMatch(newprice, "^\\d+$") || !Regex.IsMatch(newinvoice, "^\\d+$"))
                {
                    dataGridView1.CurrentRow.Cells[3].Value = str;
                    dataGridView1.CurrentRow.Cells[4].Value = str2;
                    dataGridView1.CurrentRow.Cells[0].Value = str3;
                }

                else
                {
                    double mount = Convert.ToDouble(newmount);
                    double price = Convert.ToDouble(newprice);

                    dataGridView1.CurrentRow.Cells[5].Value = (mount * price);

                    double newtotal = 0;
                    foreach(DataGridViewRow d in dataGridView1.Rows)
                    {
                        newtotal += Convert.ToDouble(d.Cells[5].Value);
                        krytxttotal.Text = newtotal.ToString();
                    }
                }
                
            }
        }

        private void krybtndelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("do oyu wanna to delete this data??", "alert", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dr == DialogResult.Yes)
            {
                for (int x = 0; x < dataGridView1.SelectedRows.Count; x++)
                {
                    if (dataGridView1.SelectedRows.Count > 0)
                    {
                        dataGridView1.Rows.Remove(dataGridView1.SelectedRows[0]);
                    }
                }

                foreach (Control s in this.Controls)
                {
                    if (s is TextBox)
                        s.Text = "";
                }
            }

            else
            {
                this.Show();
            }
        }

        private void krybtnprinting_Click(object sender, EventArgs e)
        {
            ((Form)printPreviewDialog1).Icon = this.Icon;
            ((Form)printPreviewDialog1).WindowState = FormWindowState.Maximized;
            ((Form)printPreviewDialog1).StartPosition = FormStartPosition.CenterScreen;
            ((Form)printPreviewDialog1).TopMost = true;
            ((Form)printPreviewDialog1).AutoSize = true;
            ((Form)printPreviewDialog1).AutoScroll = true;
            ((Form)printPreviewDialog1).BackColor = this.BackColor;
            ((Form)printPreviewDialog1).AllowDrop = false;
            if(printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(Properties.Resources._454, 20, 20, 200, 200);
            int margin = 40;
            Font f = new Font("italic", 14,FontStyle.Bold);

            string strinvoice = "#ON " + krytxtinvoice.Text;
            string strdate = "التاريخ و الساعة: " + krytxtdate.Text;
            string strname = "المطلوب من السيد/ة: " + krytxtname.Text;

            SizeF fontinvoice = e.Graphics.MeasureString(strinvoice, f);
            SizeF fontdate = e.Graphics.MeasureString(strdate, f);
            SizeF fontname = e.Graphics.MeasureString(strname, f);

            e.Graphics.DrawString(strinvoice, f, Brushes.Black, (e.PageBounds.Width - fontinvoice.Width) / 2, margin - 10);
            e.Graphics.DrawString(strdate, f, Brushes.Black, e.PageBounds.Width - fontdate.Width+35, margin + 40);
            e.Graphics.DrawString(strname, f, Brushes.Black, e.PageBounds.Width - fontname.Width-5, margin + fontinvoice.Height + fontdate.Height + 30);

            float preheights = margin + fontinvoice.Height + fontdate.Height + fontname.Height;
            e.Graphics.DrawRectangle(Pens.Black, margin, margin + fontinvoice.Height + fontdate.Height + fontname.Height + 100, e.PageBounds.Width - margin * 2, e.PageBounds.Height - margin - preheights - 80);
            float preheight = 150;

            float prewidth1 = 200;
            float prewidth2 = prewidth1 + 125;
            float prewidth3 = prewidth2 + 125;
            float prewidth4 = prewidth3 + 125;
            e.Graphics.DrawLine(Pens.Black, margin, preheights + preheight, e.PageBounds.Width - margin * 2+40, preheight + preheights);

            e.Graphics.DrawString("الصنف", f, Brushes.Black, e.PageBounds.Width - margin * 2-80, preheights + preheight-30);
            e.Graphics.DrawLine(Pens.Black, e.PageBounds.Width - margin * 2 - prewidth1+50, preheight+65, e.PageBounds.Width - margin * 2 - prewidth1+50, preheight+preheights+815);

            e.Graphics.DrawString("الكمية", f, Brushes.Black, e.PageBounds.Width - margin * 2 - 230, preheights + preheight - 30);
            e.Graphics.DrawLine(Pens.Black, e.PageBounds.Width - margin * 2 - prewidth2 + 50, preheight + 65, e.PageBounds.Width - margin * 2 - prewidth2 + 50, preheight + preheights + 815);

            e.Graphics.DrawString("السعر", f, Brushes.Black, e.PageBounds.Width - margin * 2 - 360, preheights + preheight - 30);
            e.Graphics.DrawLine(Pens.Black, e.PageBounds.Width - margin * 2 - prewidth3 + 50, preheight + 65, e.PageBounds.Width - margin * 2 - prewidth3 + 50, preheight + preheights + 817);

            e.Graphics.DrawString("الأجمالي الفرعي", f, Brushes.Black, e.PageBounds.Width - margin * 2 - 625, preheights + preheight - 30);

            float rowh = 50;
            for(int c=0;c<dataGridView1.Rows.Count;c++)
            {
                e.Graphics.DrawString(dataGridView1.Rows[c].Cells[2].Value.ToString(), f, Brushes.Black, e.PageBounds.Width - margin * 2 - 100, preheights + rowh + 105);
                e.Graphics.DrawString(dataGridView1.Rows[c].Cells[3].Value.ToString(), f, Brushes.Black, e.PageBounds.Width - margin * 2 - 210, preheights + rowh + 105);
                e.Graphics.DrawString(dataGridView1.Rows[c].Cells[4].Value.ToString(), f, Brushes.Black, e.PageBounds.Width - margin * 2 - 345, preheights + rowh + 105);
                e.Graphics.DrawString(dataGridView1.Rows[c].Cells[5].Value.ToString(), f, Brushes.Black, e.PageBounds.Width - margin * 2 - 570, preheights + rowh + 105);
                e.Graphics.DrawLine(Pens.Black, margin, preheights + rowh + 135, e.PageBounds.Width - margin * 2 +40, preheights + rowh + 135);
                rowh += 60;
            }
            
        }

        private void dataGridView1_CellStyleContentChanged(object sender, DataGridViewCellStyleContentChangedEventArgs e)
        {

        }

        private void dataGridView1_CellStyleChanged(object sender, DataGridViewCellEventArgs e)
        {
             if(dataGridView1.CurrentRow != null)
            {
                krytxtinvoice.Text = dataGridView1.CurrentRow.Cells[0].Value + "";
                krytxtname.Text = dataGridView1.CurrentRow.Cells[1].Value + "";
                krycbx.Text = dataGridView1.CurrentRow.Cells[2].Value + "";
                krytxtmount.Text = dataGridView1.CurrentRow.Cells[3].Value + "";
                krytxtprice.Text = dataGridView1.CurrentRow.Cells[4].Value + "";
            }
        }
    }
}
