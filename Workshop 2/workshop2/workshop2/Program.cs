using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace workshop2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Model.Member member = new Model.Member();
            Controller.SecretaryController s_controll = new Controller.SecretaryController();
            s_controll.run();
        }
    }
}
