using DomeinLaag.DTOs;
using DomeinLaag.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.MockDataToegang
{
    internal class AutoEigenaarMockData : IAutoEigenaar
    {
        public int VerwijderID { get; set; }
        public AutoEigenaarDTO DTO { get; set; }
        public void Aanmaken(AutoEigenaarDTO dto)
        {
            DTO = dto;
        }

        public void AanpassenOpID(int id, AutoEigenaarDTO dto)
        {
            DTO = dto;
        }

        public List<AutoEigenaarDTO> AllesOphalen()
        {
            return new List<AutoEigenaarDTO>();
        }

        public List<AutoDTO> AutosOphalenOpID(int eigenaarID)
        {
            return new List<AutoDTO>();
        }

        public AutoEigenaarDTO OphalenOpID(int id)
        {
            AutoEigenaarDTO dto = new AutoEigenaarDTO();
            dto.EigenaarID = id;
            return dto;
        }

        public void VerwijderenOpID(int id)
        {
            VerwijderID = id;
        }
    }
}
