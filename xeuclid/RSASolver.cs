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
        public BigInteger p { get; set; }
        public BigInteger q1 { get; set; }
        public BigInteger q2 { get; set; }
        public BigInteger a { get; set; }
        public BigInteger b { get; set; }
        public BigInteger M { get; set; }
        public EuclidExtendedSolution solution { get; set; }

        public BigInteger BerechneMessageAnhandEinesChiffratsUndPublicKeys(public_key publicKeyVonA, public_key publicKeyVonB, BigInteger chiffre)
        {
            p = BerechneP(publicKeyVonA, publicKeyVonB);
            q1 = BerechneQ1(publicKeyVonA, p);
            q2 = BerechneQ2(publicKeyVonB, p);

            a = publicKeyVonA.e;
            b = BerechneB(p, q1);

            EuclidExtendedSolution solution = BerechneEEALösung(a, b);

            M = BerechneMessage(publicKeyVonA, chiffre, solution);
            return M;
        }

        public static BigInteger BerechneP(public_key publicKeyVonA, public_key publicKeyVonB)
        {
            return BigInteger.GreatestCommonDivisor(publicKeyVonA.N, publicKeyVonB.N);
        }

        public static BigInteger BerechneQ1(public_key publicKeyVonA, BigInteger p)
        {
            return publicKeyVonA.N / p;
        }

        public BigInteger BerechneQ2(public_key publicKeyVonB, BigInteger p)
        {
            return publicKeyVonB.N / p;
        }

        public static BigInteger BerechneB(BigInteger p, BigInteger q1)
        {
            return (p - 1) * (q1 - 1);
        }

        public BigInteger BerechneChiffrat(public_key publicKeyVonA, BigInteger M)
        {
            return BigInteger.ModPow(M, publicKeyVonA.e, publicKeyVonA.N);
        }

        public BigInteger BerechneMessage(public_key publicKeyVonA, BigInteger chiffre, EuclidExtendedSolution solution)
        {
            return BigInteger.ModPow(chiffre, solution.X, publicKeyVonA.N);
        }

        public EuclidExtendedSolution BerechneEEALösung(BigInteger a, BigInteger b)
        {
            EuclidExtended euclidExtended = new EuclidExtended(a, b);
            solution = euclidExtended.solve();
            return solution;
        }
    }

}
