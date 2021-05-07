/*----------------------------------------------------------------------------------------------------------------------
    Timer sınıfı
----------------------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CSD
{    
    public class App
    {
        public static void Main()
        {
            Timer timer = new Timer(o => Console.Write("."), null, 0, 1000);

            

            Console.ReadKey(false);
        }
    }
    
}

