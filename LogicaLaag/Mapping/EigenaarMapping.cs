using InterfaceLaag.DTOs;
using LogicaLaag.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaLaag.Mapping
{
    public class EigenaarMapping
    {
        public EigenaarModel MapDTONaarModel(EigenaarDTO dto)
        {
            EigenaarModel model = new EigenaarModel()
            {
                EigenaarID = dto.EigenaarID,
                Naam = dto.Naam,
                Email = dto.Email
            };
            return model;
        }

        public EigenaarDTO MapModelNaarDTO(EigenaarModel model)
        {
            EigenaarDTO dto = new EigenaarDTO()
            {
                EigenaarID = model.EigenaarID,
                Naam = model.Naam,
                Email = model.Email
            };
            return dto;
        }

        public List<EigenaarModel> MapDTOLijstNaarModelLijst(List<EigenaarDTO> DTOs)
        {
            List<EigenaarModel> models = new List<EigenaarModel>();
            foreach (var dto in DTOs)
            {
                models.Add(MapDTONaarModel(dto));
            }
            return models;
        }
    }
}
