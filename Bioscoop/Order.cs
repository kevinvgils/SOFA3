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

            if (isStudentOrder) {
                // Every 2nd ticket is free for students
                for (int i = 0; i < movieTickets.Count; i++) {
                    if (movieTickets[i].isPremium) {
                        totalPrice += i % 2 == 0 ? movieTickets[i].getPrice() + 2 : 0;
                    } else {
                        totalPrice += i % 2 == 0 ? movieTickets[i].getPrice() : 0;
                    }
                }
                return totalPrice;
            } else {
                // Every 2nd ticket is free for everyone on weekdays
                for (int i = 0; i < movieTickets.Count; i++) {
                    if (movieTickets[i].movieScreening.dateAndTime.Day <= 4) {
                        if (movieTickets[i].isPremium) {
                            totalPrice += i % 2 == 0 ? movieTickets[i].getPrice() + 3 : 0;
                        } else {
                            totalPrice += i % 2 == 0 ? movieTickets[i].getPrice() : 0;
                        }
                    } else {
                        totalPrice += movieTickets[i].getPrice();
                    }
                }

                // If order is 6 or more give 10% discount

                if(movieTickets.Count >= 6) {
                    totalPrice *= 0.9;
                }
                return totalPrice;
            }
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
