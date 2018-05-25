using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem1
{
    public class Seat
    {
        protected int Row { get; set; }
        protected int Column { get; set; }
        public string seatName { get; set; }
        protected bool isBookingRequested { get; set; }
        public bool isBooked { get; set; }
        
        //Name seats using the requested Letter + Number convention 
        //initialize and make all seats bookable and available
        public void configureSeat(int Row, int Column)
        {
            this.Row = Row;
            this.Column = Column;
            isBooked = false;
            isBookingRequested = false;
            nameSeat(Row, Column);
        }

        public Seat()
        {
            
        }

        //Getters and Setters
        public int getRow()
        {
            return Row;
        }
        public int getColumn()
        {
            return Column;
        }

        //Checking whether the seat has already been booked
        public bool canBeBooked()
        {
            bool canBook = false;
            if(isBooked == false)
            {
                canBook = true;
            }
            return canBook;
        }

        public bool bookSeat()
        {
            isBooked = true;
            return isBooked;
        }

        public bool unbookSeat()
        {
            isBooked = false;
            return isBooked;
        }

        //public bool bookingRequested(){}

        public void nameSeat(int r, int c)
        {

           switch(r)
            {
                case 1:
                    seatName = "A" + c.ToString();
                    break;
                case 2:
                    seatName = "B" + c.ToString();
                    break;
                case 3:
                    seatName = "C" + c.ToString();
                    break;
                case 4:
                    seatName = "D" + c.ToString();
                    break;
                case 5:
                    seatName = "E" + c.ToString();
                    break;
                case 6:
                    seatName = "F" + c.ToString();
                    break;
                case 7:
                    seatName = "G" + c.ToString();
                    break;
                case 8:
                    seatName = "H" + c.ToString();
                    break;
                case 9:
                    seatName = "I" + c.ToString();
                    break;
                case 10:
                    seatName = "J" + c.ToString();
                    break;
                case 11:
                    seatName = "K" + c.ToString();
                    break;


            }

        }
    }
}
