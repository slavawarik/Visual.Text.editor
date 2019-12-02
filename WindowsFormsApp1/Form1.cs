using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic.Logging;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        string file_path;
        string file_text;
        string file_text_u;
                            
        private void Button1_Click_1(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
            return;
            richTextBox1.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;
            file_path = openFileDialog1.FileName;
            textBox1.Text = file_path;
            this.reloadText();
        }

        private void reloadText()
        {
            string tmp = File.ReadAllText(file_path);

            if (tmp != file_text)
            {
                               
                {
                    file_text = File.ReadAllText(file_path);
                    textBox2.Text = file_text;
                    toolStripStatusLabel1.Text = "";

                    if (timer1.Enabled == false)
                    {
                        timer1.Enabled = true;
                        timer1.Start();
                    }
                }
            }
        }
        private void Button2_Click_1(object sender, EventArgs e)
        {
            using (FileStream fs = new FileStream(file_path, FileMode.Append))
            using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
            {
                sw.WriteLine(file_text);
            }
            MessageBox.Show("Текст добавлен и сохранен");
            textBox2.Text = "";
            richTextBox1.Text = "";
            this.reloadText();
            
        }

        private void Timer1_Tick_1(object sender, EventArgs e)
        {
            if (File.Exists(file_path) == false)
            {
                timer1.Stop();
                timer1.Enabled = false;
                return;
            }

            if (button2.Enabled == true)
            {
                string tmp = File.ReadAllText(file_path);
                if (file_text_u != tmp)
                {
                    toolStripStatusLabel1.Text = "Есть изменения в исходном файле.";

                }
            }

        }

        private void RichTextBox1_TextChanged_1(object sender, EventArgs e)
        {
            file_text = richTextBox1.Text;
            
        }

        private void Button3_Click_1(object sender, EventArgs e)
        {
            
            File.WriteAllText(file_path, file_text, Encoding.UTF8);
            MessageBox.Show("Файл сохранен");
            textBox2.Text = "";
            richTextBox1.Text = "";
            this.reloadText();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {
            file_text = textBox2.Text;
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = textBox2.Text;

        }
    } 
}
