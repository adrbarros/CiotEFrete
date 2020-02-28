using System.ComponentModel;

using ACBr.Net.DFe.Core.Attributes;
using ACBr.Net.DFe.Core.Document;
using ACBr.Net.DFe.Core.Serializer;

namespace CiotEFrete.Classes
{
    [DFeRoot("LogoutRequest", Namespace = "http://schemas.ipc.adm.br/efrete/logon/objects")]
    public sealed class LogoutRequest : DFeDocument<LogoutRequest>, INotifyPropertyChanged
    {
        #region Eventos

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion 

        #region Construtores

        public LogoutRequest()
        {
            Versao = 1;
        }

        #endregion

        #region Propriedades

        [DFeElement(TipoCampo.Str, "Integrador", Namespace = "http://schemas.ipc.adm.br/efrete/objects", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 1)]
        public string Integrador { get; set; }

        [DFeElement(TipoCampo.Int, "Versao", Namespace = "http://schemas.ipc.adm.br/efrete/objects", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 2)]
        public int Versao { get; set; }

        [DFeElement(TipoCampo.Str, "Token", Namespace = "http://schemas.ipc.adm.br/efrete/objects", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 3)]
        public string Token { get; set; }
        #endregion Propriedades
    }
}
