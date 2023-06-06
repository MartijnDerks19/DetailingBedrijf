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
            return models;
        }
    }
}
