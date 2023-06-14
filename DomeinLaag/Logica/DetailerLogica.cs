using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomeinLaag.DTOs;
using DomeinLaag.Interfaces;
using DomeinLaag.Mapping;
using DomeinLaag.Models;

namespace DomeinLaag.Logica
{
    public class DetailerLogica
    {
        private IDetailer _data;
        private DetailerMapping _detailerMapping = new DetailerMapping();
        private AfspraakMapping _afspraakMapping = new AfspraakMapping();
        public DetailerLogica(IDetailer data)
        {
            _data = data;
        }
        public List<DetailerModel> HaalAllesOp()
        {
            List<DetailerModel> models = _detailerMapping.MapDTOLijstNaarModelLijst(_data.AllesOphalen());
            return models;
        }

        public DetailerModel HaalOpViaID(int id)
        {
            DetailerModel model = _detailerMapping.MapDTONaarModel(_data.OphalenOpID(id));
            return model;

        }

        public DetailerModel AfsprakenOphalenOpID(int id)
        {
            DetailerModel detailer = _detailerMapping.MapDTONaarModel(_data.OphalenOpID(id));
            List<AfspraakModel> afspraken = _afspraakMapping.MapDTOLijstNaarModelLijst(_data.AfsprakenOphalenOpID(id));
            detailer.AfsprakenDetailer = afspraken;
            return detailer;
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
