using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace workshop2.Controller
{
    class SecretaryController
    {
        View.ConsollView s_menu = new View.ConsollView();
        Model.textDAL text_dal = new Model.textDAL();

        public void run()
        {
            bool loopRuns = true;
            do
            {
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
                    default: loopRuns = false;                 //TODO! fixa så att programmet avslutar med q
                        break;
                }

            } while (loopRuns == true);            
        }

        public void createMember()
        {

             // gaaah nu har jag tappat bort mig vad jag håller på med
            s_menu.enterName();        // allt ligger i klassen ConsollView i olika metoder men vart ska man skapa klassen?
            try
            {
                string name = Console.ReadLine();
                s_menu.enterPersonalNumber();
                string personalNumber = Console.ReadLine();
                Model.Member member = new Model.Member(name, personalNumber);
                text_dal.saveMember();
            }
            catch(Exception e)
            {
                
                 Console.WriteLine(e.Message);//anropa tex ShowDisplayMessage för utskrift av meddelanden
                 Console.ReadKey();
                 Console.Clear(); 
            }
            
            
            //Model.Member e_member = new Model.Member("Emilia Drake", 890419);
            //Model.Member s_member = new Model.Member("Stoffe Svensson", 910213);
            //View.ShowMember v_showMember = new View.ShowMember();
            //v_showMember.show(e_member);
            //v_showMember.show(s_member);
        }


    }
}
