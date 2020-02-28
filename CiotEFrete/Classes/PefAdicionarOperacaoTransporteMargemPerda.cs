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
    public sealed class PefAdicionarOperacaoTransporteMargemPerda : INotifyPropertyChanged
    {
        #region Eventos

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Propriedades

        [DFeIgnore]
        public TipoMargem Tipo { get; set; }

        [DFeElement(TipoCampo.Str, "Tipo", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 1)]
        public string TipoProxy
        {
            get
            {
                switch (Tipo)
                {
                    case TipoMargem.Nenhum: return "Nenhum";
                    case TipoMargem.Porcentagem: return "Porcentagem";
                    case TipoMargem.Absoluto: return "Absoluto";
                    default: throw new NotImplementedException("Tipo de margem de perda não implementado");
                }
            }

            set
            {
                switch (value.ToLower())
                {
                    case "nenhum": Tipo = TipoMargem.Nenhum; break;
                    case "porcentagem": Tipo = TipoMargem.Porcentagem; break;
                    case "absoluto": Tipo = TipoMargem.Absoluto; break;
                    default: throw new NotImplementedException("Tipo de margem de perda não implementado");
                }
            }
        }

        [DFeElement(TipoCampo.De2, "Valor", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 2)]
        public decimal Valor { get; set; }

        #endregion
    }
}
