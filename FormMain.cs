using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace MyTextor
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void button_openFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            string f = openFileDialog1.FileName;
            try
            {
                FileStream fs = new FileStream(f, FileMode.Open);
                StreamReader sr = new StreamReader(fs);
                textBox1.Text = sr.ReadToEnd();
                sr.Close();
                fs.Close();
            }
            catch (Exception ex)
            {

            }
        }

        private void button_exec_Click(object sender, EventArgs e)
        {
            string t = textBox1.Text.Trim();
            MyJS.processText(t);
        }
    }
}
