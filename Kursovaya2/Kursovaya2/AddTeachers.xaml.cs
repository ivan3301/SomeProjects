using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;

namespace Kursovaya2
{
    /// <summary>
    /// Логика взаимодействия для AddTeachers.xaml
    /// </summary>
    public partial class AddTeachers : Window
    {
        public AddTeachers()
        {
            InitializeComponent();
        }

        private void Btn_Click_Add(object sender, RoutedEventArgs e)
        {
            try
            {
                string fileName = "..\\..\\files\\Persons.txt";
                StreamWriter sw = new StreamWriter(File.Open(fileName, FileMode.Append));
                sw.WriteLine("Преподаватель ; " + tb1.Text + " ; " + tb2.Text + " ; " + tb3.Text + " ; " + tb4.Text);
                sw.Close();

                MessageBox.Show("Добавлено успешно!");
            }
            catch
            {
                MessageBox.Show("Ошибка при дозаписи!");
            }
            tb1.Clear();
            tb2.Clear();
            tb3.Clear();
            tb4.Clear();
        }

        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
