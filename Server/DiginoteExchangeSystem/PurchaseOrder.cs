﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.DiginoteExchangeSystem
{
    class PurchaseOrder : Order
    {
        public PurchaseOrder(int quantity, DateTime timestamp, DateTime suspension) : base(quantity, timestamp, suspension)
        {
        }

        public PurchaseOrder() : base()
        {

        }
    }
}
