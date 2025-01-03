﻿namespace ApiModel.Models;
public class DirecaoClinica : Entity<long>
{
    public string? Nome { get; set; }
    public string? Cargo { get; set; }
    public string? Identificacao { get; set; }
    public DateOnly ValidadeIdentificacao { get; set; }
    public string? Cedula { get; set; }
    public string? Ordem { get; set; }
    public string? Especialidade { get; set; }
    public long EspecialidadeId { get; set; }
    public string? Observacoes { get; set; }
    public long EstabelecimentoId { get; set; }
    public long TipologiaId { get; set; }
    public string? Tipologia { get; set; }
}