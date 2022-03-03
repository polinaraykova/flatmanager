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
    public partial class ManagerForm : Form
    {

        /**********************************************/

        /* Переменные, которые будут хранить на протяжение работы программы логин и пароль и другие данные пользователя. */
        public string addres = string.Empty;
        public string square = string.Empty;

        public string num = string.Empty;
        public string rent = string.Empty;
        public string descr = string.Empty;
        public string status = string.Empty;
        public string rate = string.Empty;

       // public string status = string.Empty;

        public Flats flat = new Flats(); // Экземпляр класса квартир.

        private Users user = new Users(); // Экземпляр класса пользователей.

        private Orders order = new Orders(); // Экземпляр класса долговоров.

        public ManagerForm(EnterForm ef)
        {

            if (EnterForm.Gvars.gFlats != null) { flat = EnterForm.Gvars.gFlats; }
            if (EnterForm.Gvars.gUsers != null) { user = EnterForm.Gvars.gUsers; }
            if (EnterForm.Gvars.gOrders != null) { order = EnterForm.Gvars.gOrders; }

            InitializeComponent();
            ListFlat();
            ListUsers();

          
        }

          private void EditUser(string tp, int inx, string dt)
        {

            try
            {
                FileStream fs = new FileStream("Users.dat", FileMode.Open);

                BinaryFormatter formatter = new BinaryFormatter();

                user = (Users)formatter.Deserialize(fs);

                fs.Close();
                if (tp == "Ustatuss")
                {
                    user.Ustatuss[inx]= dt;
                }
                FileStream fs1 = new FileStream("Users.dat", FileMode.OpenOrCreate);

                BinaryFormatter formatter1 = new BinaryFormatter();
                formatter1.Serialize(fs1, user); // Сериализуем класс.
                fs1.Close();


            }
            catch { return; }
        }


        private void AddFlat() // Регистрируем квартиру.
        {

            int addflat = 1;
            if (addresTextBox.Text == "" || squareTextBox.Text == "" || numTextBox.Text == "" || rentTextBox.Text == "" || descrTextBox.Text == "" || statusTextBox.Text == "" || rateTextBox.Text == "")
            { MessageBox.Show("Все данные по квартире  необходимо заполнить!"); return; }
            if (flat.Adresses.Count > 0)
            {
                for (int i = 0; i < flat.Adresses.Count; i++) // перебираем квартиру если нет такого же адреса
                {
                    if (flat.Adresses[i] == addresTextBox.Text)
                    {
                        MessageBox.Show("Квартира с таким адресом уже есть!");
                        addflat = 0;
                        break;
                    }
                }
                    if (addflat==1) 
                    {

                        flat.Adresses.Add(addresTextBox.Text);
                        flat.Squares.Add(squareTextBox.Text);
                        flat.Nums.Add(numTextBox.Text);
                        flat.Rents.Add(rentTextBox.Text);
                        flat.Descrs.Add(descrTextBox.Text);
                        flat.Statuses.Add(statusTextBox.Text);
                        flat.Rates.Add(rateTextBox.Text);
                        // flat.Statuses.Add(Convert.ToString(0));

                        FileStream fs = new FileStream("Flats.dat", FileMode.OpenOrCreate);

                        BinaryFormatter formatter = new BinaryFormatter();
                        formatter.Serialize(fs, flat); // Сериализуем класс.

                        fs.Close();

                        addres = addresTextBox.Text;
                        square = squareTextBox.Text;

                        num = numTextBox.Text;
                        rent = rentTextBox.Text;
                        descr = descrTextBox.Text;
                        status = statusTextBox.Text;
                        rate = rateTextBox.Text;
                    // status = statusTextBox.Text;
                    MessageBox.Show("Квартира добавлена в список");
                    return;
                    //  this.Close();


                }
                
            }
            else
            {
                flat.Adresses.Add(addresTextBox.Text);
                flat.Squares.Add(squareTextBox.Text);
                flat.Nums.Add(numTextBox.Text);
                flat.Rents.Add(rentTextBox.Text);
                flat.Descrs.Add(descrTextBox.Text);
                flat.Statuses.Add(statusTextBox.Text);
                flat.Rates.Add(rateTextBox.Text);
                // flat.Statuses.Add(Convert.ToString(0));
                FileStream fs = new FileStream("Flats.dat", FileMode.OpenOrCreate);

                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, flat); // Сериализуем класс.

                fs.Close();

                addres = addresTextBox.Text;
                square = squareTextBox.Text;

                num = numTextBox.Text;
                rent = rentTextBox.Text;
                descr = descrTextBox.Text;
                status = statusTextBox.Text;
                rate = rateTextBox.Text;
                MessageBox.Show("Квартира добавлена в список");
                return;

            }



        }


        /**********************************************/
        public void ListFlat()
        {

            orderBtn.Visible = false;
            orderedBtn.Visible = false;

            FlatsListBox.DrawMode = DrawMode.OwnerDrawVariable;
            FlatsListBox.BackColor = Color.White;

            FlatsListBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(FlatsListBox_DrawItem);
            FlatsListBox.SelectedIndexChanged += new System.EventHandler(FlatsListBox_SelectedIndexChanged);
            //перенос
            FlatsListBox.MeasureItem += lst_MeasureItem;
            FlatsListBox.DrawItem += lst_DrawItem;/**/

            FlatsListBox.DrawItem +=
            new System.Windows.Forms.DrawItemEventHandler(
            FlatsListBox_DrawItem);

            FlatsListBox.Items.Clear();
            string stat = "";
            for (int i = 0; i < flat.Adresses.Count; i++) // 
            {
                if (flat.Statuses[i] == Convert.ToString(0))     { stat = " СВОБОДНА ";      }
                if (flat.Statuses[i] == Convert.ToString(1)) { stat = " ПОДАНА ЗАЯВКА "; }
                if (flat.Statuses[i] == Convert.ToString(2)) { stat = " ЗАКЛЮЧЁН ДОГОВОР "; }
                FlatsListBox.Items.Add("№" + i + " адрес: " + flat.Adresses[i] + " площадь:" + flat.Squares[i] + " | кол-во комнат: " + flat.Nums[i] + " | стоимость аренды/сутки: " + flat.Rents[i] + " | описание: " + flat.Descrs[i] + " " + stat + " | оценка: " + flat.Rates[i]);


            }
            if (flat.Adresses.Count > 0) { 
            FlatsListBox.SelectedIndex = 0;
            }
            return;
        }

        private void ListUsers()
        {

            banBtn.Visible = false;
            unbanBtn.Visible = false;
            
            /**/
            UsersListBox.DrawMode = DrawMode.OwnerDrawVariable;
            UsersListBox.BackColor = Color.White;

            //перенос
            UsersListBox.MeasureItem += Ust_MeasureItem;
            UsersListBox.DrawItem += Ust_DrawItem;


            UsersListBox.DrawItem +=
              new System.Windows.Forms.DrawItemEventHandler(UsersListBox_DrawItem);


             UsersListBox.Items.Clear();
            for (int i = 0; i < user.Logins.Count; i++) //
            {
                
                UsersListBox.Items.Add("№" + i + " login: " + user.Logins[i] + " ФИО: " + user.Usurnames[i] + " " + user.Unames[i] + " " + user.Umiddlenames[i] + " ДР: " + user.Ubdates[i] + " телефон: " + user.Uphones[i] + " статус: " + user.Ustatuss[i]);


            }
            UsersListBox.SelectedIndex = 0;
            return;
        }

        //прорисовка списка квартир с цветами
        private void FlatsListBox_DrawItem(object sender,
              System.Windows.Forms.DrawItemEventArgs e)
        {
            // Перерисовываем фон всех элементов ListBox.  
            e.DrawBackground();

            // Создаем объект Brush.  
            Brush myBrush = Brushes.Black;
            //нечётные заполняем фон
            if (e.Index % 2 == 0)
            {
                myBrush = Brushes.LightGray;
                e.Graphics.FillRectangle(myBrush, e.Bounds);

            }
            else
            {
                myBrush = Brushes.White;
                e.Graphics.FillRectangle(myBrush, e.Bounds);

            } /* */



            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                myBrush = Brushes.LightBlue;
                e.Graphics.FillRectangle(myBrush, e.Bounds);
                // Перерисовываем текст текущего элемента  
                //красим цвета в зависимости от статуса
                myBrush = Brushes.Black;
                int line = Int32.Parse(flat.Statuses[e.Index]);
                if (line == 1) { myBrush = Brushes.Red; }
                if (line == 2) { myBrush = Brushes.Green; }

                e.Graphics.DrawString(
                    ((ListBox)sender).Items[e.Index].ToString(),
                    e.Font, myBrush, e.Bounds,
                    StringFormat.GenericDefault);

            }
            else
            {
                myBrush = Brushes.Black;
                int line = Int32.Parse(flat.Statuses[e.Index]);
                if (line == 1) {  myBrush = Brushes.Red; }
                if (line == 2) { myBrush = Brushes.Green; }
                // Перерисовываем текст текущего элемента  
                e.Graphics.DrawString(
                    ((ListBox)sender).Items[e.Index].ToString(),
                    e.Font, myBrush, e.Bounds,
                    StringFormat.GenericDefault);
            }

        }

        //прорисовываем список пользователей
        private void UsersListBox_DrawItem(object sender,
             System.Windows.Forms.DrawItemEventArgs e)
        {
            // Перерисовываем фон всех элементов ListBox.  
            e.DrawBackground();

            // Создаем объект Brush.  
            Brush myBrush = Brushes.Black;
            // делаем фон для нечётных строк
            if (e.Index % 2 == 0)
            {
                myBrush = Brushes.LightGray;
                e.Graphics.FillRectangle(myBrush, e.Bounds);

            }
            else
            {
                myBrush = Brushes.White;
                e.Graphics.FillRectangle(myBrush, e.Bounds);

            } /* */


            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                myBrush = Brushes.LightBlue;
                e.Graphics.FillRectangle(myBrush, e.Bounds);
                // Перерисовываем текст текущего элемента  
                //в зависимости от статусу красим текст
                myBrush = Brushes.Black;
                int line = Int32.Parse(user.Ustatuss[e.Index]);
                if (line == 1) { myBrush = Brushes.Red; }
                if (line == 2) { myBrush = Brushes.Green; }

                e.Graphics.DrawString(
                    ((ListBox)sender).Items[e.Index].ToString(),
                    e.Font, myBrush, e.Bounds,
                    StringFormat.GenericDefault);

            }
            else
            {
                myBrush = Brushes.Black;
                int line = Int32.Parse(user.Ustatuss[e.Index]);
                if (line == 1) { myBrush = Brushes.Red; }
                if (line == 0) { myBrush = Brushes.Green; }
                // Перерисовываем текст текущего элемента  
                e.Graphics.DrawString(
                    ((ListBox)sender).Items[e.Index].ToString(),
                    e.Font, myBrush, e.Bounds,
                    StringFormat.GenericDefault);
            }

        }
        //высоту строки под отображение всег текста меняем
        private void lst_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = (int)e.Graphics.MeasureString(FlatsListBox.Items[e.Index].ToString(), FlatsListBox.Font, FlatsListBox.Width).Height;
        }

        private void lst_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (FlatsListBox.Items.Count > 0)
            {
                e.DrawBackground();
                e.DrawFocusRectangle();
                e.Graphics.DrawString(FlatsListBox.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds);
            }
        }

        private void Ust_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = (int)e.Graphics.MeasureString(UsersListBox.Items[e.Index].ToString(), UsersListBox.Font, UsersListBox.Width).Height;
        }

        private void Ust_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (UsersListBox.Items.Count > 0)
            {
                e.DrawBackground();
                e.DrawFocusRectangle();
                e.Graphics.DrawString(UsersListBox.Items[e.Index].ToString(), e.Font, new SolidBrush(e.ForeColor), e.Bounds);
            }
        }
        private void ManagerForm_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void addFlat_Click(object sender, EventArgs e)
        { 
         AddFlat();
         ListFlat();

           

        }

        //отображение кнопок в зависимости от статуса фокусной строки
        private void FlatsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //номер выделенной строки
            int ind = FlatsListBox.SelectedIndex;
            int line = Int32.Parse(flat.Statuses[ind]);
            if (line == 0)
            {
                orderBtn.Visible = false;
                orderedBtn.Visible = false;
            }
            if (line == 1) { 
            orderBtn.Visible = true;
            orderedBtn.Visible = false;
                }
            if (line == 2)
            {
                orderBtn.Visible = false;
                orderedBtn.Visible = true;
            }
            
        }

        //отображение кнопок в зависимости от статуса фокусной строки
        private void UsersListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //номер выделенной строки
            int ind = UsersListBox.SelectedIndex;
            int line = Int32.Parse(user.Ustatuss[ind]);
            if (line == 0)
            {
                banBtn.Visible = true;
                unbanBtn.Visible = false;
            }
            if (line == 1 )
            {
                banBtn.Visible = false;
                unbanBtn.Visible = true;
            }
            // MessageBox.Show(""+ind);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {

        }
        //редактировнаие заказа
        private void EditOrder(string tp, int inx, string dt)
        {

            try
            {
                FileStream fs = new FileStream("Orders.dat", FileMode.Open);

                BinaryFormatter formatter = new BinaryFormatter();

                order = (Orders)formatter.Deserialize(fs);

                fs.Close();
                if (tp == "Date1") { order.Date1[inx] = dt; }
                if (tp == "Date2") { order.Date2[inx] = dt; }

                if (tp == "FlatNum") { order.FlatNum[inx] = dt; }
                if (tp == "UserNum") { order.UserNum[inx] = dt; }
                if (tp == "Price") { order.Price[inx] = dt; }
                if (tp == "Status") { order.Status[inx] = dt; }

                FileStream fs1 = new FileStream("Orders.dat", FileMode.OpenOrCreate);

                BinaryFormatter formatter1 = new BinaryFormatter();
                formatter1.Serialize(fs1, order); // Сериализуем класс.
                fs1.Close();


            }
            catch { return; }
        }

        //одобрение заявки на договор
        private void button1_Click(object sender, EventArgs e)
        {
            /*******************************/
            var ord = new EnterForm();
            int ind = FlatsListBox.SelectedIndex;
            

            int fid = order.FlatNum.IndexOf(Convert.ToString(ind));
           
            if (order != null && fid != -1)
            {
                EditOrder("Status", ind, Convert.ToString(1));
                ord.EditFlat("Statuses", ind, Convert.ToString(2));
             
                ord.LoadOrders(); // Метод десериализует класс.
                ord.LoadFlats(); // Метод десериализует класс./* */
                if (EnterForm.Gvars.gFlats != null) { flat = EnterForm.Gvars.gFlats; }
                ListFlat();
            }

         }
        //блокировка пользователя
            private void banBtn_Click(object sender, EventArgs e)
        {
            var ef1 = new EnterForm();
            int ind = UsersListBox.SelectedIndex;
            EditUser("Ustatuss", ind, Convert.ToString(1));
            ef1.LoadUsers(); // Метод десериализует класс.
            UsersListBox.Items.Clear();
            
            ListUsers();
            UsersListBox.SelectedIndex = ind;
        }
        //разблокировка пользлвателя
        private void unbanBtn_Click(object sender, EventArgs e)
        {
            var ef1 = new EnterForm();
            int ind = UsersListBox.SelectedIndex;
            EditUser("Ustatuss", ind, Convert.ToString(0));
           ef1.LoadUsers(); // Метод десериализует класс.
            UsersListBox.Items.Clear();

            ListUsers();
            UsersListBox.SelectedIndex = ind;
            
        }

        private void Form1_FormClosing(object sender, FormClosedEventArgs e)
        {
           
           Application.Exit();
        }

        //показ договора
        private void orderedBtn_Click(object sender, EventArgs e)
        {
            /*****************/
            string ordertext = "";
            int ind = FlatsListBox.SelectedIndex;
            //int uid = user.Logins.IndexOf(registrationForm.login);

            int fid = order.FlatNum.IndexOf(Convert.ToString(ind));
            int uid = Int32.Parse(order.UserNum[fid]);


            if (order != null && fid != -1 )
            {

                ordertext = "Клиент: " + user.Usurnames[uid] + " " + user.Unames[uid] + " " + user.Umiddlenames[uid] + " \n" + "Логин: " + user.Logins[uid] + " телефон: " + user.Uphones[uid] + " \n" + "День рожденья: " + user.Ubdates[uid] + "\n";
                ordertext = ordertext + "-----------------------------------\n";
                ordertext = ordertext + "Квартира по адресу: " + flat.Adresses[ind] + " \n" + "Площадь: " + flat.Squares[ind] + "\n" + "Кол-во комнат: " + flat.Nums[ind] + "\n" + "Стоимость аренды в сутки: " + flat.Rents[ind] + "\n" + "Оценка: " + flat.Rates[ind] + "\n";
                ordertext = ordertext + "-----------------------------------\n";
                ordertext = ordertext + "Начало аренды: " + order.Date1[fid] + " \n" + "Окончание аренды: " + order.Date2[fid] + "\n" + "Сумма к уплате: " + order.Price[fid] + "\n";

                MessageBox.Show(ordertext);
            }
            else
            {
                MessageBox.Show("Доступ запрещён");
            }
        }
    }
}
