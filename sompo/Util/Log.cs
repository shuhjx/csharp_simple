using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sompo.Util
{
    class Log
    {
        private static readonly bool Debug = true;

        public static void Print(Object obj)
        {
            if (Debug) {
               Console.Out.Write(obj);
            }
        }
        public static void Println(Object obj)
        {
            if (Debug)
            {
                Console.Out.WriteLine(obj);
            }
        }
    }
}
