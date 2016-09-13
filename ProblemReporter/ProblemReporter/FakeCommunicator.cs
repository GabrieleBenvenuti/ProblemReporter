using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemReporter
{
    public class FakeCommunicator : ICommunicator
    {
        private List<Report> Reports { get; set; }

        public FakeCommunicator() : base()
        {
            Reports = new List<Report>();
        }

        public void DeleteReport(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Report> GetAllReports()
        {
            return Reports;
        }

        public Report GetReport(int id)
        {
            return Reports[id];
        }

        public void SubmitReport(string title, string description)
        {
            Report report = new Report(Reports.Count, title, description, DateTime.Now, Client.RetrieveUsername(), false);
            Reports.Add(report);
        }

        public void UpdateReport(int id, string title, string description, bool isFixed)
        {
            var report = Reports[id];
            report.Title = title;
            report.Description = description;
            report.IsFixed = isFixed;
            report.Date = DateTime.Now;
        }
    }
}
