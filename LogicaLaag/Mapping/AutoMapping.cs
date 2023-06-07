using InterfaceLaag.DTOs;
using LogicaLaag.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaLaag.Mapping
{
    public class AutoMapping
    {
        public AutoModel MapDTONaarModel(AutoDTO dto)
        {
            AutoModel model = new AutoModel()
            {
                AutoID = dto.AutoID,
                Merk = dto.Merk,
                Type = dto.Type,
                Bouwjaar = dto.Bouwjaar
            };
            return model;
        }

        public AutoDTO MapModelNaarDTO(AutoModel model)
        {
            AutoDTO dto = new AutoDTO()
            {
                AutoID = model.AutoID,
                Merk = model.Merk,
                Type = model.Type,
                Bouwjaar = model.Bouwjaar
            };
            return dto;
        }

        public List<AutoModel> MapDTOLijstNaarModelLijst(List<AutoDTO> DTOs)
        {
            List<AutoModel> models = new List<AutoModel>();
            foreach (var dto in DTOs)
            {
                models.Add(MapDTONaarModel(dto));
            }
            return models;
        }
    }
}
