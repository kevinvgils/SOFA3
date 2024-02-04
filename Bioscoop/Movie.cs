using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bioscoop {
    public class Movie {
        public string Title;
        public List<MovieScreening> movieScreenings;
        public Movie(string title) {
            this.Title = title;
        }

        public void addScreening(MovieScreening screening) {
            this.movieScreenings.Add(screening);
        }
    }
}
