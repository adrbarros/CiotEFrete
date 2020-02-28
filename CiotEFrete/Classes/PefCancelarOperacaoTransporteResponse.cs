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
    [DFeRoot("CancelarOperacaoTransporteResponse", Namespace = "http://schemas.ipc.adm.br/efrete/pef")]
    public sealed class PefCancelarOperacaoTransporteResponse : DFeDocument<PefCancelarOperacaoTransporteResponse>, INotifyPropertyChanged
    {
        #region Eventos

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Propriedades

        [DFeElement("CancelarOperacaoTransporteResult", Namespace = "http://schemas.ipc.adm.br/efrete/pef/objects", Ocorrencia = Ocorrencia.Obrigatoria)]
        public PefCancelarOperacaoTransporteResult Result { get; set; }

        #endregion
    }
}
