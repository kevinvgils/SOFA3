using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Bioscoop.Tests {
    [TestFixture]
    public class OrderTests {
        [Test]
        public void CalculatePrice_EverySecondTicketFreeForStudentsOrWeekdays_ShouldCalculateCorrectPrice() {
            // Arrange
            Movie movie = new Movie("Test Movie");
            MovieScreening screening = new MovieScreening(movie, DateTime.Now, 10.0);

            MovieTicket ticket1 = new MovieTicket(screening, 1, 1, false);
            MovieTicket ticket2 = new MovieTicket(screening, 1, 2, false);
            MovieTicket ticket3 = new MovieTicket(screening, 1, 3, false);
            MovieTicket ticket4 = new MovieTicket(screening, 1, 4, false);
            MovieTicket ticket5 = new MovieTicket(screening, 1, 5, false);

            Order order = new Order(1, true);

            // Act
            order.addSeatReservation(ticket1);
            order.addSeatReservation(ticket2);
            order.addSeatReservation(ticket3);
            order.addSeatReservation(ticket4);
            order.addSeatReservation(ticket5);

            double totalPrice = order.CalculatePrice();

            // Assert
            double expectedTotalPrice = ticket1.getPrice() + ticket2.getPrice() + ticket5.getPrice();

            Assert.AreEqual(expectedTotalPrice, totalPrice);
        }

        [Test]
        public void CalculatePrice_FullPriceForNonStudentsOnWeekendsWithGroupDiscount_ShouldCalculateCorrectPrice() {
            // Arrange
            Movie movie = new Movie("Test Movie");
            MovieScreening screening = new MovieScreening(movie, new DateTime(2024, 2, 4), 15.0); // A weekend date

            MovieTicket ticket1 = new MovieTicket(screening, 1, 1, false);
            MovieTicket ticket2 = new MovieTicket(screening, 1, 2, false);
            MovieTicket ticket3 = new MovieTicket(screening, 1, 3, false);
            MovieTicket ticket4 = new MovieTicket(screening, 1, 4, false);
            MovieTicket ticket5 = new MovieTicket(screening, 1, 5, false);
            MovieTicket ticket6 = new MovieTicket(screening, 1, 6, false);

            Order order = new Order(2, false); // Non-student order

            // Act
            order.addSeatReservation(ticket1);
            order.addSeatReservation(ticket2);
            order.addSeatReservation(ticket3);
            order.addSeatReservation(ticket4);
            order.addSeatReservation(ticket5);
            order.addSeatReservation(ticket6);

            double totalPrice = order.CalculatePrice();

            // Assert
            double expectedTotalPrice = (6 * screening.pricePerSeat) * 0.9;

            Assert.AreEqual(expectedTotalPrice, totalPrice);
        }

        [Test]
        public void CalculatePrice_PremiumTicketPriceAddedCorrectly_ShouldCalculateCorrectPrice() {
            // Arrange
            Movie movie = new Movie("Test Movie");
            MovieScreening screening = new MovieScreening(movie, DateTime.Now, 10.0);

            MovieTicket premiumTicket = new MovieTicket(screening, 1, 1, true);

            Order order = new Order(1, true);

            // Act
            order.addSeatReservation(premiumTicket);

            double totalPrice = order.CalculatePrice();

            // Assert
            double expectedTotalPrice = premiumTicket.getPrice() + 2;

            Assert.AreEqual(expectedTotalPrice, totalPrice);
        }
    }
}
