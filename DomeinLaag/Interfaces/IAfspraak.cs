using DomeinLaag.DTOs;

namespace DomeinLaag.Interfaces;

public interface IAfspraak
{
    void Aanmaken(AfspraakDTO dto);
    void VerwijderenOpID(int id);
    void AanpassenOpID(int id, AfspraakDTO dto);
    AfspraakDTO OphalenOpID(int id);
    List<AfspraakDTO> AllesOphalen();
}