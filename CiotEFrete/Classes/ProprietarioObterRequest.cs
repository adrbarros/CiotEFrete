using ACBr.Net.DFe.Core.Attributes;
using ACBr.Net.DFe.Core.Document;
using ACBr.Net.DFe.Core.Serializer;

using System.ComponentModel;

namespace CiotEFrete.Classes
{
    [DFeRoot("ObterRequest", Namespace = "http://schemas.ipc.adm.br/efrete/motoristas/objects")]
    public sealed class ProprietarioObterRequest : DFeDocument<ProprietarioObterRequest>, INotifyPropertyChanged
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

        [DFeElement(TipoCampo.Int, "RNTRC", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 3)]
        public long Rntrc { get; set; }

        #endregion
    }
}
