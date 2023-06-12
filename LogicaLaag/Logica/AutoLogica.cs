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
        private ICRUDCollectie<AutoDTO> _data;
        private AutoMapping _mapping = new AutoMapping();
        public AutoLogica(ICRUDCollectie<AutoDTO> data)
        {
            _data = data;
        }
        public List<AutoModel> HaalAllesOp()
        {
            List<AutoModel> models = _mapping.MapDTOLijstNaarModelLijst(_data.AllesOphalen());
            return models;
        }

        public AutoModel HaalOpViaID(int id)
        {
            AutoModel model = _mapping.MapDTONaarModel(_data.OphalenOpID(id));
            return model;

        }

        public void Aanmaken(AutoDTO dto)
        {
            if (dto.Merk == null)
            {
                throw new InvalidDataException("Het merk van een auto moet ingevuld zijn!");
            }
            _data.Aanmaken(dto);
        }

        public void Verwijderen(int id)
        {
            _data.VerwijderenOpID(id);
        }
    }
}
