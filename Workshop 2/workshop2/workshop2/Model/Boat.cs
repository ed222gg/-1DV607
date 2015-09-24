using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace workshop2.Model
{
    class Boat
    {
        public enum Type
        {
            Sailboat,
            Motorsailer,
            Kayak,
            Canoe,
            Other
        }

        Type b_type;
        int b_length;
        int m_id;

        public Boat(Type type, int length, int id)
        {
            b_type = type;
            b_length = length;
            m_id = id;
        }

    }
}
