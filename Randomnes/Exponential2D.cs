using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Randomnes
{
    /// <summary>
    /// 指数分布
    /// </summary>
    class Exponential2D : Random2D
    {
        public const double Mean = 0.5;
        private readonly Random random = new XorShift(236857);

        public override Point Next()
        {
            return new Point((int)(GetExponential() * 1000) - 500, (int)(GetExponential() * 1000) - 500);
        }

        public double GetExponential()
        {
            var r = random.NextDouble();
            return -Mean * Math.Log(1 - r);
        }
    }
}
