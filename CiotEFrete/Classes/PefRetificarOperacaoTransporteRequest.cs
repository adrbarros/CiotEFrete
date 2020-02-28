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
    [DFeRoot("RetirarOperacaoTransporteRequest", Namespace = "http://schemas.ipc.adm.br/efrete/pef/objects")]
    public sealed class PefRetificarOperacaoTransporteRequest : DFeDocument<PefRetificarOperacaoTransporteRequest>, INotifyPropertyChanged
    {
        #region Eventos

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Construtores
        public PefRetificarOperacaoTransporteRequest()
        {
            Versao = 2;
        }

        /// <summary>
        /// Aproveita os dados da sessão já aberta no client (Token e Integrador)
        /// </summary>
        /// <param name="client">O client</param>
        public PefRetificarOperacaoTransporteRequest(Client client) : this()
        {
            Token = client.Token;
            Integrador = client.Integrador;
        }
        #endregion

        #region Propriedades

        [DFeElement(TipoCampo.Str, "CodigoIdentificacaoOperacao", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 1)]
        public string CodigoIdentificacaoOperacao { get; set; }

        [DFeElement(TipoCampo.Int, "CodigoMunicipioDestino", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 2)]
        public int CodigoMunicipioDestino { get; set; }

        [DFeElement(TipoCampo.Int, "CodigoMunicipioOrigem", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 3)]
        public int CodigoMunicipioOrigem { get; set; }

        [DFeElement(TipoCampo.Str, "Integrador", Namespace = "http://schemas.ipc.adm.br/efrete/objects", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 4)]
        public string Integrador { get; set; }

        [DFeElement(TipoCampo.Str, "Token", Namespace = "http://schemas.ipc.adm.br/efrete/objects", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 5)]
        public string Token { get; set; }

        [DFeElement("Veiculos", Namespace = "http://schemas.ipc.adm.br/efrete/objects", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 6)]
        public PefAdicionarOperacaoTransporteVeiculos Veiculos { get; set; }

        [DFeElement(TipoCampo.Int, "Versao", Namespace = "http://schemas.ipc.adm.br/efrete/objects", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 7)]
        public int Versao { get; set; }

        [DFeElement(TipoCampo.Int, "QuantidadeSaques", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 8)]
        public int QuantidadeSaques { get; set; }

        [DFeElement(TipoCampo.Int, "QuantidadeTransferencias", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 9)]
        public int QuantidadeTransferencias { get; set; }

        #endregion
    }
}
