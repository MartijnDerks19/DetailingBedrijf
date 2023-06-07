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
    public class DetailerMockData : IDetailer
    {
        private List<DetailerDTO> _detailers = new List<DetailerDTO>();
        public List<DetailerDTO> AlleDetailers { get { return _detailers; } set { _detailers = value; } }

        public DetailerMockData()
        {
            AlleDetailers = VulLijst(20);
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

        public List<DetailerDTO> VulLijst(int hoeveelheid)
        {
            int id = 0;
            List<DetailerDTO> detailers = new List<DetailerDTO> ();
            for (int i = 0; i < hoeveelheid; i++)
            {
                DetailerDTO dto = new DetailerDTO()
                {
                    DetailerID = id,
                    Naam = "Test"
                };
                detailers.Add(dto);
                id++;
            }
            return detailers;
        }
    }
}
