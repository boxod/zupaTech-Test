using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem1
{
    [Serializable]
    public class Booking
    {
        public int bookingID { get; set; }
        public User client { get; set; }
        public Event attendingEvent { get; set; }
        public Seat BookedSeat { get; set; }
        public bool bookingSuccesfull { get; set; }
        public float bookingPrice { get; set; }
        
        public Booking()
        {

        }
        

        public void bookASeat(User client, Event attendingEvent, Seat BookedSeat)
        {
            this.client = client;
            this.attendingEvent = attendingEvent;
            this.BookedSeat = BookedSeat;
            bookingSuccesfull = false;
            if (checkNumberOfBookedSeatsPerUser() == true)
            {
                if (attendingEvent.EventRoom.getSeatFromRoom(BookedSeat).canBeBooked() == true)
                {
                    attendingEvent.EventRoom.getSeatFromRoom(BookedSeat).bookSeat();
                    attendingEvent.EventRoom.getSeatFromRoom(BookedSeat).isBooked = true;
                    bookingSuccesfull = true;
                }
            }
        }


        public bool checkNumberOfBookedSeatsPerUser()
        {
            int bookingsDone = 1;
            bool canHeBook = true;
            List<Booking> userBookings = client.GetBookingsHistory();
            foreach(Booking b in userBookings)
            {
                if(b.attendingEvent == attendingEvent)
                {
                    bookingsDone++;
                }
                
            }
            if(bookingsDone > attendingEvent.bookingsPerUser)
            {
                canHeBook = false;
            }
            
            return canHeBook;
        }


        //string returning information
        //public string BookingInformation()
        //{
        //    string information = "";
        //    information = information + "Client name: " + client.getUserName() + "\n" +
        //                                "Client email: " + client.getUserEmail() + "\n" +
        //                                "Event Name: " + attendingEvent.eventName + "\n" +
        //                                "Event Room: " + attendingEvent.EventRoom.roomName + "\n" +
        //                                "Can He Book: " + checkNumberOfBookedSeatsPerUser().ToString() + "\n" +
        //                                "Seat Booked: " + attendingEvent.EventRoom.getSeatFromRoom(BookedSeat).canBeBooked().ToString() + "\n" + 
        //                                "Seat Name: " + attendingEvent.EventRoom.getSeatFromRoom(BookedSeat).seatName + "\n";

        //    return information;
        //}

    }
}
