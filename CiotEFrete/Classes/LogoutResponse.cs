using ACBr.Net.DFe.Core.Attributes;
using ACBr.Net.DFe.Core.Document;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiotEFrete.Classes
{
    [DFeRoot("LogoutResponse", Namespace = "http://schemas.ipc.adm.br/efrete/logon")]
    public sealed class LogoutResponse : DFeDocument<LogoutResponse>, INotifyPropertyChanged
    {
        #region Eventos

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion 

        #region Propriedades

        [DFeElement("LogoutResult", Namespace = "http://schemas.ipc.adm.br/efrete/logon/objects", Ocorrencia = Ocorrencia.Obrigatoria)]
        public LogoutResult Result { get; set; }

        #endregion 
    }
}
