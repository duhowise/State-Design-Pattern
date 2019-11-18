namespace State_Design_Pattern.Logic
{
    public abstract class BookingState
    {
        public abstract void EnterState(BookingContext bookingContext);
        public abstract void Cancel(BookingContext bookingContext);
        public abstract void DatePassed(BookingContext bookingContext);
        public abstract void EnterDetails(BookingContext bookingContext,string atendee,int ticketCount);
        
    }
}
