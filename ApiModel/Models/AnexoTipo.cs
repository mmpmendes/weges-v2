namespace ApiModel.Models;

/// <summary>
/// Tipo de anexo que pode ser associado a um estabelecimento
/// Nipc, AlvaraCM, MedidasANPC, ParecerANPC,Lista de Verificacao, Ficheiros a Anexar, Direitos e Deveres dos Pacientes, Licenciamento e Registo Legal
/// </summary>
public class AnexoTipo : Entity<long>
{
    public required string Tipo { get; set; }
}
