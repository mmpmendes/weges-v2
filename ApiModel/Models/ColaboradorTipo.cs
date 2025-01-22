namespace ApiModel.Models;

/// <summary>
/// Tipos de colaboradores
/// Corpo Clínico, Administrativo, etc
/// </summary>
public class ColaboradorTipo : Entity<long>
{
    public required string Tipo { get; set; }
}
