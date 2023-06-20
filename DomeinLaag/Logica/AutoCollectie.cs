using DomeinLaag.DTOs;
using DomeinLaag.Interfaces;
using DomeinLaag.Mapping;
using DomeinLaag.Models;

namespace DomeinLaag.Logica
{
    public class AutoCollectie
    {
        private IAuto _data;
        private AutoMapping _mapping = new AutoMapping();
        public AutoCollectie(IAuto data)
        {
            _data = data;
        }
        public List<AutoModel> HaalAllesOp()
        {
            List<AutoModel> models = _mapping.MapDTOLijstNaarModelLijst(_data.AllesOphalen());
            return models;
        }

        public AutoModel HaalOpViaID(int id)
        {
            AutoModel model = _mapping.MapDTONaarModel(_data.OphalenOpID(id));
            return model;

        }

        public void Aanmaken(AutoDTO dto)
        {
            if (dto.Merk == null)
            {
                throw new InvalidDataException("Het merk van een auto moet ingevuld zijn!");
            }
            _data.Aanmaken(dto);
        }

        public void Verwijderen(int id)
        {
            _data.VerwijderenOpID(id);
        }

        public void Aanpassen(int id, AutoModel model)
        {
            AutoDTO oudeDto = _data.OphalenOpID(id);
            AutoDTO dto = _mapping.MapModelNaarDTO(model);

            dto.AutoID = oudeDto.AutoID;
            dto.EigenaarID = oudeDto.EigenaarID;

            _data.AanpassenOpID(id, dto);
        }
    }
}
