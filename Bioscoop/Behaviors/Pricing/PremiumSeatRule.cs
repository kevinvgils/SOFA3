using Bioscoop.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Bioscoop.Behaviors.Pricing
{
    internal class PremiumSeatRule : IPriceCalculationStrategy
    {
        public double EditPrice(List<MovieTicket> tickets, bool isStudentOrder, double startingPrice, int ticketNumber)
        {
            if (!tickets[ticketNumber].isPremium) return startingPrice;
            return startingPrice += isStudentOrder ? 2 : 3;
        }
    }
}
