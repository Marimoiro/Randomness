using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Randomnes
{
    /// <summary>
    /// 拡散律速凝集
    /// </summary>
    class DLACluster : Random2D
    {
        public override bool LerpMode => true;

        private const int Size = 100;
        private bool[,] Cluster = new bool[Size * 2, Size * 2];
        private int Radius = 3;
        private readonly Random random = new XorShift(236857);

        public DLACluster()
        {
            Cluster[Size, Size] = true;
        }

        public override Point Next()
        {
            var pop = Radius + 4;
            var theta = 2 * random.NextDouble() * Math.PI;

            var popX = (int)(pop * Math.Cos(pop) + Size);
            var popY = (int)(pop * Math.Sin(pop) + Size);

            var distance = pop;

            do
            {
                popX += random.Next(-1, 2);
                popY += random.Next(-1, 2);

                var size2 = Size * 2;

                var check = (popX >= 0 && popX < size2 && popY >= 0 && popY < size2) &&
                            (Cluster[popX, popY] ||
                             Cluster[(popX + 1) % size2, popY] ||
                             Cluster[(popX - 1 + size2) % size2, popY] ||
                             Cluster[popX, (popY + 1) % size2] ||
                             Cluster[popX, (popY - 1 + size2) % size2]);
                int dx = popX - Size, dy = popY - Size;
                distance = dx * dx + dy * dy;
                if (check)
                {
                    var r = 1000 / size2;
                    Cluster[popX, popY] = true;
                    Radius = Math.Max(Radius, (int) Math.Ceiling(Math.Sqrt(distance)));
                    var p = new Point(popX * 1000 / Size - 1000,
                        popY * 1000 / Size - 1000);
                    return p;
                }



            } while (distance < 750 * 750);

            return Next();
        }
    }
}
