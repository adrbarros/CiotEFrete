using System.ComponentModel;

using ACBr.Net.DFe.Core.Attributes;
using ACBr.Net.DFe.Core.Serializer;


namespace CiotEFrete.Classes
{
    public class ProprietarioGravar : INotifyPropertyChanged
    {
        #region Eventos

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion 

        #region Propriedades

        [DFeElement(TipoCampo.Str, "CNPJ", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 1)]
        public string Cnpj { get; set; }

        [DFeIgnore]
        public TipoPessoa TipoPessoa { get; set; }

        [DFeElement(TipoCampo.Str, "TipoPessoa", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 2)]
        public string TipoPessoaProxy
        {
            get => this.TipoPessoa == TipoPessoa.Fisica ? "Fisica" : "Juridica";
            set => this.TipoPessoa = value == "Juridica" ? TipoPessoa.Juridica : TipoPessoa.Fisica;
        }

        [DFeElement("Endereco", Namespace = "http://schemas.ipc.adm.br/efrete/objects", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 3)]
        public Endereco Endereco { get; set; }

        [DFeElement(TipoCampo.Int, "RNTRC", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 4)]
        public long Rntrc { get; set; }

        [DFeElement(TipoCampo.Str, "RazaoSocial", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 5)]
        public string RazaoSocial { get; set; }

        [DFeElement("Telefones", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 6)]
        public Telefones Telefones { get; set; }

        #endregion
    }
}
