using System;
using System.Collections.Generic;
using System.Text;

namespace Laborator4.domain
{
    public class Entity<Tid>
    {
        public Tid id { get; set; }
        
        public Tid getId()
        {
            return id;
        }
    }
}
