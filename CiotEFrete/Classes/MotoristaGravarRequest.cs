using System;
using System.ComponentModel;

using ACBr.Net.DFe.Core.Attributes;
using ACBr.Net.DFe.Core.Document;
using ACBr.Net.DFe.Core.Serializer;

namespace CiotEFrete.Classes
{
    [DFeRoot("GravarRequest", Namespace = "http://schemas.ipc.adm.br/efrete/motoristas/objects")]
    public sealed class MotoristaGravarRequest : DFeDocument<MotoristaGravarRequest>, INotifyPropertyChanged
    {
        #region Eventos

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion 

        #region Construtores
        public MotoristaGravarRequest()
        {
            Versao = 2;
        }

        /// <summary>
        /// Aproveita os dados da sessão já aberta no client (Token e Integrador)
        /// </summary>
        /// <param name="client">O client</param>
        public MotoristaGravarRequest(Client client) : this()
        {
            Token = client.Token;
            Integrador = client.Integrador;
        }
        #endregion

        #region Propriedades

        [DFeElement(TipoCampo.Str, "Integrador", Namespace = "http://schemas.ipc.adm.br/efrete/objects", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 1)]
        public string Integrador { get; set; }

        [DFeElement(TipoCampo.Str, "Token", Namespace = "http://schemas.ipc.adm.br/efrete/objects", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 2)]
        public string Token { get; set; }

        [DFeElement(TipoCampo.Int, "Versao", Namespace = "http://schemas.ipc.adm.br/efrete/objects", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 3)]
        public int Versao { get; set; }

        [DFeElement(TipoCampo.Str, "CNH", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 4)]
        public string Cnh { get; set; }

        [DFeElement(TipoCampo.Str, "CPF", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 5)]
        public string Cpf { get; set; }

        [DFeIgnore]
        public DateTime DataNascimento { get; set; }

        [DFeElement(TipoCampo.Str, "DataNascimento", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 6)]
        public string DataNascimentoProxy
        {
            get => DataNascimento.ToString("yyyy-MM-dd");
            set => DataNascimento = DateTime.Parse(value);
        }

        [DFeElement("Endereco", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 7)]
        public Endereco Endereco { get; set; }

        [DFeElement(TipoCampo.Str, "Nome", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 8)]
        public string Nome { get; set; }

        [DFeElement(TipoCampo.Str, "NomeDeSolteiroDaMae", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 8)]
        public string NomeDeSolteiroDaMae { get; set; }

        [DFeElement("Telefones", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 9)]
        public Telefones Telefones { get; set; }

        #endregion Propriedades
    }
}
