using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JBlocks.Tests
{
    [TestClass]
    public class JBlockChainTests
    {
        private readonly string testSourceWalledId = $"c9b79ff1841fb5cfecc66e1ea5a29b4d";
        private readonly string testDestinationWalledId = $"bee2f0b0c21075018e494bdf075b0b23";
        private readonly double testAmount = 19.95;

        [TestMethod]
        public void TestGenerateDefaultJBlock()
        {
            var jBlock = new JBlock();

            Assert.AreEqual(jBlock.Index, 0);
        }

        [TestMethod]
        public void TestGenerateJBlock()
        {
            var jBlock = new JBlock();

            jBlock.Data = new CryptoTransaction()
            {
                SourceWalletId = testSourceWalledId,
                DestinationWalletId = testDestinationWalledId,
                Amount = testAmount
            };

            //  verify that object is properly constructed
            Assert.AreEqual(jBlock.Index, 0);
            Assert.AreEqual(jBlock.Data.SourceWalletId, testSourceWalledId);
            Assert.AreEqual(jBlock.Data.DestinationWalletId, testDestinationWalledId);
            Assert.AreEqual(jBlock.Data.Amount, testAmount);
        }

        [TestMethod]
        public void TestGenerateBlockchain()
        {
            var testCoin = new JBlockChain();

            testCoin.AddGenesisBlock();

            //  send money
            testCoin.AddBlock(new JBlock()
            {
                Data = new CryptoTransaction()
                {
                    SourceWalletId = testSourceWalledId,
                    DestinationWalletId = testDestinationWalledId,
                    Amount = testAmount
                }
            });

            //  send back half
            testCoin.AddBlock(new JBlock()
            {
                Data = new CryptoTransaction()
                {
                    SourceWalletId = testDestinationWalledId,
                    DestinationWalletId = testSourceWalledId,
                    Amount = testAmount * .5
                }
            });
            var chain = testCoin.Chain as List<JBlock>;

            Assert.AreEqual(chain.Count, 3);
        }
    }
}