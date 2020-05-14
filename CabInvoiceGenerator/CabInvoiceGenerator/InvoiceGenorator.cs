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


        public double CalculateFare(double distance, int time)
        {

            double totalFare = distance * minimumCostPerKilometer + time * costPerTime;
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
                totalFare += CalculateFare(ride.distance, ride.time);
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