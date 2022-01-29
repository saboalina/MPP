using System;

namespace model
{
    [Serializable]
    public class Employee : Entity<int>
    {
        public String Username { get; set; }
        public String Password { get; set; }

        public override string ToString()
        {
            return Username;
        }
    }
}