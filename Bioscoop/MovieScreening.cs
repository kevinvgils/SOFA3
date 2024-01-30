using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bioscoop {
    public class MovieScreening {
        public DateTime dateAndTime;
        public double pricePerSeat { get; set; }
        public Movie movie { get; set; }

        public MovieScreening(Movie movie, DateTime dateTime, double pricePerSeat) {
            this.dateAndTime = dateTime;
            this.pricePerSeat = pricePerSeat;
            this.movie = movie;
        }
    }
}
