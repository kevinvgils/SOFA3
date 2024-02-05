using Bioscoop.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Bioscoop.Behaviors.Pricing
{
    internal class FreeSeatRule : IPriceCalculationStrategy
    {
        public double EditPrice(List<MovieTicket> tickets, bool isStudentOrder, double startingPrice, int ticketNumber)
        {
            bool isWeekDay = tickets[ticketNumber].movieScreening.dateAndTime.DayOfWeek >= DayOfWeek.Monday && tickets[ticketNumber].movieScreening.dateAndTime.DayOfWeek <= DayOfWeek.Thursday;

            if ((isStudentOrder || isWeekDay) && ticketNumber % 2 == 1) return 0;
            return startingPrice;
        }
    }
}
