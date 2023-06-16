using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DomeinLaag.DTOs;
using DomeinLaag.Exceptions;
using DomeinLaag.Interfaces;
using DomeinLaag.Mapping;
using DomeinLaag.Models;

namespace DomeinLaag.Logica
{
    public class AfspraakCollectie
    {
        private IAfspraak _afspraakData;
        private IDetailer _detailerData;
        private AfspraakMapping _mapping = new AfspraakMapping();
        public AfspraakCollectie(IAfspraak afspraakData, IDetailer detailerData)
        {
            _afspraakData = afspraakData;
            _detailerData = detailerData;

        }
        public List<AfspraakModel> HaalAllesOp()
        {
            List<AfspraakModel> models = _mapping.MapDTOLijstNaarModelLijst(_afspraakData.AllesOphalen());
            return models;
        }

        public AfspraakModel HaalOpViaID(int id)
        {
            AfspraakModel model = _mapping.MapDTONaarModel(_afspraakData.OphalenOpID(id));
            return model;

        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dto"></param>
        /// <exception cref="DagIsVolGeplandException"></exception>
        /// <exception cref="DeZaakIsGeslotenException"></exception>
        public void ProbeerAanmaken(AfspraakDTO dto)
        {
            List<AfspraakDTO> afspraken = _detailerData.AfsprakenOphalenOpID(dto.DetailerID);
            if (IsDagVolGepland(afspraken, dto))
            {
                throw new DagIsVolGeplandException("Datum is vol probeer een andere dag"); //Catch exception in ui 
            }
            else if (DeZaakIsGesloten(dto))
            {
                throw new DeZaakIsGeslotenException("Wij zijn helaas gesloten op maandag probeer een andere dag. ");
            }
            _afspraakData.Aanmaken(dto);
        }

        public void Verwijderen(int id)
        {
            _afspraakData.VerwijderenOpID(id);
        }

        public List<AfspraakModel> HaalOpVoorDetailer(int detailerID)
        {
           List<AfspraakModel> afspraken = _mapping.MapDTOLijstNaarModelLijst(_detailerData.AfsprakenOphalenOpID(detailerID));
            return afspraken;
        }

        private bool DeZaakIsGesloten(AfspraakDTO dto)
        {
            DayOfWeek dag = dto.DatumEnTijd.DayOfWeek;
            if (dag== DayOfWeek.Monday)
            {
                return true;
            }
            return false;
        }

        private bool IsDagVolGepland(List<AfspraakDTO> afspraken, AfspraakDTO dto)
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
