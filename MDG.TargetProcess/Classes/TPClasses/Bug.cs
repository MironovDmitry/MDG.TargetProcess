using System;
using System.Collections.Generic;

namespace MDG.TargetProcess
{
    public class Bug : Entity
    {        
        
        public UserStory UserStory { get; set; }        
        public List<object> CustomFields { get; set; }
    }

    public class Bugs
    {
        public string Next { get; set; }
        public List<Bug> Items { get; set; }
    }
}
