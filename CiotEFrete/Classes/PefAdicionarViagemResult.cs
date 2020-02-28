using ACBr.Net.DFe.Core.Attributes;
using ACBr.Net.DFe.Core.Serializer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiotEFrete.Classes
{
    public sealed class PefAdicionarViagemResult : INotifyPropertyChanged
    {
        #region Eventos

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Propriedades

        [DFeElement(TipoCampo.Str, "CodigoIdentificacaoOperacao", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 1)]
        public string CodigoIdentificacaoOperacao { get; set; }

        [DFeElement("Excecao", Namespace = "http://schemas.ipc.adm.br/efrete/objects", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 2)]
        public Excecao Excecao { get; set; }

        [DFeElement(TipoCampo.Int, "QuantidadeDeViagens", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 3)]
        public int QuantidadeViagens { get; set; }

        [DFeElement("DocumentoViagem", Namespace = "http://schemas.ipc.adm.br/efrete/objects", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 4)]
        public PefAdicionarViagemDocumentoViagem DocumentoViagem { get; set; }

        [DFeElement(TipoCampo.Int, "QuantidadeDePagamentos", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 5)]
        public int QuantidadePagamentos { get; set; }

        [DFeElement("DocumentoPagamento", Namespace = "http://schemas.ipc.adm.br/efrete/objects", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 6)]
        public PefAdicionarViagemDocumentoPagamento DocumentoPagamento { get; set; }

        [DFeIgnore]
        public bool Sucesso { get; set; }

        [DFeElement(TipoCampo.Str, "Sucesso", Namespace = "http://schemas.ipc.adm.br/efrete/objects", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 7)]
        public string SucessoProxy
        {
            get => Sucesso ? "true" : "false";
            set => Sucesso = value == "true";
        }

        [DFeElement(TipoCampo.Str, "Versao", Namespace = "http://schemas.ipc.adm.br/efrete/objects", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 8)]
        public string Versao { get; set; }

        #endregion
    }
}
