using System;
using System.Collections;

namespace AOP_Test
{
   public class Inventory
   {
      private Hashtable inventory = new Hashtable();
      public Inventory()
      {
         inventory["item100"] = 100;
         inventory["item200"] = 200;
      }

      public bool CheckOut(string product, int quantity)
      {
         int qty = GetQuantity(product);
         return qty > quantity;
      }

      public int GetQuantity(string product)
      {
         int qty = 0;
         if (inventory[product] != null)
            qty = (int)inventory[product];
         return qty;
      }

      public void Update(string product, int quantity)
      {
         int qty = GetQuantity(product);
         inventory[product] = qty - quantity;
      }

   }
}
