namespace Bioscoop.Interfaces {
    public interface IPriceCalculationStrategy {
        double EditPrice(List<MovieTicket> tickets, bool isStudentOrder, double startingPrice, int ticketNumber);
    }
}