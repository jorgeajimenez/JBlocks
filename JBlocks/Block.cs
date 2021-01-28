using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace JBlocks
{
    public abstract class Block<T>
    {
        public int Index { get; set; }
        public long TimeStamp { get; set; }
        public T Data { get; set; }
        public string PreviousHash { get; set; }
        public string Nonce { get; set; }
        public string Target { get; set; }
        public string Source { get; set; }
        public string CurrentHash { get; set; }

        public Block(long timestamp, string previousHash, T data)
        {
            TimeStamp = timestamp;
            PreviousHash = previousHash;
            Data = data;
            Index = 0;
        }

        public Block()
        {
            TimeStamp = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            Index = 0;
        }

        public virtual string CalculateHash()
        {
            var sha256 = SHA256.Create();

            byte[] inputBytes = Encoding.ASCII.GetBytes($"{TimeStamp}-{PreviousHash ?? ""}-{Data.GetHashCode()}");
            byte[] outputBytes = sha256.ComputeHash(inputBytes);

            return Convert.ToBase64String(outputBytes);
        }
    }
}