using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDG.TargetProcess.Classes.TPClasses
{
    public class BugHistory
    {        
        public Bug Bug { get; set; }       
    }

    public class BugHistories
    {
        public string Next { get; set; }
        public List<BugHistory> Items { get; set; }
    }
}
