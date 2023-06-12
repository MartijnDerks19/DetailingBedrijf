using LogicaLaag.DTOs;
using LogicaLaag.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestProject.MockDataToegang
{
    public class DetailerMockData : ICRUDCollectie<DetailerDTO>
    {
        public DetailerDTO DTO { get; set; }
        public int VerwijderID { get; set; }
        public DetailerMockData()
        {

        }

        public List<DetailerDTO> AllesOphalen()
        {
            return new List<DetailerDTO>();
        }

        public DetailerDTO OphalenOpID(int id)
        {
            DetailerDTO dto = new DetailerDTO()
            {
                DetailerID = id,
                Naam = "Tests"
            };
            return dto;
        }

        public void Aanmaken(DetailerDTO detailer)
        {
            ZetDetailerDTOGelijkAanInputVanAanmaakMethode(detailer);
        }

        public void VerwijderenOpID(int id)
        {
            ZetIDGelijkAanInputVanVerwijderMethode(id);
        }

        public void AanpassenOpID(int id, DetailerDTO entiteit)
        {
            throw new NotImplementedException();
        }

        public void ZetDetailerDTOGelijkAanInputVanAanmaakMethode(DetailerDTO dto)
        {
            DTO = dto;
        }

        public void ZetIDGelijkAanInputVanVerwijderMethode(int id)
        {
            VerwijderID = id;
        }
    }
}
