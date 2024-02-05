using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Bioscoop {
    public class Order {
        public int orderNr { get; set; }
        public bool isStudentOrder { get; set; }
        public List<MovieTicket> movieTickets { get; set; }
        public Order(int orderNr, bool isStudentOrder) {
            this.orderNr = orderNr;
            this.isStudentOrder = isStudentOrder;
            movieTickets = new List<MovieTicket>();
        }

        public void addSeatReservation(MovieTicket ticket) {
            movieTickets.Add(ticket);
        }

        public double CalculatePrice() {

            double totalPrice = 0;

            for (int i = 0; i < movieTickets.Count; i++) {

                MovieTicket ticket = movieTickets[i];
                double priceToAdd = ticket.getPrice();
                bool isWeekDay = ticket.movieScreening.dateAndTime.DayOfWeek >= DayOfWeek.Monday && ticket.movieScreening.dateAndTime.DayOfWeek <= DayOfWeek.Thursday;

                //handeling premium tickets
                if (ticket.isPremium) priceToAdd += isStudentOrder ? 2 : 3;

                //handeling 2nd free tickets for students or weekdays
                if ((isStudentOrder || isWeekDay) && i % 2 == 1) priceToAdd = 0;

                totalPrice += priceToAdd;
            }

            //handeling 10% discount for non students
            if (!isStudentOrder && movieTickets.Count >= 6) totalPrice *= 0.9;

            return totalPrice;
        }

        public void export(TicketExportFormat exportFormat) {
            if(exportFormat == TicketExportFormat.PLAINTEXT) {
                Console.WriteLine(movieTickets.ToString());
            } else {
                Console.WriteLine(JsonSerializer.Serialize(movieTickets));
            }
        }
    }
}
