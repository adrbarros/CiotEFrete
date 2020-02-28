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
    [DFeRoot("GravarResponse", Namespace = "http://schemas.ipc.adm.br/efrete/proprietarios")]
    public sealed class ProprietarioGravarResponse : DFeDocument<ProprietarioGravarResponse>, INotifyPropertyChanged
    {
        #region Eventos

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Propriedades

        [DFeElement("GravarResult", Namespace = "http://schemas.ipc.adm.br/efrete/proprietarios/objects", Ocorrencia = Ocorrencia.Obrigatoria)]
        public ProprietarioGravarResult Result { get; set; }

        #endregion Properties
    }
}
