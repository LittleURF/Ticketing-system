﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticketing_System
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new TicketsDB();
            var mainTicket = db.GetTicket(1);
            mainTicket.DisplayTicket();

        }
    }
}