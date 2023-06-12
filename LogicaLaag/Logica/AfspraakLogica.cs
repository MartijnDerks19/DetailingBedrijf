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
    public class AfspraakLogica
    {
        private ICRUDCollectie<AfspraakDTO> _data;
        private IDashboard _dashboardData;
        private AfspraakMapping _mapping = new AfspraakMapping();
        public AfspraakLogica(ICRUDCollectie<AfspraakDTO> data, IDashboard dashboardData)
        {
            _data = data;
            _dashboardData = dashboardData;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        /// <exception cref="InvalidOperationException"></exception>
        public void ProbeerAanmaken(AfspraakDTO dto)
        {
            List<AfspraakDTO> afspraken = _dashboardData.AllesOphalenVoorDetailer(dto.DetailerID);
            if (IsDagVolGepland(afspraken, dto))
            {
                throw new InvalidOperationException("Er zijn al 2 afspraken ingepland op deze dag!"); //Catch exception in ui 
            }
            _data.Aanmaken(dto);
        }

        public void Verwijderen(int id)
        {
            _data.VerwijderenOpID(id);
        }

        public List<AfspraakModel> HaalOpVoorDetailer(int detailerID)
        {
           List<AfspraakModel> afspraken = _mapping.MapDTOLijstNaarModelLijst(_dashboardData.AllesOphalenVoorDetailer(detailerID));
            return afspraken;
        }

        public bool IsDagVolGepland(List<AfspraakDTO> afspraken, AfspraakDTO dto)
        {
            int i = 0;
            foreach (AfspraakDTO afspraak in afspraken)
            {
                if (i == 2)
                {
                    return true;
                }
                else if (afspraak.DatumEnTijd == dto.DatumEnTijd)
                {
                    i++;
                }
            }
            return false;
        }
    }
}
