using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Randomnes
{
    /// <summary>
    ///n=10,p=0.3,0.5の多項式分布
    /// </summary>
    class Multinomial2D : Random2D
    {
        public override int Alpha => 30;
        private readonly Random random = new XorShift(236857);

        public override Point Next()
        {
            return new Point(GetMultinomiall(0.5) * 20 - 500, GetMultinomiall(0.3) * 20 - 500);
        }

        public int GetMultinomiall(double p)
        {
            return new int[50].Count(_ => random.NextDouble() <= p);
        }
    }
}
