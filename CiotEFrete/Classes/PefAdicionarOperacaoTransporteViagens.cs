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
    public sealed class PefAdicionarOperacaoTransporteViagens : INotifyPropertyChanged
    {
        #region Eventos

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Propriedades

        [DFeElement(TipoCampo.Str, "DocumentoViagem", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 1)]
        public string DocumentoViagem { get; set; }
        
        [DFeElement(TipoCampo.Int, "CodigoMunicipioOrigem", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 2)]
        public int CodigoMunicipioOrigem { get; set; }

        [DFeElement(TipoCampo.Int, "CodigoMunicipioDestino", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 3)]
        public int CodigoMunicipioDestino { get; set; }

        [DFeIgnore]
        public string CepOrigem { get; set; }

        [DFeElement(TipoCampo.Str, "CepOrigem", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 4)]
        public string CepOrigemProxy
        {
            get => $"{CepOrigem.Substring(0, 5)}-{CepOrigem.Substring(5, 3)}";
            set => CepOrigem = string.Concat(value.Where(char.IsDigit));
        }

        [DFeIgnore]
        public string CepDestino { get; set; }

        [DFeElement(TipoCampo.Str, "CepDestino", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 5)]
        public string CepDestinoProxy
        {
            get => $"{CepDestino.Substring(0, 5)}-{CepDestino.Substring(5, 3)}";
            set => CepDestino = string.Concat(value.Where(char.IsDigit));
        }

        [DFeElement(TipoCampo.Int, "DistanciaPercorrida", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 6)]
        public int DistanciaPercorrida { get; set; }

        [DFeElement("Valores", Namespace = "http://schemas.ipc.adm.br/efrete/pef/objects", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 7)]
        public PefAdicionarOperacaoTransporteValores Valores { get; set; }

        [DFeIgnore]
        public TipoPagamento TipoPagamento { get; set; }

        [DFeElement(TipoCampo.Str, "TipoPagamento", Namespace = "http://schemas.ipc.adm.br/efrete/pef/objects", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 8)]
        public string TipoPagamentoProxy
        {
            get
            {
                switch (TipoPagamento)
                {
                    case TipoPagamento.eFRETE: return "eFRETE";
                    case TipoPagamento.TransferenciaBancaria: return "TransferenciaBancaria";
                    case TipoPagamento.Outros: return "Outros";
                    default: throw new NotImplementedException("Tipo de pagamento não implementado");
                }
            }

            set
            {
                switch (value.ToLower())
                {
                    case "efrete": TipoPagamento = TipoPagamento.eFRETE; break;
                    case "transferenciabancaria": TipoPagamento = TipoPagamento.TransferenciaBancaria; break;
                    case "outros": TipoPagamento = TipoPagamento.Outros; break;
                    default: throw new NotImplementedException("Tipo de pagamento não implementado");
                }
            }
        }

        [DFeElement("NotasFiscais", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 9)]
        public PefAdicionarOperacaoTransporteNotasFiscais NotasFiscais { get; set; }

        #endregion
    }
}
