using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yacthRegistration.View
{
    class yachtConsole
    {
        public void menuShow()
        {
            Console.WriteLine("Välkommen!");
            Console.WriteLine("Tryck 1 för att lägga till ny medlem");
            Console.WriteLine("Tryck 2 för att ta bort medlem");
            Console.WriteLine("Tryck 3 för att ändra medlem");
            Console.WriteLine("Tryck 4 för att visa medlemmar");
            Console.WriteLine("Tryck 5 för att lägga till båtar");
            Console.WriteLine("Tryck 6 för att ändra båtar");
            Console.WriteLine("Tryck valfri knapp för att avsluta");   
        }

        public void enterName()
        {
            Console.Write("Ange namn på medlem: ");
        }

        public void enterPersonalNumber()
        {
            Console.Write("Ange personens personnummer: ");
        }

        public void listMembers(List<Model.Member> memberlist)
        {
            string output;
            int pos = 1;
            foreach (Model.Member member in memberlist)
            {
                output = string.Format("{2} - {0}\nPersonnummer: {1}\nUnik id = {3}\nAntal båtar: {4}\n", member.Name, member.Ssn, pos, member.Id.ToString(), member.Boats.Count);
                Console.WriteLine(output);
                pos++;
            }
        }

        public void deleteMember(List<Model.Member> memberlist)
        {
            listMembers(memberlist);
            Console.WriteLine("\n Vilken medlem skall tas bort? Skriv in positions siffran...");
        }

        public void showMember(Model.Member member)
        {
            Console.Clear();
            string output = String.Format("Namn: {0}\nPersonnummer: {1}\nUnik ID: {2}\nAntal Båtar: {3}\n", member.Name, member.Ssn, member.Id, member.Boats.Count);

            foreach (Model.Boat boat in member.Boats)
            {
                output += String.Format("\nTyp: {0}\nLängd: {1}\n", boat.BoatType, boat.Length);
            }
            Console.WriteLine(output);
        }

        public void BoatTypes()
        {
        }

        public void listBoatTypes(Object value, int pos)
        {
            string output = String.Format("{0}: {1}", pos, value);
            Console.WriteLine(output);
        }

        public void enterBoatType()
        {
            Console.WriteLine("Vilken typ av båt registrerar du?\nTryck in siffra för att lägga till båttyp.\n");
        }

        public void enterBoatLength()
        {
            Console.WriteLine("Hur lång är båten?");
        }
    }
}
