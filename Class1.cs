using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public enum Status
    {
        NotStarted,
        Completed
    }
    public enum Importance
    {
        Important,
        NotImportant
    }
    public enum TaskType
    {
        Work,
        Study,
        Personal
    }
    [Serializable]
    public class Task
    {
        string name;
        DateTime date;
        DateTime time;
        Status status;
        Importance importance;
        TaskType type;

        public Task()
        {
            date = DateTime.Now;
        }
        public Task(string nameOfTask, DateTime d, TaskType t, Importance i)
        {
            status = Status.NotStarted;
            name = nameOfTask;
            date = d.Date;
            time = d;
            type = t;
            importance = i;
        }

        public string Name { get => name; set => name = value; }
        public DateTime Date { get => date; set => date = value; }
        public DateTime Time { get => time; set => time = value; }
        public Status Status { get => status; set => status = value; }

        public Importance Importance { get => importance; set => importance = value; }

        public TaskType Type { get  => type; set => type = value; }

        //переопределим ToString, чтобы контролы могли правильно отображать названия тасок
        public override string ToString()
        {
            if (importance == Importance.Important) return (name + " (" + time.ToShortTimeString() + ") " + "   ★");
            else return (name + " (" + time.ToShortTimeString() + ")     ");
        }
    }
}
