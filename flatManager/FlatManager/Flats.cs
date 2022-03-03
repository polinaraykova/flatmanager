using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;

namespace Reg
{
    [Serializable]
    public class Flats // Класс, который хранит регистрационные данные.
    {
        public List<string> Adresses = new List<string>(); // адрес.
        public List<string> Squares = new List<string>(); // площадь.


        public List<string> Nums = new List<string>(); // колво комнат.
        public List<string> Rents = new List<string>(); // стоимость арнеды.
        public List<string> Descrs = new List<string>(); //Описания.

        public List<string> Statuses = new List<string>(); // Статусы.
        public List<string> Rates = new List<string>(); // Оценки.

       // public List<string> Ustatuss = new List<string>(); // Статусы.



    }
}
