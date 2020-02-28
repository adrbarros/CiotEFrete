using System.ComponentModel;

using ACBr.Net.DFe.Core.Attributes;
using ACBr.Net.DFe.Core.Document;

namespace CiotEFrete.Classes
{
    [DFeRoot("LoginResponse", Namespace = "http://schemas.ipc.adm.br/efrete/logon")]
    public sealed class LoginResponse : DFeDocument<LoginResponse>, INotifyPropertyChanged
    {
        #region Eventos

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion 

        #region Propriedades

        [DFeElement("LoginResult", Namespace = "http://schemas.ipc.adm.br/efrete/logon/objects", Ocorrencia = Ocorrencia.Obrigatoria)]
        public LoginResult Result { get; set; }

        #endregion 
    }
}