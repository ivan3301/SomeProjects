using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{

    class WorkWDate
    {
        private DateTime data;

        public WorkWDate()
        {
            data = new DateTime(2009, 1, 1);
        }

        public WorkWDate(string dSt)
        {
            data = DateTime.Parse(dSt);
        }

        public DateTime Yesterday() // метод для определения предыдущего дня
        {
            return data.Subtract(TimeSpan.FromDays(1));
        }

        public DateTime Tommorow() // метод для определения следующего дня
        {
            return data.Add(TimeSpan.FromDays(1));
        }

        public int MonthLeft() // метод для определения кол-ва дней до конца месяца
        {
            return DateTime.DaysInMonth(data.Year, data.Month) - data.Day;
        }

        public DateTime InputData // св-во, позволяющее установить или получить значение поле класса
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
            }
        }

        public bool IsLeap // св-во позволяющее определить год високосным
        {
            get
            {
                return DateTime.IsLeapYear(data.Year);
            }
        }

        public DateTime this[int i] // Индексатор, позволяющий определить дату i-того по счету дня относительно установленной даты
        {
            get
            {
                return data.AddDays(i);
            }
        }

        public static bool operator !(WorkWDate data) // возвращает true, если дата не является последним днем месяца
        {
            return !(DateTime.DaysInMonth(data.InputData.Year, data.InputData.Month) == data.InputData.Day);
        }

        public static bool operator true(WorkWDate d) // перегрузка константы true
        {
            if (d.data.Day == 1 && d.data.Month == 1)
                return true;
            else
                return false;
        }

        public static bool operator false(WorkWDate d) // перегрузка константы false
        {

            if (d.data.Day != 1 && d.data.Month != 1)
                return false;
            else
                return true;
        }

        public static bool operator &(WorkWDate obj1, WorkWDate obj2) // равенство полей
        {
            return Object.Equals(obj1.InputData, obj2.InputData);
        }
    }
}
