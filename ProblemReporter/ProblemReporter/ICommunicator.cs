using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemReporter
{
    public interface ICommunicator
    {
        IList<Report> GetAllReports();
        Report GetReport(int id);
        void SubmitReport(string title, string description);
        void UpdateReport(int id, string title, string description, bool isFixed);
        void DeleteReport(int id);
    }
}
