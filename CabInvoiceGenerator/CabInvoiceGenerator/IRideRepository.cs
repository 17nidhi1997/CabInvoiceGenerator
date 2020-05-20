using System;
using System.Collections.Generic;
using System.Text;

namespace cabInvoiceGenerator
{
    public interface IRideRepository
    {
        public void AddRides(string userId, Ride[] rides);
        public Ride[] GetRides(string userId);
    }
}
