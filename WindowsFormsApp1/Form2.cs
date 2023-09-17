using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        private object newForm;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
         // Получаем введенные значения логина и пароля
            string login = textBox1.Text;
            string password = textBox2.Text;

            // Проверяем логин и пароль (здесь можно добавить свою логику аутентификации)
            if (login == "Admin" && password == "123" || login == "Vlad" && password == "1234")
                
            {
                // Если аутентификация успешна, открываем вторую форму с названием "Form1"
                Form1 form1 = new Form1();
                form1.Show();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль. Пшёл отсюда.");
            }
        }
    }
}
