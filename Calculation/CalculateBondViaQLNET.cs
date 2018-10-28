using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLNet;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //CH0317921671
            Calendar calendar = new NullCalendar();

            int settlementDays = 0;

            Date issueDate = new Date(new DateTime(2017, 11, 30));
            Date today = new Date(new DateTime(2018, 11, 10));
            Date maturityDate = new Date(new DateTime(2018, 11, 29));

            Date evaluationDate = calendar.adjust(maturityDate);
            Date settlementDate = calendar.advance(evaluationDate, new Period(settlementDays, TimeUnit.Days));
            QLNet.Settings.setEvaluationDate(evaluationDate);
            //double coupon = 0.03375;
            Compounding comp = Compounding.Compounded;
            Frequency freq = Frequency.Annual;
            DayCounter dc = new ActualActual(ActualActual.Convention.Bond);

            Period tenor = new Period(1, TimeUnit.Years);
            List<Date> dates = new List<Date>()
            {
                issueDate,
                new Date(30, 11, 2018)
            };

            List<bool> isRegular = new List<bool>()
            {
                false
            };


            Schedule schedule = new Schedule(dates,
            calendar,
                BusinessDayConvention.Unadjusted,
                BusinessDayConvention.Unadjusted,
                tenor,
                DateGeneration.Rule.Backward,
                true,
                isRegular);

            List<double> coupon = new List<double>()
            {
                0.03375
            };
            FixedRateBond bond = new FixedRateBond(0,
                5000.0,
                schedule,
                coupon,
                new ActualActual(),
                BusinessDayConvention.Unadjusted,
                100.0,
                issueDate,
                calendar,
                tenor,
                calendar);

            Dictionary<DateTime, double> values = new Dictionary<DateTime, double>()
            {
                { new DateTime(2017,12, 04), 102.85 },
                { new DateTime(2017,12, 05), 102.85 },
                { new DateTime(2017,12, 06), 102.82 },
                { new DateTime(2017,12, 07), 102.81 },
                { new DateTime(2017,12, 08), 102.80 },
            };

            foreach(var z in values)
            {
                QLNet.Settings.setEvaluationDate(new Date(z.Key));
                var t = bond.yield(z.Value,
                    bond.dayCounter(),
                    Compounding.Compounded,
                    Frequency.Annual);
                Console.WriteLine(t);
            }

            //var t = bond.yield(100,
            //    bond.dayCounter(),
            //    Compounding.Compounded,
            //    Frequency.Annual);

            //var tt = bond.dirtyPrice(t, bond.dayCounter(), Compounding.Compounded, Frequency.Annual);

            //Console.WriteLine(t);
            //Console.WriteLine(tt);
        }
    }
}
