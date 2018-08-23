using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Randomnes
{
    class RoundRandom2D : Random2D
    {
        private readonly Random random = new XorShift(236857);

        public override Point Next()
        {
            var theta = 2 * random.NextDouble() * Math.PI;
            var r = random.Next(700);

            var x = r * Math.Cos(theta);
            var y = r * Math.Sin(theta);

            return new Point((int) x, (int) y);
        }

    }
}
