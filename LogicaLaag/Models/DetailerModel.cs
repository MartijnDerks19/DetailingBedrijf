using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaLaag.Models
{
    public class DetailerModel
    {
        private int _detailerID;
        private string _naam;
        private List<Afspraak> afspraken = new List<Afspraak>();

        public int DetailerID { get; set; }
        public string Naam { get; set; }
    }
}
