using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace xeuclid
{
    public class RSASolver
    {
        // Algorithmus Source:
        // https://assignmentshark.com/blog/extended-euclidean-algorithm-example/
        public void Solve(public_key public_Key_Arthur, public_key public_Key_Ford, BigInteger chiffre)
        {
            BigInteger p = BerechneP(public_Key_Arthur, public_Key_Ford);
            BigInteger q1 = BerechneQ1(public_Key_Arthur, p);
            BigInteger q2 = BerechneQ2(public_Key_Ford, p);

            BigInteger a = public_Key_Arthur.e;
            BigInteger b = BerechneB(p, q1);

            EuclidExtendedSolution solution = BerechneEEALösung(a, b);

            BigInteger M = BerechneMessage(public_Key_Arthur, chiffre, solution);
            BigInteger C_Kontrolle = BerechneChiffrat(public_Key_Arthur, M);
        }

        private static BigInteger BerechneP(public_key public_Key_Arthur, public_key public_Key_Ford)
        {
            return BigInteger.GreatestCommonDivisor(public_Key_Arthur.N, public_Key_Ford.N);
        }

        private static BigInteger BerechneQ1(public_key public_Key_Arthur, BigInteger p)
        {
            return public_Key_Arthur.N / p;
        }

        private BigInteger BerechneQ2(public_key public_Key_Ford, BigInteger p)
        {
          return public_Key_Ford.N / p;
        }

        private static BigInteger BerechneB(BigInteger p, BigInteger q1)
        {
            return (p - 1) * (q1 - 1);
        }

        private BigInteger BerechneChiffrat(public_key public_Key_Arthur, BigInteger M)
        {
            return BigInteger.ModPow(M, public_Key_Arthur.e, public_Key_Arthur.N);
        }

        private BigInteger BerechneMessage(public_key public_Key_Arthur, BigInteger chiffre, EuclidExtendedSolution solution)
        {
            return BigInteger.ModPow(chiffre, solution.X, public_Key_Arthur.N);
        }

        private EuclidExtendedSolution BerechneEEALösung(BigInteger a, BigInteger b)
        {
            EuclidExtended euclidExtended = new EuclidExtended(a, b);
            EuclidExtendedSolution solution = euclidExtended.solve();
            return solution;
        }
    }

}
