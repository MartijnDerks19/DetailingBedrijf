using DomeinLaag.DTOs;

namespace DomeinLaag.Interfaces;

public interface IAutoEigenaar
{
    void Aanmaken(AutoEigenaarDTO dto);
    void VerwijderenOpID(int id);
    void AanpassenOpID(int id, AutoEigenaarDTO dto);
    AutoEigenaarDTO OphalenOpID(int id);
    List<AutoEigenaarDTO> AllesOphalen();
    List<AutoDTO> AutosOphalenOpID(int eigenaarID);
}