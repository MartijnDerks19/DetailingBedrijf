using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomeinLaag.Models
{
    public class AfspraakModel
    {
        public int DetailerID { get; set; }
        public int AutoID { get; set; }
        public int AfspraakID { get; set; }
        public DateTime DatumEnTijd { get; set; }
        
        //ToDo: Dit zou misschien een geschikte plek kunnen zijn om een aantal check methodes toe te voegen. Zodat je aan de model zelf kan vragen of er een afspraak gepland kan worden 
        //ToDo: En wanneer de eerstvolgende vrije dag is. 
    }
}
