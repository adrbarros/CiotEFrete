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
    public sealed class PefAdicionarPagamentoInformacoesBancarias : INotifyPropertyChanged
    {
        #region Eventos

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Propriedades
               
        [DFeElement(TipoCampo.Str, "Agencia", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 1)]
        public string Agencia { get; set; }

        [DFeElement(TipoCampo.Str, "Conta", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 2)]
        public string Conta { get; set; }

        [DFeElement(TipoCampo.Str, "InstituicaoBancaria", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 3)]
        public string InstituicaoBancaria { get; set; }

        #endregion
    }
}
