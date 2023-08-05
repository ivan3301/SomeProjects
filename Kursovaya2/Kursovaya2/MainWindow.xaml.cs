using System;
using System.Windows;

namespace Kursovaya2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public class Persona // Базовый класс
    {
        public string status { get; set; } // Статус
        public string fio { get; set; } // Ф.И.О.
        public DateTime DOB { get; set; } // Дата рождения
        public Persona(string status, string fio, DateTime DOB)
        {
            this.status = status;
            this.fio = fio;
            this.DOB = DOB;
        }
    }

    public class Teacher : Persona // Наследующий класс Teacher
    {
        public string rank { get; set; } // Учебное звание
        public string kaf { get; set; } // Кафедра
        public Teacher(string status, string fio, DateTime DOB, string rank, string kaf)
            : base(status, fio, DOB)
        {
            this.rank = rank;
            this.kaf = kaf;
        }
    }

    public class Student : Persona // Наследующий класс Student
    {
        public string FOE { get; set; } // Форма обучения
        public string Group { get; set; } // Группа
        public float StudTime { get; set; } // Время обучения
        public string number { get; set; } // Номер студенческого
        public Student(string status, string fio, DateTime DOB, string FOE, string Group, float StudTime, string number)
            : base(status, fio, DOB)
        {
            this.FOE = FOE;
            this.Group = Group;
            this.StudTime = StudTime;
            this.number = number;
        }
    }

    public class GraduateStudent : Persona // Наследующий класс GraduateStudent
    {
        public float StudTime { get; set; } // Время обучения
        public string Topic { get; set; } // Тема диссертации
        public GraduateStudent(string status, string fio, DateTime DOB, float StudTime, string Topic)
            : base(status, fio, DOB)
        {
            this.StudTime = StudTime;
            this.Topic = Topic;
        }
    }
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Btn_Click_Stud(object sender, RoutedEventArgs e)
        {
            Students form = new Students();
            form.Show();
        }

        private void Btn_Click_Teach(object sender, RoutedEventArgs e)
        {
            Teachers form = new Teachers();
            form.Show();
        }

        private void Btn_Click_GS(object sender, RoutedEventArgs e)
        {
            GraduateStudents form = new GraduateStudents();
            form.Show();
        }
    }
}
