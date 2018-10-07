using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculation
{
    public class CalculationLogger
    {
        public event EventHandler HandleMessage;

        public void NotifyNewMessage(string message, MessageType messageType)
        {
            EventHandler handler = HandleMessage;
            if (handler != null)
            {
                // This will call the any form that is currently "wired" to the event, notifying them
                // of the new message.
                handler(this, new MessageEventArgs(message, messageType));
            }
        }

    }
}
