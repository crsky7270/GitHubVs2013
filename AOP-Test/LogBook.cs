using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace AOP_Test
{
   public class LogBook
   {
      public LogBook()
      {

      }

      public static void Log(string logData)
      {
         Console.WriteLine("log:{0}", logData);
      }
   }
}
