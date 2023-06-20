using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomeinLaag.DTOs;
using DomeinLaag.Interfaces;

namespace TestProject.MockDataToegang
{
    public class AutoMockData : IAuto
    {
        public int VerwijderID { get; set; }
        public AutoDTO DTO { get; set; }  
        public void Aanmaken(AutoDTO dto)
        {
            DTO = dto;
        }

        public void AanpassenOpID(int id, AutoDTO dto)
        {
            throw new NotImplementedException();
        }

        public List<AutoDTO> AllesOphalen()
        {
            throw new NotImplementedException();
        }

        public List<AutoDTO> AllesOphalenVoorEigenaar(int id)
        {
            throw new NotImplementedException();
        }

        public AutoDTO OphalenOpID(int id)
        {
            throw new NotImplementedException();
        }

        public void VerwijderenOpID(int id)
        {
            VerwijderID = id;
        }
    }
}
