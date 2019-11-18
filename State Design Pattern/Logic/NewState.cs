using System;

namespace State_Design_Pattern.Logic
{
    public class NewState : BookingState
    {
        public override void Cancel(BookingContext bookingContext)
        {
            bookingContext.TransitionToState(new ClosedState("Booking Canceled"));
        }

        public override void DatePassed(BookingContext bookingContext)
        {
            bookingContext.TransitionToState(new ClosedState("Booking Expired"));

        }

        public override void EnterDetails(BookingContext bookingContext, string attendee, int ticketCount)
        {
            bookingContext.Attendee = attendee;
            bookingContext.TicketCount = ticketCount;
            bookingContext.TransitionToState(new PendingState());
        }

        public override void EnterState(BookingContext bookingContext)
        {
            bookingContext.BookingID = new Random().Next();
            bookingContext.ShowState("New");
            bookingContext.View.ShowEntryPage();
        }
    }
}
