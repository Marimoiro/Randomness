using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Randomnes
{
    /// <summary>
    /// 植物の一部における周囲の植物の成長を抑制するようなモデル
    /// Allelopathy自体は相互作用程度の意味
    /// </summary>
    class Allelopathy2D :Random2D
    {
        private readonly Random random = new XorShift(236857);

        private const int Size = 40;
        private int[,] Power = new int[Size, Size];

        public override Point Next()
        {
            Point p;
            for (int i = 0; i < 100; i++)
            {
                p = new Point(random.Next(Size),random.Next(Size));
                if(Power[p.X,p.Y] <= i) break;
            }

            int x = p.X, y = p.Y;
            Power[x, y] += 3;

            Power[(x + 1) % Size, y] += 2;
            Power[(x + Size - 1) % Size, y] += 2;
            Power[x, (y + 1) % Size] += 2;
            Power[x, (y + Size - 1) % Size] += 2;

            Power[(x + 2) % Size, y] += 1;
            Power[(x + Size - 2) % Size, y] += 1;
            Power[x, (y + 2) % Size] += 1;
            Power[x, (y + Size - 2) % Size] += 1;

            var r = 1000 / Size;
            return new Point(p.X * 1000 / Size - 500 + random.Next(r) - r / 2,
                p.Y * 1000 / Size - 500 + random.Next(r) - r / 2);

        }
    }
}
