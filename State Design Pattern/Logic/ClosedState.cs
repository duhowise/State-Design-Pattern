using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State_Design_Pattern.Logic
{
    public class ClosedState : BookingState
    {
        private readonly string reason;

        public ClosedState(string reason)
        {
            this.reason = reason;
        }
        public override void Cancel(BookingContext bookingContext)
        {
            bookingContext.View.ShowError("Invalid action for this state","Closed booking Error");
        }

        public override void DatePassed(BookingContext bookingContext)
        {
            bookingContext.View.ShowError("Invalid action for this state", "Closed booking Error");

        }

        public override void EnterDetails(BookingContext bookingContext, string atendee, int ticketCount)
        {
            bookingContext.View.ShowError("Invalid action for this state", "Closed booking Error");

        }

        public override void EnterState(BookingContext bookingContext)
        {
            bookingContext.ShowState("Closed");
            bookingContext.View.ShowStatusPage(reason);
        }


    }
}
