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

    public enum TipoDiferencaFrete
    {
        SemDiferenca = 0,
        SomenteUltrapassado = 1,
        Integral = 2
    }

    public enum BaseDiferencaFrete
    {
        QuantidadeDesembarque = 0,
        QuantidadeMenor = 1
    }

    #endregion

    public sealed class PefAdicionarOperacaoTransporteDiferencaDeFrete : INotifyPropertyChanged
    {
        #region Eventos

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Propriedades

        [DFeIgnore]
        public TipoDiferencaFrete Tipo { get; set; }

        [DFeElement(TipoCampo.Str, "Tipo", Namespace = "http://schemas.ipc.adm.br/efrete/pef/objects", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 1)]
        public string TipoProxy
        {
            get
            {                
                switch (Tipo)
                {
                    case TipoDiferencaFrete.SemDiferenca: return "SemDiferenca";
                    case TipoDiferencaFrete.SomenteUltrapassado: return "SomenteUltrapassado";
                    case TipoDiferencaFrete.Integral: return "Integral";                    
                    default: throw new NotImplementedException("Tipo de diferença de frete não implementado");
                }
            }

            set
            {                
                switch (value.ToLower())
                {
                    case "semdiferenca": Tipo = TipoDiferencaFrete.SemDiferenca; break;
                    case "somenteultrapassado": Tipo = TipoDiferencaFrete.SomenteUltrapassado; break;
                    case "integral": Tipo = TipoDiferencaFrete.Integral; break;
                    default: throw new NotImplementedException("Tipo de diferença de frete não implementado");
                }
            }
        }

        [DFeIgnore]
        public BaseDiferencaFrete Base { get; set; }

        [DFeElement(TipoCampo.Str, "Base", Namespace = "http://schemas.ipc.adm.br/efrete/pef/objects", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 2)]
        public string BaseProxy
        {
            get => Base == BaseDiferencaFrete.QuantidadeDesembarque ? "QuantidadeDesembarque" : "QuantidadeMenor";
            set => Base = value == "QuantidadeMenor" ? BaseDiferencaFrete.QuantidadeMenor : BaseDiferencaFrete.QuantidadeDesembarque;
        }

        [DFeElement("Tolerancia", Namespace = "http://schemas.ipc.adm.br/efrete/pef/objects", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 3)]
        public PefAdicionarOperacaoTransporteToleranciaAceitaParaCalculo Tolerancia { get; set; }

        [DFeElement("MargemGanho", Namespace = "http://schemas.ipc.adm.br/efrete/pef/objects", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 4)]
        public PefAdicionarOperacaoTransporteMargemGanho MargemGanho { get; set; }

        [DFeElement("MargemPerda", Namespace = "http://schemas.ipc.adm.br/efrete/pef/objects", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 5)]
        public PefAdicionarOperacaoTransporteMargemPerda MargemPerda { get; set; }

        #endregion
    }
}
