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
    [DFeRoot("AdicionarPagamentoResponse", Namespace = "http://schemas.ipc.adm.br/efrete/pef")]
    public sealed class PefAdicionarPagamentoResponse : DFeDocument<PefAdicionarPagamentoResponse>, INotifyPropertyChanged
    {
        #region Eventos

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Propriedades

        [DFeElement("AdicionarPagamentoResult", Namespace = "http://schemas.ipc.adm.br/efrete/pef/objects", Ocorrencia = Ocorrencia.Obrigatoria)]
        public PefAdicionarPagamentoResult Result { get; set; }

        #endregion
    }
}
