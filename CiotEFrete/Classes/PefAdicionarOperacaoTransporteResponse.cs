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
    [DFeRoot("AdicionarOperacaoTransporteResponse", Namespace = "http://schemas.ipc.adm.br/efrete/pef")]
    public sealed class PefAdicionarOperacaoTransporteResponse : DFeDocument<PefAdicionarOperacaoTransporteResponse>, INotifyPropertyChanged
    {
        #region Eventos

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Propriedades

        [DFeElement("AdicionarOperacaoTransporteResult", Namespace = "http://schemas.ipc.adm.br/efrete/pef/objects", Ocorrencia = Ocorrencia.Obrigatoria)]
        public PefAdicionarOperacaoTransporteResult Result { get; set; }

        #endregion
    }
}
