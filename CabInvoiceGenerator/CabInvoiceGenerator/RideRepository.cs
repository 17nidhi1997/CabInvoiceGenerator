using System;
using System.Collections.Generic;
using System.Text;

namespace CabInvoiceGenerator
{
    public class RideRepository
    {
        public Dictionary<string, List<Ride>> userRideObject;
        public RideRepository()
        {
            this.userRideObject = new Dictionary<string, List<Ride>>();
        }
        public void AddRides(string userId, Ride[] rides)
        {
            if (userId == null)
                throw new customException(ExceptionType.NULL_exception + "");
            bool checkRide = userRideObject.ContainsKey(userId);
            List<Ride> list = new List<Ride>();
            if (checkRide == false)
            {
                list.AddRange(rides);
                userRideObject.Add(userId, list);

            }
            else
            {
                foreach (Ride ride in rides)
                    userRideObject[userId].Add(ride);
            }
        }
        public Ride[] GetRides(string userId)
        {
            return userRideObject[userId].ToArray();
        }

    }
}
