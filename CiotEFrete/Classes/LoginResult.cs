using System.ComponentModel;
using ACBr.Net.DFe.Core.Attributes;
using ACBr.Net.DFe.Core.Serializer;

namespace CiotEFrete.Classes
{
    public sealed class LoginResult : INotifyPropertyChanged
    {
        #region Eventos

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion 

        #region Propriedades

        [DFeElement(TipoCampo.Str, "Token", Namespace = "http://schemas.ipc.adm.br/efrete/objects", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 1)]
        public string Token { get; set; }

        [DFeElement(TipoCampo.Str, "Versao", Namespace = "http://schemas.ipc.adm.br/efrete/objects", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 2)]
        public string Versao { get; set; }

        [DFeIgnore]
        public bool Sucesso { get; set; }

        [DFeElement(TipoCampo.Str, "Sucesso", Namespace = "http://schemas.ipc.adm.br/efrete/objects", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 3)]
        public string SucessoProxy
        {
            get => Sucesso ? "true" : "false";
            set => Sucesso = value == "true";
        }

        [DFeElement("Excecao", Namespace = "http://schemas.ipc.adm.br/efrete/objects", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 4)]
        public Excecao Excecao { get; set; }

        [DFeElement(TipoCampo.Str, "ProtocoloServico", Namespace = "http://schemas.ipc.adm.br/efrete/objects", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 5)]
        public string ProtocoloServico { get; set; }

        #endregion 
      
    }
}