using LogicaLaag.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaLaag.Interfaces
{
    public interface IDashboard
    {
        List<AfspraakDTO> AllesOphalenVoorDetailer(int detailerID);
    }
}
