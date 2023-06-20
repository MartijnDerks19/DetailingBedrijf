using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            throw new NotImplementedException();
        }

        public List<AfspraakDTO> AllesOphalen()
        {
            throw new NotImplementedException();
        }

        public AfspraakDTO OphalenOpID(int id)
        {
            throw new NotImplementedException();
        }

        public void VerwijderenOpID(int id)
        {
            VerwijderID = id;
        }
    }
}
