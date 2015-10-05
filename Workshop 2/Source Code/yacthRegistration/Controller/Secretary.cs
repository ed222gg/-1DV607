using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yacthRegistration.Controller
{
    class Secretary
    {
        public enum Choice
        {
            y,
        }

        private const string path = "yachtClub.bin";
        Model.YachClub listOfMembers = new Model.YachClub();
        View.YachtConsole yConsole = new View.YachtConsole();

        public void Run()
        {
            listOfMembers.GetData(path);

            bool loopRuns = true;
            do
            {                
                yConsole.ClearConsole();
                yConsole.MenuShow();
                switch (HandleReadKey())
                {
                    case 1:
                        CreateMember();
                        break;
                    case 2:
                        DeleteMember(listOfMembers.GetMemberArray());
                        break;
                    case 3:
                        ListMembers(listOfMembers.GetMemberArray());
                        break;
                    default:
                        listOfMembers.SaveData(path);
                        loopRuns = false;                 //TODO! fixa så att programmet avslutar med q
                        break;
                }

            } while (loopRuns == true);

        }            

        public void ListMembers(List<Model.Member> memberlist)
        {
            yConsole.ClearConsole();
            yConsole.ListingMembersMessage();
            yConsole.ListMembers(memberlist);

            int value = HandleReadLine();
            if (value != 0 && value <= memberlist.Count)
            {
                var member = memberlist[value - 1];
                MemberMenu(member);
            }
            else
            {
                yConsole.ClearConsole();
            }
              
        }

        public void ListBoatTypes()
        {
            int pos = 1;
            var enumArray = Enum.GetValues(typeof(Model.Boat.Type));
            foreach (var type in enumArray)
            {
                if (pos < enumArray.Length)
                {
                    yConsole.ListBoatTypes(type, pos);
                    pos++;
                }
            }
        }

        public void DeleteMember(List<Model.Member> memberlist)
        {
            yConsole.DeleteMember(memberlist);
            int value = HandleReadLine();
            if (value != 0 && value <= memberlist.Count)
            {
                memberlist.RemoveAt(value - 1);
                yConsole.ClearConsole();
            }
            else
            {
                
                yConsole.ErrorMessage("Ett fel inträffade");
            
                Console.ReadKey();
            }
            
        }

        public int HandleReadKey()
        {
            string key = Console.ReadKey().KeyChar.ToString();
            int value;
            int.TryParse(key, out value);
            return value;
        }

        public int HandleReadLine()
        {
            string key = Console.ReadLine();
            int value;
            int.TryParse(key, out value);
            return value;
        }

        public Model.Boat.Type HandleBoatType(int boatValue)
        {
            foreach (int i in Enum.GetValues(typeof(Model.Boat.Type)))
            {
                if (i == boatValue)
                {
                    return (Model.Boat.Type)Enum.ToObject(typeof(Model.Boat.Type), boatValue);
                }
            }
            return Model.Boat.Type.None;
        }

        public float HandleBoatLength(string inputLength)
        {
            try
            {
                return Convert.ToSingle(inputLength);
            }
            catch (Exception)
            {
                yConsole.BoatLengthMessage();
            }

            return 0;
        }

        public void AddBoat(Model.Member member)
        {
            yConsole.ClearConsole();
            Model.Boat.Type boatTypes = Model.Boat.Type.None;
            float value = 0;
                            
            yConsole.ShowMember(member);
            ListBoatTypes();
            try
            {
                yConsole.EnterBoatType();
                int boatValue = HandleReadKey();
                boatTypes = HandleBoatType(boatValue);

                yConsole.EnterBoatLength();
                string floatValue = Console.ReadLine();
                value = HandleBoatLength(floatValue);
                member.AddBoat(new Model.Boat(boatTypes, value));
            }
            catch (Exception e)
            {
                yConsole.ErrorMessage(e.Message);
                Console.ReadKey();
            }
            
        }

        public void ChangeBoat(Model.Member member)
        {
            yConsole.ShowMember(member);
            yConsole.ChangeBoatMessage();
            Model.Boat boat;
            
            int value = HandleReadLine();
            if (value != 0 && member.Boats.Count != 0)
            {
                boat = member.Boats[value - 1];
                yConsole.ShowBoat(boat.BoatType, boat.Length);
                ListBoatTypes();

                yConsole.EnterBoatType();
                int boatValue = HandleReadKey();
                Model.Boat.Type boatTypes = HandleBoatType(boatValue);

                yConsole.EnterBoatLength();
                string floatValue = Console.ReadLine();
                float boatLength = HandleBoatLength(floatValue);

                boat.BoatType = boatTypes;
                boat.Length = boatLength;
            }

        }

        public void RemoveBoat(Model.Member member)
        {
            yConsole.ShowMember(member);
            yConsole.RemoveBoatMessage();
            Model.Boat boat;

            int value = HandleReadLine();
            if (value != 0 && value <= member.Boats.Count)
            {
                boat = member.Boats[value - 1];
                yConsole.ShowBoat(boat.BoatType, boat.Length);
                yConsole.AlertMessage();
                string choice = Console.ReadKey().KeyChar.ToString();
                    if (choice == Secretary.Choice.y.ToString())
                    {
                        member.Boats.RemoveAt(value - 1);
                        
                    }
                    else if (choice != Secretary.Choice.y.ToString())
                    {
                        return;
                    }
            }
        }

        public void MemberMenu(Model.Member member)
        {
            bool runs = true;
            do
            {
                yConsole.ShowMember(member);
                yConsole.MemberChoices();
                switch (HandleReadKey())
                {
                    case 1:
                        ChangeMember(member);
                        break;
                    case 2:
                        AddBoat(member);
                        break;
                    case 3:
                        ChangeBoat(member);
                        break;
                    case 4:
                        RemoveBoat(member);
                        break;
                    default: runs = false;
                        break;
                }
            } while (runs == true);
        }

        public string HandleMemberInputName()
        {
            yConsole.EnterName();
            string name = Console.ReadLine();
            return name;
        }

        public string HandleMemberInputPersonalNumber()
        {
            yConsole.EnterPersonalNumber();
            string personalNumber = Console.ReadLine();
            return personalNumber;
        }

        public void ChangeMember(Model.Member member)
        {
            try
            {
                yConsole.ShowMember(member);
                string name = HandleMemberInputName();
                string pnumber = HandleMemberInputPersonalNumber();

                member.Name = name;
                member.Ssn = pnumber;
                yConsole.ClearConsole();
            }
            catch (Exception e)
            {
                yConsole.ErrorMessage(e.Message);
                Console.ReadKey();
            }
        }

        public void CreateMember()
        {
            try
            {

                yConsole.ClearConsole();
                string name = HandleMemberInputName();
                string personalNumber = HandleMemberInputPersonalNumber();
                Model.Member member = new Model.Member(name, personalNumber);

                listOfMembers.AddData(member);
            }
            catch (Exception e)
            {
                yConsole.ErrorMessage(e.Message);
                Console.ReadKey();
            }
        }
    }
}
