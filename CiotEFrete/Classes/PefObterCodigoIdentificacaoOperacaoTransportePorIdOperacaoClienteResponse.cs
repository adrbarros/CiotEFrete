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
    [DFeRoot("ObterCodigoIdentificacaoOperacaoTransportePorIdOperacaoClienteResponse", Namespace = "http://schemas.ipc.adm.br/efrete/pef")]
    public sealed class PefObterCodigoIdentificacaoOperacaoTransportePorIdOperacaoClienteResponse : DFeDocument<PefObterCodigoIdentificacaoOperacaoTransportePorIdOperacaoClienteResponse>, INotifyPropertyChanged
    {
        #region Eventos

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Propriedades

        [DFeElement("ObterCodigoIdentificacaoOperacaoTransportePorIdOperacaoClienteResult", Namespace = "http://schemas.ipc.adm.br/efrete/pef/objects", Ocorrencia = Ocorrencia.Obrigatoria)]
        public PefObterCodigoIdentificacaoOperacaoTransportePorIdOperacaoClienteResult Result { get; set; }

        #endregion
    }
}
