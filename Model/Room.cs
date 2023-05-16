using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBooking
{
    public class Room
    {
        public int Id {  get; set; }
        public string Floor { get; set; }
        public int Capacity { get; set; }
        public bool Status { get; set; }
    }
}
