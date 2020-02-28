using ACBr.Net.DFe.Core.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiotEFrete.Classes
{
    public sealed class PefAdicionarOperacaoTransporteNotasFiscais : INotifyPropertyChanged
    {
        #region Eventos

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Propriedades

        [DFeElement("NotaFiscal", Ocorrencia = Ocorrencia.Obrigatoria)]
        public PefAdicionarOperacaoTransporteNotaFiscal NotaFiscal { get; set; }

        #endregion
    }
}
