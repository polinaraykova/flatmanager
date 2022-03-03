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
    public partial class EnterForm : Form
    {

        public Flats flat = new Flats(); // Экземпляр класса квартир.
        public Users user = new Users(); // Экземпляр класса пользователей.
        public Orders order = new Orders(); // Экземпляр класса договоров.

        

        //глобальные переменные
        public static class Gvars
        {

            public static Flats gFlats { get; set; } // квартиры
            public static Users gUsers { get; set; } //пользователи
            public static Orders gOrders { get; set; } //договора
        }

        //загрузка квартир из файла
            public void LoadFlats()
            {
                try
                {
                    FileStream fs = new FileStream("Flats.dat", FileMode.Open);

                    BinaryFormatter formatter = new BinaryFormatter();

                    flat = (Flats)formatter.Deserialize(fs);

                    fs.Close();

                    Gvars.gFlats = flat;

                }
                catch { return; }
            }
        //загрузка польователей
        public void LoadUsers()
        {
            try
            {
                FileStream fs = new FileStream("Users.dat", FileMode.Open);

                BinaryFormatter formatter = new BinaryFormatter();

                user = (Users)formatter.Deserialize(fs);

                fs.Close();
                Gvars.gUsers = user;
            }
            catch { return; }
        }
        //редактировнаие квартиры
        public void EditFlat(string tp, int inx, string dt)
        {

            try
            {
                FileStream fs2 = new FileStream("Flats.dat", FileMode.Open);

                BinaryFormatter formatter2 = new BinaryFormatter();

                flat = (Flats)formatter2.Deserialize(fs2);
                fs2.Close();
                if (tp == "Statuses") { flat.Statuses[inx] = dt; }
                if (tp == "Rates") { flat.Rates[inx] = dt; }

                Gvars.gFlats = flat;
                FileStream fs3 = new FileStream("Flats.dat", FileMode.OpenOrCreate);

                BinaryFormatter formatter3 = new BinaryFormatter();
                formatter3.Serialize(fs3, flat); // Сериализуем класс.
                fs3.Close();


            }
            catch(FormatException) { return; }
        }
        //загрузка договоров
        public void LoadOrders()
        {
            try
            {
                FileStream fs = new FileStream("Orders.dat", FileMode.Open);

                BinaryFormatter formatter = new BinaryFormatter();

                order = (Orders)formatter.Deserialize(fs);

                fs.Close();
                Gvars.gOrders = order;

                /************/

                if (order != null && order.FlatNum.Count > 0)
                {
                    for (int i = 0; i < order.FlatNum.Count; i++) // перебираем договора для удаления просроченных
                    {

                        DateTime Date2 = DateTime.Parse(order.Date2[i]);
                        if (DateTime.Now > Date2)
                        {

                            EditFlat("Statuses", Int32.Parse(order.FlatNum[i]), Convert.ToString(0));

                            order.Date1.RemoveAt(i);
                            order.Date2.RemoveAt(i);
                            order.FlatNum.RemoveAt(i);
                            order.UserNum.RemoveAt(i);
                            order.Price.RemoveAt(i);
                            order.Status.RemoveAt(i);

                           FileStream fs1 = new FileStream("Orders.dat", FileMode.OpenOrCreate);

                            BinaryFormatter formatter1 = new BinaryFormatter();
                            formatter1.Serialize(fs1, order); // Сериализуем класс.
                            fs1.Close();
                            Gvars.gOrders = order;
                            LoadOrders();
                            LoadFlats();
                        }
                    }
                        /************/
                    }
                }
            catch { return; }
        }


        //вход на форму
        public EnterForm()
        {
            InitializeComponent();
            LoadOrders();
            LoadFlats();
            LoadUsers();
            
        }

        private void userEnter_Click(object sender, EventArgs e)
        {
            //при клике на кнопку вызывается форма для регистрации/входа пользователя
            //класс form 2 задаётся переменной Newform
            EnterForm ef = new EnterForm();
            this.Hide();
            RegForm newForm = new RegForm(ef);
            //показывается форма регистрации
            newForm.Show();
           

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void managerEnter_Click(object sender, EventArgs e)
        {

            //при клике на кнопку вызывается форма для менеджера
            EnterForm ef = new EnterForm();
            this.Hide();
            ManagerForm MForm = new ManagerForm(ef);
            //показывается форма
            MForm.Show();

        }
    }
}
