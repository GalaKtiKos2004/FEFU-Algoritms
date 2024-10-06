using System;

namespace Informatics
{
    public class BitManipulator
    {
        private const int BitesInByte = 8;

        private byte[] _byteArray;

        public BitManipulator(int bitCount)
        {
            _byteArray = new byte[(bitCount + BitesInByte) / BitesInByte];
        }

        public void SetBit(int index, bool value)
        {
            int byteIndex = index / BitesInByte;
            int bitPosition = index % BitesInByte;

            if (value)
            {
                _byteArray[byteIndex] |= (byte)(1 << bitPosition);
            }
            else
            {
                _byteArray[byteIndex] &= (byte)~(1 << bitPosition);
            }
        }

        public bool GetBit(int index)
        {
            int byteIndex = index / 8;
            int bitPosition = index % 8;
            return (_byteArray[byteIndex] & (1 << bitPosition)) != 0;
        }
    }

    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            BitManipulator primes = new BitManipulator(n + 1);

            for (int i = 2; i <= n; i++)
            {
                primes.SetBit(i, true);
            }

            for (int i = 2; i * i <= n; i++)
            {
                if (primes.GetBit(i))
                {
                    for (int j = i * i; j <= n; j += i)
                    {
                        primes.SetBit(j, false);
                    }
                }
            }

            for (int i = 2; i <= n; i++)
            {
                if (primes.GetBit(i))
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}