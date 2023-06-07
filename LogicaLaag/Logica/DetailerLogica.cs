﻿using DataLaag.DTOs;
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
        private IDetailer _data;
        private DetailerMapping _mapping = new DetailerMapping();
        public DetailerLogica(IDetailer data)
        {
            _data = data;
        }
        public List<DetailerModel> HaalAlleDetailersOp()
        {
            List<DetailerModel> models = _mapping.MapDTOLijstNaarModelLijst(_data.AlleDetailersOphalen());
            return SorteerLijstOpNaam(models);
        }

        public DetailerModel HaalDetailerOpViaID(int id)
        {
            DetailerModel model = _mapping.MapDTONaarModel(_data.DetailerOphalenOpID(id));
            return model;

        }

        public void DetailerAanmaken(DetailerDTO dto)
        {
            if (dto.Naam != null)
            {
                _data.DetailerToevoegen(dto);
            }
            else
            {
                throw new InvalidDataException("De naam van een detailer moet ingevuld zijn!");
            }
        }

        public void VerwijderDetailer(int id)
        {
            _data.VerwijderDetailerOpID(id);
        }

        private List<DetailerModel> SorteerLijstOpNaam(List<DetailerModel> models)
        {
            List<DetailerModel> sortedList = models.OrderBy(o => o.Naam).ToList();
            return sortedList;
        }
    }
}
