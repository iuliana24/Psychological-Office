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
            int dateComparison = Date.CompareTo(other.Date);
            if (dateComparison == 0)
            {
                return Time.CompareTo(other.Time);
            }
            return dateComparison;
        }
    }
}
