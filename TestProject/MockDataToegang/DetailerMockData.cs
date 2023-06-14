using DomeinLaag.DTOs;
using DomeinLaag.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestProject.MockDataToegang
{
    public class DetailerMockData : IDetailer
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

        public List<AfspraakDTO> AfsprakenOphalenOpID(int detailerID)
        {
            throw new NotImplementedException();
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
            DTO = detailer;
        }

        public void VerwijderenOpID(int id)
        {
            VerwijderID = id;
        }

        public void AanpassenOpID(int id, DetailerDTO entiteit)
        {
            throw new NotImplementedException();
        }
    }
}
