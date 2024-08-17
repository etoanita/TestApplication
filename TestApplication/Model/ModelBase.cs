using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication.Model
{
    public class ModelBase
    {
        public int Id { get; set; }
        public Guid Uid { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

    }
}
