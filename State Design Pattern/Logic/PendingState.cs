using System;
using System.Threading;

namespace State_Design_Pattern.Logic
{
    public class PendingState : BookingState
    {
        CancellationTokenSource cancellationToken;


        public override void Cancel(BookingContext bookingContext)
        {
            cancellationToken.Cancel();
        }

        public override void DatePassed(BookingContext bookingContext)
        {
        }

        public override void EnterDetails(BookingContext bookingContext, string atendee, int ticketCount)
        {
        }

        public override void EnterState(BookingContext bookingContext)
        {
            cancellationToken = new CancellationTokenSource();
            bookingContext.ShowState("Pending");
            bookingContext.View.ShowStatusPage("Processing booking");
                StaticFunctions.ProcessBooking(bookingContext, ProcessingComplete, cancellationToken);
        }

        private void ProcessingComplete(BookingContext booking, ProcessingResult result)
        {
            switch (result)
            {
                case ProcessingResult.Sucess:
                    booking.TransitionToState(new NewState());
                    break;
                case ProcessingResult.Fail:
                    booking.View.ShowProcessingError();
                    booking.TransitionToState(new NewState());
                    break;
                case ProcessingResult.Cancel:
                    booking.TransitionToState(new ClosedState("Processing Canceled"));
                    break;
                default:
                    break;
            }
        }
    }
    
}
