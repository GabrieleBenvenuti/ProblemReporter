using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemReporter
{
    public class Report
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Subscriber { get; set; }
        public bool IsFixed { get; set; }

        public Report(int id, string title, string description, DateTime date, string subscriber, bool isFixed)
        {
            ID = id;
            Title = title;
            Description = description;
            Date = date;
            Subscriber = subscriber;
            IsFixed = isFixed;
        }
    }
}
