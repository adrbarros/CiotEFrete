using System.ComponentModel;

using ACBr.Net.DFe.Core.Attributes;
using ACBr.Net.DFe.Core.Document;

namespace CiotEFrete.Classes
{
    [DFeRoot("GravarResponse", Namespace = "http://schemas.ipc.adm.br/efrete/veiculos")]
    public sealed class VeiculoGravarResponse : DFeDocument<VeiculoGravarResponse>, INotifyPropertyChanged
    {
        #region Eventos

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Propriedades

        [DFeElement("GravarResult", Namespace = "http://schemas.ipc.adm.br/efrete/veiculos/objects", Ocorrencia = Ocorrencia.Obrigatoria)]
        public VeiculoGravarResult Result { get; set; }

        #endregion Propiedades
    }
}
