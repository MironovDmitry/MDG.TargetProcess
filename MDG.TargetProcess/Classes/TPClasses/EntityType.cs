using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDG.TargetProcess
{
    public class EntityType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsExtendable { get; set; }
        public bool IsSearchable { get; set; }
        public bool IsUnitInHourOnly { get; set; }
        public bool IsAssignable { get; set; }
    }

    public class EntityTypes
    {
        public string Next { get; set; }
        public List<EntityType> Items { get; set; }
    }
}
