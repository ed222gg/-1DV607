using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yacthRegistration.Controller
{
    class Secretary
    {
        private const string path = "yachtClub.bin";
        Model.YachClub listOfMembers = new Model.YachClub();
        View.yachtConsole yConsole = new View.yachtConsole();

        public void run()
        {
            listOfMembers.getData(path);

            bool loopRuns = true;
            do
            {
                yConsole.menuShow();
                switch (handleIntegerChoice())
                {
                    case 1:
                        createMember();
                        break;
                    case 2:
                        deleteMember(listOfMembers.getMemberArray());
                        break;
                    case 3:
                        changeMember(listOfMembers.getMemberArray());
                        break;
                    case 4:
                        listMembers(listOfMembers.getMemberArray());
                        break;
                    case 5:
                        addBoat(listOfMembers.getMemberArray());
                        break;
                    case 6:
                        changeBoat(listOfMembers.getMemberArray());
                        break;
                    default:
                        listOfMembers.saveData(path);
                        loopRuns = false;                 //TODO! fixa så att programmet avslutar med q
                        break;
                }

            } while (loopRuns == true);

        }

        public void createMember()
        {
            try
            {
                Console.Clear();
                yConsole.enterName();
                string name = Console.ReadLine();
                yConsole.enterPersonalNumber();
                string personalNumber = Console.ReadLine();
                Model.Member member = new Model.Member(name, personalNumber);

                listOfMembers.addData(member);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                Console.ReadKey();
                Console.Clear();
            }
        }

        public void listMembers(List<Model.Member> memberlist)
        {
            Console.Clear();
            Console.WriteLine("Visa medlem genom att skriva in deras siffra till vänster.\n(dubbelklicka in siffran!!!)\n");
            yConsole.listMembers(memberlist);

            int value = handleIntegerChoice();
            if (value != 0)
            {
                var member = memberlist[handleIntegerChoice() - 1];
                yConsole.showMember(member);
            }
            else
            {
                Console.Clear();
            }
              
        }

        public void deleteMember(List<Model.Member> memberlist)
        {
            yConsole.deleteMember(memberlist);
            memberlist.RemoveAt(handleIntegerChoice() - 1);
            Console.Clear();
        }


        public int handleIntegerChoice()
        {
            string key = Console.ReadKey().KeyChar.ToString();
            int value;
            int.TryParse(key, out value);
            return value;
        }

        public void changeMember(List<Model.Member> memberlist)
        {
            Console.Clear();
            Console.WriteLine("Vilken medlem vill du ändra?\nSkriv in siffran\n");
            yConsole.listMembers(memberlist);

            int test = handleIntegerChoice();
            if (test != 0) { 
                var member = memberlist[test - 1];
                yConsole.showMember(member);

                yConsole.enterName();
                string name = Console.ReadLine();
                yConsole.enterPersonalNumber();
                string personalNumber = Console.ReadLine();

                member.changeInformation(name, personalNumber);
                Console.Clear();
            }
            else
            {
                Console.Clear();
            }
        }

        public void addBoat(List<Model.Member> memberlist)
        {
            Model.Boat.Type boatTypes = Model.Boat.Type.Other;
            float value = 0;
            Console.Clear();
            Console.WriteLine("MILLAN vill ha en båt, välj millan!!");
            yConsole.listMembers(memberlist);
            

            int test = handleIntegerChoice();
            if (test != 0)
            {
                var member = memberlist[test - 1];
                yConsole.showMember(member);
                int pos = 1;

                foreach (var type in Enum.GetValues(typeof(Model.Boat.Type)))
                {
                    yConsole.listBoatTypes(type, pos);
                    pos++;
                }

                yConsole.enterBoatType();
                int boatValue = handleIntegerChoice();
                
                foreach (int i in Enum.GetValues(typeof(Model.Boat.Type)))
                {
                    if(i == boatValue)
                    {
                        boatTypes = (Model.Boat.Type)Enum.ToObject(typeof(Model.Boat.Type), boatValue);
                    }  
                }

                yConsole.enterBoatLength();
                string floatValue = Console.ReadLine();
                try
                {
                    value = Convert.ToSingle(floatValue);
                }
                catch (Exception)
                {
                    Console.WriteLine("Du skriver float med kommatecken.");
                }

                member.addBoat(new Model.Boat(boatTypes, value));
                
            }
            else
            {
                Console.Clear();
            }
        }

        public void changeBoat(List<Model.Member> memberlist)
        {

        }
    }
}
