using DataLaag.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLaag.Interfaces
{
    public interface IDetailer
    {
        void DetailerToevoegen(DetailerDTO detailer);
        public void VerwijderDetailerOpID(int id);
        public DetailerDTO DetailerOphalenOpID(int id);
        List<DetailerDTO> AlleDetailersOphalen();
    }
}
