using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Licenta
{
    public class Interpretation
    {
        public int InterpretationID { get; set; }
        public int TestID { get; set; }
        public int ScoreMin { get; set; }
        public int ScoreMax { get; set; }
        public string Text { get; set; }
    }
}
