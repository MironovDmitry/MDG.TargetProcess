using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDG.TargetProcess
{
    public class Priority
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Importance { get; set; }
        public bool IsDefault { get; set; }
        public EntityType EntityType { get; set; }
    }

    public class Priorities
    {
        public string Next { get; set; }
        public List<Priority> Items { get; set; }
    }
}
