using System;
using System.Collections.Generic;
using System.Text;

namespace cabInvoiceGenerator
{
    public class InvoiceSummary
    {
        public int noOfRides { get; set; }
        public double totalFare { get; set; }
        public double averageFare { get; set; }
        public void CalculateAverageCabFare()
        {
            averageFare = totalFare / noOfRides;
        }
    }
}      
