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
    [DFeRoot("ObterResponse", Namespace = "http://schemas.ipc.adm.br/efrete/proprietarios")]
    public sealed class ProprietarioObterResponse : DFeDocument<ProprietarioObterResponse>, INotifyPropertyChanged
    {
        #region Eventos

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Propriedades

        [DFeElement("ObterResponse", Namespace = "http://schemas.ipc.adm.br/efrete/proprietarios/objects", Ocorrencia = Ocorrencia.Obrigatoria)]
        public ProprietarioObterResult Result { get; set; }

        #endregion 
    }
}
