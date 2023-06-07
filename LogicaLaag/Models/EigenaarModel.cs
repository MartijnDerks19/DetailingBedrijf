using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaLaag.Models
{
    public class EigenaarModel
    {
        public int EigenaarID { get; set; }
        public string Naam { get; set; }
        public string Email { get; set; }
        public List<AutoModel> AutosEigenaar { get; set; }
    }
}
