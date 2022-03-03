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
    public partial class RegForm : Form
    {
        RegistrationForm registrationForm = new RegistrationForm();
        public Flats flat = new Flats(); // Экземпляр класса квартир.
        private Users user = new Users(); // Экземпляр класса пользователей.
        private Orders order = new Orders(); // Экземпляр класса договоров.

        public RegForm(EnterForm f)
        {
            InitializeComponent();
  
            registrationForm.ShowDialog(); // Отображаем форму авторизации.

            dateTimePicker1.Value = DateTime.Today.AddDays(0);
            dateTimePicker1.MinDate = DateTime.Today.AddDays(0);
            dateTimePicker2.Value = DateTime.Today.AddDays(+1);
            dateTimePicker2.MinDate = DateTime.Today.AddDays(+1);


            if (EnterForm.Gvars.gFlats != null) { flat = EnterForm.Gvars.gFlats; }
            if (EnterForm.Gvars.gUsers != null) { user = EnterForm.Gvars.gUsers; }
            if (EnterForm.Gvars.gOrders != null) { order = EnterForm.Gvars.gOrders; }
            

            nameLabel.Text = "Здравствуйте, " + registrationForm.login + " " + registrationForm.surname + " " + registrationForm.name + " " + registrationForm.middlename;


        }

    private void RegForm_Load(object sender, EventArgs e)
        {
            EnterForm ef = new EnterForm();
            ManagerForm ManForm = new ManagerForm(ef);
            //получили список квартир
            if (EnterForm.Gvars.gFlats != null) { flat = EnterForm.Gvars.gFlats; }
            //построили список квартир
            ListFlat();
        }
        //редактировнаие квартиры
        public void EditFlat(string tp, int inx, string dt)
        {

            try
            {
                FileStream fs = new FileStream("Flats.dat", FileMode.Open);

                BinaryFormatter formatter = new BinaryFormatter();

                flat = (Flats)formatter.Deserialize(fs);

                fs.Close();
                if (tp == "Statuses")  {  flat.Statuses[inx] = dt; }
                if (tp == "Rates") { flat.Rates[inx] = dt; }
                
                FileStream fs1 = new FileStream("Flats.dat", FileMode.OpenOrCreate);

                BinaryFormatter formatter1 = new BinaryFormatter();
                formatter1.Serialize(fs1, flat); // Сериализуем класс.
                fs1.Close();


            }
            catch { return; }
        }


        private void AddOrder() // Регистрируем заявку.договор
        {
            var uid = user.Logins.IndexOf(registrationForm.login);
            int ind = FlatsListBox.SelectedIndex;
            

           int price = Int32.Parse(flat.Rents[ind]);
                        
            if (dateTimePicker2.Value < DateTime.Now)
            {
                MessageBox.Show("Дата окончания не должна быть меньше текущей!"); return;
            }

            if (dateTimePicker2.Value < dateTimePicker1.Value)
            {
                MessageBox.Show("Дата окончания не должна быть меньше начальной!"); return;
            }
            int days = (dateTimePicker2.Value - dateTimePicker1.Value).Days;
            if (days <= 0) { days = 1; }
              string rentprice = Convert.ToString(price*days);
            int addorder = 1;
            //добавляем квартиру проверяя ранее были уже квартиры или нет
            if (order != null && order.FlatNum.Count > 0)
            {
                for (int i = 0; i < order.FlatNum.Count; i++) // перебираем квартиру если нет такого же адреса
                {
                    if (order.FlatNum[i] == Convert.ToString(ind) && order.UserNum[i] == Convert.ToString(uid))
                    {
                       addorder = 0;
                        break;
                    }
                }
                 if (addorder == 1 ) { 
                   
                        if (flat.Statuses[ind] == Convert.ToString(0))
                    {
                        order.Date1.Add(dateTimePicker1.Value.ToString("dd/MM/yyyy HH:mm:ss"));
                        order.Date2.Add(dateTimePicker2.Value.ToString("dd/MM/yyyy HH:mm:ss"));
                        order.FlatNum.Add(Convert.ToString(ind));
                        order.UserNum.Add(Convert.ToString(uid));
                        order.Price.Add(rentprice);
                        order.Status.Add(Convert.ToString(0)); /* */

                        EditFlat("Statuses", ind, Convert.ToString(1));

                        using (FileStream fs = new FileStream("Orders.dat", FileMode.OpenOrCreate))
                        {
                            BinaryFormatter formatter = new BinaryFormatter();
                            formatter.Serialize(fs, order); // Сериализуем класс.

                            fs.Close();
                        }
                        MessageBox.Show("Заявка подана!");
                        // break;
                    }
                    else
                        {
                        MessageBox.Show("Заявка/договор на эту квартиру уже есть!");
                        return;
                        }

                   // }
                } else { MessageBox.Show("Заявка на эту квартиру уже есть!"); }

                
            }
            else
            {

                order.Date1.Add(dateTimePicker1.Value.ToString("dd/MM/yyyy HH:mm:ss"));
                order.Date2.Add(dateTimePicker2.Value.ToString("dd/MM/yyyy HH:mm:ss"));
                order.FlatNum.Add(Convert.ToString(ind));
                order.UserNum.Add(Convert.ToString(uid));
                order.Price.Add(rentprice);
                order.Status.Add(Convert.ToString(0)); /* */

                EditFlat("Statuses", ind, Convert.ToString(1));

                FileStream fs = new FileStream("Orders.dat", FileMode.OpenOrCreate);

                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, order); // Сериализуем класс.

                fs.Close();
                MessageBox.Show("Заявка подана!");
               // return;

            }
        }



        /**********************************************/
        public void ListFlat()
        {

            orderBtn.Visible = false;
            orderedBtn.Visible = false;
            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;

            FlatsListBox.DrawMode = DrawMode.OwnerDrawVariable;
            //FlatsListBox.DataSource = flat;
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
            string yourFlat = "";

            int uid = user.Logins.IndexOf(registrationForm.login);

            
            for (int i = 0; i < flat.Adresses.Count; i++) // 
            {
                int fid = order.FlatNum.IndexOf(Convert.ToString(i));
                if (order != null && fid != -1 && Int32.Parse(order.UserNum[fid]) == uid && flat.Statuses[i] != Convert.ToString(0)) {
                    yourFlat = " ВАМИ ";
                } else
                {
                    yourFlat = "";
                }

                        

                    if (flat.Statuses[i] == Convert.ToString(0)) { stat = " СВОБОДНА "; }
                    if (flat.Statuses[i] == Convert.ToString(1)) { stat = " ПОДАНА ЗАЯВКА "; }
                    if (flat.Statuses[i] == Convert.ToString(2)) { stat = " ЗАКЛЮЧЁН ДОГОВОР "; }
                    FlatsListBox.Items.Add("№" + i + " адрес: " + flat.Adresses[i] + " площадь:" + flat.Squares[i] + " | кол-во комнат: " + flat.Nums[i] + " | стоимость аренды/сутки: " + flat.Rents[i] + " | описание: " + flat.Descrs[i] + " " + yourFlat+ stat + " | оценка: " + flat.Rates[i]);


            }
            if (flat.Adresses.Count > 0)
            {
                FlatsListBox.SelectedIndex = 0;
            }
            return;
        }
        /***********/
        private void FlatsListBox_DrawItem(object sender,
                  System.Windows.Forms.DrawItemEventArgs e)
        {
            // Перерисовываем фон всех элементов ListBox.  
            e.DrawBackground();

            // Создаем объект Brush.  
            Brush myBrush = Brushes.Black;

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
                if (line == 1) { myBrush = Brushes.Red; }
                if (line == 2) { myBrush = Brushes.Green; }
                // Перерисовываем текст текущего элемента  
                e.Graphics.DrawString(
                    ((ListBox)sender).Items[e.Index].ToString(),
                    e.Font, myBrush, e.Bounds,
                    StringFormat.GenericDefault);
            }

            // Если ListBox в фокусе, рисуем прямоугольник   
            //вокруг активного элемента.  

        }

        private void UsersListBox_DrawItem(object sender,
             System.Windows.Forms.DrawItemEventArgs e)
        {
            // Перерисовываем фон всех элементов ListBox.  
            e.DrawBackground();

            // Создаем объект Brush.  
            Brush myBrush = Brushes.Black;

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

        /***************/
        //показ/скрытие кнопок в зависимости от квартиры и пользователя
        private void FlatsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //номер выделенной строки
            int ind = FlatsListBox.SelectedIndex;
            int line = Int32.Parse(flat.Statuses[ind]);
            int uid = user.Logins.IndexOf(registrationForm.login);
            int fid = order.FlatNum.IndexOf(Convert.ToString(ind));


            orderBtn.Visible = false;
            orderedBtn.Visible = false;
            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;
            label1.Visible = false;
            label2.Visible = false;

            /*  */
            if (line == 0 )
              {
                orderBtn.Visible = true;
                orderedBtn.Visible = false;
                dateTimePicker1.Visible = true;
                dateTimePicker2.Visible = true;

                label1.Visible = true;
                label2.Visible = true;
            }
              if (line == 1)
              {
                orderBtn.Visible = false;
                orderedBtn.Visible = false;
                dateTimePicker1.Visible = false;
                dateTimePicker2.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
            }
              if (line == 2)
              {

                    orderBtn.Visible = false;
                orderedBtn.Visible = false;
                dateTimePicker1.Visible = false;
                dateTimePicker2.Visible = false;
                label1.Visible = false;
                label2.Visible = false;

                if (order != null && fid != -1 && Int32.Parse(order.UserNum[fid]) == uid)
                {
                    orderBtn.Visible = false;
                    orderedBtn.Visible = true;
                    dateTimePicker1.Visible = false;
                    dateTimePicker2.Visible = false;
                    label1.Visible = false;
                    label2.Visible = false;
                }

            } /* */
            
        }
        //оценка квартир
        private void button1_Click(object sender, EventArgs e)
        {
            /**************/
            int ind = FlatsListBox.SelectedIndex;
            int rate = Int32.Parse(comboBox1.Text);
            int prevrate = Int32.Parse(flat.Rates[ind]);
            rate = ((rate + prevrate) / 2)+1;
            if (rate > 5) { rate = 5; }

            EditFlat("Rates", ind, Convert.ToString(rate));

            ListFlat();

            if (flat.Adresses.Count > 0)
            {
                FlatsListBox.SelectedIndex = ind;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void nameLabel_Click(object sender, EventArgs e)
        {

        }

        //отправка заявки на договор
        private void orderBtn_Click(object sender, EventArgs e)
        {
            /******************/
            AddOrder();
            
            var ord = new EnterForm();
            ord.LoadOrders(); // Метод десериализует класс.
            ord.LoadFlats(); // Метод десериализует класс.
            flat = EnterForm.Gvars.gFlats;
            ListFlat();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
        //просмотр договора
        private void orderedBtn_Click(object sender, EventArgs e)
        {
            /*****************/
            string ordertext = "";
            int ind = FlatsListBox.SelectedIndex;
            int uid = user.Logins.IndexOf(registrationForm.login);

            int fid = order.FlatNum.IndexOf(Convert.ToString(ind));



            if (order != null && fid !=-1 && Int32.Parse(order.UserNum[fid]) == uid) { 

            ordertext = "Клиент: " + user.Usurnames[uid] + " " + user.Unames[uid] + " " + user.Umiddlenames[uid] + " \n" + "Логин: " + user.Logins[uid] + " телефон: " + user.Uphones[uid] + " \n" + "День рожденья: " + user.Ubdates[uid] + "\n";
                ordertext = ordertext + "-----------------------------------\n";
             ordertext = ordertext + "Квартира по адресу: "+flat.Adresses[ind]+" \n"+ "Площадь: "+flat.Squares[ind]+"\n"+ "Кол-во комнат: "+flat.Nums[ind]+"\n"+"Стоимость аренды в сутки: "+flat.Rents[ind]+"\n"+"Оценка: "+flat.Rates[ind]+"\n";
                ordertext = ordertext + "-----------------------------------\n";
                ordertext = ordertext + "Начало аренды: " + order.Date1[fid] + " \n" + "Окончание аренды: " + order.Date2[fid] + "\n" + "Сумма к уплате: " + order.Price[fid] + "\n";

                MessageBox.Show(ordertext);
            }   else {
            MessageBox.Show("Доступ запрещён");
            }

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void RegForm_FormClosing(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

    }
}
