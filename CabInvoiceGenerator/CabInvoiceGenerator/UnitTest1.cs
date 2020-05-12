using NUnit.Framework;

namespace CabInvoiceGenerator
{
    public class Tests
    {
        /// <summary>
        /// test 1.1
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
        /// test 1.2
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
    }
}