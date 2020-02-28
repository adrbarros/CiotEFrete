using ACBr.Net.DFe.Core.Attributes;
using ACBr.Net.DFe.Core.Serializer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CiotEFrete.Classes
{
    public sealed class PefAdicionarOperacaoTransporteObservacoes : INotifyPropertyChanged
    {
        #region Eventos

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Propriedades 

        [DFeElement(TipoCampo.Str, "String", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 1)]
        public string String { get; set; }

        #endregion
    }
}
