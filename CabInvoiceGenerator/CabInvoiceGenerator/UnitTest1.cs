using NUnit.Framework;

namespace CabInvoiceGenerator
{
    public class Tests
    {
        /// <summary>
        /// Test 1.1
        /// </summary>
        [Test]
        public void GivenLessDistanceAndTime_ShouldReturnTotalFare()
        {
            InvoiceGenorator invoice = new InvoiceGenorator();
            double distance = 2.0;
            int time = 5;
            double fare = invoice.CalculateFare(distance, time);
            Assert.AreEqual(expected: 25, fare, delta: 0.0);
        }

        /// <summary>
        /// Test 1.2
        /// </summary>
        [Test]
        public void GivenLessDistanceAndTime_ShouldReturnMinFare()
        {
            InvoiceGenorator invoice = new InvoiceGenorator();
            double distance = 0.1;
            int time = 1;
            double fare = invoice.CalculateFare(distance, time);
            Assert.AreEqual(expected: 5, fare, delta: 0.0);
        }

        /// <summary>
        /// Test 2
        /// </summary>
        [Test]
        public void GivenMultipleRider_ShouldReturnTotalFare()
        {
            InvoiceGenorator invoice = new InvoiceGenorator();
            Ride[] rides = { new Ride(distance: 2.0 ,time : 5),
                            new Ride ( distance:0.1,time :1)
            };

            double fare = invoice.CalculateFare(rides);
            Assert.AreEqual(expected: 30, fare, delta: 0.0);
        }

        /// <summary>
        /// test 3
        /// </summary>
        [Test]
        public void GivenMultipleRides_ShouldReturnInvoiceSummary()
        {
            InvoiceGenorator invoice = new InvoiceGenorator();
            Ride[] rides = { new Ride(2.0, 5),
                new Ride(0.1, 1)
            };
            InvoiceSummary invoiceSummary = invoice.CalculateFare(rides);
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
        public void GivenUserId_InvoiceServiceGetsListOfRidesFromRideRepository_ReturnInvoice()
        {
            string userId = "17nidhi1997";
            Ride[] rides = {new Ride(2.0, 5),
                   new Ride(0.1, 1)
               };
            Ride[] rides1 = {new Ride(2.0, 5),
                   new Ride(0.1, 1)
               };

            RideRepository rideRepository = new RideRepository();
            rideRepository.AddRides(userId, rides);
            rideRepository.AddRides(userId, rides1);
            InvoiceGenorator invoice = new InvoiceGenorator();
            InvoiceSummary total = invoice.CalculateFare(rideRepository.GetRides(userId));
            Assert.AreEqual(60, total.totalFare);
        }

        /// <summary>
        /// test 4.2
        /// </summary>
        [Test]
        public void GivenUserId_InvoiceServicefRidesFromRideRepository_ReturnNullException()
        {
            try
            {
                string userId = null;
                Ride[] rides = {new Ride(2.0, 5),
                   new Ride(0.1, 1)
            };
                RideRepository rideRepository = new RideRepository();
                rideRepository.AddRides(userId, rides);
                InvoiceGenorator invoice = new InvoiceGenorator();
                InvoiceSummary total = invoice.CalculateFare(rideRepository.GetRides(userId));
            }
            catch (customException e)
            {
                Assert.AreEqual("NULL_exception", e.mgs);
            }
        }

    }
}  