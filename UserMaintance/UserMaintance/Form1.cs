﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserMaintance.Entities;

namespace UserMaintance
{
    public partial class Form1 : Form
    {
        BindingList<User> users = new BindingList<User>();
        public Form1()
        {
            InitializeComponent();

            label1.Text = Resource1.FullName;
            //label2.Text = Resource1.FirstName;
            button1.Text = Resource1.Add;

            listBox1.DataSource = users;
            listBox1.ValueMember = "ID";
            listBox1.DisplayMember = "FullName";

            button2.Text = "Fájlba írás";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var u = new User()
            {
                FullName = textBox1.Text,
                //FirstName = textBox2.Text
            };
            users.Add(u);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.InitialDirectory = Application.StartupPath;
            sfd.Filter = "CSV file (*.csv)|*.csv| All Files (*.*)|*.*";
            sfd.DefaultExt = "csv";

            if (sfd.ShowDialog() != DialogResult.OK) return;


            using (StreamWriter sw = new StreamWriter(sfd.FileName, false, Encoding.UTF8))
            {

                sw.WriteLine("ID; FullName");

                foreach (User u in listBox1.Items)
                {
                    sw.Write(u.ID.ToString());
                    sw.Write(";");
                    sw.Write(u.FullName);
                    sw.WriteLine();
                }

            }
            MessageBox.Show("A fájlba írás megtörtént");

            Application.Exit();
        }
    }
}
