using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Reg
{
    public partial class RegistrationForm : Form
    {
        /* Переменные, которые будут хранить на протяжение работы программы логин и пароль и другие данные пользователя. */
        public string login = string.Empty;
        public string password = string.Empty;

        public string surname = string.Empty;
        public string name = string.Empty;
        public string middlename = string.Empty;
        public string bdate = string.Empty;
        public string phone = string.Empty;

        public string status = string.Empty;

        private Users user = new Users(); // Экземпляр класса пользователей.

        public RegistrationForm()
        {
            InitializeComponent();
            if (EnterForm.Gvars.gUsers != null) { user = EnterForm.Gvars.gUsers; } //загружаем список пользователей
           
        }

           private void EnterToForm()
        {
            for (int i = 0; i < user.Logins.Count; i++) // Ищем пользователя и проверяем правильность пароля.
            {
                if (user.Logins[i] == loginTextBox.Text && user.Passwords[i] == passwordTextBox.Text)
                {
                    login = user.Logins[i];
                    password = user.Passwords[i];

                    surname = user.Usurnames[i];
                    name = user.Unames[i];
                    middlename = user.Umiddlenames[i];
                    bdate = user.Ubdates[i];
                    phone = user.Uphones[i];
                    status = user.Ustatuss[i];

                    if (Int32.Parse(user.Ustatuss[i]) ==  1)
                    {
                        MessageBox.Show("Вход запрещён");
                       
                    }
                    else { 

                    MessageBox.Show("Вы вошли в систему!");
                        this.Close();
                    }
                    
                    
                    break;
                }
                else if (user.Logins[i] == loginTextBox.Text && passwordTextBox.Text != user.Passwords[i])
                {
                    login = user.Logins[i];

                    MessageBox.Show("Неверный пароль!");
                }
            }

            if (login == "") { MessageBox.Show("Пользователь " + loginTextBox.Text + " не найден!"); }
        }

        private void AddUser() // Регистрируем нового пользователя.
        {
            int adduser = 1;
            if (loginTextBox.Text == "" || passwordTextBox.Text == "" || surnameTextBox.Text == "" || nameTextBox.Text == "" || middlenameTextBox.Text == "" || bdateTextBox.Text == "" || phoneTextBox.Text == "") 
            { MessageBox.Show("Все данные пользователя для регистрации необходимо заполнить!"); return; }
            if (user.Logins.Count > 0) {
                for (int i = 0; i < user.Logins.Count; i++) // Ищем пользователя и проверяем правильность пароля.
                {
                    if (user.Logins[i] == loginTextBox.Text)
                    {
                        MessageBox.Show("Пользователь с таким логином уже есть, введите другой логин!");
                        adduser = 0;
                        return;
                    }
                }

                    if (adduser == 1 )
                    {

                        user.Logins.Add(loginTextBox.Text);
                        user.Passwords.Add(passwordTextBox.Text);
                        user.Usurnames.Add(surnameTextBox.Text);
                        user.Unames.Add(nameTextBox.Text);
                        user.Umiddlenames.Add(middlenameTextBox.Text);
                        user.Ubdates.Add(bdateTextBox.Text);
                        user.Uphones.Add(phoneTextBox.Text);
                        user.Ustatuss.Add(Convert.ToString(0));

                        FileStream fs = new FileStream("Users.dat", FileMode.OpenOrCreate);

                        BinaryFormatter formatter = new BinaryFormatter();
                        formatter.Serialize(fs, user); // Сериализуем пользователя и отправляем в файл

                        fs.Close();

                        login = loginTextBox.Text;
                        password=  passwordTextBox.Text;

                        surname = surnameTextBox.Text;
                        name = nameTextBox.Text;
                        middlename = middlenameTextBox.Text;
                        bdate = bdateTextBox.Text;
                        phone = phoneTextBox.Text;
                        status = statusTextBox.Text;


                        this.Close();
                       

                    }
                
             } else {
                 user.Logins.Add(loginTextBox.Text);
                 user.Passwords.Add(passwordTextBox.Text);
                user.Usurnames.Add(surnameTextBox.Text);
                user.Unames.Add(nameTextBox.Text);
                user.Umiddlenames.Add(middlenameTextBox.Text);
                user.Ubdates.Add(bdateTextBox.Text);
                user.Uphones.Add(phoneTextBox.Text);
                user.Ustatuss.Add(Convert.ToString(0));
                FileStream fs = new FileStream("Users.dat", FileMode.OpenOrCreate);

                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, user); // Сериализуем пользователя и отправляем в файл

                fs.Close();

                login = loginTextBox.Text;
                password = passwordTextBox.Text;

                surname = surnameTextBox.Text;
                name = nameTextBox.Text;
                middlename = middlenameTextBox.Text;
                bdate = bdateTextBox.Text;
                phone = phoneTextBox.Text;
                status = statusTextBox.Text;
                this.Close();

            }
                    


        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Закрываем программу.
        }

        private void regButton_Click(object sender, EventArgs e)
        {
            AddUser(); //добавляем пользователя
        }

        private void enterButton_Click(object sender, EventArgs e)
        {
            EnterToForm(); 
        }

        private void RegistrationForm_FormClosed(object sender, FormClosedEventArgs e)
        {
           //
             if (login == "" | password == "" | status == "1")
                      {
                Application.Exit();
                  }
            else
            {
               //nterToForm();
            }
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
