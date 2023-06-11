using DataLaag.DTOs;
using InterfaceLaag.DTOs;
using InterfaceLaag.Interfaces;
using LogicaLaag.Mapping;
using LogicaLaag.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaLaag.Logica
{
    public class AutoEigenaarLogica
    {
        private ICRUDCollectie<AutoEigenaarDTO> _data;
        private AutoEigenaarMapping _mapping = new AutoEigenaarMapping();
        public AutoEigenaarLogica(ICRUDCollectie<AutoEigenaarDTO> data)
        {
            _data = data;
        }
        public List<AutoEigenaarModel> HaalAllesOp()
        {
            List<AutoEigenaarModel> models = _mapping.MapDTOLijstNaarModelLijst(_data.AllesOphalen());
            return models;
        }

        public AutoEigenaarModel OphalenOpID(int id)
        {
            AutoEigenaarModel model = _mapping.MapDTONaarModel(_data.OphalenOpID(id));
            return model;

        }

        public void Aanmaken(AutoEigenaarDTO dto)
        {
            if (dto.Naam == null)
            {
                throw new InvalidDataException("De naam van een eigenaar moet ingevuld zijn!");
            }
            _data.Aanmaken(dto);
        }

        public void VerwijderenOpID(int id)
        {
            _data.VerwijderenOpID(id);
        }
    }
}
