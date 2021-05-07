using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSD.Test
{
    public class Sample
    {
        [Conditional("DEBUG")]
        public static void Foo()
        {
            Console.WriteLine("Foo");
        }
    }
}
