
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace workshop2.View
{
    class StartMenu
    {
        public void show()
        {
            Console.WriteLine("Välkommen!");
            Console.WriteLine("Tryck 1 för att lägga till ny medlem");
            Console.WriteLine("Tryck 2 för att ta bort medlem");
            Console.WriteLine("Tryck 3 för att ändra medlem");
            Console.WriteLine("Tryck 4 för att visa medlem");
            Console.WriteLine("Tryck Q för att avsluta");
        }

    }
}
