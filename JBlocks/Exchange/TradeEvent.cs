using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JBlocks.Exchange
{
    public class TradeEvent
    {
        private long TimeStamp { get; set; }
        private string Symbol { get; set; }
        private decimal Amount { get; set; }
    }
}