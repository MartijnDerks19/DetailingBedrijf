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
    public class AfspraakLogica
    {
        private ICRUDCollectie<AfspraakDTO> _data;
        private AfspraakMapping _mapping = new AfspraakMapping();
        public AfspraakLogica(ICRUDCollectie<AfspraakDTO> data)
        {
            _data = data;
        }
        public List<AfspraakModel> HaalAllesOp()
        {
            List<AfspraakModel> models = _mapping.MapDTOLijstNaarModelLijst(_data.AllesOphalen());
            return models;
        }

        public AfspraakModel HaalOpViaID(int id)
        {
            AfspraakModel model = _mapping.MapDTONaarModel(_data.OphalenOpID(id));
            return model;

        }

        public void Aanmaken(AfspraakDTO dto)
        {
            if (dto.DatumEnTijd == null)
            {
                throw new InvalidDataException("De datum van een afspraak moet ingevuld zijn.");
            }
            _data.Aanmaken(dto);
        }

        public void Verwijderen(int id)
        {
            _data.VerwijderenOpID(id);
        }
    }
}
