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

    public enum TipoToleranciaDePerda
    {
        Nenhum = 0,
        Porcentagem = 1,
        ValorAbsoluto = 2
    }

    #endregion

    public sealed class PefAdicionarOperacaoTransporteToleranciaDePerdaDeMercadoria : INotifyPropertyChanged
    {
        #region Eventos

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Propriedades

        [DFeIgnore]
        public TipoToleranciaDePerda Tipo { get; set; }

        [DFeElement(TipoCampo.Str, "Tipo", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 1)]
        public string TipoProxy
        {
            get
            {                
                switch (Tipo)
                {
                    case TipoToleranciaDePerda.Nenhum: return "Nenhum";
                    case TipoToleranciaDePerda.Porcentagem: return "Porcentagem";
                    case TipoToleranciaDePerda.ValorAbsoluto: return "Valor Absoluto";                    
                    default: throw new NotImplementedException("Tipo de tolerância não implementado");
                }
            }

            set
            {                
                switch (value.ToLower())
                {
                    case "nenhum": Tipo = TipoToleranciaDePerda.Nenhum; break;
                    case "porcentagem": Tipo = TipoToleranciaDePerda.Porcentagem; break;
                    case "valorabsoluto": Tipo = TipoToleranciaDePerda.ValorAbsoluto; break;
                    default: throw new NotImplementedException("Tipo de tolerância não implementado");
                }
            }
        }

        [DFeElement(TipoCampo.De2, "Valor", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 2)]
        public decimal Valor { get; set; }

        #endregion
    }
}
