namespace ApiModel.Models;

/// <summary>
/// Tipo de anexo que pode ser associado a um estabelecimento
/// Nipc, AlvaraCM, MedidasANPC, ParecerANPC,Lista de Verificacao, Ficheiros a Anexar, Direitos e Deveres dos Pacientes, Licenciamento e Registo Legal
/// </summary>
public class AnexoTipo : Entity<long>
{
    public static AnexoTipo Nipc = new() { Id = 1, Tipo = "Nipc" };
    public static AnexoTipo AlvaraCM = new() { Id = 2, Tipo = "AlvaraCM" };
    public static AnexoTipo MedidasANPC = new() { Id = 3, Tipo = "MedidasANPC" };
    public static AnexoTipo ParecerANPC = new() { Id = 4, Tipo = "ParecerANPC" };
    public static AnexoTipo ListaVerificacao = new() { Id = 5, Tipo = "ListaVerificacao" };
    public static AnexoTipo FicheirosAnexar = new() { Id = 6, Tipo = "FicheirosAnexar" };
    public static AnexoTipo DireitosDeveresPacientes = new() { Id = 7, Tipo = "DireitosDeveresPacientes" };
    public static AnexoTipo Licenciamento = new() { Id = 8, Tipo = "Licenciamento" };
    public static AnexoTipo RegistoLegal = new() { Id = 9, Tipo = "RegistoLegal" };

    public required string Tipo { get; set; }
}
