using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem1
{
    [Serializable]
    public class Room:Seat
    {
        private Seat[,] Seats;
        protected int numberOfRows { get; set; }
        protected int numberOfColumns { get; set; }
        public string roomName { get; set; }

        public Seat getSeatFromRoom(Seat requestedSeat)
        {
            Seat mySeat = null;
            foreach(Seat s in Seats)
            {
                if (s == requestedSeat)
                {
                    mySeat = s;
                }
            }
            return mySeat;

        }

        public Seat getSeatFromRoom(int Row, int Column)
        {

            return Seats[Row-1,Column-1] ;
        }

        public Room()
        {
            
        }

        // Initialize a seat for every position available inside the room
        public void configureRoom(int numberRows, int numberColumns, string roomName)
        {
            numberOfRows = numberRows;
            numberOfColumns = numberColumns;
            this.roomName = roomName;
            Seats = new Seat[numberOfRows, numberOfColumns];
            for (int i = 0;i<numberOfRows;i++)
            {
                for(int j = 0;j<numberOfColumns;j++)
                {
                    Seat newSeat = new Seat();
                    newSeat.configureSeat(i + 1, j + 1);
                    Seats[i, j] = newSeat;
                }
            }

        }

        //Console print displaying information about all seats
        public void printAllSeatInfo()
        {
            string information = "Number of Seats: " + Seats.Length + "\n";

            for (int i = 0; i < numberOfRows; i++)
            {
                for (int j = 0; j < numberOfColumns; j++)
                {
                    information = information + " Seat Name: " + Seats[i, j].seatName + " Seat location: r: " + Seats[i, j].getRow().ToString() + " c: " + Seats[i, j].getColumn().ToString() + " isBooked: " + Seats[i, j].isBooked + "\n";
                }
            }
            Console.WriteLine(information);
        }
    }
}
