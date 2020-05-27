using System;
using System.Collections.Generic;
using System.Text;

namespace cabInvoiceGenerator
{
    class InvoiceGenorator
    {
        public  double minimumCostPerKilometer = 10.0;
        public   int costPerTime = 1;
        public  int mimumFare = 5;
        public double CalculateFare(cabRide cabride, double Distance, double Time)
        {
            double totalFare = Distance * minimumCostPerKilometer + Time * costPerTime;
            if (totalFare < mimumFare)
                return mimumFare;
            else
                return totalFare;
        }
        public InvoiceSummary CalculateFare(Ride[] rides)
        {
            double totalFare = 0;
            int noOfRides = 0;
            foreach (Ride ride in rides)
            {
                totalFare += CalculateFare(ride.rideType, ride.distance,ride.time);
                noOfRides++;
            }
            InvoiceSummary invoiceSummary = new InvoiceSummary();
            invoiceSummary.noOfRides = noOfRides;
            invoiceSummary.totalFare = totalFare;
            invoiceSummary.CalculateAverageCabFare();
            return invoiceSummary;
        }
    }
}
