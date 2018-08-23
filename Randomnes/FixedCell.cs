using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Randomnes
{
    class FixedCell : Random2D
    {
        public override bool LerpMode => true;

        const int CellSize = 100;
        bool[,] Cell = new bool[CellSize, CellSize];
        private int[,] CellProbability = new int[CellSize, CellSize];
        private Queue<Point> Points = new Queue<Point>();
        List<Point> WaitingPoint = new List<Point>();

        void Initialize()
        {
            XorShift random = new XorShift(236857);

            for (int x = 0; x < CellSize; x++)
            for (int y = 0; y < CellSize; y++)
            {
                CellProbability[x, y] = random.Next();
            }

            AddPoint(50, 50);
            for (int i = 0; i < 1200; i++)
            {
                int max = 0;
                Point maxP;

                foreach (var point in WaitingPoint)
                {
                    if (CellProbability[point.X, point.Y] >= max)
                    {
                        maxP = point;
                        max = CellProbability[point.X, point.Y];
                    }
                }

                AddPoint(maxP.X, maxP.Y);
            }
        }

        void AddPoint(int x, int y)
        {
            Points.Enqueue(new Point(x, y));
            Cell[x, y] = true;

            void AddWaitingList(int wx, int wy)
            {
                if (wx < 0 || wy < 0 || wx >= CellSize || wy >= CellSize) return;
                ;
                if (Cell[wx, wy]) return;

                WaitingPoint.Add(new Point(wx, wy));
            }

            AddWaitingList(x - 1, y);
            AddWaitingList(x + 1, y);
            AddWaitingList(x, y - 1);
            AddWaitingList(x, y + 1);

            WaitingPoint.Remove(new Point(x, y));
        }

        private bool initialized;
        public override Point Next()
        {
            if (!initialized)
            {
                Initialize();
                initialized = true;
            }

            var p = Points.Dequeue();
            return new Point( p.X * 1000 / CellSize-500, p.Y * 1000 / CellSize - 500);
        }
    }
}
