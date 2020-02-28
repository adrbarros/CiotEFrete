using ACBr.Net.DFe.Core.Attributes;
using ACBr.Net.DFe.Core.Document;
using ACBr.Net.DFe.Core.Serializer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiotEFrete.Classes
{
    [DFeRoot("ObterCodigoIdentificacaoOperacaoTransportePorIdOperacaoClienteRequest", Namespace = "http://schemas.ipc.adm.br/efrete/pef/objects")]
    public sealed class PefObterCodigoIdentificacaoOperacaoTransportePorIdOperacaoClienteRequest : DFeDocument<PefObterCodigoIdentificacaoOperacaoTransportePorIdOperacaoClienteRequest>, INotifyPropertyChanged
    {
        #region Eventos

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Construtores
        public PefObterCodigoIdentificacaoOperacaoTransportePorIdOperacaoClienteRequest()
        {
            Versao = 1;
        }

        /// <summary>
        /// Aproveita os dados da sessão já aberta no client (Token e Integrador)
        /// </summary>
        /// <param name="client">O client</param>
        public PefObterCodigoIdentificacaoOperacaoTransportePorIdOperacaoClienteRequest(Client client) : this()
        {
            Token = client.Token;
            Integrador = client.Integrador;
        }
        #endregion

        #region Propriedades

        [DFeElement(TipoCampo.Str, "MatrizCNPJ", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 1)]
        public string MatrizCnpj { get; set; }

        [DFeElement(TipoCampo.Str, "IdOperacaoCliente", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 2)]
        public string IdOperacaoCliente { get; set; }

        [DFeElement(TipoCampo.Str, "Integrador", Namespace = "http://schemas.ipc.adm.br/efrete/objects", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 3)]
        public string Integrador { get; set; }

        [DFeElement(TipoCampo.Str, "Token", Namespace = "http://schemas.ipc.adm.br/efrete/objects", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 4)]
        public string Token { get; set; }

        [DFeElement(TipoCampo.Int, "Versao", Namespace = "http://schemas.ipc.adm.br/efrete/objects", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 5)]
        public int Versao { get; set; }
                
        #endregion
    }
}
