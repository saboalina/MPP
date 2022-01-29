using System;

namespace model
{
    public class Agent : Entity<int>
    {
        public String Username { get; set; }
        public String Password { get; set; }

        public override string ToString()
        {
            return Username;
        }
    }
}