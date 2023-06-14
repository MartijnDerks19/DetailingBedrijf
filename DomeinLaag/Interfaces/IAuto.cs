using DomeinLaag.DTOs;

namespace DomeinLaag.Interfaces;

public interface IAuto
{
    void Aanmaken(AutoDTO dto);
    void VerwijderenOpID(int id);
    void AanpassenOpID(int id, AutoDTO dto);
    AutoDTO OphalenOpID(int id);
    List<AutoDTO> AllesOphalen();
    List<AutoDTO> AllesOphalenVoorEigenaar(int id);
}