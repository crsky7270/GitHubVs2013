using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace AOP_Test
{
   public class CallTraceProperty : IContextProperty, IContributeObjectSink
   {
      public CallTraceProperty()
      {

      }

      public bool IsNewContextOK(Context newCtx)
      {
         return true;
      }

      public void Freeze(Context newContext)
      {
         
      }

      public string Name
      {
         get { return "OrderTrace"; }
      }

      public IMessageSink GetObjectSink(MarshalByRefObject obj, IMessageSink nextSink)
      {
         return new CallTraceSink(nextSink);
      }
   }
}
