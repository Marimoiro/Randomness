using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Randomnes
{
    /// <summary>
    /// C#のランダムそのまま[x,y]を一様分布で出力
    /// </summary>
    class CsRandom2D : Random2D
    {
        private readonly Random random = new Random(236857);
        public override Point Next()
        {
            return new Point(random.Next(-500, 500), random.Next(-500, 500));
        }
    }
}
