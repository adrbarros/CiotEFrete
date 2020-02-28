using ACBr.Net.DFe.Core.Attributes;
using ACBr.Net.DFe.Core.Serializer;

namespace CiotEFrete.Classes
{
    public sealed class Telefones
    {
        [DFeElement("Celular", Namespace = "http://schemas.ipc.adm.br/efrete/objects", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 1)]
        public Telefone Celular { get; set; }

        [DFeElement("Fax", Namespace = "http://schemas.ipc.adm.br/efrete/objects", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 2)]
        public Telefone Fax { get; set; }

        [DFeElement("Fixo", Namespace = "http://schemas.ipc.adm.br/efrete/objects", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 3)]
        public Telefone Fixo { get; set; }

    }

    public sealed class Telefone
    {
        [DFeElement(TipoCampo.Str, "DDD", Namespace = "http://schemas.ipc.adm.br/efrete/objects", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 4)]
        public string Ddd { get; set; }

        [DFeElement(TipoCampo.Str, "Numero", Namespace = "http://schemas.ipc.adm.br/efrete/objects", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 5)]
        public string Numero { get; set; }
    }
}
