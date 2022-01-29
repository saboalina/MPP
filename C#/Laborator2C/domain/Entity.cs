using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2C.domain
{
    public class Entity<TID>
    {
        public TID ID { get; set; }
    }
}
