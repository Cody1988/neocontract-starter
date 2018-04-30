using System;
using System.IO;
using System.Linq;
using Neo.Cryptography;
using Neo.VM;

namespace neocontract_starter_unittest
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new ExecutionEngine(null, Crypto.Default);

            byte[] script = File.ReadAllBytes(@"/Users/cody/project/learn-plan/neo/neocontract/neocontract-starter/neocontract-starter/bin/Debug/netstandard2.0/neocontract-starter.avm");
            engine.LoadScript(script);

            using (ScriptBuilder builder = new ScriptBuilder())
            {
                //builder.EmitPush(2); // value for c
                //builder.EmitPush(3); // value for b
                //builder.EmitPush(5); // value for a 

                int[] parameters = { 3, 4, 2 };
                // parameter pass to contract by stack order, so reverse array first
                parameters.Reverse().ToList().ForEach(p =>
                {
                    builder.EmitPush(p);
                });
                engine.LoadScript(builder.ToArray());
            }
            // execute engine
            engine.Execute();

            var result = engine.EvaluationStack.Peek().GetBigInteger();
            Console.WriteLine($"execute result : {result}");
            Console.ReadLine();
        }
    }
}
