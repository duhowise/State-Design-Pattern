using System;
using System.Threading;
using State_Design_Pattern.UI;

namespace State_Design_Pattern.Logic
{
    public class Booking
    {
        private MainWindow View { get;  set; }
        private bool isNew;
        private bool isPending;
        private bool isBooked;
        public string Attendee { get; set; }
        public int TicketCount { get; set; }
        public int BookingID { get; set; }

        private CancellationTokenSource cancelToken;
       
        public Booking(MainWindow view)
        {
            isNew = true;
            isPending= true;
            View = view;
            BookingID = new Random().Next();
            ShowState("New");
            view.ShowEntryPage();
        }

        public void SubmitDetails(string attendee, int ticketCount)
        {
            if (isNew)
            {
                isNew = false;
                Attendee = attendee;
                TicketCount = ticketCount;
                cancelToken = new CancellationTokenSource();
                StaticFunctions.ProcessBooking(this, ProcessingComplete, cancelToken);
                ShowState("Pending");
                View.ShowStatusPage("Processing Booking");
            }
        }

        public void Cancel()
        {
            if (isNew)
            {

                ShowState("Closed");
                View.ShowStatusPage("Canceled by user");
                isNew = false;
            }
            else if(isPending)
            {
                cancelToken.Cancel(); 
            }
            else if (isBooked)
            {
                ShowState("Closed");
                View.ShowStatusPage("Booking canceled expect a refund");
                isBooked = false;
            }

            else
            {
                View.ShowError("Closed bookings cannot be canceled");
            }
        }

        public void DatePassed()
        {
            if (isNew)
            {
                ShowState("Closed");
                View.ShowStatusPage("Booking Expired");
                isNew = false;
            }
            else if (isBooked)
            {
                ShowState("Closed");
                View.ShowStatusPage("we hope you enjoyed the event");
                isBooked = false;
            }

            else
            {
                View.ShowError("Closed bookings cannot expire");

            }
        }

        public void ProcessingComplete(Booking booking, ProcessingResult result)
        {
            isPending = false;
            switch (result)
            {
                case ProcessingResult.Sucess:
                    ShowState("Booked");
                    View.ShowStatusPage("Enjoy the Event");
                    break;
                case ProcessingResult.Fail:
                    isNew = true;
                    View.ShowProcessingError();
                    Attendee = string.Empty;
                    BookingID = new Random().Next();
                    ShowState("New");
                    View.ShowEntryPage();
                    break;
                case ProcessingResult.Cancel:
                    ShowState("Closed");
                    View.ShowStatusPage("Processing Canceled");
                    break;
            }
        }

        public void ShowState(string stateName)
        {
            View.grdDetails.Visibility = System.Windows.Visibility.Visible;
            View.lblCurrentState.Content = stateName;
            View.lblTicketCount.Content = TicketCount;
            View.lblAttendee.Content = Attendee;
            View.lblBookingID.Content = BookingID;
        }

      

    }
}


