using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using DomeinLaag.DTOs;
using DomeinLaag.Interfaces;

namespace TestProject.MockDataToegang
{
    public class AfspraakMockData : IAfspraak
    {
        public int VerwijderID { get; set; }
        public AfspraakDTO DTO { get; set; }


        public void Aanmaken(AfspraakDTO dto)
        {
            DTO = dto;
        }

        public void AanpassenOpID(int id, AfspraakDTO dto)
        {
            DTO = dto;
        }

        public List<AfspraakDTO> AllesOphalen()
        {
            return new List<AfspraakDTO>();
        }

        public AfspraakDTO OphalenOpID(int id)
        {
            AfspraakDTO dto = new AfspraakDTO();
            dto.AfspraakID = id;
            return dto;
        }

        public void VerwijderenOpID(int id)
        {
            VerwijderID = id;
        }
    }
}
