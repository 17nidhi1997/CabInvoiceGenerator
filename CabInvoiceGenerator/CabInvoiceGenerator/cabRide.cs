using System;
using System.Collections.Generic;
using System.Text;

namespace cabInvoiceGenerator
{
   public class cabRide
    {
        public static readonly cabRide Normal = new cabRide(10.0, 1.0, 5.0);
        public static readonly cabRide Premium = new cabRide(15.0, 2.0, 20.0);
        public static IEnumerable<cabRide> Values
        {
            get
            {
                yield return Normal;
                yield return Premium;
            }
        }
        public double CostPerKilometer { get; private set; }
        public double CostPerMin { get; private set; }
        public double MinFare { get; private set; }
        public cabRide(double CostPerKilometer, double CostPerMin, double MinFare)
        {
            this.CostPerKilometer = CostPerKilometer;
            this.CostPerMin = CostPerMin;
            this.MinFare = MinFare;
        }

        public double CalculateFare(Ride ride)
        {
            double RideCost = ride.distance * CostPerKilometer + ride.time * CostPerMin;
            return Math.Max(RideCost, MinFare);
        }
    }
}
