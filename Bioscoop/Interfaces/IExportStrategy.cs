using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bioscoop.Interfaces {
    public interface IExportStrategy {
        void Export(List<MovieTicket> movieTickets);
    }
}
