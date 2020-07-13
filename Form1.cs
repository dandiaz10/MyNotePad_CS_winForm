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

namespace myNotePad
{
    public partial class Form1 : Form
    {
        string path; //glopal path variable

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void udnoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //create local object for dialog to open a file using OpenFileDialog class
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Text Document|*.txt", ValidateNames = true, Multiselect = false })
            {
                if(ofd.ShowDialog() == DialogResult.OK)//open the dialog and check if is okay
                {
                    using (StreamReader sr = new StreamReader(ofd.FileName)) //object that streams data from a file
                    {
                        path = ofd.FileName; //save the path of the file
                        Task<string> text = sr.ReadToEndAsync(); //create function that reads all the values and return as string
                        textBox1.Text = text.Result; //result is the local string that contains what was readed.
                    }
                }
            }
        }

        private async void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(path)) // check if path is null or empty
            {
                using(SaveFileDialog sfd = new SaveFileDialog() { Filter = "Text Document|*.txt", ValidateNames = true})
                {
                    if(sfd.ShowDialog() == DialogResult.OK)
                    {
                        path = sfd.FileName;
                        using (StreamWriter sw = new StreamWriter(sfd.FileName))//streamWriter object is created to modify current path file.
                        {
                            await sw.WriteLineAsync(textBox1.Text);//over writes the content of the textbox to be saved.
                        }
                    }
                }
            }
            else //if file was already saved
            {
                using(StreamWriter sw = new StreamWriter(path))//streamWriter object is created to modify current path file.
                {
                    await sw.WriteLineAsync(textBox1.Text);//over writes the content of the textbox to be saved.
                }
            }
        }

        private async void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Text Document|*.txt", ValidateNames = true })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(sfd.FileName))//streamWriter object is created to modify current path file.
                    {
                        await sw.WriteLineAsync(textBox1.Text);//over writes the content of the textbox to be saved.
                    }
                }
            }

        }

            private void NewToolStripMenuItem_Click(object sender, EventArgs e) //enter when click new
        {
            path = string.Empty; //no path is set
            textBox1.Clear(); //clear textbox
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FormAbout frm = new FormAbout()) //create new local object of class FormAbout
            {
                frm.ShowDialog(); //pops out the formAbout
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit(); //exit the program
        }
    }
}
