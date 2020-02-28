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
    [DFeRoot("RetirarOperacaoTransporteResponse", Namespace = "http://schemas.ipc.adm.br/efrete/pef")]
    public sealed class PefRetificarOperacaoTransporteResponse : DFeDocument<PefRetificarOperacaoTransporteResponse>, INotifyPropertyChanged
    {
        #region Eventos

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Propriedades

        [DFeElement("RetirarOperacaoTransporteResult", Namespace = "http://schemas.ipc.adm.br/efrete/pef/objects", Ocorrencia = Ocorrencia.Obrigatoria)]
        public PefRetificarOperacaoTransporteResult Result { get; set; }

        #endregion
    }
}
