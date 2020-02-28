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

    public enum UnidadeMedidaDaMercadoria
    {
        Tonelada = 0,
        Kg = 1
    }

    public enum TipoCalculoQuebraFrete
    {
        SemQuebra = 0,
        QuebraSomenteUltrapassado = 1,
        QuebraIntegral = 2
    }

    #endregion
    
    public sealed class PefAdicionarOperacaoTransporteNotaFiscal : INotifyPropertyChanged
    {
        #region Eventos

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion 

        #region Propriedades

        [DFeElement(TipoCampo.Str, "Numero", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 1)]
        public string Numero { get; set; }

        [DFeElement(TipoCampo.Str, "Serie", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 2)]
        public string Serie { get; set; }

        [DFeIgnore]
        public DateTime? Data { get; set; }

        [DFeElement(TipoCampo.Str, "Data", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 3)]
        public string DataProxy
        {
            get => Data?.ToString("yyyy-MM-dd");
            set => Data = DateTime.Parse(value);
        }

        [DFeElement(TipoCampo.De2, "ValorTotal", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 4)]
        public decimal ValorTotal { get; set; }

        [DFeElement(TipoCampo.De2, "ValorDaMercadoriaPorUnidade", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 5)]
        public decimal ValorMercadoriaPorUnidade { get; set; }

        [DFeElement(TipoCampo.Str, "CodigoNCMNaturezaCarga", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 6)]
        public string CodigoNcmNaturezaCarga { get; set; }

        [DFeElement(TipoCampo.Str, "DescricaoDaMercadoria", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 7)]
        public string DescricaoMercadoria { get; set; }
                
        [DFeIgnore]
        public UnidadeMedidaDaMercadoria UnidadeMedidaMercadoria { get; set; }

        [DFeElement(TipoCampo.Str, "UnidadeDeMedidaDaMercadoria", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 8)]
        public string UnidadeDeMedidaMercadoriaProxy
        {
            get => this.UnidadeMedidaMercadoria == UnidadeMedidaDaMercadoria.Tonelada ? "Tonelada" : "Kg";
            set => this.UnidadeMedidaMercadoria = value == "Kg" ? UnidadeMedidaDaMercadoria.Kg : UnidadeMedidaDaMercadoria.Tonelada;
        }
                
        [DFeIgnore]
        public TipoCalculoQuebraFrete TipoCalculo { get; set; }

        [DFeElement(TipoCampo.Str, "TipoDeCalculo", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 9)]
        public string TipoCalculoProxy
        {
            get
            {                
                switch (TipoCalculo)
                {
                    case TipoCalculoQuebraFrete.SemQuebra: return "SemQuebra";
                    case TipoCalculoQuebraFrete.QuebraSomenteUltrapassado: return "QuebraSomenteUltrapassado";
                    case TipoCalculoQuebraFrete.QuebraIntegral: return "QuebraIntegral";
                    default: throw new NotImplementedException("Tipo de cálculo não implementado");
                }
            }

            set
            {                
                switch (value.ToLower())
                {
                    case "semquebra": TipoCalculo = TipoCalculoQuebraFrete.SemQuebra; break;
                    case "quebrasomenteultrapassado": TipoCalculo = TipoCalculoQuebraFrete.QuebraSomenteUltrapassado; break;
                    case "quebraintegral": TipoCalculo = TipoCalculoQuebraFrete.QuebraIntegral; break;
                    default: throw new NotImplementedException("Tipo de cálculo não implementado");
                }
            }
        }

        [DFeElement(TipoCampo.De2, "ValorDoFretePorUnidadeDeMercadoria", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 10)]
        public decimal ValorFretePorUnidadeDeMercadoria { get; set; }

        [DFeElement(TipoCampo.De2, "QuantidadeDaMercadoriaNoEmbarque", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 11)]
        public decimal QuantidadeMercadoriaNoEmbarque { get; set; }

        [DFeElement(TipoCampo.De2, "ToleranciaDePerdaDeMercadoria", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 12)]
        public PefAdicionarOperacaoTransporteToleranciaDePerdaDeMercadoria ToleranciaDePerdaDeMercadoria { get; set; }

        [DFeElement(TipoCampo.De2, "DiferencaDeFrete", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 13)]
        public PefAdicionarOperacaoTransporteDiferencaDeFrete DiferencaDeFrete { get; set; }

        #endregion
    }
}
