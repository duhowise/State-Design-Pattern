using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State_Design_Pattern.Logic
{
    public class PendingState : BookingState
    {


        public override void Cancel(BookingContext bookingContext)
        {
            throw new System.NotImplementedException();
        }

        public override void DatePassed(BookingContext bookingContext)
        {
            throw new System.NotImplementedException();
        }

        public override void EnterDetails(BookingContext bookingContext, string atendee, int ticketCount)
        {
            throw new System.NotImplementedException();
        }

        public override void EnterState(BookingContext bookingContext)
        {
            throw new System.NotImplementedException();
        }


    }
    
}
