using System;

namespace model
{
    [Serializable]
    public class Entity<TID>
    {
        public TID ID { get; set; } 
    }
}