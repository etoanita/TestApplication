using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication.Model
{
    public class Cylinder : ModelBase
    {
        public int Stroke {  get; set; }
        public int Bore { get; set; }
        public int OuterDiameter { get; set; }
        public int ShrinkLength { get; set; }
        public int ExtendLength { get; set; }
        public int OilPortDistance { get; set; }
    }
}
