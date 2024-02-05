using Bioscoop.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bioscoop.Behaviors.Pricing
{
    internal class GroupDisscountRule : IPriceCalculationStrategy
    {
        public double EditPrice(List<MovieTicket> tickets, bool isStudentOrder, double startingPrice, int ticketNumber)
        {
            if (isStudentOrder && tickets.Count >= 6) return startingPrice *= 0.9;
            return startingPrice;
        }
    }
}
