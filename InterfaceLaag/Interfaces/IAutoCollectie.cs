using DataLaag.DTOs;
using InterfaceLaag.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLaag.Interfaces
{
    public interface IAutoCollectie
    {
        public void VerwijderAutoOpID(int id);
        public void AutoToevoegen(int EigenaarID, AutoDTO auto);
        public AutoDTO AutoOphalenOpID(int id);
        List<AutoDTO> AlleAutosOphalen();
    }
}
