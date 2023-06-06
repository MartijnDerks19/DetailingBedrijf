using DataLaag.DTOs;
using LogicaLaag.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaLaag.Mapping
{
    public class DetailerMapping
    {
        public DetailerModel MapDTONaarModel(DetailerDTO dto)
        {
            DetailerModel model = new DetailerModel()
            {
                DetailerID = dto.DetailerID,
                Naam = dto.Naam,
            };
            return model;
        }

        public DetailerDTO MapModelNaarDTO(DetailerModel model)
        {
            DetailerDTO dto = new DetailerDTO()
            {
                DetailerID = model.DetailerID,
                Naam = model.Naam,
            };
            return dto;
        }

        public List<DetailerModel> MapDTOLijstNaarModelLijst(List<DetailerDTO> DTOs)
        {
            List<DetailerModel> models = new List<DetailerModel>();
            foreach (var dto in DTOs)
            {
                models.Add(MapDTONaarModel(dto));
            }
            return models;
        }
    }
}
