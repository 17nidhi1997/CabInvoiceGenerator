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
    }