using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace MDG.TargetProcess
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class User
    {
        public string Kind { get; set; }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public string Email { get; set; }
        //public string Login { get; set; }
        //public DateTime CreateDate { get; set; }
        //public DateTime ModifyDate { get; set; }
        //public DateTime? DeleteDate { get; set; }
        public bool IsActive { get; set; }
        //public bool IsAdministrator { get; set; }
        //public DateTime? LastLoginDate { get; set; }
        //public double WeeklyAvailableHours { get; set; }
        //public int CurrentAllocation { get; set; }
        //public double CurrentAvailableHours { get; set; }
        //public DateTime? AvailableFrom { get; set; }
        //public int AvailableFutureAllocation { get; set; }
        //public double AvailableFutureHours { get; set; }
        //public bool IsObserver { get; set; }
        //public object Skills { get; set; }
        //public string ActiveDirectoryName { get; set; }
        public Role Role { get; set; }
    }

    public class Users
    {
        public string Next { get; set; }
        public List<User> Items { get; set; }
    }
}
