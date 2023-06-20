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
            throw new NotImplementedException();
        }

        public List<AutoEigenaarDTO> AllesOphalen()
        {
            throw new NotImplementedException();
        }

        public List<AutoDTO> AutosOphalenOpID(int eigenaarID)
        {
            throw new NotImplementedException();
        }

        public AutoEigenaarDTO OphalenOpID(int id)
        {
            throw new NotImplementedException();
        }

        public void VerwijderenOpID(int id)
        {
            VerwijderID = id;
        }
    }
}
