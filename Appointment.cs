using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licenta
{
    public class Appointment : IComparable<Appointment>
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public bool IsCompleted { get; set; }

        public int CompareTo(Appointment other)
        {

            if (other == null) return 1;

            int result = Date.CompareTo(other.Date);
            if (result == 0)
            {
                result = Time.CompareTo(other.Time);
            }
            return result;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Appointment other = (Appointment)obj;
            return Id == other.Id && Date == other.Date && Time == other.Time;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Date, Time);
        }
    }
}
