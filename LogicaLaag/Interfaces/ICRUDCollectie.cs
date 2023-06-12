using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaLaag.Interfaces
{
    public interface ICRUDCollectie <T>
    {
        void Aanmaken(T entiteit);
        void VerwijderenOpID(int id);
        void AanpassenOpID(int id, T entiteit);
        T OphalenOpID(int id);
        List<T> AllesOphalen();
    }
}
