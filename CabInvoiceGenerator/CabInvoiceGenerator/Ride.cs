using System;
using System.Collections.Generic;
using System.Text;

namespace cabInvoiceGenerator
{
   public class Ride
    {
        readonly public double distance;
        readonly public double time;
        readonly public cabRide rideType;
        public Ride (cabRide rideType,double distance,double time)
        {
            this.rideType = rideType;
            this.distance = distance;
            this.time = time;
        }
    }
}
