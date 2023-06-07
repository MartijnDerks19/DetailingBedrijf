using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaLaag.Models
{
    public class AfspraakModel
    {
        public int DetailerID { get; set; }
        public int AutoID { get; set; }
        public int AfspraakID { get; set; }
        public DateTime DatumEnTijd { get; set; }
    }
}
