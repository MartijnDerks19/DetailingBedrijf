using DataLaag.DTOs;
using InterfaceLaag.Interfaces;
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
        private List<DetailerDTO> _detailers = new List<DetailerDTO>();
        public List<DetailerDTO> AlleDetailers { get { return _detailers; } set { _detailers = value; } }

        public DetailerMockData(List<DetailerDTO> detailers)
        {
            _detailers = detailers;
        }

        public List<DetailerDTO> AlleDetailersOphalen()
        {
            return AlleDetailers;
        }

        public DetailerDTO DetailerOphalenOpID(int id)
        {
            DetailerDTO detailer = new DetailerDTO();
            foreach (var dto in AlleDetailers)
            {
                if (dto.DetailerID == id)
                {
                    detailer = dto;
                }
            }
            return detailer;
        }

        public void DetailerToevoegen(DetailerDTO detailer)
        {
            AlleDetailers.Add(detailer);
        }

        public void VerwijderDetailerOpID(int id)
        {
            var detailer = _detailers.FirstOrDefault(x => x.DetailerID == id);
            if (detailer != null)
            {
                _detailers.Remove(detailer);
            }
        }

        public void Aanmaken(DetailerDTO entiteit)
        {
            throw new NotImplementedException();
        }

        public void VerwijderenOpID(int id)
        {
            throw new NotImplementedException();
        }

        public void AanpassenOpID(int id, DetailerDTO entiteit)
        {
            throw new NotImplementedException();
        }

        public DetailerDTO OphalenOpID(int id)
        {
            throw new NotImplementedException();
        }

        public List<DetailerDTO> AllesOphalen()
        {
            throw new NotImplementedException();
        }
    }
}
