using System.ComponentModel;

using ACBr.Net.DFe.Core.Attributes;
using ACBr.Net.DFe.Core.Document;

namespace CiotEFrete.Classes
{
    [DFeRoot("ObterResponse", Namespace = "http://schemas.ipc.adm.br/efrete/motoristas")]
    public sealed class MotoristaObterResponse : DFeDocument<MotoristaObterResponse>, INotifyPropertyChanged
    {
        #region Eventos

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Propriedades

        [DFeElement("ObterResponse", Namespace = "http://schemas.ipc.adm.br/efrete/motoristas/objects", Ocorrencia = Ocorrencia.Obrigatoria)]
        public MotoristaObterResult Result { get; set; }

        #endregion 

    }
}
