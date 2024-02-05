using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Bioscoop.Behaviors.Pricing;
using Bioscoop.Interfaces;

namespace Bioscoop {
    public class Order {
        public int orderNr { get; set; }
        public bool isStudentOrder { get; set; }
        public List<MovieTicket> movieTickets { get; set; }

        private IExportStrategy ExportStrategy;
        private List<IPriceCalculationStrategy> PricePerTicketCalculationStrategies;
        private List<IPriceCalculationStrategy> GroupPriceCalculationStrategies;

        public Order(int orderNr, bool isStudentOrder, IExportStrategy exportStrategy) {
            this.orderNr = orderNr;
            this.isStudentOrder = isStudentOrder;
            movieTickets = new List<MovieTicket>();

            PricePerTicketCalculationStrategies = new List<IPriceCalculationStrategy>();
            PricePerTicketCalculationStrategies.Add(new PremiumSeatRule());
            PricePerTicketCalculationStrategies.Add(new FreeSeatRule());
            

            GroupPriceCalculationStrategies = new List<IPriceCalculationStrategy>();
            GroupPriceCalculationStrategies.Add(new GroupDisscountRule());

            ExportStrategy = exportStrategy;
        }

        public void addSeatReservation(MovieTicket ticket) {
            movieTickets.Add(ticket);
        }

        public double CalculatePrice() {

            double totalPrice = 0;

            for (int i = 0; i < movieTickets.Count; i++) {

                MovieTicket ticket = movieTickets[i];
                double priceToAdd = ticket.getPrice();

                //Handeling strategies related to the individual ticket price
                foreach (IPriceCalculationStrategy strategy in PricePerTicketCalculationStrategies)
                {
                    priceToAdd = strategy.EditPrice(movieTickets, isStudentOrder, priceToAdd, i);
                }

                totalPrice += priceToAdd;
            }

            //Handeling strategies related to the full price
            foreach (IPriceCalculationStrategy strategy in GroupPriceCalculationStrategies)
            {
                totalPrice = strategy.EditPrice(movieTickets, isStudentOrder, totalPrice, 0);
            }

            return totalPrice;
        }

        public void setExportStrategy(IExportStrategy exportStrategy) {
            this.ExportStrategy = exportStrategy;
        }

        public void export() {
            ExportStrategy.Export(this.movieTickets);
        }
    }
}
