using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yacthRegistration.Model
{
    [Serializable]
    class Boat
    {
        public enum Type
        {
            Sailboat = 1,
            Motorsailer = 2,
            Kayak = 3,
            Canoe = 4,
            Other = 5,
            None
        }

        private Type _boatType;
        private float _length;

        public float Length
        {
            get
            {
                return _length;
            }

            set
            {
                if (value < 1)
                {
                    throw new Exception("Du angav inte en korrekt längd på din båt");
                }
                _length = value;
            }
        }

        public Type BoatType
        {
            get
            {
                return _boatType;
            }

            set
            {
                if (value == Type.None)
                {
                    throw new Exception("Sådan båtar finns inte här!");
                }
                _boatType = value;
            }
        }

        public Boat(Type type, float length)
        {
            BoatType = type;
            Length = length;
        }

    }
}
