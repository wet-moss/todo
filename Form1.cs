using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace WindowsFormsApp1
{
    public partial class MainForm : Form
    {
        //----------- атрибуты --------------//

        List<Task> tasks;
        DateTime selectedDateStart = DateTime.Now;
        DateTime selectedDateEnd = DateTime.Now;
        bool flag = true; //чекбокс/листбокс

        //--------------- открытие программы ---------------//
        public MainForm()
        {
            InitializeComponent();
            tasks = new List<Task>();
            Deserialize();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            flag = true;
            ShowChecklist();
            ShowListBox();
            UpdateBoldedDates(myCalendar);
            checkedListBox1.Visible = flag;
            listBox1.Visible = !flag;
            cb_work.Visible = cb_study.Visible = cb_personal.Visible = !flag;
            cb_work.CheckState = cb_study.CheckState = cb_personal.CheckState = CheckState.Checked;
            label1.Text = "Задания на сегодня: ";
        }

        private void SortTasks()
        {
            tasks = tasks.OrderBy(x => x.Status).ThenBy(x => x.Date.Date).ThenBy(x => x.Importance).ThenBy(x => x.Time.TimeOfDay).ThenBy(x => x.Type).ThenBy(x => x.Name).ToList();
        }

        private void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            selectedDateStart = e.Start.Date;
            selectedDateEnd = e.End.Date;
            ShowChecklist(selectedDateStart, selectedDateEnd); //показывает чеклист на выбранный промежуток/день
            ShowListBox(selectedDateStart, selectedDateEnd);
            switch (selectedDateStart == selectedDateEnd) //отображает надпись с заданием
            {
                case (true):
                    if (selectedDateStart != DateTime.Now.Date)
                        label1.Text = "Задания на " + selectedDateEnd.ToShortDateString();
                    else
                        label1.Text = "Задания на сегодня";
                    break;
                case (false):
                    label1.Text = "Задания на " + selectedDateStart.ToShortDateString() + " - " + selectedDateEnd.ToShortDateString();
                    break;
            }
        }

        private void UpdateBoldedDates(MonthCalendar monthCalendar)
        {
            List<DateTime> dates = new List<DateTime>();
            foreach (Task t in tasks)
            {
                if (!dates.Contains(t.Date))
                {
                    dates.Add(t.Date);
                }
            }
            myCalendar.BoldedDates = dates.ToArray();
        }

        //------------------- чек-лист -------------------------//

        private void ShowChecklist(DateTime taskDateStart, DateTime taskDateEnd)
        {
            checkedListBox1.Items.Clear();
            SortTasks();
            checkedListBox1.ItemCheck -= checkedListBox1_ItemCheck; //отписка от ивента ItemCheck во время проставления
                                                                    //статуса 'checked' в коде
            foreach (Task t in tasks)
            {
                if (t.Date.Date >= taskDateStart.Date && t.Date.Date <= taskDateEnd.Date)
                {
                    checkedListBox1.Items.Add(t);
                    checkedListBox1.SetItemChecked(checkedListBox1.Items.IndexOf(t), t.Status == Status.Completed);
                }

            }
            checkedListBox1.ItemCheck += checkedListBox1_ItemCheck; //подписываемся обратно      
        }

        private void ShowChecklist()
        {
            ShowChecklist(DateTime.Now, DateTime.Now);
        }

        private void checkedListBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                Task t = (checkedListBox1.SelectedItem as Task);
                tasks.Remove(t);
                ShowChecklist(myCalendar.SelectionStart, myCalendar.SelectionEnd);
                UpdateBoldedDates(myCalendar);
            }
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            Task t = (checkedListBox1.Items[e.Index] as Task);
            if (e.NewValue == CheckState.Checked)
            {
                t.Status = Status.Completed;
            }
            else
            {
                t.Status = Status.NotStarted;
            }
            SortTasks();
            ShowChecklist(selectedDateStart, selectedDateEnd);
            BeginInvoke(new Action(() => { ShowChecklist(selectedDateStart, selectedDateEnd); }));
            //метод ставится в очередь выполнения, а не выполняется моментально
        }

        //-------------------- листбокс -----------------------//

        private void ShowListBox(DateTime taskDateStart, DateTime taskDateEnd)
        {
            listBox1.Items.Clear();
            foreach (Task t in tasks)
            {
                if (t.Date.Date >= taskDateStart.Date && t.Date.Date <= taskDateEnd.Date)
                {
                    if (t.Type == TaskType.Work && cb_work.Checked)
                    {
                    listBox1.Items.Add(t);
                    }
                    if (t.Type == TaskType.Study && cb_study.Checked)
                    {
                        listBox1.Items.Add(t);
                    }
                    if (t.Type == TaskType.Personal && cb_personal.Checked)
                    {
                        listBox1.Items.Add(t);
                    }
                }
            }
            SortTasks();
            listBox1.DrawMode = DrawMode.OwnerDrawFixed;
            listBox1.DrawItem += new DrawItemEventHandler(ListBox1_DrawItem);
        }

        private void ShowListBox()
        {
            SortTasks();
            ShowListBox(DateTime.Now.Date, DateTime.Now.Date);
        }

        private void ListBox1_DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            if (e.Index == -1) { return; }
            e.DrawBackground();
            Graphics g = e.Graphics;
            Brush myBrush = (e.State & DrawItemState.Selected) != DrawItemState.Selected ?
                  new SolidBrush(e.BackColor) : new SolidBrush(Color.FromArgb(237, 241, 224));
            g.FillRectangle(myBrush, e.Bounds);
            Task t = new Task();

            t = listBox1.Items[e.Index] as Task;
            switch (t.Type)
            {
                case TaskType.Work:
                    myBrush = new SolidBrush(Color.FromArgb(30, 21, 11));
                    break;
                case TaskType.Study:
                    myBrush = new SolidBrush(Color.FromArgb(201, 148, 24));
                    break;
                case TaskType.Personal:
                    myBrush = new SolidBrush(Color.FromArgb(153, 92, 136));
                    break;
            }
            Font f = new Font(e.Font.FontFamily, e.Font.Size, FontStyle.Strikeout);
            if (t.Status == Status.Completed)
            {
                e.Graphics.DrawString(listBox1.Items[e.Index].ToString(),
                f, myBrush, e.Bounds, StringFormat.GenericDefault);
            }
            else
            {
                e.Graphics.DrawString(listBox1.Items[e.Index].ToString(),
                e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);
            }
            e.DrawFocusRectangle();
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                Task t = (listBox1.SelectedItem as Task);
                tasks.Remove(t);
                ShowListBox(myCalendar.SelectionStart, myCalendar.SelectionEnd);
                UpdateBoldedDates(myCalendar);
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            Task t = listBox1.SelectedItem as Task;
            if (t.Status == Status.Completed)
                t.Status = Status.NotStarted;
            else
                t.Status = Status.Completed;
            SortTasks();
            ShowListBox(myCalendar.SelectionStart, myCalendar.SelectionEnd);
        }

        //---------------- взаимодействие с кнопками ---------------------//

        private void button1_Click(object sender, EventArgs e)
        {

            SubForm form = new SubForm(selectedDateStart, selectedDateEnd); //создаётся новая форма типа Form2
            if (form.ShowDialog(this) == DialogResult.OK) //создаётся новый диалог, и если нажимется ок, то...
            {
                if (form.repeat == 0) //если количество повторений 1, то добавляется один таск
                {
                    tasks.Add(form.task);
                }
                else //если количество повторений 2
                {
                    for (int i = 0; i <= form.repeat; i++)
                    {
                        Task t = new Task();
                        t.Name = form.task.Name;
                        t.Date = form.task.Date.AddDays(i);
                        t.Time = form.task.Time;
                        t.Status = form.task.Status;
                        t.Importance = form.task.Importance;
                        t.Type = form.task.Type;
                        tasks.Add(t);
                    }
                }
                UpdateBoldedDates(myCalendar);
                ShowChecklist(myCalendar.SelectionStart, myCalendar.SelectionEnd);
                ShowListBox(myCalendar.SelectionStart, myCalendar.SelectionEnd);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            flag = !flag;
            checkedListBox1.Visible = flag;
            listBox1.Visible = !flag;
            cb_work.Visible = cb_study.Visible = cb_personal.Visible = !flag;
        }

        private void cb_study_CheckedChanged(object sender, EventArgs e)
        {
            ShowListBox(selectedDateStart, selectedDateEnd);
        }

        private void cb_personal_CheckedChanged(object sender, EventArgs e)
        {
            ShowListBox(selectedDateStart, selectedDateEnd);
        }

        private void cb_work_CheckedChanged(object sender, EventArgs e)
        {
            ShowListBox(selectedDateStart, selectedDateEnd);
        }

        //--------------------- контекстное меню -----------------//

        private void contextMenu_Opening(object sender, CancelEventArgs e)
        {
            Task t;
            if (checkedListBox1.Visible)
            {
                t = checkedListBox1.SelectedItem as Task;
            }
            else
            {
                t = listBox1.SelectedItem as Task;
            }
            if (t != null)
                    if (t.Importance == Importance.Important)
                    {
                        Imp.CheckState = CheckState.Checked;
                    }
                    else
                    {
                        Imp.CheckState = CheckState.Unchecked;
                    }
            else
            Imp.CheckState = CheckState.Indeterminate;
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            if (flag)
            {
                if (checkedListBox1.SelectedItem != null)
                {
                    SubForm form = new SubForm(checkedListBox1.SelectedItem as Task);
                    if (form.ShowDialog(this) == DialogResult.OK) //создаётся новый диалог, и если нажимется ок, то...
                    {
                    }
                    UpdateBoldedDates(myCalendar);
                    SortTasks();
                    ShowChecklist(myCalendar.SelectionStart, myCalendar.SelectionEnd);
                }
                else
                {
                    DialogResult result;
                    result = MessageBox.Show("Выберите нужную задачу", "Error", MessageBoxButtons.OK);
                }
            }
            else
            {
                if (listBox1.SelectedItem != null)
                {
                    SubForm form = new SubForm(listBox1.SelectedItem as Task);
                    if (form.ShowDialog(this) == DialogResult.OK) //создаётся новый диалог, и если нажимется ок, то...
                    {
                        //tasks.Remove(listBox1.SelectedItem as Task);
                        //tasks.Add(listBox1.SelectedItem as Task);
                    }
                    UpdateBoldedDates(myCalendar);
                    SortTasks();
                    ShowListBox(myCalendar.SelectionStart, myCalendar.SelectionEnd);
                }
                else
                {
                    DialogResult result;
                    result = MessageBox.Show("Выберите нужную задачу", "Error", MessageBoxButtons.OK);
                }

            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (flag)
            {
                if (checkedListBox1.SelectedItem != null)
                {
                    tasks.Remove(checkedListBox1.SelectedItem as Task);
                    UpdateBoldedDates(myCalendar);
                    SortTasks();
                    ShowChecklist(myCalendar.SelectionStart, myCalendar.SelectionEnd);
                }
                else
                {
                    DialogResult result;
                    result = MessageBox.Show("Выберите нужную задачу", "Error", MessageBoxButtons.OK);
                }
            }
            else
            {
                if (listBox1.SelectedItem != null)
                {
                    SubForm form = new SubForm(listBox1.SelectedItem as Task);

                    tasks.Remove(listBox1.SelectedItem as Task);
                    UpdateBoldedDates(myCalendar);
                    SortTasks();
                    ShowListBox(myCalendar.SelectionStart, myCalendar.SelectionEnd);
                }
                else
                {
                    DialogResult result;
                    result = MessageBox.Show("Выберите нужную задачу", "Error", MessageBoxButtons.OK);
                }

            }
        }

        private void Imp_Click(object sender, EventArgs e)
        {
            if (flag)
            {
                if (checkedListBox1.SelectedItem != null)
                {
                    if ((checkedListBox1.SelectedItem as Task).Importance == Importance.Important)
                        (checkedListBox1.SelectedItem as Task).Importance = Importance.NotImportant;
                    else (checkedListBox1.SelectedItem as Task).Importance = Importance.Important;

                    SortTasks();
                    ShowChecklist(myCalendar.SelectionStart, myCalendar.SelectionEnd);
                }
                else
                {
                    DialogResult result;
                    result = MessageBox.Show("Выберите нужную задачу", "Error", MessageBoxButtons.OK);
                }
            }
            else
            {
                if (listBox1.SelectedItem != null)
                {
                    if ((listBox1.SelectedItem as Task).Importance == Importance.Important)
                        (listBox1.SelectedItem as Task).Importance = Importance.NotImportant;
                    else (listBox1.SelectedItem as Task).Importance = Importance.Important;

                    SortTasks();
                    ShowListBox(myCalendar.SelectionStart, myCalendar.SelectionEnd);
                }
                else
                {
                    DialogResult result;
                    result = MessageBox.Show("Выберите нужную задачу", "Error", MessageBoxButtons.OK);
                }

            }
        }

        //---------------- завершение программы ---------------------//

        private void Serialize()
        {
            Stream stream = File.Open("tasks.txt", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(stream, tasks);
            stream.Close();
        }

        private void Deserialize()
        {
            Stream stream = File.OpenRead("tasks.txt");
            BinaryFormatter bf = new BinaryFormatter();
            tasks = (List<Task>)bf.Deserialize(stream);
            stream.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Serialize();
        }
    }
}



