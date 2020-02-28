using System.ComponentModel;

using ACBr.Net.DFe.Core.Attributes;
using ACBr.Net.DFe.Core.Document;
using ACBr.Net.DFe.Core.Serializer;


namespace CiotEFrete.Classes
{
    [DFeRoot("GravarRequest", Namespace = "http://schemas.ipc.adm.br/efrete/veiculos/objects")]
    public sealed class VeiculoGravarRequest : DFeDocument<VeiculoGravarRequest>, INotifyPropertyChanged
    {
        #region Eventos

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion Events

        #region Construtores
        public VeiculoGravarRequest()
        {
            Versao = 1;
        }

        /// <summary>
        /// Aproveita os dados da sessão já aberta no client (Token e Integrador)
        /// </summary>
        /// <param name="client">O client</param>
        public VeiculoGravarRequest(Client client) : this()
        {
            Token = client.Token;
            Integrador = client.Integrador;
        }
        #endregion

        #region Propriedades

        [DFeElement(TipoCampo.Str, "Integrador", Namespace = "http://schemas.ipc.adm.br/efrete/objects", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 1)]
        public string Integrador { get; set; }

        [DFeElement(TipoCampo.Str, "Token", Namespace = "http://schemas.ipc.adm.br/efrete/objects", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 2)]
        public string Token { get; set; }

        [DFeElement("Veiculo", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 3)]
        public VeiculoGravar Veiculo { get; set; }

        [DFeElement(TipoCampo.Int, "Versao", Namespace = "http://schemas.ipc.adm.br/efrete/objects", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 4)]
        public int Versao { get; set; }
        #endregion
    }
}
