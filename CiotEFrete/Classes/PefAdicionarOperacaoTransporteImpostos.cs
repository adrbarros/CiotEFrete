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
    public sealed class PefAdicionarOperacaoTransporteImpostos : INotifyPropertyChanged
    {
        #region Eventos

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Propriedades

        [DFeElement(TipoCampo.De2, "IRRF", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 1)]
        public decimal Irrf { get; set; }

        [DFeElement(TipoCampo.De2, "SestSenai", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 2)]
        public decimal SestSenai { get; set; }

        [DFeElement(TipoCampo.De2, "INSS", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 3)]
        public decimal Inss { get; set; }

        [DFeElement(TipoCampo.De2, "ISSQN", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 4)]
        public decimal Issqn { get; set; }

        [DFeElement(TipoCampo.De2, "OutrosImpostos", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 5)]
        public decimal OutrosImpostos { get; set; }

        [DFeElement(TipoCampo.Str, "DescricaoOutrosImpostos", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 6)]
        public string DescricaoOutrosImpostos { get; set; }
        
        #endregion

    }
}
