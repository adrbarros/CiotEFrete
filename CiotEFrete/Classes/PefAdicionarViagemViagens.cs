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
    public sealed class PefAdicionarViagemViagens : INotifyPropertyChanged
    {
        #region Eventos

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Propriedades

        [DFeElement(TipoCampo.Int, "CodigoMunicipioDestino", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 1)]
        public int CodigoMunicipioDestino { get; set; }

        [DFeElement(TipoCampo.Int, "CodigoMunicipioOrigem", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 2)]
        public int CodigoMunicipioOrigem { get; set; }

        [DFeIgnore]
        public string CepOrigem { get; set; }

        [DFeElement(TipoCampo.Str, "CepOrigem", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 3)]
        public string CepOrigemProxy
        {
            get => $"{CepOrigem.Substring(0, 5)}-{CepOrigem.Substring(5, 3)}";
            set => CepOrigem = string.Concat(value.Where(char.IsDigit));
        }

        [DFeIgnore]
        public string CepDestino { get; set; }

        [DFeElement(TipoCampo.Str, "CepDestino", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 4)]
        public string CepDestinoProxy
        {
            get => $"{CepDestino.Substring(0, 5)}-{CepDestino.Substring(5, 3)}";
            set => CepDestino = string.Concat(value.Where(char.IsDigit));
        }

        [DFeElement(TipoCampo.Str, "DocumentoViagem", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 5)]
        public string DocumentoViagem { get; set; }

        [DFeElement("NotasFiscais", Namespace = "http://schemas.ipc.adm.br/efrete/objects", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 6)]
        public PefAdicionarViagemNotasFiscais NotasFiscais { get; set; }

        [DFeElement("Valores", Namespace = "http://schemas.ipc.adm.br/efrete/objects", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 7)]
        public PefAdicionarViagemValores Valores { get; set; }

        [DFeElement("Pagamentos", Namespace = "http://schemas.ipc.adm.br/efrete/objects", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 8)]
        public PefAdicionarViagemPagamentos Pagamentos { get; set; }

        #endregion
    }
}
