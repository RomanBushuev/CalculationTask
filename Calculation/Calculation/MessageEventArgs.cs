using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculation
{
    public class MessageEventArgs:EventArgs
    {
        private string _message = string.Empty;
        private MessageType _type = MessageType.Default;
        public MessageEventArgs(string message, MessageType messageType = MessageType.Default)
        {
            _message = message;
            _type = messageType;
        }

        public String Message
        {
            get
            {
                return _message;
            }
        }

        public MessageType MessageType
        {
            get
            {
                return _type;
            }
        }
    }
}
