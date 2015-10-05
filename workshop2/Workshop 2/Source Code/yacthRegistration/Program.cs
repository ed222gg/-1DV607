using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yacthRegistration
{
    class Program
    {
        static void Main(string[] args)
        {
            Controller.Secretary secretary = new Controller.Secretary();
            secretary.run();
        }
    }
}
