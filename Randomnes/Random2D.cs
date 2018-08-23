using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Randomnes
{
    /// <summary>
    /// xyそれぞれ-500 ～ 500の点をランダムに出力するランダム生成装置の基底
    /// </summary>
    abstract class Random2D
    {
        public virtual int Alpha => 180;

        public virtual bool LerpMode => false;
        public abstract Point Next();
    }
}
