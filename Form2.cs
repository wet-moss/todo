using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace WindowsFormsApp1
{
    public partial class SubForm : Form
    {
        //----------- переменные --------------//

        public double repeat = 0;
        public Task task; 
        bool flag = false; // Add/Edit

        //---------------------------------------------------------//

        public SubForm()
        {
            InitializeComponent();
        }

        //перегрузка для Add
        public SubForm(DateTime dataStart, DateTime dataEnd)
        {
            flag = false;
            task = new Task(" ", dataStart, TaskType.Personal, Importance.NotImportant);
            task.Time = DateTime.Now;
            InitializeComponent();
            repeat = (dataEnd - dataStart).TotalDays;
        }

        //перегрузка для Edit
        public SubForm(Task t)
        {
            flag = true;
            task = t;
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (flag)
            {
                numericUpDown1.Visible = false;
                label4.Visible = false;
                label3.Visible = false;
                checkBox2.Visible = true;
                this.Text = "Edit";
            }
            else
            {
                numericUpDown1.Visible = true;
                label4.Visible = true;
                label3.Visible = true;
                checkBox2.Visible = false;
                this.Text = "Add task";
            }
            if (repeat == 0)
            {
                numericUpDown1.Value = 1;
            }
            else
            {
                numericUpDown1.Value = (decimal)repeat + 1;
            }

            textBox1.Text = task.Name.ToString();
            dateTimePicker1.Value = task.Date.Date;
            dateTimePicker2.Value = task.Time;
            checkBox1.Checked = (task.Importance == Importance.Important);
            checkBox2.Checked = (task.Status == Status.Completed);
            switch (task.Type)
            {
                case TaskType.Work:
                comboBox1.SelectedIndex = 0;
                    break;
                case TaskType.Study: comboBox1.SelectedIndex = 1;
                    break;
                case TaskType.Personal: comboBox1.SelectedIndex = 2;
                    break;
            }
            label4.Text = "До " + task.Date.AddDays(repeat).ToShortDateString();
        }

        //---------------------------------------------------------//

        //изменяется имя
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            task.Name = textBox1.Text;
        }
        
        // когда выбирается новая дата
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            task.Date = dateTimePicker1.Value;
            label4.Text = "До " + (task.Date.AddDays(repeat)).ToShortDateString();
        }

        // изменение количества повторов
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            repeat = decimal.ToDouble(numericUpDown1.Value) - 1;
            label4.Text = "До " + (task.Date.AddDays(repeat)).ToShortDateString();
        }

        //изменение времени
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            task.Time = dateTimePicker2.Value;
        }

        //изменение важности
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) { task.Importance = Importance.Important; }
            else { task.Importance = Importance.NotImportant;}
        }

        //изменение типа
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0) { task.Type = TaskType.Work; }
            else if (comboBox1.SelectedIndex == 1) {  task.Type = TaskType.Study; }
            else { task.Type = TaskType.Personal; }
        }

        //изменение статуса
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked) { task.Status = Status.Completed; }
            else { task.Status = Status.NotStarted; }
        }

    }
}
