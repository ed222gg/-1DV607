using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace workshop2.View
{
    class ConsollView
    {
        public void show()
        {

            Console.WriteLine("Välkommen!");
            Console.WriteLine("Tryck 1 för att lägga till ny medlem");
            Console.WriteLine("Tryck 2 för att ta bort medlem");
            Console.WriteLine("Tryck 3 för att ändra medlem");
            Console.WriteLine("Tryck 4 för att visa medlem");
            Console.WriteLine("Tryck valfri knapp för att avsluta");

        }
        public void enterName()
        {
            Console.Clear();
            Console.Write("Ange namn på ny medlem: ");
        }
        public void enterPersonalNumber()
        {
            Console.Write("Ange personens personnummer: ");
        }

         public void ShowMember()
        {
             
        }

        public void show(Model.Member member)
        {
            Console.WriteLine("{0}, född {1} med unikt id {2}", member.Name, member.PersonalNumber);

        }
    }
}
