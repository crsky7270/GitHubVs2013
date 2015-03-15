using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace AOP_Test
{
   public class CallTraceSink : IMessageSink
   {
      private readonly IMessageSink _nextSink;
      public CallTraceSink(IMessageSink nextMessageSink)
      {
         _nextSink = nextMessageSink;
      }

      public IMessage SyncProcessMessage(IMessage msg)
      {
         //throw new NotImplementedException();
         Preprocess(msg);
         IMessage retMsg = NextSink.SyncProcessMessage(msg);
         Postprocess(msg, retMsg);
         return retMsg;
      }

      private void Postprocess(IMessage msg, IMessage retMsg)
      {
         IMethodCallMessage callMessage = msg as IMethodCallMessage;
         if (callMessage == null)
            return;
         Console.WriteLine("log order information");
      }

      private void Preprocess(IMessage msg)
      {
         //throw new NotImplementedException();
         IMethodCallMessage callMessage = msg as IMethodCallMessage;
         if (callMessage == null)
            return;
         if (callMessage.MethodName == "Submit")
         {
            string product = callMessage.GetArg(0).ToString();
            int qty = (int)callMessage.GetArg(1);

            if (new Inventory().CheckOut(product, qty))
               Console.WriteLine("Order availible");
            else
            {
               Console.WriteLine("Order Unvalible");
               SendMail(1);
            }
         }
      }


      /// <summary>
      /// send email
      /// </summary>
      private void SendMail(int ts)
      {
         Console.WriteLine("send mail!");
      }

      public IMessageCtrl AsyncProcessMessage(IMessage msg, IMessageSink replySink)
      {
         return null;
      }

      public IMessageSink NextSink
      {
         get { return _nextSink; }
      }
   }
}
