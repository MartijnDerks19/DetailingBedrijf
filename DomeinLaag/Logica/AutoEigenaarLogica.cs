using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomeinLaag.DTOs;
using DomeinLaag.Interfaces;
using DomeinLaag.Mapping;
using DomeinLaag.Models;

namespace DomeinLaag.Logica
{
    public class AutoEigenaarLogica
    {
        private IAutoEigenaar _eigenaarData;
        private IAuto _autoData;
        private AutoEigenaarMapping _eigenaarMapping = new AutoEigenaarMapping();
        private AutoMapping _autoMapping = new AutoMapping();
        
        public AutoEigenaarLogica(IAutoEigenaar eigenaarData, IAuto autoData)
        {
            _eigenaarData = eigenaarData;
            _autoData = autoData;
        }
        public List<AutoEigenaarModel> HaalAllesOp()
        {
            List<AutoEigenaarModel> models = _eigenaarMapping.MapDTOLijstNaarModelLijst(_eigenaarData.AllesOphalen());
            return models;
        }

        public AutoEigenaarModel OphalenOpID(int id)
        {
            AutoEigenaarModel model = _eigenaarMapping.MapDTONaarModel(_eigenaarData.OphalenOpID(id));
            return model;

        }

        public void Aanmaken(AutoEigenaarDTO dto)
        {
            if (dto.Naam == null)
            {
                throw new InvalidDataException("De naam van een eigenaar moet ingevuld zijn!");
            }
            _eigenaarData.Aanmaken(dto);
        }

        public void VerwijderenOpID(int id)
        {
            _eigenaarData.VerwijderenOpID(id);
        }
        
        public AutoEigenaarModel HaalAutosOpVoorEigenaar(int eigenaarID)
        {
            AutoEigenaarDTO dto = _eigenaarData.OphalenOpID(eigenaarID);
            AutoEigenaarModel model = _eigenaarMapping.MapDTONaarModel(dto);
            List<AutoDTO> autos = _autoData.AllesOphalenVoorEigenaar(eigenaarID);
            model.AutosEigenaar = _autoMapping.MapDTOLijstNaarModelLijst(autos);
            return model;
        }
    }
}
