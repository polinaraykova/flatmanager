using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;

namespace Reg
{
    [Serializable]
    public class Orders // Класс, который хранит регистрационные данные.
    {
        public List<string> Date1 = new List<string>(); // адрес.
        public List<string> Date2 = new List<string>(); // площадь.


        public List<string> FlatNum = new List<string>(); // колво комнат.
        public List<string> UserNum = new List<string>(); // стоимость арнеды.
        public List<string> Price = new List<string>(); //Описания.

        public List<string> Status = new List<string>(); // Статусы.

       // public List<string> Ustatuss = new List<string>(); // Статусы.



    }
}
