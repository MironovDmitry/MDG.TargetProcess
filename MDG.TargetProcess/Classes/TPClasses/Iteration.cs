using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDG.TargetProcess
{
    public class TeamIteration : Iteration_abstract
    {   
        public Team Team { get; set; }        
        public List<object> CustomFields { get; set; }
    }

    public class TeamIterations
    {
        public string Next { get; set; }
        public List<TeamIteration> Items { get; set; }
    }

    public class Iteration : Iteration_abstract
    {  
        public Release Release { get; set; }        
        public List<object> CustomFields { get; set; }
    }

    public class Iterations
    {
        public string Next { get; set; }
        public List<Iteration> Items { get; set; }
    }
}
