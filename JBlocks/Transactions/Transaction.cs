using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JBlocks.Transactions
{
    public abstract class Transaction
    {
        public string SourceWalletId { get; set; }
        public string DestinationWalletId { get; set; }
        public double Amount { get; set; }
    }
}