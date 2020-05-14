using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    class InvoiceGenorator
    {
        public const double minimumCostPerKilometer = 10.0;
        public const int costPerTime = 1;
        public const int mimumFare = 5;
        // Declared and Initialised Variables of Premimum rides
        readonly private double premiusCostPerKiloMeter = 15.0;
        readonly private double premimunCostPerMinute = 2.0;
        readonly private double premimunMinimumFare = 20.0;


        public double CalculateFare(string rideType, double Distance, double Time)
        {
            if (rideType == "normal")
            {
                double totalFare = Distance * minimumCostPerKilometer + Time * costPerTime;
                if (totalFare < mimumFare)
                    return mimumFare;
                else
                    return totalFare;
            }
            // Calculation for premimunFare
            if (rideType == "premium")
            {
                double totalFare = (Distance * premiusCostPerKiloMeter) + (Time * premimunCostPerMinute);
                if (totalFare > premimunMinimumFare)
                {
                    return totalFare;
                }
            }
            return premimunMinimumFare;
        }



        public InvoiceSummary CalculateFare(Ride[] rides)
        {
            double totalFare = 0;
            int noOfRides = 0;
            foreach (Ride ride in rides)
            {
                totalFare += CalculateFare(ride.rideType, ride.distance, ride.time);
                noOfRides += 1;
            }
            InvoiceSummary invoiceSummary = new InvoiceSummary();
            invoiceSummary.noOfRides = noOfRides;
            invoiceSummary.totalFare = totalFare;
            invoiceSummary.CalculateAverageCabFare();
            return invoiceSummary;
        }

    }
}