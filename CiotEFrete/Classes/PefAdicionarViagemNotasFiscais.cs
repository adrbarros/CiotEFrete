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
    public sealed class PefAdicionarViagemNotasFiscais : INotifyPropertyChanged
    {
        #region Eventos

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Propriedades

        [DFeElement(TipoCampo.Str, "CodigoNCMNaturezaCarga", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 1)]
        public string CodigoNcmNaturezaCarga { get; set; }

        [DFeIgnore]
        public DateTime? Data { get; set; }

        [DFeElement(TipoCampo.Str, "Data", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 2)]
        public string DataProxy
        {
            get => Data?.ToString("yyyy-MM-dd");
            set => Data = DateTime.Parse(value);
        }

        [DFeElement(TipoCampo.Str, "DescricaoDaMercadoria", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 3)]
        public string DescricaoMercadoria { get; set; }

        [DFeElement(TipoCampo.Str, "Numero", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 4)]
        public string Numero { get; set; }

        [DFeElement(TipoCampo.De2, "QuantidadeDaMercadoriaNoEmbarque", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 5)]
        public decimal QuantidadeMercadoriaNoEmbarque { get; set; }

        [DFeElement(TipoCampo.Str, "Serie", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 6)]
        public string Serie { get; set; }

        [DFeIgnore]
        public TipoCalculoQuebraFrete TipoCalculo { get; set; }

        [DFeElement(TipoCampo.Str, "TipoDeCalculo", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 7)]
        public string TipoCalculoProxy
        {
            get
            {
                switch (TipoCalculo)
                {
                    case TipoCalculoQuebraFrete.SemQuebra: return "Sem Quebra";
                    case TipoCalculoQuebraFrete.QuebraSomenteUltrapassado: return "Quebra Somente Ultrapassado";
                    case TipoCalculoQuebraFrete.QuebraIntegral: return "Quebra Integral";
                    default: throw new NotImplementedException("Tipo de cálculo não implementado");
                }
            }

            set
            {
                switch (value.ToLower())
                {
                    case "ctc": TipoCalculo = TipoCalculoQuebraFrete.SemQuebra; break;
                    case "etc": TipoCalculo = TipoCalculoQuebraFrete.QuebraSomenteUltrapassado; break;
                    case "tac": TipoCalculo = TipoCalculoQuebraFrete.QuebraIntegral; break;
                    default: throw new NotImplementedException("Tipo de cálculo não implementado");
                }
            }
        }

        [DFeElement(TipoCampo.De2, "ToleranciaDePerdaDeMercadoria", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 8)]
        public PefAdicionarOperacaoTransporteToleranciaDePerdaDeMercadoria ToleranciaDePerdaDeMercadoria { get; set; }

        [DFeIgnore]
        public UnidadeMedidaDaMercadoria UnidadeMedidaMercadoria { get; set; }

        [DFeElement(TipoCampo.Str, "UnidadeDeMedidaDaMercadoria", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 9)]
        public string UnidadeDeMedidaMercadoriaProxy
        {
            get => this.UnidadeMedidaMercadoria == UnidadeMedidaDaMercadoria.Tonelada ? "Tonelada" : "Kg";
            set => this.UnidadeMedidaMercadoria = value == "Kg" ? UnidadeMedidaDaMercadoria.Kg : UnidadeMedidaDaMercadoria.Tonelada;
        }

        [DFeElement(TipoCampo.De2, "ValorDaMercadoriaPorUnidade", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 11)]
        public decimal ValorMercadoriaPorUnidade { get; set; }

        [DFeElement(TipoCampo.De2, "ValorDoFretePorUnidadeDeMercadoria", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 12)]
        public decimal ValorFretePorUnidadeDeMercadoria { get; set; }

        [DFeElement(TipoCampo.De2, "ValorTotal", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 13)]
        public decimal ValorTotal { get; set; }

        #endregion
    }
}
