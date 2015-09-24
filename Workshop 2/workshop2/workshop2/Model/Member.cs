using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace workshop2.Model
{
    class Member
    {
        string m_name;
        int p_number;
        int u_id;
        int unique = 1;

        public Member(string name, int personalNumber)
        {
            m_name = name;
            p_number = personalNumber;
            u_id = unique;
            unique++;
        }

        public string getName()
        {
            return m_name;
        }

        public int getPersonalNumber()
        {
            return p_number;
        }

        public int getID()
        {
            return u_id;
        }
    }
}
