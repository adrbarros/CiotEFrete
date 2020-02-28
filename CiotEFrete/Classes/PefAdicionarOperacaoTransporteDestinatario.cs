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
    public sealed class PefAdicionarOperacaoTransporteDestinatario : INotifyPropertyChanged
    {
        #region Eventos

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
        
        #region Propriedades

        [DFeElement(TipoCampo.Str, "NomeOuRazaoSocial", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 1)]
        public string NomeOuRazaoSocial { get; set; }

        [DFeElement(TipoCampo.Str, "CpfOuCnpj", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 2)]
        public string CpfOuCnpj { get; set; }

        [DFeElement("Endereco", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 3)]
        public PefAdicionarOperacaoTransporteEndereco Endereco { get; set; }

        [DFeElement(TipoCampo.Str, "EMail", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 4)]
        public string Email { get; set; }

        [DFeElement("Telefones", Ocorrencia = Ocorrencia.NaoObrigatoria, Ordem = 5)]
        public Telefones Telefones { get; set; }

        [DFeIgnore]
        public bool ResponsavelPeloPagamento { get; set; }

        [DFeElement(TipoCampo.Str, "ResponsavelPeloPagamento", Ocorrencia = Ocorrencia.Obrigatoria, Ordem = 6)]
        public string ResponsavelPeloPagamentoProxy
        {
            get => ResponsavelPeloPagamento ? "true" : "false";
            set => ResponsavelPeloPagamento = value == "true";
        }

        #endregion
    }
}
