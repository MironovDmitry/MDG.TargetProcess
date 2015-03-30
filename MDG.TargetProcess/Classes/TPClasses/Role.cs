using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDG.TargetProcess
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool HasEffort { get; set; }
        public bool CanChangeOwner { get; set; }
    }

    public class Roles
    {
        public List<Role> Items { get; set; }
    }
}
