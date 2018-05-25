using System;
using BookingSystem1;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BookingConsole.UnitTest
{
    [TestClass]
    public class BookingTests
    {
        [TestMethod]
        public void bookASeat_simlpeBooking_ReturnsTrue()
        {
            //Arrange
            var bookARoom = new Booking();
            var createRoom = new Room();
            var createEvent = new Event();
            var createUser = new User();
            int roomRows = 10;
            int roomColumns = 10;
            string roomName = "NewRoom";
            string eventName = "NewEvent";
            string userName = "NewName";
            string userEmail = "NewEmail";
            //Act
            createRoom.configureRoom(roomRows,roomColumns,roomName);
            createEvent.configureEvent(eventName,createRoom);
            createUser.updateUser(userName,userEmail);
            bookARoom.bookASeat(createUser,createEvent,createEvent.EventRoom.getSeatFromRoom(1,1));

            var result = bookARoom.attendingEvent.EventRoom.getSeatFromRoom(1, 1).isBooked;
            //Assert
            Assert.IsTrue(result);
        }
    }
}
