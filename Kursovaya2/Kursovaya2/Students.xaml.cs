using System;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.IO;

namespace Kursovaya2
{
    /// <summary>
    /// Логика взаимодействия для Students.xaml
    /// </summary>
    public partial class Students : Window
    {
        public Student[] masStud = new Student[] { };
        public Students()
        {
            InitializeComponent();
        }

        private void grid_Loaded(object sender, RoutedEventArgs e)
        {
            int i = 0;
            int t = 0;
            StreamReader f = new StreamReader("..\\..\\files\\Persons.txt", Encoding.GetEncoding("windows-1251"));
            string st;
            while (!f.EndOfStream)
            {
                st = f.ReadLine();
                string[] s = st.Split(';');
                if (s[0] == "Студент ")
                {
                    i++;
                    Array.Resize(ref masStud, masStud.Length + 1);
                    masStud[t] = new Student(s[0], s[1], DateTime.Parse(s[2]), s[3], s[4], float.Parse(s[5]), s[6]);
                    t++;
                }
            }
            f.Close();
            i--;
            grid.ItemsSource = masStud;
        }

        private void Btn_Click_AddStud(object sender, RoutedEventArgs e)
        {
            AddStudents form = new AddStudents();
            form.Show();
        }

        private void Btn_Click_Upd(object sender, RoutedEventArgs e)
        {
            Array.Resize(ref masStud, 0);
            grid.ItemsSource = null;
            grid.Items.Refresh();
            int i = 0;
            int t = 0;
            StreamReader f = new StreamReader("..\\..\\files\\Persons.txt", Encoding.GetEncoding("windows-1251"));
            string st;
            while (!f.EndOfStream)
            {
                st = f.ReadLine();
                string[] s = st.Split(';');
                if (s[0] == "Студент ")
                {
                    i++;
                    Array.Resize(ref masStud, masStud.Length + 1);
                    masStud[t] = new Student(s[0], s[1], DateTime.Parse(s[2]), s[3], s[4], float.Parse(s[5]), s[6]);
                    t++;
                }
            }
            f.Close();
            i--;
            grid.ItemsSource = masStud;
        }

        private void Btn_Click_Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnAdd_MEnter(object sender, MouseEventArgs e)
        {
            CursorPos.Text = "Добавить нового студента";
        }
        private void BtnAdd_MLeave(object sender, MouseEventArgs e)
        {
            CursorPos.Text = "";
        }
        private void BtnUpd_MEnter(object sender, MouseEventArgs e)
        {
            CursorPos.Text = "Обновить таблицу";
        }
        private void BtnUpd_MLeave(object sender, MouseEventArgs e)
        {
            CursorPos.Text = "";
        }
        private void BtnSave_MEnter(object sender, MouseEventArgs e)
        {
            CursorPos.Text = "Сохранить список студентов в файл";
        }
        private void BtnSave_MLeave(object sender, MouseEventArgs e)
        {
            CursorPos.Text = "";
        }
        private void BtnClose_MEnter(object sender, MouseEventArgs e)
        {
            CursorPos.Text = "Закрыть окно";
        }
        private void BtnClose_MLeave(object sender, MouseEventArgs e)
        {
            CursorPos.Text = "";
        }

        private void Btn_Click_Save(object sender, RoutedEventArgs e)
        {
            FileStream fs = new FileStream("..\\..\\files\\saves\\Students.txt", FileMode.Create);
            StreamWriter streamWriter = new StreamWriter(fs);
            try
            {
                for (int j = 0; j < masStud.Length; j++)
                {
                    string stroka1 = masStud[j].status + ";" + masStud[j].fio + ";" + masStud[j].DOB.ToShortDateString() + ";" +
                        masStud[j].FOE + ";" + masStud[j].Group + ";" + masStud[j].StudTime + ";" + masStud[j].number;
                    streamWriter.WriteLine(stroka1);
                }

                streamWriter.Close();
                fs.Close();

                MessageBox.Show("Файл успешно сохранен");
            }
            catch
            {
                MessageBox.Show("Ошибка при сохранении файла!");
            }
        }
    }
}
