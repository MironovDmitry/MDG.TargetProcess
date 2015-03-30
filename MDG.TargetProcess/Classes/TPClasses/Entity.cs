using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDG.TargetProcess
{
    public class Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public object EndDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public object LastCommentDate { get; set; }
        public string Tags { get; set; }
        public double NumericPriority { get; set; }
        public double Effort { get; set; }
        public double EffortCompleted { get; set; }
        public double EffortToDo { get; set; }
        public double Progress { get; set; }
        public double TimeSpent { get; set; }
        public double TimeRemain { get; set; }
        public object PlannedStartDate { get; set; }
        public object PlannedEndDate { get; set; }
        public double InitialEstimate { get; set; }
        public Project Project { get; set; }
        public EntityType EntityType { get; set; }
        public Owner Owner { get; set; }
        public object LastCommentedUser { get; set; }
        public Release Release { get; set; }
        public object Iteration { get; set; }
        public TeamIteration TeamIteration { get; set; }
        public Team Team { get; set; }
        public Priority Priority { get; set; }
        public EntityState EntityState { get; set; }
        public object Feature { get; set; }
        public object LinkedTestPlan { get; set; }        
    }

    public class EntityState
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double NumericPriority { get; set; }
    }
        
}
