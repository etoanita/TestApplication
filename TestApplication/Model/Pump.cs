using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication.Model
{
    public class Pump : ModelBase
    {
        public int Capacity { get; set; }
        public double Head { get; set; }
        public int Speed { get; set; }
        public int Efficiency { get; set; }
        public double MotorPower { get; set; }
    }
}
