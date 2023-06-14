using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomeinLaag.DTOs;
using DomeinLaag.Models;

namespace DomeinLaag.Mapping
{
    public class AutoEigenaarMapping
    {
        public AutoEigenaarModel MapDTONaarModel(AutoEigenaarDTO dto)
        {
            AutoEigenaarModel model = new AutoEigenaarModel()
            {
                EigenaarID = dto.EigenaarID,
                Naam = dto.Naam,
                Email = dto.Email
            };
            return model;
        }

        public AutoEigenaarDTO MapModelNaarDTO(AutoEigenaarModel model)
        {
            AutoEigenaarDTO dto = new AutoEigenaarDTO()
            {
                EigenaarID = model.EigenaarID,
                Naam = model.Naam,
                Email = model.Email
            };
            return dto;
        }

        public List<AutoEigenaarModel> MapDTOLijstNaarModelLijst(List<AutoEigenaarDTO> DTOs)
        {
            List<AutoEigenaarModel> models = new List<AutoEigenaarModel>();
            foreach (var dto in DTOs)
            {
                models.Add(MapDTONaarModel(dto));
            }
            return models;
        }
    }
}
