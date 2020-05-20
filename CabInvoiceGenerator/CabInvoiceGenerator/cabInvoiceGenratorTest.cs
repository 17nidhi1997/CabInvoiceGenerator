using NUnit.Framework;

namespace cabInvoiceGenerator
{
    public class Tests
    {

        InvoiceGenorator invoiceGenorator = new InvoiceGenorator();
        RideRepository rideRepository = new RideRepository();
        /// <summary>
        /// Test 1.1
        /// </summary>
        [Test]
        public void GivenLessDistanceAndTime_ShouldReturnTotalFare()
        {
            double distance = 2.0;
            int time = 5;
            double fare = invoiceGenorator.CalculateFare(cabRide.Normal, distance, time);
            Assert.AreEqual(expected: 25, fare, delta: 0.0);
        }

        /// <summary>
        /// Test 1.2
        /// </summary>
        [Test]
        public void GivenLessDistanceAndTime_ShouldReturnMinFare()
        {
           
            double distance = 0.1;
            int time = 1;
            double fare = invoiceGenorator.CalculateFare(cabRide.Normal, distance, time);
            Assert.AreEqual(expected: 5, fare, delta: 0.0);
        }

        /// <summary>
        /// Test 2
        /// </summary>
        [Test]
        public void GivenMultipleRider_ShouldReturnTotalFare()
        {
           
            Ride[] rides = { new Ride(cabRide.Normal ,distance: 2.0 ,time : 5),
                            new Ride (cabRide.Normal, distance:0.1,time :1)
            };
            var expectedsummary = 30;
            InvoiceSummary invoiceSummary=invoiceGenorator.CalculateFare(rides);
            Assert.AreEqual(expectedsummary ,invoiceSummary);
        }

        /// <summary>
        /// test 3
        /// </summary>
        [Test]
        public void GivenMultipleRides_ShouldReturnInvoiceSummary()
        {
            
            Ride[] rides = { new Ride(cabRide.Normal, 2.0, 5),
                             new Ride(cabRide.Normal, 0.1, 1)
            };
            InvoiceSummary invoiceSummary = invoiceGenorator.CalculateFare(rides);
            InvoiceSummary expected = new InvoiceSummary
            {
                noOfRides = 2,
                totalFare = 30,
                averageFare = 15
            };
            object.Equals(expected, invoiceSummary);

        }

        /// <summary>
        /// test 4.1
        /// </summary>
        [Test]
        public void GivenUserId_WhenInvoiceServiceGetsListOfRidesFromRideRepository_ShouldReturnInvoice()
        {
            string userId = "17nidhi1997";
            Ride[] rides = {new Ride(cabRide.Normal,2.0, 5),
                            new Ride(cabRide.Normal,0.1, 1)
               };
            Ride[] rides1 = {new Ride(cabRide.Normal,2.0, 5),
                             new Ride(cabRide.Normal,0.1, 1)
               };
            rideRepository.AddRides(userId, rides);
            rideRepository.AddRides(userId, rides1);
            InvoiceSummary total = invoiceGenorator.CalculateFare(rideRepository.GetRides(userId));
            Assert.AreEqual(120, total.totalFare);
        }

        /// <summary>
        /// test 4.2
        /// </summary>
        [Test]
        public void GivenUserId_WhenInvoiceServicefRidesFromRideRepository_ShouldReturnNullException()
        {
            try
            {
                string userId = null;
                Ride[] rides = {new Ride(cabRide.Normal,2.0, 5),
                                new Ride(cabRide.Normal,0.1, 1)
                                };
                rideRepository.AddRides(userId, rides);
                InvoiceSummary total = invoiceGenorator.CalculateFare(rideRepository.GetRides(userId));
            }
            catch (customException e)
            {
                Assert.AreEqual("NULL_exception", e.mgs);
            }
        }
        /// <summary>
        /// test 4.3
        /// </summary>
        [Test]
        public void GivenMultipleUserId_WhenInvoiceServicefRidesFromRideRepos_ShouldReturninvoice()
        {
            string userId = "17nidhi1997";
            Ride[] rides = {new Ride(cabRide.Normal, 2.0, 5),
                            new Ride(cabRide.Normal, 0.1, 1)
               };
            string userId1 = "17nidhi1997";
            Ride[] rides1 = {new Ride(cabRide.Normal,2.0, 5),
                             new Ride(cabRide.Normal,0.1, 1)
               };
            rideRepository.AddRides(userId, rides);
            rideRepository.AddRides(userId1, rides1);
            InvoiceSummary total = invoiceGenorator.CalculateFare(rideRepository.GetRides(userId));
            InvoiceSummary total1 = invoiceGenorator.CalculateFare(rideRepository.GetRides(userId1));
            Assert.AreEqual(120, total.totalFare+total1.totalFare);
        }
        /// <Test 5>
        /// Invoice Service
        /// Given a user id, will have 'normal' and 'premimun' ridethe Invoice Service gets the List of rides from the RideRepository,
        /// and returns Total Average of normalFare and premimumFare.
        /// </Test 5>
        [Test]
        public void GivenUserIdOfMultiRidesToUserId_ShouldTotalFare()
        {
            string userId = "nidhi18";
            Ride[] rides =
            {
                new Ride(cabRide.Normal,2.0,1.0),
                new Ride(cabRide.Premium,2.5,1.5)
            };
            rideRepository.AddRides(userId, rides);
            InvoiceSummary retunTotal = invoiceGenorator.CalculateFare(rideRepository.GetRides(userId));
            Assert.AreEqual(47.5, retunTotal.totalFare);
        }

        /// <summary>
        /// test 5.2
        /// </summary>
        [Test]
        public void GivenMultipleUserId_WhenInvoiceServiceGetsListOfRidesFromRideRepository_ShouldReturnInvoice()
        {
            string userId = "17nidhi1997";

            Ride[] rides = {new Ride(cabRide.Premium,2.0, 5),
                   new Ride(cabRide.Premium,0.1, 1)
               };
            string userId1 = "abc21997";
            Ride[] rides1 = {new Ride(cabRide.Premium,2.0, 5),
                   new Ride(cabRide.Premium,0.1, 1)
               };

            RideRepository rideRepository = new RideRepository();
            rideRepository.AddRides(userId, rides);
            rideRepository.AddRides(userId1, rides1);
            InvoiceSummary total = invoiceGenorator.CalculateFare(rideRepository.GetRides(userId));
            Assert.AreEqual(30, total.totalFare);
        }

        /// <summary>
        /// test 5.3
        /// </summary>
        [Test]
        public void GivenUserId_WhenInvoiceServiceGetsListOfRidesFromRideRepository_ShouldReturnNullException()
        {
            try
            {
                string userId = null;
                Ride[] rides = {new Ride(cabRide.Premium,2.0, 5),
                   new Ride(cabRide.Premium,0.1, 1)
            };
                RideRepository rideRepository = new RideRepository();
                rideRepository.AddRides(userId, rides);
                InvoiceSummary total = invoiceGenorator.CalculateFare(rideRepository.GetRides(userId));
            }
            catch (customException e)
            {
                Assert.AreEqual("NULL_exception", e.mgs);
            }
        }
    }
}