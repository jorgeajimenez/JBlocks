﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JBlocks.Transactions;

namespace JBlocks.Block
{
    public class JBlock : Block<Transaction>
    {
        public JBlock() : base()
        {
        }

        public JBlock(long timestamp, string previousHash, Transaction data) : base(timestamp, previousHash, data)
        {
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}