using System;

namespace model
{
    [Serializable]
    public class Excursie : Entity<int>
    {
        public String Destination { get; set; }
        public String Airport { get; set; }
        public DateTime Departure { get; set; }
        public float Price { get; set; }
        public int AvailableSeats { get; set; }

        public override string ToString()
        {
            return ID + ";" + Destination + ";" + Airport + ";" + Departure + ";" + Price + ";" + AvailableSeats;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() == typeof(Excursie))
            {
                Excursie e = (Excursie)obj;
                return ID == e.ID;
            }

            return false;
        }
    }
}