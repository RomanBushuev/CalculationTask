using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculation
{
    public abstract class CalculationOneDay
    {
        protected CalculationLogger _logger;

        public CalculationOneDay()
        {
            _logger = new CalculationLogger();
        }

        public virtual bool Run()
        {
            throw new NotImplementedException();
        }

        public virtual void Stop()
        {

        }

        public void Notify(string message, MessageType messageType)
        {
            _logger.NotifyNewMessage(message, messageType);
        }

        public CalculationLogger CalculationLogger
        {
            get
            {
                return _logger;
            }
        }


    }
}
