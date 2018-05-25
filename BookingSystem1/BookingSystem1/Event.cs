using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem1
{
    [Serializable]
    public class Event
    {
        
        public string eventName { get; set; }
        public DateTime eventDateStart{ get; set; }
        public DateTime eventEndDate { get; set; }
        public Room EventRoom { get; set; }
        public int bookingsPerUser = 1;

        public Event( )
        {
           
        }

        public void configureEvent(string eventName, Room EventRoom)
        {
            this.eventName = eventName;
            this.EventRoom = EventRoom;
        }


    }
}
