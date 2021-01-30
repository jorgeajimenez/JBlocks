using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JBlocks.Transactions;
using JBlocks.Block;

namespace JBlocks.BlockChain
{
    public class JBlockChain : IBlockChain<JBlock>
    {
        public IEnumerable<JBlock> Chain { get; set; }

        public JBlock Initialize(Transaction transaction)
        {
            return new JBlock();
        }

        public JBlock CreateGenesisBlock()
        {
            //  creates a new block with timestamp
            var genesis = new JBlock();

            //  assign empty data, calculate hash for seeding the chain
            genesis.Data = new CryptoTransaction() { SourceWalletId = "", DestinationWalletId = "", Amount = 0.0 };
            genesis.CurrentHash = genesis.CalculateHash();

            return genesis;
        }

        public void AddGenesisBlock(JBlock block)
        {
            var chain = Chain as List<JBlock>;
            if (chain == null) chain = new List<JBlock>();

            chain.Add(block);
            Chain = chain;
        }

        public void AddGenesisBlock()
        {
            var chain = Chain as List<JBlock>;
            if (chain == null) chain = new List<JBlock>();

            chain.Add(CreateGenesisBlock());
            Chain = chain;
        }

        public JBlock GetLatestBlock()
        {
            return Chain.ToList()[Chain.ToList().Count - 1];
        }

        public void AddBlock(JBlock block)
        {
            var latestBlock = GetLatestBlock();
            block.Index = latestBlock.Index + 1;
            block.PreviousHash = latestBlock.CurrentHash;
            block.CurrentHash = block.CalculateHash();

            block.Target = block.Data.DestinationWalletId;
            block.Source = block.Data.SourceWalletId;

            var chain = Chain as List<JBlock>;
            if (chain == null) chain = new List<JBlock>();
            chain.Add(block);
            Chain = chain;
        }
    }
}