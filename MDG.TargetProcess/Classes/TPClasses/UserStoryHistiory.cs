using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDG.TargetProcess
{
    public class UserStoryHistiory : History
    {        
        public UserStory UserStory { get; set; }        
    }

    public class UserStoryHistiories
    {
        public string Next { get; set; }
        public List<UserStoryHistiory> Items { get; set; }
    }
}
