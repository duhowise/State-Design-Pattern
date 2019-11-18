namespace State_Design_Pattern.Logic
{
    public class BookedState : BookingState
    {
        
        
        public override void Cancel(BookingContext bookingContext)
        {
            bookingContext.TransitionToState(new ClosedState("Booking canceled:  Expect a refund"));
        }

        public override void DatePassed(BookingContext bookingContext)
        {
            bookingContext.TransitionToState(new ClosedState("We hope you Enjoyed the event"));
        }

        public override void EnterDetails(BookingContext bookingContext, string atendee, int ticketCount)
        {
            throw new System.NotImplementedException();
        }

        public override void EnterState(BookingContext bookingContext)
        {
            bookingContext.ShowState("Booked");
            bookingContext.View.ShowStatusPage("Enjoy the event");
        }
   
        
    }
}
