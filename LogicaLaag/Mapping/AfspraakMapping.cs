using DataLaag.DTOs;
using InterfaceLaag.DTOs;
using LogicaLaag.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaLaag.Mapping
{
    public class AfspraakMapping
    {
        public AfspraakModel MapDTONaarModel(AfspraakDTO dto)
        {
            AfspraakModel model = new AfspraakModel()
            {
                DetailerID = dto.DetailerID,
                AutoID = dto.AutoID,
                AfspraakID = dto.AfspraakID,
                DatumEnTijd = dto.DatumEnTijd,
            };
            return model;
        }

        public AfspraakDTO MapModelNaarDTO(AfspraakModel model)
        {
            AfspraakDTO dto = new AfspraakDTO()
            {
                DetailerID = model.DetailerID,
                AutoID = model.AutoID,
                AfspraakID = model.AfspraakID,
                DatumEnTijd = model.DatumEnTijd,
            };
            return dto;
        }

        public List<AfspraakModel> MapDTOLijstNaarModelLijst(List<AfspraakDTO> DTOs)
        {
            List<AfspraakModel> models = new List<AfspraakModel> ();
            foreach (var dto in DTOs)
            {
                models.Add(MapDTONaarModel(dto));
            }
            return models;
        }
    }
}
