﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomBooking
{
    public class Account
    {
        public int EmployeeId { get; set; }
        public string Password { get; set; }
        public bool IsDeleted { get; set; }
        public string OTP { get; set; }
        public bool IsUsed { get; set; }
        public DateTime ExpiredTime { get; set; }
    }
}
