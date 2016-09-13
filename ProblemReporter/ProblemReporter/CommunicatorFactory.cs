using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProblemReporter
{
    public class CommunicatorFactory
    {
        public static ICommunicator CreateCommunicator(string type)
        {
            switch (type)
            {
                case "Fake":
                    return new FakeCommunicator();
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
