using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i;
            WorkWDate d = new WorkWDate();
            textBox1.Text = Convert.ToString(d.InputData);
            textBox2.Text = Convert.ToString(d.Yesterday());
            textBox3.Text = Convert.ToString(d.Tommorow());
            textBox4.Text = Convert.ToString(d.MonthLeft());
            if (d.IsLeap) textBox5.Text = ("Да");
            else textBox5.Text = ("Нет");
            i = Convert.ToInt32(textBox30.Text);
            textBox13.Text = Convert.ToString(d[i]);
            if (!(d)) textBox14.Text = ("Не является");
            else textBox14.Text = ("Является");
            if (d) textBox15.Text = ("Дата является началом года");
            else textBox15.Text = ("Дата не является началом года");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string st1;
            st1 = textBox6.Text;
            WorkWDate D = new WorkWDate(st1);
            textBox11.Text = Convert.ToString(D.InputData);
            textBox7.Text = Convert.ToString(D.Yesterday());
            textBox8.Text = Convert.ToString(D.Tommorow());
            textBox9.Text = Convert.ToString(D.MonthLeft());
            if (D.IsLeap) textBox10.Text = ("Да");
            else textBox10.Text = ("Нет");

            int i = Convert.ToInt32(textBox30.Text);
            textBox16.Text = Convert.ToString(D[i]);
            if (!(D)) textBox17.Text = ("Не является");
            else textBox17.Text = ("Является");
            if (D) textBox18.Text = ("Дата является началом года");
            else textBox18.Text = ("Дата не является началом года");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox30.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();

            textBox1.Clear();
            textBox13.Clear();
            textBox14.Clear();
            textBox15.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox11.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();

            textBox16.Clear();
            textBox17.Clear();
            textBox18.Clear();
            textBox19.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string st1;
            st1 = textBox6.Text;
            WorkWDate D = new WorkWDate(st1);
            WorkWDate d = new WorkWDate();
            if (d & D) textBox19.Text = ("Поля равны");
            else textBox19.Text = ("Поля не равны");
        }
    }
}
