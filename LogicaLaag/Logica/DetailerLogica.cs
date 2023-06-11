using DataLaag.DTOs;
using InterfaceLaag.Interfaces;
using LogicaLaag.Mapping;
using LogicaLaag.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaLaag.Logica
{
    public class DetailerLogica
    {
        private ICRUDCollectie<DetailerDTO> _data;
        private DetailerMapping _mapping = new DetailerMapping();
        public DetailerLogica(ICRUDCollectie<DetailerDTO> data)
        {
            _data = data;
        }
        public List<DetailerModel> HaalAllesOp()
        {
            List<DetailerModel> models = _mapping.MapDTOLijstNaarModelLijst(_data.AllesOphalen());
            return models;
        }

        public DetailerModel HaalOpViaID(int id)
        {
            DetailerModel model = _mapping.MapDTONaarModel(_data.OphalenOpID(id));
            return model;

        }

        public void Aanmaken(DetailerDTO dto)
        {
            if (dto.Naam == null)
            {
                throw new InvalidDataException("De naam van een detailer moet ingevuld zijn!");
            }
            _data.Aanmaken(dto);
        }

        public void Verwijderen(int id)
        {
            _data.VerwijderenOpID(id);
        }
    }
}
