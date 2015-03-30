using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDG.TargetProcess
{
    public abstract class History
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Effort { get; set; }
        public double EffortCompleted { get; set; }
        public double EffortToDo { get; set; }
        public EntityState EntityState { get; set; }
        public User Modifier { get; set; }        
        public Release Release { get; set; }
        public Iteration Iteration { get; set; }
    }
}
