using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnimeDump
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists(textBox1.Text + @"DeleteThis\") == false)
            {
                Directory.CreateDirectory(textBox1.Text + @"DeleteThis\");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateListbox();
        }

        private void UpdateListbox()
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();

            DirectoryInfo d = new DirectoryInfo(textBox1.Text);//Assuming Test is your Folder
            FileInfo[] Files = d.GetFiles("*.mp4"); //Getting Text files
            foreach (FileInfo file in Files)
            {
                listBox1.Items.Add(file.Name);
            }

            string[] folders = System.IO.Directory.GetDirectories(textBox1.Text, "*", System.IO.SearchOption.AllDirectories);
            foreach (string str in folders)
            {
                listBox2.Items.Add(str.Replace(textBox1.Text, ""));
            }

            DirectoryInfo d2 = new DirectoryInfo(textBox1.Text + @"DeleteThis\");//Assuming Test is your Folder
            FileInfo[] Files2 = d2.GetFiles("*.mp4"); //Getting Text files
            foreach (FileInfo file1 in Files2)
            {
                listBox3.Items.Add(file1.Name);
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            foreach (var item in listBox1.SelectedItems)
            {
                File.Move(textBox1.Text + item.ToString(), textBox1.Text + @"DeleteThis\" + item.ToString());
            }
            UpdateListbox();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int num = 0;
            string FolderName = "";
            foreach (var item in listBox1.SelectedItems)
            {
                if (num == 0)
                {
                    string input = Microsoft.VisualBasic.Interaction.InputBox("Please name your folder.", "Packup Tools", item.ToString(), -1, -1);
                    FolderName = input;
                    if (FolderName == "")
                    {
                        MessageBox.Show("Operation Cancelled");
                        return;
                    }else
                    {
                        if (Directory.Exists(textBox1.Text + FolderName + @"\") == false)
                        {
                            Directory.CreateDirectory(textBox1.Text + FolderName + @"\");
                        }

                    }
                }
                try
                {
                    File.Move(textBox1.Text + item.ToString(), textBox1.Text + FolderName + @"\" + item.ToString());
                }catch
                {
                    MessageBox.Show("Some Error has occured while moving the file " + item.ToString());
                }
               
                num++;
            }
            UpdateListbox();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UpdateListbox();
        }
    }
}
