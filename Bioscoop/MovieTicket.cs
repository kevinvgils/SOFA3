namespace Bioscoop {
    public class MovieTicket {
        public int rowNr;
        public int seatNr;
        public bool isPremium;
        public MovieScreening movieScreening;

        public MovieTicket(MovieScreening movieScreening, int rowNr, int seatNr, bool isPremiumReservation) {
            this.rowNr = rowNr;
            this.seatNr = seatNr;
            this.isPremium= isPremiumReservation;
            this.movieScreening= movieScreening;
        }

        public double getPrice() {
            return movieScreening.pricePerSeat;
        }
    }
}