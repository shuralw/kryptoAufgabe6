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
        public BigInteger BerechneMessageAnhandEinesChiffratsUndPublicKeys(public_key publicKeyVonA, public_key publicKeyVonB, BigInteger chiffre)
        {
            BigInteger p = BerechneP(publicKeyVonA, publicKeyVonB);
            BigInteger q1 = BerechneQ1(publicKeyVonA, p);
            BigInteger q2 = BerechneQ2(publicKeyVonB, p);

            BigInteger a = publicKeyVonA.e;
            BigInteger b = BerechneB(p, q1);

            EuclidExtendedSolution solution = BerechneEEALösung(a, b);

            BigInteger M = BerechneMessage(publicKeyVonA, chiffre, solution);
            return M;
        }

        public static BigInteger BerechneP(public_key public_Key_Arthur, public_key public_Key_Ford)
        {
            return BigInteger.GreatestCommonDivisor(public_Key_Arthur.N, public_Key_Ford.N);
        }

        public static BigInteger BerechneQ1(public_key public_Key_Arthur, BigInteger p)
        {
            return public_Key_Arthur.N / p;
        }

        public BigInteger BerechneQ2(public_key public_Key_Ford, BigInteger p)
        {
          return public_Key_Ford.N / p;
        }

        public static BigInteger BerechneB(BigInteger p, BigInteger q1)
        {
            return (p - 1) * (q1 - 1);
        }

        public BigInteger BerechneChiffrat(public_key public_Key_Arthur, BigInteger M)
        {
            return BigInteger.ModPow(M, public_Key_Arthur.e, public_Key_Arthur.N);
        }

        public BigInteger BerechneMessage(public_key public_Key_Arthur, BigInteger chiffre, EuclidExtendedSolution solution)
        {
            return BigInteger.ModPow(chiffre, solution.X, public_Key_Arthur.N);
        }

        public EuclidExtendedSolution BerechneEEALösung(BigInteger a, BigInteger b)
        {
            EuclidExtended euclidExtended = new EuclidExtended(a, b);
            EuclidExtendedSolution solution = euclidExtended.solve();
            return solution;
        }
    }

}
