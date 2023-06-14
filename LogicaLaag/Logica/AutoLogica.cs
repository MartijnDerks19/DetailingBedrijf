using LogicaLaag.DTOs;
using LogicaLaag.Interfaces;
using LogicaLaag.Mapping;
using LogicaLaag.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaLaag.Logica
{
    public class AutoLogica
    {
        private ICRUDCollectie<AutoDTO> _autoData;
        private ICRUDCollectie<AutoEigenaarDTO> _eigenaarData;
        private IDashboard _dashboardData;
        private AutoMapping _autoMapping = new AutoMapping();
        private AutoEigenaarMapping _eigenaarMapping = new AutoEigenaarMapping();
        public AutoLogica(ICRUDCollectie<AutoDTO> autoData, ICRUDCollectie<AutoEigenaarDTO> eigenaarData, IDashboard dashboardData)
        {
            _autoData = autoData;
            _eigenaarData = eigenaarData;
            _dashboardData = dashboardData;
        }
        public List<AutoModel> HaalAllesOp()
        {
            List<AutoModel> models = _autoMapping.MapDTOLijstNaarModelLijst(_autoData.AllesOphalen());
            return models;
        }

        public AutoModel HaalOpViaID(int id)
        {
            AutoModel model = _autoMapping.MapDTONaarModel(_autoData.OphalenOpID(id));
            return model;

        }

        public void Aanmaken(AutoDTO dto)
        {
            if (dto.Merk == null)
            {
                throw new InvalidDataException("Het merk van een auto moet ingevuld zijn!");
            }
            _autoData.Aanmaken(dto);
        }

        public void Verwijderen(int id)
        {
            _autoData.VerwijderenOpID(id);
        }

        public AutoEigenaarModel HaalAutosOpVoorEigenaar(int eigenaarID)
        {
            AutoEigenaarDTO dto = _eigenaarData.OphalenOpID(eigenaarID);
            AutoEigenaarModel model = _eigenaarMapping.MapDTONaarModel(dto);
            List<AutoDTO> autos = _dashboardData.AutosOphalenVoorEigenaar(eigenaarID);
            model.AutosEigenaar = _autoMapping.MapDTOLijstNaarModelLijst(autos);
            return model;
        }
    }
}
