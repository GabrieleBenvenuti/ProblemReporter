using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemReporter
{
    public class Client
    {
        static ICommunicator communicator = CommunicatorFactory.CreateCommunicator("Fake");

        
        public static IList<Report> GetAllReports()
        {
            return communicator.GetAllReports();
        }

        public static Report GetReport(int id)
        {
            return communicator.GetReport(id);
        }

        public static void SubmitReport(string title, string description)
        {
            communicator.SubmitReport(title, description);
        }

        public static void UpdateReport(int id, string title, string description, bool isFixed)
        {
            communicator.UpdateReport(id, title, description, isFixed);
        }

        public static void DeleteReport(int id)
        {
            communicator.DeleteReport(id);
        }

        public static string RetrieveUsername()
        {
            return "User";
        }
    }
}
