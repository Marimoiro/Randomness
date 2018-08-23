using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Randomnes
{
    /// <summary>
    /// ランダムウォーク
    /// </summary>
    class RandomWalker2D : Random2D
    {
        public override int Alpha => 130;
        public override bool LerpMode => true;
        private readonly Random random = new XorShift(236857);

        private Point before = new Point(500, 500);

        public RandomWalker2D()
        {

        }

        public override Point Next()
        {
            var p = new Point(before.X + random.Next(-20, 20), before.Y + random.Next(-20, 20));
            before = p;
            return new Point(p.X - 500, p.Y - 500);
        }
    }
}
