using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingSystem1;

namespace BookingConsole
{


    class Program
    {
        static void Main(string[] args)
        {
            manageSystem.addBookingTest();
            
            manageSystem.serializeBookings();

            Console.ReadLine();
        }


    }

    public class manageSystem
    {
        //My lists of data
        public static List<Room> myRooms = new List<Room>();
        public static List<Event> myEvents = new List<Event>();
        public static List<User> myUsers = new List<User>();
        public static List<Booking> myBookings = new List<Booking>();

        //Serialize the list of Bookings
        public static void serializeBookings()
        {
            try
            {
                System.Xml.Serialization.XmlSerializer writer =
                       new System.Xml.Serialization.XmlSerializer(typeof(List<Booking>));

                var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//SerializationBooking.xml";
                System.IO.FileStream file = System.IO.File.Create(path);

                writer.Serialize(file, myBookings);
                file.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine("Error - Unable to earialize: " + e.Message); 
            }
        }

        //Creates
        public static void createUser(string name, string email)
        {
            bool exists = false;
            foreach (User i in myUsers)
            {
                if (i.userAlreadyCreated(name, email) == true)
                {
                    exists = true;
                    break;
                }
            }
            if (exists == false)
            {
                User newUser = new User();
                newUser.updateUser(name, email);
                myUsers.Add(newUser);
            }
            else
            {
                Console.WriteLine("User already exists");
            }

        }

        //Creates an object of type Room and ads it to the list of rooms
        public static void createRoom(int numberOfRows, int numberOfColumns, string name)
        {
            Room newRoom = new Room();
            newRoom.configureRoom(numberOfRows, numberOfColumns, name);
            myRooms.Add(newRoom);
        }

        //Creates an object of type Event and ads it to the list of Events
        public static void createEvent(string name, Room eventLocation)
        {
            Event newEvent = new Event();
            newEvent.configureEvent(name, eventLocation);
            myEvents.Add(newEvent);
        }

        //Override Method that allows the event creator to select maximum number of bookings per user
        //Creates an object of type Event and ads it to the list of Events
        public static void createEvent(string name, Room eventLocation, int bookingsPerUser)
        {
            Event newEvent = new Event();
            newEvent.configureEvent(name, eventLocation);
            newEvent.bookingsPerUser = bookingsPerUser;
            myEvents.Add(newEvent);
        }

        //Creates an object of type Booking and ads it to the list of Bookings
        public static void createBooking(User Client, Event attendedEvent, Seat reservedSeat)
        {
            Booking newBooking = new Booking();
            newBooking.bookASeat(Client, attendedEvent, reservedSeat);
            if (newBooking.bookingSuccesfull)
            {
                Client.addBookingToHistory(newBooking);
                myBookings.Add(newBooking);
            }
        }

        //Testing Method to Showcase working example
        public static void addBookingTest()
        {
            int numberOfBookings = 6;
            int creatRoomRows = 10, createRoomColumns = 10;

            createRoom(creatRoomRows, createRoomColumns, "Meeting Room 1");
            createEvent("Eastleigh Monthly meeting", myRooms[0], 4);
            createUser("Bogdan", "b@s.com");



            for (int i = 1; i <= numberOfBookings; i++)
            {
                createBooking(myUsers[0], myEvents[0], myEvents[0].EventRoom.getSeatFromRoom(1, i));
            }

            Console.WriteLine("Bookings Count = " + myBookings.Count);
            //createUser("Bogdan2", "m@c.com");
            //createBooking(myUsers[1], myEvents[0], myEvents[0].EventRoom.getSeatFromRoom(1, 1));

        }
    }
}
