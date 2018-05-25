using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem1
{
    [Serializable]
    public class User
    {
        public string name { get; set; }
        public string email { get; set; }
        protected List<Booking> bookingHistory = new List<Booking>();

        public User()
        {
            
        }

        public string getUserName()
        {
            return name;
        }
        public string getUserEmail()
        {
            return email;
        }

        public void updateUser(string name, string email)
        {
            this.name = name;
            this.email = email;
        }

        public bool userAlreadyCreated(string nameCheck, string emailCheck)
        {
            bool isalreadycreated = false;
            int areSame = 0;
            if (nameCheck == name)
            {
                areSame++;
            }
            if (emailCheck == email)
            {
                areSame++;
            }
            if (areSame != 0)
            {
                isalreadycreated = true;
            }
            return isalreadycreated;
        }

        public void addBookingToHistory(Booking newBooking)
        {
            bookingHistory.Add(newBooking);
        }

        public List<Booking> GetBookingsHistory()
        {
            return bookingHistory;
        }

        public void cancelBooking(Booking canceledBoking)
        {
            bookingHistory.Remove(canceledBoking);
        }

        

    }
}
