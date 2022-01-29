using System;

namespace model
{
    [Serializable]
    public class Ticket : Entity<int>
    {
        public String ClientName { get; set; }
        public String TouristsName { get; set; }
        public int NoSeats { get; set; }
        
        public Excursie Excursie { get; set; }

        public override string ToString()
        {
            return ID + ";" + ClientName + ";" + TouristsName + ";" + NoSeats + ";" + Excursie.ToString();
        }
    }
}