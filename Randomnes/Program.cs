using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Randomnes
{
    class Program
    {
        private const int MaxPoints = 1000;

        static void Main(string[] args)
        {

            Assembly a = Assembly.GetEntryAssembly();
            var randoms = a.GetTypes().Where(t => t.IsSubclassOf(typeof(Random2D)))
                .Select(Activator.CreateInstance).OfType<Random2D>().ToArray();


            if (!Directory.Exists("images"))
            {
                Directory.CreateDirectory("images");
            }

            Color start = Color.Red;
            Color end = Color.Green;

            foreach (var random in randoms)
            {
                using (var bmp = new Bitmap(1000, 1000))
                using (var g = Graphics.FromImage(bmp))
                using (SolidBrush pointBrash =
                    new System.Drawing.SolidBrush(Color.FromArgb(random.Alpha, Color.Blue)))
                {


                    for (int i = 0; i < MaxPoints; i++)
                    {
                        if (random.LerpMode)
                        {
                            double p = (double) i / MaxPoints;
                            pointBrash.Color = Color.FromArgb(random.Alpha,
                                (int) (start.R * (1 - p) + end.R * p),
                                (int) (start.G * (1 - p) + end.G * p),
                                (int) (start.B * (1 - p) + end.B * p));
                        }

                        var point = random.Next();
                        g.FillEllipse(pointBrash, new Rectangle(point.X - 8 + 500, point.Y - 8 + 500, 16, 16));
                    }

                    var type = random.GetType().Name;
                    bmp.Save($"images/{type}.png", ImageFormat.Png);
                }


            }
        }
    }
}
