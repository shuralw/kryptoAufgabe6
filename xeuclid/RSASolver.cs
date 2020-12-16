﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace xeuclid
{
    class RSASolver
    {
        // Algorithmus Source:
        // https://assignmentshark.com/blog/extended-euclidean-algorithm-example/
        public void Solve(public_key public_Key_Arthur, public_key public_Key_Ford, BigInteger chiffre)
        {
            BigInteger p = BigInteger.GreatestCommonDivisor(public_Key_Arthur.N, public_Key_Ford.N);
            BigInteger q1 = public_Key_Arthur.N / p;
            BigInteger q2 = public_Key_Ford.N / p;

            BigInteger a = public_Key_Arthur.e;
            BigInteger b = (p - 1) * (q1 - 1);

            EuclidExtended euclidExtended = new EuclidExtended(a, b);
            EuclidExtendedSolution solution = euclidExtended.solve();

            BigInteger M = BigInteger.ModPow(chiffre, solution.D, public_Key_Arthur.N);

            //Console.WriteLine("gcd(" + a + " , " + b + ") = {" + solution.D + ", {" + solution.X + ", " + solution.Y + "}}");
            Console.WriteLine("gcd(" + a + " , " + b + ") = ");

            Console.WriteLine("D: " + solution.D);
            Console.WriteLine("X: " + solution.X);
            Console.WriteLine("Y: " + solution.Y);

            Console.WriteLine("Message: " + M);
        }



    }

}
