using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Randomnes
{
    /// <summary>
    /// 植物の一部における周囲の植物の成長を抑制するようなモデル
    /// 周囲に強烈な抑制効果を出すようにした
    /// Allelopathy自体は相互作用程度の意味
    /// </summary>
    class AllelopathyHard2D :Random2D
    {
        private readonly Random random = new XorShift(236857);

        private const int Size = 100;
        private int[,] Power = new int[Size, Size];

        public override Point Next()
        {
            Point p;
            for (int i = 0; i < 100; i++)
            {
                p = new Point(random.Next(Size), random.Next(Size));
                if (Power[p.X, p.Y] <= i) break;
            }

            int x = p.X, y = p.Y;

            for (int i = -2; i < 2; i++)
            for (int j = -2; j < 2; j++)
            {
                Power[(p.X + i + Size) % Size, (p.Y + j + Size) % Size] = 100;
            }

            var r = 1000 / Size;
            return new Point(p.X * 1000 / Size - 500 + random.Next(r) - r / 2,
                p.Y * 1000 / Size - 500 + random.Next(r) - r / 2);

        }
    }
}
