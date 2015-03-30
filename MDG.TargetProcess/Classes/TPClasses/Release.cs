using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDG.TargetProcess
{
    public class Release
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public object LastCommentDate { get; set; }
        public string Tags { get; set; }
        public double NumericPriority { get; set; }
        public bool IsCurrent { get; set; }
        public double Progress { get; set; }
        public Process Process { get; set; }
        public EntityType EntityType { get; set; }
        public Owner Owner { get; set; }
        public object LastCommentedUser { get; set; }
        public Project Project { get; set; }
        public object LinkedTestPlan { get; set; }
        public List<object> CustomFields { get; set; }
    }

    public class Releases
    {
        public string Next { get; set; }
        public List<Release> Items { get; set; }
    }
}
