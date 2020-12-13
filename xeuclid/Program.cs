using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Numerics;

namespace xeuclid
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger x = 1, y = 1;
            BigInteger a = BigInteger.Parse("22110353244313571990253947726448700077443799253406660177539041122286765386297310000624571255327108496704433541802282181077577052293207873618616856325300481078151287575967405833226335344276559322617210444468625925561175939075849496718494786067062535178871669751762240085850774614288584598896914586928107067984493428904565220859347561525719531741217278287666243358923774175067649151386827137528823240283946807493177939741504278807764069512011353961858632308604834276891354166708590024569596034499839659092216324314789282948363742579018085735215693697393708782328192259892300038044916383109648663926619841075984159391291");
            BigInteger b = 65537;
            BigInteger g = gcdExtended(a, b, x, y);
            Console.WriteLine("gcd(" + a + " , " +
                                b + ") = " + g);
        }

        // extended Euclidean Algorithm 
        public static BigInteger gcdExtended(BigInteger a, BigInteger b,
                                    BigInteger x, BigInteger y)
        {
            // Base Case 
            if (a == 0)
            {
                x = 0;
                y = 1;
                return b;
            }

            // To store results of 
            // recursive call 
            BigInteger x1 = 1, y1 = 1;
            BigInteger gcd = gcdExtended(b % a, a, x1, y1);

            // Update x and y using 
            // results of recursive call 
            x = y1 - (b / a) * x1;
            y = x1;

            return gcd;
        }
    }
}
