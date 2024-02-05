namespace Bioscoop.Interfaces {
    public interface IPriceCalculationStrategy {
        double CalculatePrice(MovieTicket ticket, bool isStudentOrder, bool isWeekDay);
    }
}