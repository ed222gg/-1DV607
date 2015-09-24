using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace workshop2.Controller
{
    class SecretaryController
    {
        public void run()
        {
            View.StartMenu s_menu = new View.StartMenu();
            s_menu.show();
            string key = Console.ReadKey().KeyChar.ToString();
            int value;
            int.TryParse(key, out value);
            switch (value)
            {
                case 1: createMember();
                    break;
                case 2: Console.WriteLine("Knapp 2 tryck!");
                    break;
                case 3: Console.WriteLine("Knapp 3 tryck!");
                    break;
                case 4: Console.WriteLine("Knapp 4 tryck!");
                    break;
                default:
                    break;
            }
        }

        public void createMember()
        {
            View.CreateMember createM = new View.CreateMember();
            createM.enterName();
            string name = Console.ReadLine();
            createM.enterPersonalNumber();
            int personalNumber = int.Parse(Console.ReadLine());
            
            //Model.Member e_member = new Model.Member("Emilia Drake", 890419);
            //Model.Member s_member = new Model.Member("Stoffe Svensson", 910213);
            //View.ShowMember v_showMember = new View.ShowMember();
            //v_showMember.show(e_member);
            //v_showMember.show(s_member);
        }


    }
}
