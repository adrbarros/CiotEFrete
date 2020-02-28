using System.ComponentModel;

using ACBr.Net.DFe.Core.Attributes;
using ACBr.Net.DFe.Core.Document;

namespace CiotEFrete.Classes
{
    [DFeRoot("GravarResponse", Namespace = "http://schemas.ipc.adm.br/efrete/motoristas")]
    public sealed class MotoristaGravarResponse : DFeDocument<MotoristaGravarResponse>, INotifyPropertyChanged
    {
        #region Eventos

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Propriedades

        [DFeElement("GravarResult", Namespace = "http://schemas.ipc.adm.br/efrete/motoristas/objects", Ocorrencia = Ocorrencia.Obrigatoria)]
        public MotoristaGravarResult Result { get; set; }

        #endregion 
    }
}
