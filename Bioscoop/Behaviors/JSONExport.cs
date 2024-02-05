using Bioscoop.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Bioscoop.Behaviors {
    public class JSONExport : IExportStrategy {
        public void Export(List<MovieTicket> movieTickets) {
            Console.WriteLine(JsonSerializer.Serialize(movieTickets));
        }
    }
}
