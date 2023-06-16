using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomeinLaag.Models
{
    public class AutoEigenaarModel
    {
        private List<AutoModel> _autosEigenaar = new();
        public int EigenaarID { get; set; }
        public string Naam { get; set; }
        public string Email { get; set; }
        public List<AutoModel> AutosEigenaar
        {
            get { return _autosEigenaar; }
            set { _autosEigenaar = value; }
        }
    }
}
