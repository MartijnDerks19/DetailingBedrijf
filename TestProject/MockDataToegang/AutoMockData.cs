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
            DTO = dto;
        }

        public List<AutoDTO> AllesOphalen()
        {
            return new List<AutoDTO>();
        }

        public List<AutoDTO> AllesOphalenVoorEigenaar(int id)
        {
            return new List<AutoDTO>();
        }

        public AutoDTO OphalenOpID(int id)
        {
            AutoDTO dto = new AutoDTO()
            {
                AutoID = id,
                Merk = "Test",
                Type = "Test1",
                Bouwjaar = 2001,
                EigenaarID = 2
            };
            return dto;
        }

        public void VerwijderenOpID(int id)
        {
            VerwijderID = id;
        }
    }
}
