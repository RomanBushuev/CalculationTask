using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace Calculation
{
    public class IncrementalAlgorithm : CalculationOneDay
    {
        public IncrementalAlgorithm()
            :base()
        {

        }

        public override bool Run()
        {
            for(int i =0;i< 100;++i)
            {
                Thread.Sleep(1000);
                if(token.IsCancellationRequested)
                {
                    Notify("Good buy", MessageType.Info);
                    return false;
                }
                Notify(i.ToString(), MessageType.Info);
            }

            return true;
        }

         
    }
}
