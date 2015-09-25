using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace workshop2.Model
{
    class Member
    {
        private string m_name;
        private string p_number;
        //private int u_id;
        //private int unique = 1;
        //private const string RegExForValidation = @"^(\d{6}|\d{8})[-|(\s)]{0,1}\d{4}$";
        Regex RegExForValidation = new Regex(@"^(\d{6}|\d{8})[-|(\s)]{0,1}\d{4}$");

        public string Name
        {
            get
            {
                return m_name;
            } 
            set
            {
                if (value.Length < 1)
                {
                    throw new ArgumentException("Du måste ange ett namn!");
                }
                m_name = value;
            }
        }

        public string PersonalNumber 
        { 
            get 
            {
                return p_number;
            }
            set 
            {
                if (!ssnValidation(value))
                {
                    throw new ArgumentException("Du måste ange ett giltligt personnummer");
                }
                p_number = value;
            }
        }

        public Member(string name, string personalNumber)
        {
            Name = name;
            PersonalNumber = personalNumber;
           // u_id = unique;
           // unique++;
        }

        public bool ssnValidation(string pnumber)
        {
            Match match = RegExForValidation.Match(pnumber);
            if (match.Success)
            {
                return true;
            }
            return false;
        }

        //public string getName()
        //{
        //    return m_name;
        //}

        //public int getPersonalNumber()
        //{
        //    return p_number;
        //}        
    }
}
