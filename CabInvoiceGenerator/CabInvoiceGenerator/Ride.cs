using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
   
      public  class Ride
        {
        public double distance;
        public double time;
        public string rideType;
        public Ride(string rideType, double distance, double time)
        {
            this.rideType = rideType;
            this.distance = distance;
            this.time = time;
        }
    }
    
}
