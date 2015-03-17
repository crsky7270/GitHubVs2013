using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOP_Test
{
   [CallTrace]
   public class Order : ContextBoundObject
   {
      private int orderId;
      private string product;
      private int quantity;
      public Order(int orderId)
      {
         this.orderId = orderId;
      }

      /// <summary>
      /// 提交方法
      /// </summary>
      public void Submit()
      {
         Inventory inventory = new Inventory();
         //检查库存
         if (inventory.CheckOut(product, quantity))
         {
            LogBook.Log("Order" + orderId + " available");
            inventory.Update(product, quantity);
         }
         else
         {
            LogBook.Log("Order" + orderId + "unavailable");
            SendMail();
         }
      }

      public void Submit(string prd, int qty)
      {
         //Inventory inventory=new Inventory();
         //if (inventory.CheckOut(prd, qty))
         //{
         //   LogBook.Log("Order" + orderId + " available");
         //   inventory.Update(prd, qty);
         //}
         //else
         //{
         //   LogBook.Log("Order" + orderId + "unavailable");
         //   SendMail();
         //}
      }

      /// <summary>
      /// 返回产品名
      /// </summary>
      public string ProductName
      {
         get { return product; }
         set { this.product = value; }
      }

      public int OrderId
      {
         get { return this.orderId; }
      }

      public int Quantity
      {
         get { return this.quantity; }
         set { quantity = value; }
      }

      public void SendMail()
      {
         Console.Write("Send Email");
      }
   }
}
