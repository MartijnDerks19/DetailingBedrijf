using DataLaag.DTOs;
using InterfaceLaag.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLaag.Interfaces
{
    public interface IDashboardCollectie
    {
        void EigenaarToevoegen(EigenaarDTO eigenaar);
        void VerwijderEigenaarOpID(int id);
        EigenaarDTO EigenaarOphalenOpID(int id);
        List<EigenaarDTO> AlleEigenarenOphalen();
    }
}
