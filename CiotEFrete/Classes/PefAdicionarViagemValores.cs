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
    public sealed class PefAdicionarViagemValores : INotifyPropertyChanged
    {
        #region Eventos

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Propriedades

        [DFeElement(TipoCampo.De2, "Combustivel", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 1)]
        public decimal Combustivel { get; set; }

        [DFeElement(TipoCampo.Str, "JustificativaOutrosCreditos", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 2)]
        public string JustificativaOutrosCreditos { get; set; }

        [DFeElement(TipoCampo.Str, "JustificativaOutrosDebitos", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 3)]
        public string JustificativaOutrosDebitos { get; set; }

        [DFeElement(TipoCampo.De2, "OutrosCreditos", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 4)]
        public decimal OutrosCreditos { get; set; }

        [DFeElement(TipoCampo.De2, "OutroDebitos", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 5)]
        public decimal OutroDebitos { get; set; }

        [DFeElement(TipoCampo.De2, "Pedagio", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 6)]
        public decimal Pedagio { get; set; }

        [DFeElement(TipoCampo.De2, "Seguro", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 7)]
        public decimal Seguro { get; set; }

        [DFeElement(TipoCampo.De2, "TotalDeAdiantamento", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 8)]
        public decimal TotalAdiantamento { get; set; }

        [DFeElement(TipoCampo.De2, "TotalDeQuitacao", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 9)]
        public decimal TotalQuitacao { get; set; }

        [DFeElement(TipoCampo.De2, "TotalOperacao", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 10)]
        public decimal TotalOperacao { get; set; }

        [DFeElement(TipoCampo.De2, "TotalViagem", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 11)]
        public decimal TotalViagem { get; set; }

        #endregion
    }
}
