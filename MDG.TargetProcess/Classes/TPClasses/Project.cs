using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDG.TargetProcess
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public object Description { get; set; }
        public object StartDate { get; set; }
        public object EndDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public object LastCommentDate { get; set; }
        public string Tags { get; set; }
        public double NumericPriority { get; set; }
        public bool IsActive { get; set; }
        public bool IsProduct { get; set; }
        public string Abbreviation { get; set; }
        public string MailReplyAddress { get; set; }
        public string Color { get; set; }
        public double Progress { get; set; }
        public Process Process { get; set; }
        public EntityType EntityType { get; set; }
        public Owner Owner { get; set; }
        public object LastCommentedUser { get; set; }        
        public Program Program { get; set; }
        public Company Company { get; set; }
        public object LinkedTestPlan { get; set; }
        public List<object> CustomFields { get; set; }
    }

    public class Projects
    {
        public List<Project> Items { get; set; }
    }
}
