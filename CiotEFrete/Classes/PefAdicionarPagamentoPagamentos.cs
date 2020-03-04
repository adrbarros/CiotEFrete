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
    public sealed class PefAdicionarPagamentoPagamento : INotifyPropertyChanged
    {
        #region Eventos

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Propriedades
        [DFeCollection("Pagamento", Namespace = "http://schemas.ipc.adm.br/efrete/pef/AdicionarPagamento", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 0)]
        public List<PefAdicionarPagamentoPagamentoDados> Pagamentos { get; set; }
        #endregion
    }
}
