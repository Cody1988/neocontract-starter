using System;
using Neo.SmartContract.Framework;

namespace neocontract_starter
{
    /// <summary>
    /// smart contract Calculate
    /// </summary>
    public class Calc : SmartContract
    {
        public static int Main(int a, int b, int c)
        {
            if (a > b)
            {
                return a * Sum(b, c);
            }
            else
            {
                return Sum(a, b) * c;
            }
        }

        public static int Sum(int x, int y)
        {
            return x + y;
        }
    }
}
