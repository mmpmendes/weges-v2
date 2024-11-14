namespace weges_v2.ApiModel;

public class Estabelecimento : Entidade<long>
{
    public string Sigla { get; private set; }
    public string Denominacao { get; private set; }
    public string Morada { get; private set; }
    public string Email { get; private set; }
    public string Telefone { get; private set; }
    //TODO: eventualmente suponho que isto vá passar a ser a sua própria tabela
    public string TipoPrestador { get; private set; }
}
