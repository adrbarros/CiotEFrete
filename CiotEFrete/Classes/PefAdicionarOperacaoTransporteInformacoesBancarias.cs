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

    public enum TipoConta
    {
        ContaCorrente = 0,
        ContaPoupanca = 1,
        ContaPagamentos = 2
    }

    #endregion

    public sealed class PefAdicionarOperacaoTransporteInformacoesBancarias : INotifyPropertyChanged
    {
        #region Eventos

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Propriedades

        [DFeElement(TipoCampo.Str, "InstituicaoBancaria", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 1)]
        public string InstituicaoBancaria { get; set; }

        [DFeElement(TipoCampo.Str, "Agencia", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 2)]
        public string Agencia { get; set; }

        [DFeElement(TipoCampo.Str, "Conta", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 3)]
        public string Conta { get; set; }

        [DFeIgnore]
        public TipoConta TipoConta { get; set; }

        [DFeElement(TipoCampo.Str, "TipoConta", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 4)]
        public string TipoContaProxy
        {
            get
            {
                switch (TipoConta)
                {
                    case TipoConta.ContaCorrente: return "ContaCorrente";
                    case TipoConta.ContaPoupanca: return "ContaPoupanca";
                    case TipoConta.ContaPagamentos: return "ContaPagamentos";
                    default: throw new NotImplementedException("Tipo de conta não implementado");
                }
            }

            set
            {
                switch (value.ToLower())
                {
                    case "contacorrente": TipoConta = TipoConta.ContaCorrente; break;
                    case "contapoupanca": TipoConta = TipoConta.ContaPoupanca; break;
                    case "contapagamentos": TipoConta = TipoConta.ContaPagamentos; break;
                    default: throw new NotImplementedException("Tipo de conta não implementado");
                }
            }
        }

        #endregion
    }
}
