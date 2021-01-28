using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JBlocks
{
    public interface IBlockChain<T>
    {
        IEnumerable<T> Chain { get; set; }

        T Initialize(Transaction transaction);

        T CreateGenesisBlock();

        void AddGenesisBlock();

        T GetLatestBlock();

        void AddBlock(T block);
    }
}