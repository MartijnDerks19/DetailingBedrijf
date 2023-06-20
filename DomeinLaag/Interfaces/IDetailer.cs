using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomeinLaag.DTOs;

namespace DomeinLaag.Interfaces
{
    public interface IDetailer 
    {
        void Aanmaken(DetailerDTO dto);
        void VerwijderenOpID(int id);
        void AanpassenOpID(int id, DetailerDTO dto);
        DetailerDTO OphalenOpID(int id);
        List<DetailerDTO> AllesOphalen();
        List<AfspraakDTO> AllesOphalenVoorDetailer(int detailerID);
    }
}

