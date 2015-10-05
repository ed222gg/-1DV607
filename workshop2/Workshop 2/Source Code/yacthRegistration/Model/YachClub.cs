using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace yacthRegistration.Model
{
    class YachClub
    {
        List<Member> memberList = new List<Member>();

        public void getData(string path)
        {
            memberList.Clear();
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read);
            try
            {
                memberList = (List<Member>)formatter.Deserialize(stream);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                stream.Close();
            }
            
        }

        public void saveData(string path)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write);

            formatter.Serialize(stream, memberList);
            stream.Close();
        }

        public void addData(Member member)
        {
            memberList.Add(member);
        }

        public List<Member> getMemberArray()
        {
            return memberList;
        }

    }
}
