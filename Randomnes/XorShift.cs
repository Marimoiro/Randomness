using System;
using System.Collections.Generic;
using System.Text;

namespace Randomnes
{
    class XorShift : Random
    {

        private UInt32 x;
        private UInt32 y;
        private UInt32 z;
        private UInt32 w;
        public XorShift(UInt64 seed)
        {
            SetSeed(seed);
        }

        /// <summary>  
        /// シード値を設定  
        /// </summary>  
        /// <param name="seed">シード値</param>  
        public void SetSeed(UInt64 seed)
        {
            // x,y,z,wがすべて0にならないようにする  
            x = 521288629u;
            y = (UInt32)(seed >> 32) & 0xFFFFFFFF;
            z = (UInt32)(seed & 0xFFFFFFFF);
            w = x ^ z;
        }

        protected override double Sample()
        {
            UInt32 t = x ^ (x << 11);
            x = y;
            y = z;
            z = w;
            w = (w ^ (w >> 19)) ^ (t ^ (t >> 8));
            return (double) (w >> 8) / 0xFFFFFFu;
        }
    }
}
