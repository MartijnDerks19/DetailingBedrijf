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
        //private ICRUDCollectie<AfspraakDTO> _data;
        //private DetailerMapping _mapping = new DetailerMapping();
        //public AfspraakLogica(ICRUDCollectie<AfspraakDTO> data)
        //{
        //    _data = data;
        //}
        //public List<AfspraakModel> HaalAlleDetailersOp()
        //{
        //    List<AfspraakModel> models = _mapping.MapDTOLijstNaarModelLijst(_data.AllesOphalen());
        //    return models;
        //}

        //public DetailerModel HaalDetailerOpViaID(int id)
        //{
        //    DetailerModel model = _mapping.MapDTONaarModel(_data.OphalenOpID(id));
        //    return model;

        //}

        //public void DetailerAanmaken(DetailerDTO dto)
        //{
        //    if (dto.Naam == null)
        //    {
        //        throw new InvalidDataException("De naam van een detailer moet ingevuld zijn!");
        //    }
        //    _data.Aanmaken(dto);
        //}

        //public void VerwijderDetailer(int id)
        //{
        //    _data.VerwijderenOpID(id);
        //}
    }
}
