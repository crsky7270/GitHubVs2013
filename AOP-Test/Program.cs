using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOP_Test
{
   class Program
   {
      static void Main(string[] args)
      {
         Order order=new Order(100);
         order.ProductName = "item100";
         order.Quantity = 150;
         order.Submit("item100",150);
         Console.ReadLine();

         Order order1=new Order(101);
         order1.ProductName = "item200";
         order1.Quantity=150;
         order1.Submit("item200", 150);
         Console.ReadLine();
      }
   }
}
