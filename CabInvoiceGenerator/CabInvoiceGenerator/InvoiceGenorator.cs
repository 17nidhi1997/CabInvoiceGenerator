using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    class InvoiceGenorator
    {
        private const double minimumCostPerKilometer = 10;
        private const int costPerTime = 1;
        private const int mimumFare = 5;


        public double CalculateFare(double distance, int time)
        {

            double totalFare = distance * minimumCostPerKilometer + time * costPerTime;
            if (totalFare < mimumFare)
                return mimumFare;
            else
                return totalFare;
        }
        public double CalculateFare(Ride[] rides)
        {
            double totalFare = 0;

            foreach (Ride ride in rides)
            {
                totalFare += this.CalculateFare(ride.distance, ride.time);
            }
            return totalFare;
        }
    }
