using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Randomnes
{
    /// <summary>
    /// XorShiftで[x,y]を一様分布で出力使用
    /// </summary>
    class XorShiftRandom2D : Random2D
    {
        private readonly Random random = new XorShift(236857);
        public override Point Next()
        {
            return new Point(random.Next(-500, 500), random.Next(-500, 500));
        }
    }
}
