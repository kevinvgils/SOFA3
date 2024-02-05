﻿using Bioscoop.Interfaces;

namespace Bioscoop.Behaviors.Export
{
    public class PlainTextExport : IExportStrategy
    {
        public void Export(List<MovieTicket> movieTickets)
        {
            Console.WriteLine(movieTickets.ToString());
        }
    }
}