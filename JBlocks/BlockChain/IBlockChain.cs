using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JBlocks.Transactions;

namespace JBlocks.BlockChain
{
    public interface IBlockChain<T>
    {
        //  enumerable containing the blocks
        IEnumerable<T> Chain { get; set; }

        //  initialize a block with a new transaction
        T Initialize(Transaction transaction);

        //  create root node for the chain
        T CreateGenesisBlock();

        //  add root node to the chain with no data
        void AddGenesisBlock();

        // add genesit block with pre-determined block
        void AddGenesisBlock(T block);

        //  fetch block last inserted
        T GetLatestBlock();

        //  add new block (reference previous block)
        void AddBlock(T block);
    }
}