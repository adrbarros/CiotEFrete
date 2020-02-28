using System.ComponentModel;

using ACBr.Net.DFe.Core.Attributes;
using ACBr.Net.DFe.Core.Document;
using ACBr.Net.DFe.Core.Serializer;

namespace CiotEFrete.Classes
{
    #region Enums

    public enum TipoPessoa
    {
        Fisica,
        Juridica
    }

    #endregion

    [DFeRoot("GravarRequest", Namespace = "http://schemas.ipc.adm.br/efrete/proprietarios/objects")]
    public sealed class ProprietarioGravarRequest : DFeDocument<ProprietarioGravarRequest>, INotifyPropertyChanged
    {
        #region Eventos

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion 
                
        #region Construtores
        public ProprietarioGravarRequest()
        {
            Versao = 3;
        }

        /// <summary>
        /// Aproveita os dados da sessão já aberta no client (Token e Integrador)
        /// </summary>
        /// <param name="client">O client</param>
        public ProprietarioGravarRequest(Client client) : this()
        {
            Token = client.Token;
            Integrador = client.Integrador;
        }
        #endregion        

        #region Propriedades

        [DFeElement(TipoCampo.Str, "Integrador", Namespace = "http://schemas.ipc.adm.br/efrete/objects", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 1)]
        public string Integrador { get; set; }

        [DFeElement(TipoCampo.Str, "CNPJ", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 2)]
        public string Cnpj { get; set; }

        [DFeIgnore]
        public TipoPessoa TipoPessoa { get; set; }

        [DFeElement(TipoCampo.Str, "TipoPessoa", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 3)]
        public string TipoPessoaProxy
        {
            get => this.TipoPessoa == TipoPessoa.Fisica ? "Fisica" : "Juridica";
            set => this.TipoPessoa = value == "Juridica" ? TipoPessoa.Juridica : TipoPessoa.Fisica;
        }

        [DFeElement("Endereco", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 4)]
        public Endereco Endereco { get; set; }

        [DFeElement(TipoCampo.Str, "RNTRC", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 5)]
        public string Rntrc { get; set; }

        [DFeElement(TipoCampo.Str, "RazaoSocial", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 6)]
        public string RazaoSocial { get; set; }

        [DFeElement("Telefones", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 7)]
        public Telefones Telefones { get; set; }

        [DFeElement(TipoCampo.Str, "Token", Namespace = "http://schemas.ipc.adm.br/efrete/objects", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 8)]
        public string Token { get; set; }

        [DFeElement(TipoCampo.Int, "Versao", Namespace = "http://schemas.ipc.adm.br/efrete/objects", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 9)]
        public int Versao { get; set; }    

        #endregion

    }
}
