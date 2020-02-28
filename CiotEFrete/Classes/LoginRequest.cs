using System.ComponentModel;
using ACBr.Net.DFe.Core.Attributes;
using ACBr.Net.DFe.Core.Document;
using ACBr.Net.DFe.Core.Serializer;

namespace CiotEFrete.Classes
{
    [DFeRoot("LoginRequest", Namespace = "http://schemas.ipc.adm.br/efrete/logon/objects")]
    public sealed class LoginRequest : DFeDocument<LoginRequest>, INotifyPropertyChanged
    {
        #region Eventos

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion 

        #region Propriedades

        [DFeElement(TipoCampo.Str, "Senha", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 1)]
        public string Senha { get; set; }

        [DFeElement(TipoCampo.Str, "Usuario", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 2)]
        public string Usuario { get; set; }

        [DFeElement(TipoCampo.Str, "Integrador", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 3)]
        public string Integrador { get; set; }

        [DFeElement(TipoCampo.Int, "Versao", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 4)]
        public int Versao { get; set; }

        #endregion Propriedades
    }
}