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
    [DFeRoot("ObterOperacaoTransportePdfResponse", Namespace = "http://schemas.ipc.adm.br/efrete/pef")]
    public sealed class PefObterOperacaoTransportePdfResponse : DFeDocument<PefObterOperacaoTransportePdfResponse>, INotifyPropertyChanged
    {
        #region Eventos

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Propriedades

        [DFeElement("ObterOperacaoTransportePdfResult", Namespace = "http://schemas.ipc.adm.br/efrete/pef/objects", Ocorrencia = Ocorrencia.Obrigatoria)]
        public PefObterOperacaoTransportePdfResult Result { get; set; }

        #endregion
    }
}
