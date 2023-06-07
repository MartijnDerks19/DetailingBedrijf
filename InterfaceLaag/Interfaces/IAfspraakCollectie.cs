using DataLaag.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLaag.Interfaces
{
    public interface IAfspraakCollectie
    {
        public void AfspraakOphalenOpID(int id);
        public void AfspraakToevoegen(DetailerDTO detailer);
        List<DetailerDTO> AlleAfsprakenOphalen();
    }
}
