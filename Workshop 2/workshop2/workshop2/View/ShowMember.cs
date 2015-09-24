using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace workshop2.View
{
    class ShowMember
    {
        public ShowMember()
        {

        }

        public void show(Model.Member member)
        {
            Console.WriteLine("{0}, född {1} med unikt id {2}", member.getName(), member.getPersonalNumber(), member.getID());

        }
    }
}
