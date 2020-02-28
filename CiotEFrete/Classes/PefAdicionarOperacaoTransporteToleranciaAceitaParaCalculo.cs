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
    #region Enums

    public enum TipoToleranciaCalculo
    {
        Nenhum = 0,
        Porcentagem = 1,
        Absoluto = 2
    }

    #endregion

    public sealed class PefAdicionarOperacaoTransporteToleranciaAceitaParaCalculo : INotifyPropertyChanged
    {
        #region Eventos

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Propriedades

        [DFeIgnore]
        public TipoToleranciaCalculo Tipo { get; set; }

        [DFeElement(TipoCampo.Str, "Tipo", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 1)]
        public string TipoToleranciaFreteProxy
        {
            get
            {                
                switch (Tipo)
                {
                    case TipoToleranciaCalculo.Nenhum: return "Nenhum";
                    case TipoToleranciaCalculo.Porcentagem: return "Porcentagem";
                    case TipoToleranciaCalculo.Absoluto: return "Absoluto";
                    default: throw new NotImplementedException("Tipo de tolerância não implementado");
                }
            }

            set
            {
                
                switch (value.ToLower())
                {
                    case "nenhum": Tipo = TipoToleranciaCalculo.Nenhum; break;
                    case "porcentagem": Tipo = TipoToleranciaCalculo.Porcentagem; break;
                    case "absoluto": Tipo = TipoToleranciaCalculo.Absoluto; break;
                    default: throw new NotImplementedException("Tipo de diferença de frete não implementado");
                }
            }
        }

        [DFeElement(TipoCampo.De2, "Valor", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 2)]
        public decimal Valor { get; set; }

        #endregion
    }
}
