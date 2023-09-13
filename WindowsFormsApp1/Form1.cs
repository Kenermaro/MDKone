using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string dbfilePath = @"C:\4ekmaryov\AutoSerivirs\WindowsFormsApp1\WindowsFormsApp1\bin\Debug\your_database.db";
            string connectionString = $"Data Source={dbfilePath}; Version=3;";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand("SELECT Image1, Image2, TextColumn FROM ImagesTable LIMIT 1;", connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            byte[] imagen1Bytes = (byte[])reader["Image1"];
                            byte[] imagen2Bytes = (byte[])reader["Image2"];
                            string textValue = reader["TextColumn"].ToString();
                            using (MemoryStream stream1 = new MemoryStream(imagen1Bytes))
                            using (MemoryStream stream2 = new MemoryStream(imagen2Bytes))
                            {
                                pictureBox1.Image = Image.FromStream(stream1);
                                pictureBox2.Image = Image.FromStream(stream2);                      
                            }
                            label1.Text = textValue;
                        }
                    }
                }
                connection.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string dbfilePath = @"C:\4ekmaryov\AutoSerivirs\WindowsFormsApp1\WindowsFormsApp1\bin\Debug\your_database.db";
            string connectionString = $"Data Source={dbfilePath}; Version=3;";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand("SELECT Image1, Image2, TextColumn FROM ImagesTable LIMIT 1 OFFSET 1;", connection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            byte[] imagen1Bytes = (byte[])reader["Image1"];
                            byte[] imagen2Bytes = (byte[])reader["Image2"];
                            string textValue = reader["TextColumn"].ToString();
                            using (MemoryStream stream1 = new MemoryStream(imagen1Bytes))
                            using (MemoryStream stream2 = new MemoryStream(imagen2Bytes))
                            {
                                pictureBox1.Image = Image.FromStream(stream1);
                                pictureBox2.Image = Image.FromStream(stream2);
                            }
                            label1.Text = textValue;
                        }
                    }
                }
                connection.Close();
            }
        }
    }
}
