using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDG.TargetProcess
{
    public class UserStory : Entity
    {
        public List<object> CustomFields { get; set; }
    }

    public class UserStories
    {
        public string Next { get; set; }
        public List<UserStory> Items { get; set; }
    }    
}
