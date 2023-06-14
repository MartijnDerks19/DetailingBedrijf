using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomeinLaag.Models
{
    public class AutoModel
    {
        public int AutoID { get; set; }
        public string Merk { get; set; }
        public string Type { get; set; }
        public int Bouwjaar { get; set; }
        public int EigenaarID { get; set; }
    }
}
