using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication.Model
{
    public class Valve : ModelBase
    {
        public float NominalPipeSize { get; set; }
        public int Globe { get; set; }
        public int BallCheck { get; set; }
        public int Angle { get; set; }
        public int SwingCheck { get; set; }
        public int PlugCock { get; set; }
        public int GateOrBallValve { get; set; }
    }
}
