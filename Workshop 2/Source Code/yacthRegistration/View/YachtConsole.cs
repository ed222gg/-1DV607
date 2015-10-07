using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yacthRegistration.View
{
    class YachtConsole
    {

        // Choice Messages
        public void MenuShow()
        {
            Console.WriteLine("Välkommen!");
            Console.WriteLine("Tryck 1 för att lägga till ny medlem");
            Console.WriteLine("Tryck 2 för att ta bort medlem");
            Console.WriteLine("Tryck 3 för att visa och/eller ändra information hos medlemmar");
            Console.WriteLine("Tryck 4 för att visa en detaljerad medlemslista");
            Console.WriteLine("Tryck valfri knapp för att avsluta");
        }

        public void MemberChoices()
        {
            Console.WriteLine("1: Vill du ändra medlems information?");
            Console.WriteLine("2: Vill du lägga till en båt?");
            Console.WriteLine("3: Vill du ändra båt information?");
            Console.WriteLine("4: Vill du ta bort en båt?");
            Console.WriteLine("Tryck valfri knapp för att återgå till startmenyn..\n");
        }

        public void NoMembers()
        {
            Console.WriteLine("Finns inga medlemmar i klubben..\nTryck valfri knapp för att återgå!");
        }


        //Member Messages
        public void EnterName()
        {
            Console.Write("Ange namn på medlem: ");
        }

        public void EnterPersonalNumber()
        {
            Console.Write("Ange personens personnummer: ");
        }

        public void DeleteMember(List<Model.Member> memberlist)
        {
            ListMembers(memberlist);
            Console.WriteLine("\n Vilken medlem skall tas bort? Skriv in positionssiffran...");
        }

        public void ListingMembersMessage()
        {
            YellowMessage();
            Console.WriteLine("Mata in en medlems positionssiffra för att visa/ändra dess information tryck sedan Enter.\n");
            ResetTheColor();
        }


        // member compact
        public void ListMembers(List<Model.Member> memberlist)
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

        // member detail
        public void ShowMember(Model.Member member)
        {            
            string output = String.Format("Namn: {0}\nPersonnummer: {1}\nUnik ID: {2}\nAntal Båtar: {3}\n", member.Name, member.Ssn, member.Id, member.Boats.Count);
            int pos = 1;
            foreach (Model.Boat boat in member.Boats)
            {
                output += String.Format("Båt:{2} - Typ: {0} - Längd: {1}\n", boat.BoatType, boat.Length, pos);
                pos++;
            }
            Console.WriteLine(output);
        }

        public void ShowBoat(Model.Boat.Type type, float length)
        {
            Console.WriteLine("\n\nType: {0} - Length: {1}\n", type, length);
        }

        public void ListBoatTypes(Object value, int pos)
        {
            string output = String.Format("{0}: {1}", pos, value);
            Console.WriteLine(output);
        }


        //Boat Messages
        public void BoatLengthMessage()
        {
            Console.WriteLine("Du skriver float med kommatecken.");
        }

        public void ChangeBoatMessage()
        {
            Console.WriteLine("Välj båt som skall ändra..\nTryck in siffran..\nEller valfri knapp för att återgå...");
        }

        public void RemoveBoatMessage()
        {
            Console.WriteLine("Välj båt som skall TAS BORT!!.\nTryck in siffran..\nEller valfri knapp för att återgå...");
        }

        public void EnterBoatLength()
        {
            Console.WriteLine("\nHur lång är båten?");
        }
        public void EnterBoatType()
        {
            Console.WriteLine("Vilken typ av båt registrerar du?\nTryck in siffra för att lägga till båttyp.\n");
        }



        // Error & alert messages
        public void AlertMessage()
        {
            Console.WriteLine("Säker på att du vill ta bort -");
            Console.WriteLine("Tryck Y för att ta bort ELLER N för att ångra.");
        }

        public void ErrorMessage(string message)
        {
            RedMessage();
            Console.WriteLine(message);
            ResetTheColor();
        }



        //Console -Color, -reset and -clear
        public void YellowMessage()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
        }

        public void RedMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }

        public void GreenMessage()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
        }

        public void ResetTheColor()
        {
            Console.ResetColor();
        }

        public void ClearConsole()
        {
            Console.Clear();
        }
    }
}
