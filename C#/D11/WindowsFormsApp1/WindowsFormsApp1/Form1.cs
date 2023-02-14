using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        
        private void Open_Click(object sender, EventArgs e)
        {
            openDg.Filter = "Rich Text Files|*.rtf|Text Files|*.txt";
            if(openDg.ShowDialog() == DialogResult.OK)
            { 
                rtx.LoadFile(openDg.FileName, (RichTextBoxStreamType)(openDg.FilterIndex - 1));
            }
        }

        private void btnCls_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveDg.Filter = "Rich Text Files|*.rtf|Text Files|*.txt";
            if (saveDg.ShowDialog() == DialogResult.OK)
            {
                rtx.SaveFile(saveDg.FileName, (RichTextBoxStreamType)(openDg.FilterIndex - 1));
            }
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            if (rtx.SelectedText.Length > 0)
            {
                colorDg.Color = rtx.SelectionColor;
                if (colorDg.ShowDialog() == DialogResult.OK)
                {
                    rtx.SelectionColor = colorDg.Color;
                }
            }
            else
                MessageBox.Show("please Select text first");
        }

        private void btnFont_Click(object sender, EventArgs e)
        {
            if (rtx.SelectedText.Length > 0)
            {
                fontDg.Font = rtx.SelectionFont;

                if (fontDg.ShowDialog() == DialogResult.OK)
                {
                    rtx.SelectionFont = fontDg.Font;
                }
            }
            else
                MessageBox.Show("please Select text first");
        }

        private void btnCst_Click(object sender, EventArgs e)
        {
           var cst =  new Custom();
            if (cst.ShowDialog() == DialogResult.OK)    
            {
                rtx.AppendText(cst.customText.ToString());
            }
        }
    }
}
